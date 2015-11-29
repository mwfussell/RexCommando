using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Windows;
using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;

namespace RexCommando
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    /// 
    public enum GameState { Menu, LevelSelect, InGame, GameOver };

    public class Game1 : Game
    {
        // Set up the size of the world with a camera that pans as the player moves
        public const int worldWidth = 2400;
        public const int worldHeight = 1440;

        public const int BossLevel = 5;

        // Set the size of the *visible* screen 
        const int screenWidth = 1362;
        const int screenHeight = 680;
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        // The spriteManager manager the update and all the drawing for the sprites on the screen including backgrounds
        public SpriteManager spriteManager;

       // Music
        SoundEffect menuMusic;
        SoundEffectInstance menuMusicIns;
        SoundEffect levelMusic;
        SoundEffectInstance LevelMusicIns;

        public Texture2D lineTexture;
        public SpriteFont hudFont;
        Texture2D menu;
        Texture2D levelSelectScreen;
        Texture2D deathScreen;

        //Game State Management
        public GameState currentGameState = GameState.Menu;
        int previousLevel = 1;
        int currentLevel = 0;
        int nextLevel = 0;

        //Menu Select
        int selectX, selectY = 0;
        Vector2[,] selections = new Vector2[2,2];
        bool shiftSelect = true;
        Button[,] buttons = new Button[2, 2];

        const int maxLives = 30; 
        int numberofLives = maxLives;

        // Setting this to true show player collision box and position information
        public bool debugPlayerCollision = false;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            // Set the size of the *visible* screen 
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            Content.RootDirectory = "Content";
            rnd = new Random();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //spriteManager = new SpriteManager(this);

            _ExplosionManager.Initialise();

            //Selection Points
            int divW = 10;
            int divH = 7;
            selections[0, 0] = new Vector2(Window.ClientBounds.Width / divW * 3, Window.ClientBounds.Height / divH * 2);
            selections[1, 0] = new Vector2(Window.ClientBounds.Width / divW * 7, Window.ClientBounds.Height / divH * 2);
            selections[0, 1] = new Vector2(Window.ClientBounds.Width / divW * 3, Window.ClientBounds.Height / divH * 5);
            selections[1, 1] = new Vector2(Window.ClientBounds.Width / divW * 7, Window.ClientBounds.Height / divH * 5);

            base.Initialize();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            lineTexture = Content.Load<Texture2D>(@"Backgrounds/Dot");
            menu = Content.Load<Texture2D>(@"Backgrounds/Menu");
            levelSelectScreen = Content.Load<Texture2D>("Backgrounds/WaterBackground"); //Content.Load<Texture2D>(@"Backgrounds/LevelSelectScreen");
            deathScreen = Content.Load<Texture2D>("Backgrounds/DeathScreen"); 
            hudFont = Content.Load<SpriteFont>(@"Fonts/Hud");
            
            //Menu buttons
            buttons[0, 0] = new Button(Content.Load<Texture2D>(@"Buttons/FlowerGuyButton"), selections[0, 0],
                                        selections[0, 0] + new Vector2(-1000, -1000));
            buttons[0, 0].ChangeState(ButtonStateM.On);
            buttons[1, 0] = new Button(Content.Load<Texture2D>(@"Buttons/LavaGuyButton"), selections[1, 0],
                                        selections[1, 0] + new Vector2(1000, -1000));
            buttons[0, 1] = new Button(Content.Load<Texture2D>(@"Buttons/OctopusGuyButton"), selections[0, 1],
                                        selections[0, 1] + new Vector2(-1000, 1000));
            buttons[1, 1] = new Button(Content.Load<Texture2D>(@"Buttons/WalrusGuyButton"), selections[1, 1],
                                        selections[1, 1] + new Vector2(1000, 1000));

            // Play Game Music in continous mode
            menuMusic = Content.Load<SoundEffect>(@"Sound/Music/MenuMusic");
            menuMusicIns = menuMusic.CreateInstance();
            menuMusicIns.IsLooped = true;
            menuMusicIns.Play();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        public Random rnd { get; private set; }
        
        public int NumberofLives
        {
            get { return numberofLives; }
            set
            {
                numberofLives = value;
                if (numberofLives == 0)
                {
                    spriteManager.GameOverCall(true);
                }
            }
        }

        public int PreviousLevel
        {
            get { return previousLevel; }
            set
            {
                previousLevel = value;
            }
        }

        public int NextLevel
        {
            get { return nextLevel; }
            set
            {
                nextLevel = value;
            }
        }

        public void ReturnToMenu()
        {
            //Pause before returning to menu
            Thread.Sleep(2000);
            //Clean up existing spritemanager ready to create a new level
            if (Components.Contains(spriteManager))
            {
                spriteManager.RemoveCurrentLevel();
                Components.Remove(spriteManager);
            } 
            currentGameState = GameState.LevelSelect;
           
            // This is a temporary piece of code to enable going F5 and F10 into the Boss level
            if (currentLevel != BossLevel)
                previousLevel = currentLevel;
            else
                previousLevel = 2;
            currentLevel = 0;
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Exit the game 
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // D key turns on/off player debugging information
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if (debugPlayerCollision == true)
                    debugPlayerCollision = false;
                else
                    debugPlayerCollision = true;
            }

            switch (currentGameState)
            {
                case GameState.Menu:
                    if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                        currentGameState = GameState.LevelSelect;
                    break;

                case GameState.LevelSelect:
                    //Move selection
                    if(shiftSelect)
                    {
                        bool changeButtonStates = false;

                        if (Keyboard.GetState().IsKeyDown(Keys.Down))
                        {
                            selectY++;
                            if (selectY > 1)
                                selectY = 0;
                            shiftSelect = false;
                            changeButtonStates = true;
                        }
                        else if (Keyboard.GetState().IsKeyDown(Keys.Up))
                        {
                            selectY--;
                            if (selectY < 0)
                                selectY = 1;
                            shiftSelect = false;
                            changeButtonStates = true;
                        }
                        else if (Keyboard.GetState().IsKeyDown(Keys.Right))
                        {
                            selectX++;
                            if (selectX > 1)
                                selectX = 0;
                            shiftSelect = false;
                            changeButtonStates = true;
                        }
                        else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                        {
                            selectX--;
                            if (selectX < 0)
                                selectX = 1;
                            shiftSelect = false;
                            changeButtonStates = true;
                        }

                        if(changeButtonStates)
                        {
                            for(int i = 0; i < 2; ++i)
                            {
                                for(int j = 0; j < 2; ++j)
                                {
                                    if(i == selectX && j == selectY)
                                        buttons[selectX, selectY].ChangeState(ButtonStateM.On);
                                    else
                                        buttons[i, j].ChangeState(ButtonStateM.Off);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (Keyboard.GetState().IsKeyUp(Keys.Left)
                            && Keyboard.GetState().IsKeyUp(Keys.Right)
                            && Keyboard.GetState().IsKeyUp(Keys.Up)
                            && Keyboard.GetState().IsKeyUp(Keys.Down))
                        {
                            shiftSelect = true;
                        }
                    }

                    //Level Launch
                    if(Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        if (selectX == 0 && selectY == 0)
                        {
                            nextLevel = 3;
                            currentGameState = GameState.InGame;
                            levelMusic = Content.Load<SoundEffect>(@"Sound/Music/WaterMusic"); 
                            UpdateMusic();
                        }
                        if (selectX == 1 && selectY == 0)
                        {
                            nextLevel = 2;
                            currentGameState = GameState.InGame;
                            levelMusic = Content.Load<SoundEffect>(@"Sound/Music/LavaMusic"); 
                            UpdateMusic();
                        }
                        if (selectX == 0 && selectY == 1)
                        {
                            nextLevel = 1;
                            currentGameState = GameState.InGame;
                            levelMusic = Content.Load<SoundEffect>(@"Sound/Music/GrassMusic"); 
                            UpdateMusic();
                        }
                        if (selectX == 1 && selectY == 1)
                        {
                            nextLevel = 4;
                            currentGameState = GameState.InGame;
                            UpdateMusic();
                        }
                    }
                    //if (Keyboard.GetState().IsKeyDown(Keys.F1))
                    //{
                    //    nextLevel = 1;
                    //    currentGameState = GameState.InGame;
                    //}
                    //if (Keyboard.GetState().IsKeyDown(Keys.F2))
                    //{
                    //    nextLevel = 2;
                    //    currentGameState = GameState.InGame;
                    //}
                    //if (Keyboard.GetState().IsKeyDown(Keys.F3))
                    //{
                    //    nextLevel = 3;
                    //    currentGameState = GameState.InGame;
                    //}
                    //if (Keyboard.GetState().IsKeyDown(Keys.F4))
                    //{
                    //    nextLevel = 4;
                    //    currentGameState = GameState.InGame;
                    //}
                    // This is the Boss Level
                    if (Keyboard.GetState().IsKeyDown(Keys.F5))
                    {
                        nextLevel = BossLevel; // Boss level is level 5
                        currentGameState = GameState.InGame;
                    }
                    break;

                case GameState.InGame:

                    if (nextLevel != currentLevel)
                    {
                        if (Components.Contains(spriteManager))
                        {
                            spriteManager.RemoveCurrentLevel();
                            Components.Remove(spriteManager); 
                        }

                        spriteManager = new SpriteManager(this);
                        spriteManager.Level = nextLevel;
                        Components.Add(spriteManager);
                        previousLevel = currentLevel;
                        currentLevel = nextLevel;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.F10))
                    {
                        ReturnToMenu();
                    }
                    break;

                case GameState.GameOver:
                    if (Components.Contains(spriteManager))
                        Components.Remove(spriteManager);
                    if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                        currentGameState = GameState.LevelSelect;
                    if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                        Exit();
                    break;        
            }

            _ExplosionManager.Update(); 

            base.Update(gameTime);
        }

        public void UpdateMusic()
        {
            //menuMusicIns.Stop();
            //// Play Level Music in continous mode
            //SoundEffectInstance LevelMusicIns = levelMusic.CreateInstance();
            //LevelMusicIns.IsLooped = true;
            //LevelMusicIns.Play();
            
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            switch (currentGameState)
            {
                case GameState.Menu:
                    GraphicsDevice.Clear(Color.White);
                    spriteBatch.Begin();
                    // Draw the menu screen
                    spriteBatch.Draw(menu,
                                      new Rectangle(Window.ClientBounds.Width / 2 - menu.Width / 2, 0, menu.Width, menu.Height),
                                      Color.White);

                    spriteBatch.End();
                    break;

                case GameState.LevelSelect:
                    GraphicsDevice.Clear(Color.White);
                    spriteBatch.Begin();
                    // Draw the Select Screen screen
                    spriteBatch.Draw(levelSelectScreen,
                                      new Rectangle(Window.ClientBounds.Width / 2 - levelSelectScreen.Width / 2, -100, levelSelectScreen.Width, levelSelectScreen.Height),
                                      Color.White);

                    _ExplosionManager.Draw(spriteBatch);

                    //Draw Buttons
                    for (int i = 0; i < 2; ++i)
                    {
                        for(int j = 0; j < 2; ++j)
                        {
                            buttons[i, j].Draw(spriteBatch);
                        }
                    }

                    //TwodDrawing.DrawCircle(selections[selectX, selectY], 20, spriteBatch, lineTexture);

                    //Level Select Title
                        //Level Select Colour Based on Level
                    Color levelColor = Color.Black;
                    string levelName = "Level Select";
                    if (buttons[0, 0].state == ButtonStateM.On)
                    {
                        levelColor = Color.LawnGreen;
                        levelName = "Grass Man";
                    }
                    else if (buttons[1, 0].state == ButtonStateM.On)
                    {   
                        levelColor = Color.Red;
                        levelName = "Lava Man";
                    }
                    else if (buttons[0, 1].state == ButtonStateM.On)
                    {
                        levelColor = Color.Aqua;
                        levelName = "Water Man";
                    }
                    else if (buttons[1, 1].state == ButtonStateM.On)
                    {
                        levelColor = Color.Gold;
                        levelName = "Metal Man";
                    }

                    //Level Select Title Shadow
                    spriteBatch.DrawString(hudFont, levelName,
                                            new Vector2(Window.ClientBounds.Width / 2 - 70, Window.ClientBounds.Height / 2 + 8),
                                            Color.FromNonPremultiplied(0, 0, 0, 120));
                    //Level Select Obj
                    spriteBatch.DrawString(hudFont, levelName, 
                                            new Vector2(Window.ClientBounds.Width / 2 - 60, Window.ClientBounds.Height / 2),
                                            levelColor);

                    spriteBatch.End();
                    break;

                case GameState.InGame:
                    GraphicsDevice.Clear(Color.White);
                    break;

                case GameState.GameOver:
                    GraphicsDevice.Clear(Color.AliceBlue);
                    spriteBatch.Begin();
                    // Draw the current player location on the screen.
                    // Draw the menu screen
                    spriteBatch.Draw(deathScreen,
                                      new Rectangle(0, 0, deathScreen.Width, deathScreen.Height),
                                      Color.White);

                    //string gameover = "Game Over. You Loose! ";
                    //spriteBatch.DrawString(hudFont, gameover, new Vector2((Window.ClientBounds.Width / 2) - (hudFont.MeasureString(gameover).X / 2),
                    //                                                          (Window.ClientBounds.Height / 2) - (hudFont.MeasureString(gameover).Y /2)),
                    //                                                          Color.SaddleBrown);
                    //gameover = "Press ENTER to exit";
                    //spriteBatch.DrawString(hudFont, gameover, new Vector2((Window.ClientBounds.Width / 2) - (hudFont.MeasureString(gameover).X / 2),
                    //                                                          (Window.ClientBounds.Height / 2) - (hudFont.MeasureString(gameover).Y /2) + 30),
                    //                                                          Color.SaddleBrown);

                    _ExplosionManager.Draw(spriteBatch);

                    spriteBatch.End();
                    break;
            } 
            
            base.Draw(gameTime);
        }
    }
}
