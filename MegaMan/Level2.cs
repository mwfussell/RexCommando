using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RexCommando
{
    // *** LAVA WORLD LEVEL ***//
    class Level2 : Level
    {
        //Sprite
        int BlockSize;

        public Level2(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        protected override void CreateBackground()
        {
            // Add one background sprite to each background layer
            backgrounds[0].Sprites.Add(new BackgroundSprite { Texture = Game.Content.Load<Texture2D>("Backgrounds/LavaBackground") });
        }

        protected override void CreatePlatforms()
        {
            int OriginYPos = 1200;
            int OrginXPos = 0;

            //Load platform textures
            Texture2D PlatformOne = Game.Content.Load<Texture2D>(@"Sprites/Platforms/LavaWorld/platformOne");
            Texture2D BlockOne = Game.Content.Load<Texture2D>(@"Sprites/Platforms/LavaWorld/LavaBlockSpriteSheet");
            Texture2D BlockTwo = Game.Content.Load<Texture2D>(@"Sprites/Platforms/LavaWorld/BlockTwo");
            Texture2D Ladder = Game.Content.Load<Texture2D>(@"Sprites/Platforms/LavaWorld/Ladder");
            Texture2D Exit = Game.Content.Load<Texture2D>(@"Sprites/GamePlay/Exit");

            //Enemy Textures
            Texture2D BlobGuy = Game.Content.Load<Texture2D>(@"Sprites/Enemies/LavaBlobGuySmall");
            Texture2D SeaHorse = Game.Content.Load<Texture2D>(@"Sprites/Enemies/LavaSeaHorse");
            Texture2D RunningMan = Game.Content.Load<Texture2D>(@"Sprites/Enemies/LavaRunningMan");

            BlockSize = BlockOne.Height;

            //******Horizontal Blocks starting at the bottom left of the screen******
            //Row 1
            OriginYPos = Game1.worldHeight - BlockSize;
            for (int xPos = 0; xPos < BlockSize * 34; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockOne, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(12, 1), new Vector2(0, 0), false, Game));
            }
            //Row 2
            OriginYPos = Game1.worldHeight - BlockSize * 2;
            for (int xPos = 0; xPos < BlockSize * 7; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            for (int xPos = BlockSize * 16; xPos < BlockSize * 30; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Row 3
            OriginYPos = Game1.worldHeight - BlockSize * 3;
            for (int xPos = BlockSize * 16; xPos < BlockSize * 30; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Row 4
            OriginYPos = Game1.worldHeight - BlockSize * 4;
            for (int xPos = BlockSize * 17; xPos < BlockSize * 20; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 22, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));

            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 25, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
 
            platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 29, OriginYPos), new Point(BlockSize, BlockSize),
                            0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
             //Row 5
             OriginYPos = Game1.worldHeight - BlockSize * 5;
             for (int xPos = BlockSize * 4; xPos < BlockSize * 10; xPos = xPos + BlockSize)
             {
                 platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
             }
             for (int xPos = BlockSize * 17; xPos < BlockSize * 19; xPos = xPos + BlockSize)
             {
                 platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
             }
             platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 25, OriginYPos), new Point(BlockSize, BlockSize),
                           0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));

             platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 29, OriginYPos), new Point(BlockSize, BlockSize),
                           0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
             //Row 6
             OriginYPos = Game1.worldHeight - BlockSize * 6;
             for (int xPos = BlockSize * 0; xPos < BlockSize * 5; xPos = xPos + BlockSize)
             {
                 platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
             }
             //Row 8
             OriginYPos = Game1.worldHeight - BlockSize * 8;
             for (int xPos = BlockSize * 7; xPos < BlockSize * 10; xPos = xPos + BlockSize)
             {
                 platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
             }
             //Row 9
             OriginYPos = Game1.worldHeight - BlockSize * 9;
             platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 4, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
             //Row 10
             OriginYPos = Game1.worldHeight - BlockSize * 10;
             /*platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 5, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));*/
             //Row 11
             OriginYPos = Game1.worldHeight - BlockSize * 11;
             for (int xPos = BlockSize * 11; xPos < BlockSize * 22; xPos = xPos + BlockSize)
             {
                 platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
             }
                 platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 6, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
             //Row 12
             OriginYPos = Game1.worldHeight - BlockSize * 12;
             for (int xPos = BlockSize * 22; xPos < BlockSize * 24; xPos = xPos + BlockSize)
             {
                 platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
             }
             //Row 13
             OriginYPos = Game1.worldHeight - BlockSize * 13;
             for (int xPos = BlockSize * 24; xPos < BlockSize * 26; xPos = xPos + BlockSize)
             {
                 platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
             }
             for (int xPos = BlockSize * 1; xPos < BlockSize * 4; xPos = xPos + BlockSize)
             {
                 platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
             }
             //Row 14
             OriginYPos = Game1.worldHeight - BlockSize * 14;
             for (int xPos = BlockSize * 26; xPos < BlockSize * 29; xPos = xPos + BlockSize)
             {
                 platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
             }
             platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 30, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            //Row 15
             OriginYPos = Game1.worldHeight - BlockSize * 15;
             platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 19, OriginYPos), new Point(BlockSize, BlockSize),
                  0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));

             platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 14, OriginYPos), new Point(BlockSize, BlockSize),
                  0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));

            //Row 16
             OriginYPos = Game1.worldHeight - BlockSize * 16;
             platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(BlockSize * 18, OriginYPos), new Point(BlockSize, BlockSize),
                  0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));


            //***** Vertical Blocks starting at the bottom left of the screen ******
 
            //Column 0 Start
            OrginXPos = BlockSize * 0;
            for (int yPos = Game1.worldHeight - BlockSize * 2; yPos > Game1.worldHeight - BlockSize * 14; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }

            //Set the EXIT location for the level on column 0
            OriginYPos = Game1.worldHeight - BlockSize * 15;
            platforms.Add(new AutomatedSprite(Exit, new Vector2(OrginXPos, OriginYPos), new Point(24, 144),
                           0, new Point(0, 0), new Point(10, 1), new Vector2(0, 0), false, Game));

            //Column 0 Continued
            for (int yPos = Game1.worldHeight - BlockSize * 16; yPos > Game1.worldHeight - BlockSize * 21; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            
            //Column 7
            OrginXPos = BlockSize * 7;
            for (int yPos = Game1.worldHeight - BlockSize * 12; yPos > Game1.worldHeight - BlockSize * 21; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Column 10
            OrginXPos = BlockSize * 10;
            for (int yPos = Game1.worldHeight - BlockSize * 6; yPos > Game1.worldHeight - BlockSize * 18; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Column 29
            OrginXPos = BlockSize * 29;
            for (int yPos = Game1.worldHeight - BlockSize * 8; yPos > Game1.worldHeight - BlockSize * 15; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            for (int yPos = Game1.worldHeight - BlockSize * 18; yPos > Game1.worldHeight - BlockSize * 21; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Ladder Column 31
            OrginXPos = BlockSize * 31;
            for (int yPos = Game1.worldHeight - BlockSize * 2; yPos > Game1.worldHeight - BlockSize * 10; yPos = yPos - BlockSize)
            {
                ladders.Add(new AutomatedSprite(Ladder, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Column 32
            OrginXPos = BlockSize * 32;
            for (int yPos = Game1.worldHeight - BlockSize * 9; yPos > Game1.worldHeight - BlockSize * 12; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockTwo, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(1, 1), new Vector2(0, 0), false, Game));
            }
            //Column 33
            OrginXPos = BlockSize * 33;
            for (int yPos = Game1.worldHeight - BlockSize * 2; yPos > Game1.worldHeight - BlockSize * 21; yPos = yPos - BlockSize)
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
            Texture2D BlobGuy = Game.Content.Load<Texture2D>(@"Sprites/Enemies/LavaBlobGuySmall");
            Texture2D SeaHorse = Game.Content.Load<Texture2D>(@"Sprites/Enemies/LavaSeaHorse");
            Texture2D RunningMan = Game.Content.Load<Texture2D>(@"Sprites/Enemies/LavaRunningMan");
            Texture2D Turret = Game.Content.Load<Texture2D>(@"Sprites/Enemies/LavaTurret");

            BlockSize = BlockOne.Height;
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 16;
            enemies.Add(new ShootingSprite(Turret, new Vector2(BlockSize * 19, OriginYPos + 4), new Point(80, 68),
                         20, new Point(0, 0), new Point(1, 1), Vector2.Zero, false, Game, bullets, LookingDirection.Right));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 16;
            enemies.Add(new ShootingSprite(Turret, new Vector2(BlockSize * 14, OriginYPos + 4), new Point(80, 68),
                         20, new Point(0, 0), new Point(1, 1), Vector2.Zero, false, Game, bullets, LookingDirection.Right));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 17;
            enemies.Add(new ShootingSprite(Turret, new Vector2(BlockSize * 18, OriginYPos + 4), new Point(80, 68),
                         20, new Point(0, 0), new Point(1, 1), Vector2.Zero, false, Game, bullets, LookingDirection.Right));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 10;
            enemies.Add(new ShootingSprite(Turret, new Vector2(BlockSize * 4, OriginYPos + 4), new Point(80, 68),
                         20, new Point(0, 0), new Point(1, 1), Vector2.Zero, false, Game, bullets, LookingDirection.Right));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 12;
            enemies.Add(new ShootingSprite(Turret, new Vector2(BlockSize * 6, OriginYPos + 4), new Point(80, 68),
                         20, new Point(0, 0), new Point(1, 1), Vector2.Zero, false, Game, bullets, LookingDirection.Left));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 4;
            enemies.Add (new ShootingSprite(Turret, new Vector2(BlockSize * 16, OriginYPos+4), new Point(80, 68),
                         20, new Point(0, 0), new Point(1, 1), Vector2.Zero, false, Game,bullets,LookingDirection.Left));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 4;
            enemies.Add(new TravelSprite(BlobGuy, new Vector2(BlockSize * 23, OriginYPos - 8), new Point(88, 80),
                            19, new Point(0, 0), new Point(3, 1), new Vector2(-2, 0), false, Game, new Vector2(10, 0)));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 4;
            enemies.Add(new AutomatedSprite(BlobGuy, new Vector2(BlockSize * 25, OriginYPos - 8), new Point(88, 80),
                        19, new Point(0, 0), new Point(3, 1), new Vector2(-2, 0), false, Game));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 5;
            enemies.Add(new ShootingSprite(Turret, new Vector2(BlockSize * 22 - 8, OriginYPos + 4), new Point(80, 68),
                         0, new Point(0, 0), new Point(1, 1), Vector2.Zero, false, Game, bullets, LookingDirection.Left));
            //enemy 
            OriginYPos = Game1.worldHeight - BlockSize * 6;
            enemies.Add(new AutomatedSprite(BlobGuy, new Vector2(BlockSize * 4, OriginYPos - 8), new Point(88, 80),
                        19, new Point(0, 0), new Point(3, 1), new Vector2(-2, 0), false, Game));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 12;
            enemies.Add(new AutomatedSprite(BlobGuy, new Vector2(BlockSize * 17, OriginYPos - 8), new Point(88, 80),
                        19, new Point(0, 0), new Point(3, 1), new Vector2(-2, 0), false, Game));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 2;
            enemies.Add(new RunningSprite(RunningMan, new Vector2(BlockSize * 14, OriginYPos - 33), new Point(108, 104),
                        19, new Point(1, 1), new Point(3, 1), new Vector2(0, 0), false, Game, player));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 12;
            enemies.Add(new RunningSprite(RunningMan, new Vector2(BlockSize * 17, OriginYPos - 33), new Point(108, 104),
                        19, new Point(1, 1), new Point(3, 1), new Vector2(0, 0), false, Game, player));
            //enemy
            OriginYPos = Game1.worldHeight - BlockSize * 12;
            enemies.Add(new RunningSprite(RunningMan, new Vector2(BlockSize * 14, OriginYPos - 33), new Point(108, 104),
                        19, new Point(1, 1), new Point(3, 1), new Vector2(0, 0), false, Game, player));
            //Test enemy
            //enemies.Add(new RunningSprite(RunningMan, new Vector2(BlockSize * 6, OriginYPos - 70), new Point(108, 104),
            //19, new Point(1, 1), new Point(3, 1), new Vector2(0, 0), false, Game, player));
        }
    }
}
