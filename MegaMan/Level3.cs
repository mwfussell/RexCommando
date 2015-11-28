using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MegaMan
{
    // *** GRASS WORLD LEVEL ***//
    class Level3 : Level
    {
        //Sprite
        int BlockSize;

        public Level3(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        protected override void CreateBackground()
        {
            // Add one background sprite to each background layer
            backgrounds[0].Sprites.Add(new BackgroundSprite { Texture = Game.Content.Load<Texture2D>("Backgrounds/GrassBackground") });
        }

        protected override void CreatePlatforms()
        {
            int OriginYPos = 1200;
            int OrginXPos = 0;

            //Load platform textures
            Texture2D BlockOne = Game.Content.Load<Texture2D>(@"Sprites/Platforms/GrassWorld/BlockOne");
            Texture2D BlockTwo = Game.Content.Load<Texture2D>(@"Sprites/Platforms/GrassWorld/BlockTwo");
            Texture2D BlockThree = Game.Content.Load<Texture2D>(@"Sprites/Platforms/GrassWorld/BlockThree");
            Texture2D Bridge = Game.Content.Load<Texture2D>(@"Sprites/Platforms/GrassWorld/bridge");
            Texture2D Ladder = Game.Content.Load<Texture2D>(@"Sprites/Platforms/GrassWorld/Ladder");
            Texture2D Exit = Game.Content.Load<Texture2D>(@"Sprites/GamePlay/Exit");

            //Enemy Textures
            Texture2D BlobGuy = Game.Content.Load<Texture2D>(@"Sprites/Enemies/GrassBlobGuy");
            Texture2D RunningMan = Game.Content.Load<Texture2D>(@"Sprites/Enemies/GrassRunningMan");
            Texture2D Turret = Game.Content.Load<Texture2D>(@"Sprites/Enemies/GrassTurret");

            BlockSize = BlockOne.Height;

            //******Horizontal Blocks starting at the bottom left of the screen******
            //Row 1
            OriginYPos = Game1.worldHeight - BlockSize;
            for (int xPos = 0; xPos < BlockSize * 34; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockOne, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Row 4
            OriginYPos = Game1.worldHeight - BlockSize * 4;
            for (int xPos = BlockSize * 18; xPos < BlockSize * 29; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(Bridge, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
                platforms.Add(new AutomatedSprite(BlockThree, new Vector2(BlockSize * 16, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            //Row 7
            OriginYPos = Game1.worldHeight - BlockSize * 7;
            for (int xPos = BlockSize * 1; xPos < BlockSize * 10; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockThree, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Row 9
            OriginYPos = Game1.worldHeight - BlockSize * 9;
            for (int xPos = BlockSize * 11; xPos < BlockSize * 17; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockThree, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            for (int xPos = BlockSize * 26; xPos < BlockSize * 29; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockThree, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Row 10
            OriginYPos = Game1.worldHeight - BlockSize * 10;
            platforms.Add(new AutomatedSprite(BlockThree, new Vector2(BlockSize * 1, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));

            platforms.Add(new AutomatedSprite(BlockThree, new Vector2(BlockSize * 5, OriginYPos), new Point(BlockSize, BlockSize),
                0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));

            platforms.Add(new AutomatedSprite(BlockThree, new Vector2(BlockSize * 6, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));

            platforms.Add(new AutomatedSprite(BlockThree, new Vector2(BlockSize * 11, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));

            platforms.Add(new AutomatedSprite(BlockThree, new Vector2(BlockSize * 17, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));

            platforms.Add(new AutomatedSprite(BlockThree, new Vector2(BlockSize * 25, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
        //Row 11
            OriginYPos = Game1.worldHeight - BlockSize * 11;

            platforms.Add(new AutomatedSprite(BlockThree, new Vector2(BlockSize * 6, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));

            platforms.Add(new AutomatedSprite(BlockThree, new Vector2(BlockSize * 10, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));

            platforms.Add(new AutomatedSprite(BlockThree, new Vector2(BlockSize * 18, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));

            platforms.Add(new AutomatedSprite(BlockThree, new Vector2(BlockSize * 24, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
           //Row 12
            OriginYPos = Game1.worldHeight - BlockSize * 12;
            for (int xPos = BlockSize * 5; xPos < BlockSize * 7; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockThree, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                                0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            for (int xPos = BlockSize * 19; xPos < BlockSize * 24; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockThree, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                                0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Row 14
            OriginYPos = Game1.worldHeight - BlockSize * 14;
            platforms.Add(new AutomatedSprite(BlockThree, new Vector2(BlockSize * 1, OriginYPos), new Point(BlockSize, BlockSize),
                0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            //Row 16
            OriginYPos = Game1.worldHeight - BlockSize * 16;
            platforms.Add(new AutomatedSprite(BlockThree, new Vector2(BlockSize * 5, OriginYPos), new Point(BlockSize, BlockSize),
                0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            //Row 18
            OriginYPos = Game1.worldHeight - BlockSize * 18;
            for (int xPos = BlockSize * 7; xPos < BlockSize * 31; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockThree, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                                0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            platforms.Add(new AutomatedSprite(BlockThree, new Vector2(BlockSize * 1, OriginYPos), new Point(BlockSize, BlockSize),
                0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));

            //Set the ***EXIT*** location for the level 3
            OriginYPos = Game1.worldHeight - BlockSize * 20;
            platforms.Add(new AutomatedSprite(Exit, new Vector2(BlockSize * 33, OriginYPos), new Point(24, 144),
                            0, new Point(0, 0), new Point(10, 1), new Vector2(0, 0), false, Game));

            //***** Vertical Blocks starting at the bottom left of the screen ******
            //Column 0
            OrginXPos = BlockSize * 0;
            for (int yPos = Game1.worldHeight - BlockSize * 2; yPos > Game1.worldHeight - BlockSize * 21; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockThree, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Column 5
            OrginXPos = BlockSize * 5;
            for (int yPos = Game1.worldHeight - BlockSize * 2; yPos > Game1.worldHeight - BlockSize * 5; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockThree, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Column 5
            OrginXPos = BlockSize * 6;
            for (int yPos = Game1.worldHeight - BlockSize * 14; yPos > Game1.worldHeight - BlockSize * 19; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockThree, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Column 9
            OrginXPos = BlockSize * 9;
            for (int yPos = Game1.worldHeight - BlockSize * 7; yPos > Game1.worldHeight - BlockSize * 13; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockThree, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Column 11
            OrginXPos = BlockSize * 11;
            for (int yPos = Game1.worldHeight - BlockSize * 2; yPos > Game1.worldHeight - BlockSize * 4; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockThree, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Column 17
            OrginXPos = BlockSize * 17;
            for (int yPos = Game1.worldHeight - BlockSize * 2; yPos > Game1.worldHeight - BlockSize * 6; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockThree, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Column 21
            OrginXPos = BlockSize * 21;
            for (int yPos = Game1.worldHeight - BlockSize * 13; yPos > Game1.worldHeight - BlockSize * 16; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockThree, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Column 29
            OrginXPos = BlockSize * 29;
            for (int yPos = Game1.worldHeight - BlockSize * 2; yPos > Game1.worldHeight - BlockSize * 5; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockThree, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Column 30
            OrginXPos = BlockSize * 30;
            for (int yPos = Game1.worldHeight - BlockSize * 2; yPos > Game1.worldHeight - BlockSize * 5; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockThree, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Ladder Column 29
            OrginXPos = BlockSize * 29;
            for (int yPos = Game1.worldHeight - BlockSize * 5; yPos > Game1.worldHeight - BlockSize * 10; yPos = yPos - BlockSize)
            {
                ladders.Add(new AutomatedSprite(Ladder, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Ladder Column 30
            OrginXPos = BlockSize * 30;
            for (int yPos = Game1.worldHeight - BlockSize * 5; yPos > Game1.worldHeight - BlockSize * 10; yPos = yPos - BlockSize)
            {
                ladders.Add(new AutomatedSprite(Ladder, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Column 31
            OrginXPos = BlockSize * 31;
            for (int yPos = Game1.worldHeight - BlockSize * 2; yPos > Game1.worldHeight - BlockSize * 19; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockThree, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Column 32
            OrginXPos = BlockSize * 32;
            for (int yPos = Game1.worldHeight - BlockSize * 2; yPos > Game1.worldHeight - BlockSize * 19; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockThree, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Column 33
            OrginXPos = BlockSize * 33;
            for (int yPos = Game1.worldHeight - BlockSize * 2; yPos > Game1.worldHeight - BlockSize * 19; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockThree, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
       
        }

        protected override void CreateEnemies()
        {
            int OriginYPos = 1440; // WorldHeight


            //Enemy Textures
            Texture2D BlockOne = Game.Content.Load<Texture2D>(@"Sprites/Platforms/GrassWorld/BlockOne");

            //Enemy Textures
            Texture2D BlobGuy = Game.Content.Load<Texture2D>(@"Sprites/Enemies/GrassBlobGuy");
            Texture2D RunningMan = Game.Content.Load<Texture2D>(@"Sprites/Enemies/GrassRunningMan");
            Texture2D Turret = Game.Content.Load<Texture2D>(@"Sprites/Enemies/GrassTurret");

            BlockSize = BlockOne.Height;
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 16;
            enemies.Add(new ShootingSprite(Turret, new Vector2(BlockSize * 21, OriginYPos + 4), new Point(80, 68),
                         0, new Point(0, 0), new Point(1, 1), Vector2.Zero, false, Game, bullets, LookingDirection.Right));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 11;
            enemies.Add(new ShootingSprite(Turret, new Vector2(BlockSize * 5, OriginYPos + 4), new Point(80, 68),
                         0, new Point(0, 0), new Point(1, 1), Vector2.Zero, false, Game, bullets, LookingDirection.Left));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 19;
            enemies.Add(new ShootingSprite(Turret, new Vector2(BlockSize * 1, OriginYPos + 4), new Point(80, 68),
                         0, new Point(0, 0), new Point(1, 1), Vector2.Zero, false, Game, bullets, LookingDirection.Right));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 17;
            enemies.Add(new ShootingSprite(Turret, new Vector2(BlockSize * 5, OriginYPos + 4), new Point(80, 68),
                         0, new Point(0, 0), new Point(1, 1), Vector2.Zero, false, Game, bullets, LookingDirection.Left));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 15;
            enemies.Add(new ShootingSprite(Turret, new Vector2(BlockSize * 1, OriginYPos + 4), new Point(80, 68),
                         0, new Point(0, 0), new Point(1, 1), Vector2.Zero, false, Game, bullets, LookingDirection.Right));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 13;
            enemies.Add(new ShootingSprite(Turret, new Vector2(BlockSize * 6, OriginYPos + 4), new Point(80, 68),
                         0, new Point(0, 0), new Point(1, 1), Vector2.Zero, false, Game, bullets, LookingDirection.Right));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 5;
            enemies.Add(new ShootingSprite(Turret, new Vector2(BlockSize * 5, OriginYPos + 4), new Point(80, 68),
                         0, new Point(0, 0), new Point(1, 1), Vector2.Zero, false, Game, bullets, LookingDirection.Left));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 4;
            enemies.Add(new ShootingSprite(Turret, new Vector2(BlockSize * 11, OriginYPos + 4), new Point(80, 68),
                         0, new Point(0, 0), new Point(1, 1), Vector2.Zero, false, Game, bullets, LookingDirection.Left));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 6;
            enemies.Add(new ShootingSprite(Turret, new Vector2(BlockSize * 17, OriginYPos + 4), new Point(80, 68),
                         0, new Point(0, 0), new Point(1, 1), Vector2.Zero, false, Game, bullets, LookingDirection.Left));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 8;
            enemies.Add(new AutomatedSprite(BlobGuy, new Vector2(BlockSize * 3, OriginYPos - 8), new Point(88, 80),
                        19, new Point(0, 0), new Point(3, 1), new Vector2(-2, 0), false, Game));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 8;
            enemies.Add(new AutomatedSprite(BlobGuy, new Vector2(BlockSize * 5, OriginYPos - 8), new Point(88, 80),
                        19, new Point(0, 0), new Point(3, 1), new Vector2(-5, 0), false, Game));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 2;
            enemies.Add(new RunningSprite(RunningMan, new Vector2(BlockSize * 9, OriginYPos - 33), new Point(108, 104),
                        19, new Point(1, 1), new Point(3, 1), new Vector2(0, 0), false, Game, player));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 2;
            enemies.Add(new RunningSprite(RunningMan, new Vector2(BlockSize * 14, OriginYPos - 33), new Point(108, 104),
                        19, new Point(1, 1), new Point(3, 1), new Vector2(0, 0), false, Game, player));
            //Test enemy
            //enemies.Add(new RunningSprite(RunningMan, new Vector2(BlockSize * 6, OriginYPos - 70), new Point(108, 104),
            //19, new Point(1, 1), new Point(3, 1), new Vector2(0, 0), false, Game, player));
        }
    }
}
