using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Windows;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;

namespace MegaMan
{

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        // Set up the size of the world with a camera that pans as the player moves
        public const int worldWidth = 2400;
        public const int worldHeight = 480;

        // Set the size of the *visible* screen 
        const int screenWidth = 2400;
        const int screenHeight = 480;
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        // The spriteManager manager the update and all the drawing for the sprites on the screen including backgrounds
        public SpriteManager spriteManager;

        SoundEffect menuMusic;
        private Texture2D dot;
        SpriteFont Font1;

        //Background Scroll Items Simple
        private Texture2D background;
        Texture2D background1;
        Vector2 backgroundPos1;
        Texture2D background2;
        Vector2 backgroundPos2;

        //Background Scroll Complex
        List<BackgroundItem> backgroundList;
        BackgroundItem basicBackground;

        //Choose Simple/Complex
        bool isComplex = false;
        float scrollSpeed = -2;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            // Set the size of the *visible* screen 
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            Content.RootDirectory = "Content";
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
            spriteManager = new SpriteManager(this);
            Components.Add(spriteManager);

            //Simple Background
             backgroundPos1 = new Vector2(0, 0);
             backgroundPos2 = new Vector2(0, 0);

            //Complex Background
             this.backgroundList = new List<BackgroundItem>();

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

            dot = Content.Load<Texture2D>(@"Backgrounds/Dot");
            Font1 = Content.Load<SpriteFont>(@"Fonts/Hud");
            menuMusic = Content.Load<SoundEffect>(@"Sound/Music/MenuMusic");
            SoundEffectInstance menuMusicIns = menuMusic.CreateInstance();
            menuMusicIns.Play();

            //Simple Background
            //background = Content.Load<Texture2D>(@"Backgrounds/Layer0_0");
            //background1 = Content.Load<Texture2D>(@"Backgrounds/Layer0_0");
            //background2 = Content.Load<Texture2D>(@"Backgrounds/Layer0_0");
            ////Set background 2 to just off the right side of the screen
            //backgroundPos2.X += background1.Width;

            ////Complex Background
            //basicBackground = new BackgroundItem(background, Vector2.Zero);
            //    //Initiate List
            //BackgroundItem start1 = new BackgroundItem(basicBackground);
            //start1.ShiftXPos(0);
            //BackgroundItem start2 = new BackgroundItem(basicBackground);
            //start2.ShiftXPos(background.Width);

            //this.backgroundList.Add(start1);
            //this.backgroundList.Add(start2);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //if(!isComplex)
            //    this.BackgroundScrollSimple();
            //else
            //    this.BackgroundScrollComplex();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
          
            // TODO: Add your drawing code here
 
            //spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            //spriteBatch.Begin();

              //if (!isComplex)
              //{
              //    spriteBatch.Draw(background1, backgroundPos1, Color.White);
              //    spriteBatch.Draw(background2, backgroundPos2, Color.White);
              //}
              //else
              //{
              //    for (int i = 0; i < this.backgroundList.Count; ++i)
              //    {
              //        spriteBatch.Draw(this.backgroundList[i].GetImage(), this.backgroundList[i].GetPos(), Color.White);
              //    }
              //}

             // spriteBatch.End();
            base.Draw(gameTime);
        }

        void BackgroundScrollSimple()
        {
            //Shifts only TWO background images in a scrolling pattern

            //Shift the backgrounds

            backgroundPos1.X += scrollSpeed;
            backgroundPos2.X += scrollSpeed;

            //Check if a backgrund has dissappeared off the left side of the screen
            //Check background 1
            if (backgroundPos1.X + background1.Width <= 0)
            {
                backgroundPos1.X = backgroundPos2.X + background2.Width;
            }
            //Check background 2
            if (backgroundPos2.X + background2.Width <= 0)
            {
                backgroundPos2.X = backgroundPos1.X + background1.Width;
            }
        }

        void BackgroundScrollComplex()
        {

            for (int i = 0; i < this.backgroundList.Count; ++i)
            {
                //Scroll each item
                this.backgroundList[i].ShiftXPos(scrollSpeed);

                //if item falls off screen, delete it and add a new one
                if (this.backgroundList[i].GetPos().X + this.backgroundList[i].GetImage().Width <= 0)
                {
                    this.backgroundList.RemoveAt(i);

                    BackgroundItem newItem = new BackgroundItem(basicBackground);
                    newItem.SetPos(new Vector2(this.backgroundList[this.backgroundList.Count - 1].GetPos().X +
                                                this.backgroundList[this.backgroundList.Count - 1].GetImage().Width,
                                                newItem.GetPos().Y));
                    this.backgroundList.Add(newItem);
                }
            }
        }
    }
}
