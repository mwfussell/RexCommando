using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RexCommando
{
    // *** WATER WORLD LEVEL ***//
    class Level1 : Level
    {
        //Sprite
        int BlockSize;
        bool platformLeft = true;

        public Level1(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        protected override void CreateBackground()
        {
            // Add one background sprite to each background layer
            backgrounds[0].Sprites.Add(new BackgroundSprite { Texture = Game.Content.Load<Texture2D>("Backgrounds/WaterBackground") });
        }

        protected override void CreatePlatforms()
        {
            int OriginYPos = 1200;
            int OrginXPos = 0;

            //Load platform textures
            Texture2D PlatformOne = Game.Content.Load<Texture2D>(@"Sprites/Platforms/WaterWorld/PlatformOne");
            Texture2D BlockOne = Game.Content.Load<Texture2D>(@"Sprites/Platforms/WaterWorld/BlockOne");
            Texture2D BlockTwo = Game.Content.Load<Texture2D>(@"Sprites/Platforms/WaterWorld/BlockTwo");
            Texture2D BlockThree = Game.Content.Load<Texture2D>(@"Sprites/Platforms/WaterWorld/BlockThree");
            Texture2D Ladder = Game.Content.Load<Texture2D>(@"Sprites/Platforms/WaterWorld/Ladder");
            Texture2D Exit = Game.Content.Load<Texture2D>(@"Sprites/GamePlay/Exit");

            //Enemy Textures
            Texture2D BlobGuy = Game.Content.Load<Texture2D>(@"Sprites/Enemies/WaterBlobGuy");
            Texture2D SeaHorse = Game.Content.Load<Texture2D>(@"Sprites/Enemies/WaterSeaHorse");
            Texture2D RunningMan = Game.Content.Load<Texture2D>(@"Sprites/Enemies/WaterRunningMan");
            Texture2D Turret = Game.Content.Load<Texture2D>(@"Sprites/Enemies/WaterTurret");

            BlockSize = BlockOne.Height;

            //for (int xPos = BlockSize*8; xPos < Game1.worldWidth; xPos = xPos + 300)
            //{
            //    platforms.Add(new AutomatedSprite(PlatformOne, new Vector2(xPos, OriginYPos), new Point(148, 40),
            //                  0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            //    OriginYPos = OriginYPos - 100;
            //}

            // ****** Blue Platforms ******
            OriginYPos = Game1.worldHeight - BlockSize * 3;
            OrginXPos = BlockSize * 8;
            platforms.Add(new AutomatedSprite(PlatformOne, new Vector2(OrginXPos, OriginYPos), new Point(148, 40),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));

            //******Horizontal Blocks starting at the bottom left of the screen******
            //Row 1
            OriginYPos = Game1.worldHeight - BlockSize;
            for (int xPos = 0; xPos < BlockSize * 33; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockOne, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }

            //enemy
            enemies.Add(new AutomatedSprite(BlobGuy, new Vector2(BlockSize * 14, OriginYPos - BlockSize - 9), new Point(88, 80),
                        19, new Point(0, 0), new Point(3, 1), new Vector2(-1, 0), false, Game));
            //enemy
            enemies.Add(new AutomatedSprite(BlobGuy, new Vector2(BlockSize * 20, OriginYPos - BlockSize - 9), new Point(88, 80),
                        19, new Point(0, 0), new Point(3, 1), new Vector2(-1, 0), false, Game));
            //enemy
            enemies.Add(new AutomatedSprite(BlobGuy, new Vector2(BlockSize * 22, OriginYPos - BlockSize - 9), new Point(88, 80),
                        19, new Point(0, 0), new Point(3, 1), new Vector2(-2, 0), false, Game));


            //Row 2
            OriginYPos = Game1.worldHeight - BlockSize * 2;
            for (int xPos = BlockSize * 17; xPos < BlockSize * 19; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            for (int xPos = BlockSize * 26; xPos < BlockSize * 28; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 10;
            enemies.Add(new RunningSprite(RunningMan, new Vector2(BlockSize * 17, OriginYPos - 33), new Point(108, 104),
                        19, new Point(1, 1), new Point(3, 1), new Vector2(0, 0), false, Game, player));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 10;
            enemies.Add(new RunningSprite(RunningMan, new Vector2(BlockSize * 20, OriginYPos - 33), new Point(108, 104),
                        19, new Point(1, 1), new Point(3, 1), new Vector2(0, 0), false, Game, player));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 9;
            enemies.Add(new AutomatedSprite(BlobGuy, new Vector2(BlockSize * 18, OriginYPos - BlockSize - 9), new Point(88, 80),
                        19, new Point(0, 0), new Point(3, 1), new Vector2(-3, 0), false, Game));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 10;
            enemies.Add(new AutomatedSprite(BlobGuy, new Vector2(BlockSize * 10, OriginYPos - BlockSize - 9), new Point(88, 80),
                        19, new Point(0, 0), new Point(3, 1), new Vector2(-3, 0), false, Game));

            //Row 4
            OriginYPos = Game1.worldHeight - BlockSize * 4;
            for (int xPos = 0; xPos < BlockSize * 5; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockOne, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 4;
            enemies.Add(new ShootingSprite(Turret, new Vector2(BlockSize * 3, OriginYPos - BlockSize * 1), new Point(80, 68),
                         0, new Point(0, 0), new Point(1, 1), Vector2.Zero, false, Game, bullets, LookingDirection.Right));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 9;
            enemies.Add(new ShootingSprite(Turret, new Vector2(BlockSize * 3, OriginYPos - BlockSize * 1), new Point(80, 68),
                         0, new Point(0, 0), new Point(1, 1), Vector2.Zero, false, Game, bullets, LookingDirection.Left));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 17;
            enemies.Add(new ShootingSprite(Turret, new Vector2(BlockSize * 5, OriginYPos - BlockSize * 1), new Point(80, 68),
                         0, new Point(0, 0), new Point(1, 1), Vector2.Zero, false, Game, bullets, LookingDirection.Left));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 12;
            enemies.Add(new ShootingSprite(Turret, new Vector2(BlockSize * 4, OriginYPos - BlockSize * 1), new Point(80, 68),
                         0, new Point(0, 0), new Point(1, 1), Vector2.Zero, false, Game, bullets, LookingDirection.Right));

            //Row 7
            OriginYPos = Game1.worldHeight - BlockSize * 7;
            for (int xPos = BlockSize * 8; xPos < BlockSize * 11; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Row 8
            OriginYPos = Game1.worldHeight - BlockSize * 8;
            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 7, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));

            //Row 9
            OriginYPos = Game1.worldHeight - BlockSize * 9;
            for (int xPos = BlockSize * 3; xPos < BlockSize * 7; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            for (int xPos = BlockSize * 14; xPos < BlockSize * 29; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Row 10
            OriginYPos = Game1.worldHeight - BlockSize * 10;
            for (int xPos = BlockSize * 10; xPos < BlockSize * 13; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Row 11
            OriginYPos = Game1.worldHeight - BlockSize * 11;
            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 9, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            //Row 12
            OriginYPos = Game1.worldHeight - BlockSize * 12;
            for (int xPos = 0; xPos < BlockSize * 9; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            for (int xPos = BlockSize * 24; xPos < BlockSize * 24; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockThree, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Row 17
            OriginYPos = Game1.worldHeight - BlockSize * 17;
            for (int xPos = BlockSize * 2; xPos < BlockSize * 34; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockOne, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }

            //Set the EXIT location for the level
            OriginYPos = Game1.worldHeight - BlockSize * 19;
            platforms.Add(new AutomatedSprite(Exit, new Vector2(BlockSize * 33, OriginYPos), new Point(24, 144),
                           0, new Point(0, 0), new Point(10, 1), new Vector2(0, 0), false, Game));

            //Row 20
            OriginYPos = Game1.worldHeight - BlockSize * 20;
            for (int xPos = 0; xPos < BlockSize * 34; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }

            //***** Vertical Blocks starting at the bottom left of the screen ******
            //Blue Platforms
            for (float yPos = Game1.worldHeight - BlockSize * 2; yPos > Game1.worldHeight - BlockSize * 16; yPos = yPos - BlockSize * 3.0f)
            {
                if (platformLeft == true)
                {
                    OrginXPos = BlockSize * 29;
                    platformLeft = false;
                }

                else
                {
                    OrginXPos = BlockSize * 31;
                    platformLeft = true;
                }
                platforms.Add(new AutomatedSprite(PlatformOne, new Vector2(OrginXPos, yPos), new Point(148, 40),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }

            //Column 2
            OrginXPos = BlockSize * 2;
            for (int yPos = Game1.worldHeight - BlockSize * 7; yPos > Game1.worldHeight - BlockSize * 10; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockOne, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Ladder Column 5
            for (int yPos = Game1.worldHeight - BlockSize * 5; yPos > Game1.worldHeight - BlockSize * 10; yPos = yPos - BlockSize)
            {
                ladders.Add(new AutomatedSprite(Ladder, new Vector2(BlockSize, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Ladder Column 13
            for (int yPos = Game1.worldHeight - BlockSize * 13; yPos > Game1.worldHeight - BlockSize * 19; yPos = yPos - BlockSize)
            {
                ladders.Add(new AutomatedSprite(Ladder, new Vector2(BlockSize, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Column 10
            OrginXPos = BlockSize * 10;
            for (int yPos = Game1.worldHeight - BlockSize; yPos > Game1.worldHeight - BlockSize * 8; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockOne, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Column 13
            OrginXPos = BlockSize * 13;
            for (int yPos = Game1.worldHeight - BlockSize * 4; yPos > Game1.worldHeight - BlockSize * 14; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Ladder Column 18
            OrginXPos = BlockSize * 18;
            for (int yPos = Game1.worldHeight - BlockSize * 3; yPos > Game1.worldHeight - BlockSize * 7; yPos = yPos - BlockSize)
            {
                ladders.Add(new AutomatedSprite(Ladder, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Column 19
            OrginXPos = BlockSize * 19;
            for (int yPos = Game1.worldHeight - BlockSize; yPos > Game1.worldHeight - BlockSize * 7; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockThree, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Column 27
            OrginXPos = BlockSize * 27;
            platforms.Add(new AutomatedSprite(BlockThree, new Vector2(OrginXPos, Game1.worldHeight - BlockSize * 5), new Point(BlockSize, BlockSize),
                          0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));

            //Column 28
            OrginXPos = BlockSize * 28;
            for (int yPos = Game1.worldHeight - BlockSize * 10; yPos > Game1.worldHeight - BlockSize * 14; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockOne, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            for (int yPos = Game1.worldHeight - BlockSize * 2; yPos > Game1.worldHeight - BlockSize * 7; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockThree, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }


            //platforms.Add(new AutomatedSprite(Game.Content.Load<Texture2D>(@"Sprites/Platforms/platformOne"),
            //new Vector2(170, 1300), new Point(148, 40), 0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));

            //platforms.Add(new AutomatedSprite(Game.Content.Load<Texture2D>(@"Sprites/Platforms/platformOne"),
            //new Vector2(370, 1200), new Point(148, 40), 0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));

            //platforms.Add(new AutomatedSprite(Game.Content.Load<Texture2D>(@"Sprites/Platforms/platformOne"),
            //new Vector2(570, 1100), new Point(148, 40), 0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
       
        }

        protected override void CreateEnemies()
        {
            int OriginYPos = 1440; // WorldHeight
            int OrginXPos = 500;

            //Load enemy textures
            Texture2D BlobGuy = Game.Content.Load<Texture2D>(@"Sprites/Enemies/WaterBlobGuy");
            Texture2D SeaHorse = Game.Content.Load<Texture2D>(@"Sprites/Enemies/WaterSeaHorse");

            //OriginYPos = (OriginYPos - block * 5);
            enemies.Add(new AutomatedSprite(BlobGuy, new Vector2(OrginXPos, OriginYPos), new Point(88, 92),
                        0, new Point(0, 0), new Point(3, 1), new Vector2(0, 0), false, Game));

        }
    }
}
