using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;


namespace RexCommando
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class SpriteManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch spriteBatch;

        // Set up a camera to follow the player
        Camera camera;
        SpriteFont font;

        // Current game level to play
        int currentLevel;
        Level currentLevelGameComponent;

        //List of Sprites including the player and layered backgrounds
        UserControlledSprite player;
        List<Layer> backgrounds;
        List<Sprite> enemies = new List<Sprite>();
        List<Sprite> bullets = new List<Sprite>();
        List<Sprite> platforms = new List<Sprite>();
        List<Sprite> ladders = new List<Sprite>();
        List<Sprite> lives = new List<Sprite>();

        //Bullets Values
        int bulletSpeed = 10;
        float bulletWait = 0.0f;
        float bulletWaitMax = 0.2f;
        SoundEffect bulletSound;
        SoundEffectInstance bulletSoundIns;
        Texture2D bulletTexture;

        //lives
        float numberofLivesWait = 0.0f;
        float numberofLivesWaitMax = 1.0f;
        float bossLifeWait = 0.0f;
        float bossLifeWaitMax = 1.0f;

        //Game Over attributes
        public bool gameOverCall = false;
        public float gameOverTimer = 0;

        Random rand = new Random();

        public SpriteManager(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);

            // Create a camera instance and limit its moving range
            camera = new Camera(GraphicsDevice.Viewport) { Limits = new Rectangle(0, 0, Game1.worldWidth, Game1.worldHeight) };

            SetNumberOfLives();
           
            // Initialize the background layers. If you add layers, then each layer can be parallaxed to give the impression of 3D depth to the background.
            backgrounds = new List<Layer>
            {
                //new Layer(_camera) { Parallax = new Vector2(0.0f, 1.0f) },
                //new Layer(_camera) { Parallax = new Vector2(0.1f, 1.0f) },
                //new Layer(_camera) { Parallax = new Vector2(0.2f, 1.0f) },
                //new Layer(_camera) { Parallax = new Vector2(0.3f, 1.0f) },
                //new Layer(_camera) { Parallax = new Vector2(0.4f, 1.0f) },
                //new Layer(_camera) { Parallax = new Vector2(0.5f, 1.0f) },
                //new Layer(_camera) { Parallax = new Vector2(0.6f, 1.0f) },
                //new Layer(_camera) { Parallax = new Vector2(0.8f, 1.0f) },
                new Layer(camera) { Parallax = new Vector2 (1.0f, 1.0f) }
            };

            //load the content for the common sprites
            font = Game.Content.Load<SpriteFont>(@"Fonts/Hud");
            bulletSound = Game.Content.Load<SoundEffect>(@"Sound/Effects/bullet");
            bulletSoundIns = bulletSound.CreateInstance();

            switch (currentLevel)
            {
                case 1:
                    bulletTexture = Game.Content.Load<Texture2D>(@"Sprites/Bullets/WaterBullet");
                    player = new UserControlledSprite(Game.Content.Load<Texture2D>(@"Sprites/Rex/RexBlue"),
                                                      new Vector2(80, Game1.worldHeight - 200), new Point(140, 140), 50,
                                                      new Point(0, 1), new Point(4, 1), new Vector2(5, 15), true, Game);

                    Level1 level1 = new Level1(Game);
                    if (!Game.Components.Contains(level1))
                    {
                        level1.InitLevel(player, platforms, ladders, enemies, backgrounds, bullets,
                                         Game.Content.Load<SoundEffect>(@"Sound/Music/WaterMusic")); 
                        Game.Components.Add(level1);
                        currentLevelGameComponent = level1;
                    }

                    break;

                case 2:
                    bulletTexture = Game.Content.Load<Texture2D>(@"Sprites/Bullets/FireBullet");
                    // Create Rex Commando player
                    player = new UserControlledSprite(Game.Content.Load<Texture2D>(@"Sprites/Rex/RexRed"),
                                                    new Vector2(120, 1196), new Point(140, 140), 50,
                                                      new Point(0, 1), new Point(4, 1), new Vector2(5, 15), true, Game);
                    Level2 level2 = new Level2(Game);
                    if (!Game.Components.Contains(level2))
                    {
                        level2.InitLevel(player,platforms, ladders, enemies, backgrounds, bullets,
                                         Game.Content.Load<SoundEffect>(@"Sound/Music/LavaMusic")); 
                        Game.Components.Add(level2);
                        currentLevelGameComponent = level2;
                    }
                    break;

                case 3:
                    bulletTexture = Game.Content.Load<Texture2D>(@"Sprites/Bullets/GrassBullet");
                    // Create Rex Commando player
                    player = new UserControlledSprite(Game.Content.Load<Texture2D>(@"Sprites/Rex/RexGreen"),
                                                      new Vector2(120, 1196), new Point(140, 140), 50,
                                                      new Point(0, 1), new Point(4, 1), new Vector2(5, 15), true, Game);
                    Level3 level3 = new Level3(Game);
                    if (!Game.Components.Contains(level3))
                    {
                        level3.InitLevel(player, platforms, ladders, enemies, backgrounds, bullets,
                                         Game.Content.Load<SoundEffect>(@"Sound/Music/GrassMusic")); 
                        Game.Components.Add(level3);
                        currentLevelGameComponent = level3;
                    }
                    break;

                case 4:
                    bulletTexture = Game.Content.Load<Texture2D>(@"Sprites/Bullets/MetalBullet");
                    // Create Rex Commando player
                    player = new UserControlledSprite(Game.Content.Load<Texture2D>(@"Sprites/Rex/RexYellow"),
                                                      new Vector2(120, 1196), new Point(140, 140), 50,
                                                      new Point(0, 1), new Point(4, 1), new Vector2(5, 15), true, Game);
                    Level4 level4 = new Level4(Game);
                    if (!Game.Components.Contains(level4))
                    {
                        level4.InitLevel(player, platforms, ladders, enemies, backgrounds, bullets,
                                         Game.Content.Load<SoundEffect>(@"Sound/Music/MetalMusic")); 
                        Game.Components.Add(level4);
                        currentLevelGameComponent = level4;
                    }
                    break;

                case Game1.BossLevel:
                    bulletTexture = Game.Content.Load<Texture2D>(@"Sprites/Bullets/BulletWhite");
                    // Create Rex Commando player
                    player = new UserControlledSprite(Game.Content.Load<Texture2D>(@"Sprites/Rex/ManWhite"),
                                                      new Vector2(120, 1196), new Point(140, 140), 50,
                                                      new Point(0, 1), new Point(4, 1), new Vector2(5, 15), true, Game);
                    BossLevel bosslevel = new BossLevel(Game);
                    if (!Game.Components.Contains(bosslevel))
                    {
                        // Boss level takes on the theme of the level that has just been played
                        bosslevel.Level = ((Game1)Game).PreviousLevel;
                        bosslevel.InitLevel(player, platforms, ladders, enemies, backgrounds, bullets,
                                            Game.Content.Load<SoundEffect>(@"Sound/Music/BossMusic")); 

                        Game.Components.Add(bosslevel);
                        currentLevelGameComponent = bosslevel;
                    }
                    //Reset the number of lives set by the level. Since this is the boss level set maximum lives in the Level class constructor
                    //SetNumberOfLives();
                    break;
            }

            SetNumberOfLives();

            // Turn on collision rectangle drawing for the player
            if (((Game1)Game).debugPlayerCollision == true)
            {
                player.drawCollisionRect = true;
                player.drawFrameRect = true;
            }

            base.LoadContent();
        }

        public void SetNumberOfLives()
        {
            //NOTE: your problem with boss lives was that you were not reseting your list
            lives = new List<Sprite>();

            //Draw the lives relative to the camera position in the top left of the game window
            for (int i = 0; i < ((Game1)Game).NumberofLives; i++)
            {
                float offset = camera.Position.X + i * 40;
                lives.Add(new AutomatedSprite(Game.Content.Load<Texture2D>(@"Sprites/GamePlay/Heart"), new Vector2(offset, camera.Position.Y), new Point(52, 76),
                              0, new Point(0, 0), new Point(1, 1), Vector2.Zero, false, Game));
            }
        }

        public void RemoveCurrentLevel()
        {
           if (currentLevelGameComponent != null)
               Game.Components.Remove(currentLevelGameComponent);
        }

        public int Level
        {
            get { return currentLevel; }
            set
            {
                if (currentLevel > 0 || currentLevel < Game1.BossLevel)
                {
                    currentLevel = value;
                }
                else
                    throw new Exception();
            }
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            //Update Game Over
            if(gameOverCall)
            {
                gameOverTimer -= elapsedTime;

                if (gameOverTimer < 0)
                {
                    if(player.isDead)
                        ((Game1)Game).currentGameState = GameState.GameOver;
                    else
                        ((Game1)Game).ReturnToMenu();
                }
            }

            // Update the player and then get the camera to focus on him
            player.Update(gameTime, Game.Window.ClientBounds);
            camera.LookAt(new Vector2 (player.position.X, player.position.Y));

            UpdateBullets(gameTime);
            UpdatePlatforms(gameTime);
            UpdateEnemies(gameTime);

            //Draw the lives relative to the camera position in the top left of the game window
            for (int i = 0; i < ((Game1)Game).NumberofLives; i++)
            {
                lives[i].position.X = camera.Position.X + i * 40 ;
                lives[i].position.Y = camera.Position.Y;
            }

            // Check for any collisions between the platforms and the player
            //Reset player state before ground collisions
            for (int i = 0; i < platforms.Count; i++)
            {
                //Darken platform if player is not on it
                platforms[i].color = Color.FromNonPremultiplied(210, 210, 210, 255);

                if (player.collisionRect.Intersects(platforms[i].collisionRect))
                {
                    //Brighten platform when jumped on
                    platforms[i].color = Color.White;

                    //If player reaches the EXIT platform then exit the level. This is dectected by the Image Name.
                    if (platforms[i].textureImage.Name == "Sprites/GamePlay/Exit")
                    {
                        // ***Go to the Boss Level. Remember the current level so this sets the boss level theme ***
                        ((Game1)Game).PreviousLevel = currentLevel;
                        ((Game1)Game).NextLevel = Game1.BossLevel;
                    }
                    else
                    {
                        //Input texture for explosions
                        player.PlatformCollisionEdge(platforms[i].collisionRect, platforms[i].textureImage);
                    }
                }
            }

            // Check for any collisions between the ladders and the player
            for (int i = 0; i < ladders.Count; i++)
            {
                //Darken ladders if player is not on it
                ladders[i].color = Color.FromNonPremultiplied(210, 210, 210, 255);

                if (player.collisionRect.Intersects(ladders[i].collisionRect))
                {
                    //Brighten ladders when jumped on
                    ladders[i].color = Color.White;

                    //player.LadderCollision(ladders[i].collisionRect);
                    player.isClimbing = true;
                    break;
                }
                else
                {
                    player.isClimbing = false;
                }
            }    
 
            // Call the base class update
            base.Update(gameTime);
        }

        public void UpdateBullets(GameTime gameTime)
        {
            //If the space bar has been pressed and enough time has passed since the last bullet then create a new bullet
            bulletWait += (float) gameTime.ElapsedGameTime.TotalSeconds;
            // Wait time between loosing lives. This is so that you do not lose lots of lives when hit by many bullets
            numberofLivesWait += (float)gameTime.ElapsedGameTime.TotalSeconds;

            //Make damaged characters blink
            if (numberofLivesWait < numberofLivesWaitMax && numberofLivesWaitMax % numberofLivesWait <= 0.05f)
                player.color.A = 0;
            else if(player.color.A == 0)
                player.color.A = 255;

            if(Keyboard.GetState().IsKeyDown(Keys.Space) && bulletWait > bulletWaitMax)
            {
                //Set timer for length of camera shake shorter
                this.camera.NewShake(3, 12);

                 player.isShooting = true;
                if (player.collisionOffsetX == -4)
                {
                    bulletSpeed = 10;
                }
                else
                {
                    bulletSpeed = -10;
                }
                if (player.LookingDirection == LookingDirection.Right)
                {
                    if (player.isJumping)
                    {
                        bullets.Add(new AutomatedSprite(bulletTexture,
                                    new Vector2(player.Position.X + 125, player.Position.Y + 40),
                                    new Point(24, 20), 0, new Point(0, 0), new Point(1, 1), new Vector2(bulletSpeed, 0), false, Game));
                    }
                    else
                    {
                        bullets.Add(new AutomatedSprite(bulletTexture,
                                new Vector2(player.Position.X + 110, player.Position.Y + 55),
                                new Point(24, 20), 0, new Point(0, 0), new Point(1, 1), new Vector2(bulletSpeed, 0), false, Game));
                    }
                }
                if (player.LookingDirection == LookingDirection.Left)
                {
                    if (player.isJumping)
                    {
                        bullets.Add(new AutomatedSprite(bulletTexture,
                                    new Vector2(player.Position.X-15, player.Position.Y + 40),
                                    new Point(24, 20), 0, new Point(0, 0), new Point(1, 1), new Vector2(bulletSpeed, 0), false, Game));
                    }
                    else
                    {
                        bullets.Add(new AutomatedSprite(bulletTexture,
                                new Vector2(player.Position.X, player.Position.Y + 55),
                                new Point(24, 20), 0, new Point(0, 0), new Point(1, 1), new Vector2(bulletSpeed, 0), false, Game));
                    }
                }

                bulletWait = 0;
                bulletSoundIns.Play();
            }
            // Update the position of each bullet
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update(gameTime, Game.Window.ClientBounds);
                _ExplosionManager.AddQuick(bullets[i].position, bullets[i].textureImage);
                bool removeBullet = false;

                //Check for any collisions between the enemies and the bullets
                for (int j = 0; j < enemies.Count; j++ )
                {
                    if (enemies[j].collisionRect.Intersects(bullets[i].collisionRect))
                    {
                        //Set timer for length of camera shake
                        this.camera.NewShake(5, 25);
                        removeBullet = true;
                        // Detect if this is a RunningSprite who has a shield or a BossSprite with a shield. They cannot be killed if facing towards the player
                        // They can only be killed when facing away from the player
                        if (enemies[j] is RexCommando.RunningSprite || (enemies[j] is RexCommando.BossSprite && ((RexCommando.BossSprite)enemies[j]).bossType == BossType.Running))
                        {
                            if (enemies[j].position.X < player.position.X && enemies[j].effect == SpriteEffects.FlipHorizontally)
                            {
                                _ExplosionManager.AddBasic(enemies[j].position, enemies[j].textureImage);
                                enemies.RemoveAt(j);
                            }
                            else if (enemies[j].position.X > player.position.X && enemies[j].effect == SpriteEffects.None)
                            {
                                _ExplosionManager.AddBasic(enemies[j].position, enemies[j].textureImage);
                                enemies.RemoveAt(j);
                            }
                        }
                        
                        // Detect if this is a BossSprite. They have a health damage that means they can take more hits
                        // before being killed
                        else if (enemies[j] is RexCommando.BossSprite)
                        {
                            ////Make boss blink when damaged
                            //if (bossLifeWait < bossLifeWaitMax && bossLifeWaitMax % bossLifeWait <= 0.05f)
                            //    enemies[j].color.A = 0;
                            //else if (enemies[j].color.A == 0)
                            //    enemies[j].color.A = 255;

                            ((BossSprite)enemies[j]).health--;
                            bossLifeWait = 0;
                            if (((BossSprite)enemies[j]).health == 0)
                            {
                                  _ExplosionManager.AddBasic(enemies[j].position, enemies[j].textureImage);
                                enemies.RemoveAt(j);
                                // If the boss is killed then return to the main menu to choose another level.
                                GameOverCall(false);
                            }
                        }
                        else
                        {
                            _ExplosionManager.AddBasic(enemies[j].position, enemies[j].textureImage);
                            enemies.RemoveAt(j);
                        }
                    }
                }
                //Check for any collisions between the platforms and the bullets
                for (int j = 0; j < platforms.Count; j++)
                {
                    if (platforms[j].collisionRect.Intersects(bullets[i].collisionRect))
                    {
                        removeBullet = true;
                    }
                }
                //Check for any collisions between the player and the bullets
                if (player.collisionRect.Intersects(bullets[i].collisionRect))
                {
                    removeBullet = true;

                    // Put a minimun wait time between lives, so they cannot be lost very quickly when running into many bullets
                    if (lives.Count > 0 && numberofLivesWait > numberofLivesWaitMax)
                    {
                        _ExplosionManager.AddBasic(lives[lives.Count - 1].position, lives[lives.Count - 1].textureImage);
                        lives.RemoveAt(lives.Count - 1);
                        --((Game1)Game).NumberofLives;
                        numberofLivesWait = 0;
                    }
                }

                //if (bullets[i].onScreen(camera.Viewport.TitleSafeArea) == false)
                //{
                //    removeBullet = true;
                //}

                if (removeBullet && bullets.Count > 0 && bullets[i] != null
                    && lives.Count > 0)
                {
                    _ExplosionManager.AddPop(bullets[i].position, lives[lives.Count - 1].textureImage);
                    bullets.RemoveAt(i);
                }
            }
        }

        public void UpdateEnemies(GameTime gameTime)
        {
            // Wait time between boss hitting the player. This is so that the boss does not die instantly
            bossLifeWait += (float)gameTime.ElapsedGameTime.TotalSeconds;

            for (int i = 0; i < enemies.Count; i++)
            {
                //Check if enemy is a boss and when jump, shake camera
                    // ---NOTE: changed this code such that only jumping bosses shake ground and only
                    //           with 50% chance of shake. Still can remove if too shakey
                if (enemies[i].GetType() == typeof(BossSprite) && (enemies[i] as BossSprite).isOnGround
                    && rand.Next(0, 2) == 1 && (enemies[i] as BossSprite).bossType == BossType.Jumping)
                {
                    this.camera.NewShake(5, 25);
                }

                //Check for any collisions between the platforms and the enemies
                for (int j = 0; j < platforms.Count; j++)
                {
                    if (platforms[j].collisionRect.Intersects(enemies[i].collisionRect))
                    {
                        if (enemies[i].speed.X < 0)
                        {
                            enemies[i].position.X = platforms[j].position.X + platforms[j].frameSize.X;
                        }

                        else
                        {
                            enemies[i].position.X = enemies[i].position.X - 5;
                        }
                        
                        enemies[i].speed *= -1;
                    }
                }
                enemies[i].Update(gameTime, Game.Window.ClientBounds);

                //Check for any collision between the player and the enemies
                if (player.collisionRect.Intersects(enemies[i].collisionRect))
                {
                    // If player touches an enemy, loose a life and enemy dies
                    // Put a minimun wait time between lives, so they cannot be lost quickly when running into many enemies
                    if (lives.Count > 0 && numberofLivesWait > numberofLivesWaitMax)
                    {
                        _ExplosionManager.AddBasic(lives[lives.Count - 1].position, lives[lives.Count - 1].textureImage);
                        lives.RemoveAt(lives.Count - 1);
                        --((Game1)Game).NumberofLives;
                        numberofLivesWait = 0;
                        this.camera.NewShake(8, 50);
                    }

                    // If this is a boss then the boss loses health
                    if (enemies[i] is RexCommando.BossSprite)
                    {
                        ////Make boss blink when damaged
                        //if (bossLifeWait < bossLifeWaitMax && bossLifeWaitMax % bossLifeWait <= 0.05f)
                        //    enemies[i].color.A = 0;
                        //else if (enemies[i].color.A == 0)
                        //    enemies[i].color.A = 255;

                        if (((BossSprite)enemies[i]).health > 0 && bossLifeWait > bossLifeWaitMax)
                        {
                            ((BossSprite)enemies[i]).health--;
                            if (((BossSprite)enemies[i]).health == 0)
                            {
                                _ExplosionManager.AddBasic(enemies[i].position, enemies[i].textureImage);
                                enemies.RemoveAt(i);
                                // If the boss is killed then return to the main menu to choose another level.
                                GameOverCall(false);
                            }
                            else
                                bossLifeWait = 0;
                        }
                    }
                    // All the other enemies die on contact.
                    else
                    {
                        _ExplosionManager.AddBasic(enemies[i].position, enemies[i].textureImage);
                        enemies.RemoveAt(i);
                    }
                }
            }
        }
        
        public void UpdatePlatforms(GameTime gameTime)
        {
            for (int i = 0; i < platforms.Count; i++)
            {
                platforms[i].Update(gameTime, Game.Window.ClientBounds);
            }
        }

        //Call this to end the level and start a delay timer to allow
        // for ending boss explosions and whatever animations
        public void GameOverCall(bool PlayerDead)
        {
            gameOverTimer = 2; //in seconds
            gameOverCall = true;

            //If player dead, add explosion at player
            if (PlayerDead)
            {
                this.player.isDead = true;
                
                _ExplosionManager.AddHuge(player.position,
                                player.textureImage);
            }
        }

        public override void Draw(GameTime gameTime)
        {

            // Update the background layers with parallaxing is required
            foreach (Layer background in backgrounds)
                background.Draw(spriteBatch); 
            
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera.GetViewMatrix(Vector2.One));

            // Draw the current player location on the screen.
            if (((Game1)Game).debugPlayerCollision == true)
            {
                spriteBatch.DrawString(font, "Player X = " + player.collisionRect.X.ToString() + "  " +
                                        "Player Y = " + player.collisionRect.Y.ToString(), new Vector2(player.Position.X, player.Position.Y - 100), Color.Black);
                spriteBatch.DrawString(font, "Screen X = " + Game.GraphicsDevice.Viewport.Width + "  " +
                                        "Screen Y = " + Game.GraphicsDevice.Viewport.Height, new Vector2(player.Position.X, player.Position.Y - 80), Color.Black);
                spriteBatch.DrawString(font, "Camera X = " + camera.Position.X + "  " +
                                         "Camera Y = " + camera.Position.Y, new Vector2(player.Position.X, player.Position.Y - 60), Color.Black);
            }

            // If this is the boss level, then draw the remaining health above the boss to show remaining hit
            if (currentLevel == Game1.BossLevel)
            {
                foreach (Sprite enemy in enemies)
                {
                    if (enemy is RexCommando.BossSprite)
                    {
                        spriteBatch.DrawString(font, ((RexCommando.BossSprite)enemy).health.ToString(),
                                                new Vector2(enemy.Position.X + enemy.frameSize.X / 2, enemy.Position.Y - 20), Color.White);
                    }
                }
            }

            //Draw the enemies
            foreach (Sprite s in enemies)
            {
                s.Draw(gameTime, spriteBatch);
            }

            //Draw the bullets
            foreach (Sprite b in bullets)
            {
                b.Draw(gameTime, spriteBatch);
            }

            //Draw the Platforms
            foreach (Sprite p in platforms)
            {
                p.Draw(gameTime, spriteBatch);
            }
            //Draw the ladders
            foreach (Sprite l in ladders)
            {
                l.Draw(gameTime, spriteBatch);
            }
            //Draw the player            
            player.Draw(gameTime, spriteBatch);

            // Draw the player Lives
            foreach (Sprite l in lives)
            {
                l.Draw(gameTime, spriteBatch);
            }

            //Draw explosions
            _ExplosionManager.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
