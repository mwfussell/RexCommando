using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MegaMan
{
    // *** METAL WORLD LEVEL ***//
    class Level4 : Level
    {
        //Sprite
        int BlockSize;

        public Level4(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        protected override void CreateBackground()
        {
            // Add one background sprite to each background layer
            backgrounds[0].Sprites.Add(new BackgroundSprite { Texture = Game.Content.Load<Texture2D>("Backgrounds/MetalBackground") });
        }

        protected override void CreatePlatforms()
        {
            int OriginYPos = 1200;
            int OrginXPos = 0;

            //Load platform textures
            Texture2D BlockOne = Game.Content.Load<Texture2D>(@"Sprites/Platforms/MetalWorld/BlockThree");
            Texture2D BlockTwo = Game.Content.Load<Texture2D>(@"Sprites/Platforms/MetalWorld/BlockFive");
            Texture2D Ladder = Game.Content.Load<Texture2D>(@"Sprites/Platforms/MetalWorld/Ladder");
            Texture2D Exit = Game.Content.Load<Texture2D>(@"Sprites/GamePlay/Exit");

            //Enemy Textures
            Texture2D BlobGuy = Game.Content.Load<Texture2D>(@"Sprites/Enemies/MetalBlobGuy");
            Texture2D SeaHorse = Game.Content.Load<Texture2D>(@"Sprites/Enemies/MetalSeaHorse");
            Texture2D RunningMan = Game.Content.Load<Texture2D>(@"Sprites/Enemies/MetalRunningMan");

            BlockSize = BlockOne.Height;

            //******Horizontal Blocks starting at the bottom left of the screen******
            //Row 1
            OriginYPos = Game1.worldHeight - BlockSize;
            for (int xPos = 0; xPos < BlockSize * 34; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockOne, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Row 2
            OriginYPos = Game1.worldHeight - BlockSize * 2;
            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 5, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            OriginYPos = Game1.worldHeight - BlockSize * 2;
            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 14, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            OriginYPos = Game1.worldHeight - BlockSize * 2;
            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 19, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            OriginYPos = Game1.worldHeight - BlockSize * 2;
            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 24, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 23, OriginYPos), new Point(BlockSize, BlockSize),
                0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            OriginYPos = Game1.worldHeight - BlockSize * 2;
            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 31, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            OriginYPos = Game1.worldHeight - BlockSize * 2;
            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 32, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            //Row 3
            OriginYPos = Game1.worldHeight - BlockSize * 3;
            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 5, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 19, OriginYPos), new Point(BlockSize, BlockSize),
                           0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            //Row 4
            OriginYPos = Game1.worldHeight - BlockSize * 4;
            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 6, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 10, OriginYPos), new Point(BlockSize, BlockSize),
                0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            //Row 5
            OriginYPos = Game1.worldHeight - BlockSize * 5;
            for (int xPos = BlockSize * 7; xPos < BlockSize * 10; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            for (int xPos = BlockSize * 16; xPos < BlockSize * 18; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            for (int xPos = BlockSize * 29; xPos < BlockSize * 31; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Row 6
            OriginYPos = Game1.worldHeight - BlockSize * 6;
            for (int xPos = BlockSize * 10; xPos < BlockSize * 13; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            for (int xPos = BlockSize * 19; xPos < BlockSize * 29; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            OriginYPos = Game1.worldHeight - BlockSize * 6;
            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 16, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            OriginYPos = Game1.worldHeight - BlockSize * 6;
            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 18, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            //Row 7
            OriginYPos = Game1.worldHeight - BlockSize * 7;
            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 10, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            OriginYPos = Game1.worldHeight - BlockSize * 7;
            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 15, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            //Row 8
            OriginYPos = Game1.worldHeight - BlockSize * 8;
            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 10, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            OriginYPos = Game1.worldHeight - BlockSize * 8;
            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 15, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            //Row 11
            OriginYPos = Game1.worldHeight - BlockSize * 11;
            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 13, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            OriginYPos = Game1.worldHeight - BlockSize * 11;
            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 12, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            //Row 12
            OriginYPos = Game1.worldHeight - BlockSize * 12;
            for (int xPos = BlockSize * 0; xPos < BlockSize * 12; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Row 13
            OriginYPos = Game1.worldHeight - BlockSize * 13;
            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 11, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            //Row 16
            OriginYPos = Game1.worldHeight - BlockSize * 16;
            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 7, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            //Row 17
            OriginYPos = Game1.worldHeight - BlockSize * 17;
            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 3, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            for (int xPos = BlockSize * 10; xPos < BlockSize * 34; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Row 18
            OriginYPos = Game1.worldHeight - BlockSize * 18;
            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 10, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 11, OriginYPos), new Point(BlockSize, BlockSize),
                0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 16, OriginYPos), new Point(BlockSize, BlockSize),
                0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));


            //Set the ***EXIT*** location for the level 3
            OriginYPos = Game1.worldHeight - BlockSize * 20;
            platforms.Add(new AutomatedSprite(Exit, new Vector2(BlockSize * 33, OriginYPos), new Point(24, 144),
                            0, new Point(0, 0), new Point(10, 1), new Vector2(0, 0), false, Game));

            //***** Vertical Blocks starting at the bottom left of the screen ******

            //Column 0 Start
            OrginXPos = BlockSize * 0;
            for (int yPos = Game1.worldHeight - BlockSize * 2; yPos > Game1.worldHeight - BlockSize * 21; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Ladder Column 2
            OrginXPos = BlockSize * 1;
            for (int yPos = Game1.worldHeight - BlockSize * 13; yPos > Game1.worldHeight - BlockSize * 18; yPos = yPos - BlockSize)
            {
                ladders.Add(new AutomatedSprite(Ladder, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Column 13 Start
            OrginXPos = BlockSize * 13;
            for (int yPos = Game1.worldHeight - BlockSize * 2; yPos > Game1.worldHeight - BlockSize * 5; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Column 14 Start
            OrginXPos = BlockSize * 14;
            for (int yPos = Game1.worldHeight - BlockSize * 9; yPos > Game1.worldHeight - BlockSize * 12; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Column 34 Start
            OrginXPos = BlockSize * 33;
            for (int yPos = Game1.worldHeight - BlockSize * 2; yPos > Game1.worldHeight - BlockSize * 19; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
        }

        protected override void CreateEnemies()
        {
            int OriginYPos = 1440; // WorldHeight

            //Platform Textures
            Texture2D BlockOne = Game.Content.Load<Texture2D>(@"Sprites/Platforms/LavaWorld/LavaBlockSpriteSheet");

            //Enemy Textures
            Texture2D BlobGuy = Game.Content.Load<Texture2D>(@"Sprites/Enemies/MetalBlobGuy");
            Texture2D SeaHorse = Game.Content.Load<Texture2D>(@"Sprites/Enemies/MetalSeaHorse");
            Texture2D RunningMan = Game.Content.Load<Texture2D>(@"Sprites/Enemies/MetalRunningMan");
            Texture2D Turret = Game.Content.Load<Texture2D>(@"Sprites/Enemies/MetalTurret");

            BlockSize = BlockOne.Height;
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 5;
            enemies.Add(new ShootingSprite(Turret, new Vector2(BlockSize * 10, OriginYPos + 4), new Point(80, 68),
                         0, new Point(0, 0), new Point(1, 1), Vector2.Zero, false, Game, bullets, LookingDirection.Right));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 17;
            enemies.Add(new ShootingSprite(Turret, new Vector2(BlockSize * 7, OriginYPos + 4), new Point(80, 68),
                         0, new Point(0, 0), new Point(1, 1), Vector2.Zero, false, Game, bullets, LookingDirection.Left));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 18;
            enemies.Add(new ShootingSprite(Turret, new Vector2(BlockSize * 3, OriginYPos + 4), new Point(80, 68),
                         0, new Point(0, 0), new Point(1, 1), Vector2.Zero, false, Game, bullets, LookingDirection.Left));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 3;
            enemies.Add(new ShootingSprite(Turret, new Vector2(BlockSize * 24, OriginYPos + 4), new Point(80, 68),
                         0, new Point(0, 0), new Point(1, 1), Vector2.Zero, false, Game, bullets, LookingDirection.Left));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 2;
            enemies.Add(new AutomatedSprite(BlobGuy, new Vector2(BlockSize * 22, OriginYPos - 8), new Point(88, 80),
                        19, new Point(0, 0), new Point(3, 1), new Vector2(-1, 0), false, Game));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 2;
            enemies.Add(new AutomatedSprite(BlobGuy, new Vector2(BlockSize * 21, OriginYPos - 8), new Point(88, 80),
                        19, new Point(0, 0), new Point(3, 1), new Vector2(-1, 0), false, Game));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 2;
            enemies.Add(new AutomatedSprite(BlobGuy, new Vector2(BlockSize * 17, OriginYPos - 8), new Point(88, 80),
                        19, new Point(0, 0), new Point(3, 1), new Vector2(-3, 0), false, Game));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 18;
            enemies.Add(new AutomatedSprite(BlobGuy, new Vector2(BlockSize * 13, OriginYPos - 8), new Point(88, 80),
                        19, new Point(0, 0), new Point(3, 1), new Vector2(-3, 0), false, Game));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 18;
            enemies.Add(new AutomatedSprite(BlobGuy, new Vector2(BlockSize * 14, OriginYPos - 8), new Point(88, 80),
                        19, new Point(0, 0), new Point(3, 1), new Vector2(-3, 0), false, Game));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 2;
            enemies.Add(new RunningSprite(RunningMan, new Vector2(BlockSize * 27, OriginYPos - 33), new Point(108, 104),
                        19, new Point(1, 1), new Point(3, 1), new Vector2(0, 0), false, Game, player));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 18;
            enemies.Add(new RunningSprite(RunningMan, new Vector2(BlockSize * 27, OriginYPos - 33), new Point(108, 104),
                        19, new Point(1, 1), new Point(3, 1), new Vector2(0, 0), false, Game, player));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 13;
            enemies.Add(new RunningSprite(RunningMan, new Vector2(BlockSize * 5, OriginYPos - 33), new Point(108, 104),
                        19, new Point(1, 1), new Point(3, 1), new Vector2(0, 0), false, Game, player));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 13;
            enemies.Add(new RunningSprite(RunningMan, new Vector2(BlockSize * 7, OriginYPos - 33), new Point(108, 104),
                        19, new Point(1, 1), new Point(3, 1), new Vector2(0, 0), false, Game, player));

            //Test enemy
            //enemies.Add(new RunningSprite(RunningMan, new Vector2(BlockSize * 6, OriginYPos - 70), new Point(108, 104),
            //19, new Point(1, 1), new Point(3, 1), new Vector2(0, 0), false, Game, player));
            
        }
    }
}
