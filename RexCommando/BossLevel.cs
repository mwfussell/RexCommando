using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RexCommando
{
    class BossLevel : Level
    {
        //Sprite
        BossSprite boss;

        // Current game level to play. This draws the blocks depending which level player came from
        int currentLevel = 1;
        int BlockSize;
        Texture2D BlockOne;
        int xSheetSize = 1;

        public BossLevel(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
            ((Game1)Game).NumberofLives = 5;
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

        protected override void CreateBackground()
        {
            // Add one background sprite to each background layer
            switch (currentLevel)
            {
                case 1:
                    backgrounds[0].Sprites.Add(new BackgroundSprite { Texture = Game.Content.Load<Texture2D>("Backgrounds/WaterBackground") });
                    break;
                case 2:
                    backgrounds[0].Sprites.Add(new BackgroundSprite { Texture = Game.Content.Load<Texture2D>("Backgrounds/LavaBackground") });
                    break;
                case 3:
                    backgrounds[0].Sprites.Add(new BackgroundSprite { Texture = Game.Content.Load<Texture2D>("Backgrounds/GrassBackground") });
                    break;
                case 4:
                    backgrounds[0].Sprites.Add(new BackgroundSprite { Texture = Game.Content.Load<Texture2D>("Backgrounds/MetalBackground") });
                    break;
                default:
                    backgrounds[0].Sprites.Add(new BackgroundSprite { Texture = Game.Content.Load<Texture2D>("Backgrounds/MetalBackground") });
                    break;
            }
        }

        protected override void CreatePlatforms()
        {
            int OriginYPos = 1200;
            int OrginXPos = 0;

            //Load platform textures
            switch (currentLevel)
            {
                case 1:
                    BlockOne = Game.Content.Load<Texture2D>(@"Sprites/Platforms/WaterWorld/BlockOne");
                    break;
                case 2:
                    BlockOne = Game.Content.Load<Texture2D>(@"Sprites/Platforms/LavaWorld/LavaBlockSpriteSheet");
                    xSheetSize = 12;
                    break;
                case 3:
                    BlockOne = Game.Content.Load<Texture2D>(@"Sprites/Platforms/GrassWorld/BlockOne");
                    break;
                case 4:
                    BlockOne = Game.Content.Load<Texture2D>(@"Sprites/Platforms/MetalWorld/BlockFive");
                    break;
                default:
                    BlockOne = Game.Content.Load<Texture2D>(@"Sprites/Platforms/MetalWorld/BlockFive");
                    break;
            }

            BlockSize = BlockOne.Height;

            //******Horizontal Blocks starting at the bottom left of the screen******
            //Row 1
            OriginYPos = Game1.worldHeight - BlockSize;
            for (int xPos = 0; xPos < BlockSize * 19; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockOne, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(xSheetSize, 1), new Vector2(0, 0), false, Game));
            }
            //Row 10
            OriginYPos = Game1.worldHeight - BlockSize * 10;
            for (int xPos = 0; xPos < BlockSize * 19; xPos = xPos + BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockOne, new Vector2(xPos, OriginYPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(xSheetSize, 1), new Vector2(0, 0), false, Game));
            }

            //***** Vertical Blocks starting at the bottom left of the screen ******
            //Column 0
            OrginXPos = BlockSize * 0;
            for (int yPos = Game1.worldHeight - BlockSize * 2; yPos > Game1.worldHeight - BlockSize * 10; yPos = yPos - BlockSize)
            {
                platforms.Add(new AutomatedSprite(BlockOne, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                              0, new Point(0, 0), new Point(xSheetSize, 1), new Vector2(0, 0), false, Game));
            }
            //Column 20
            for (OrginXPos = BlockSize * 18; OrginXPos < BlockSize * 27; OrginXPos = OrginXPos + BlockSize)
            {
                for (int yPos = Game1.worldHeight - BlockSize * 1; yPos > Game1.worldHeight - BlockSize * 11; yPos = yPos - BlockSize)
                {
                    platforms.Add(new AutomatedSprite(BlockOne, new Vector2(OrginXPos, yPos), new Point(BlockSize, BlockSize),
                                  0, new Point(0, 0), new Point(xSheetSize, 1), new Vector2(0, 0), false, Game));
                }
            }
        }

        protected override void CreateEnemies()
        {
            //int OriginYPos = 1440; // WorldHeight
            int OriginYPos = Game1.worldHeight - BlockSize * 5;

            //Load platform textures
            switch (currentLevel)
            {
                case 1:
                    //standing animation
                    OriginYPos = Game1.worldHeight - BlockSize * 2;
                    boss = new BossSprite(Game.Content.Load<Texture2D>(@"Sprites/Bosses/WaterMan"), new Vector2(BlockSize * 14, OriginYPos - 30), new Point(104, 100),
                                           0, new Point(0, 0), new Point(9, 1), new Vector2(0, 0), true, Game, player, bullets, BlockSize, 5, 1, enemies);
                    boss.effect = SpriteEffects.FlipHorizontally;
                    boss.bossType = BossType.Flying;
                    boss.shootType = ShootType.Seahorse;
                    break;
                case 2:
                    boss = new BossSprite(Game.Content.Load<Texture2D>(@"Sprites/Bosses/LavaMan"), new Vector2(BlockSize * 15, OriginYPos + 8), new Point(108, 132),
                                          0, new Point(1, 1), new Point(1, 1), new Vector2(-3, 0), true, Game, player, bullets, BlockSize, 15, 2, enemies);
                    boss.bossType = BossType.Jumping;
                    break;
                case 3:
                    OriginYPos = Game1.worldHeight - BlockSize * 2;
                    boss = new BossSprite(Game.Content.Load<Texture2D>(@"Sprites/Bosses/GrassMan"), new Vector2(BlockSize * 15, OriginYPos - 30), new Point(120, 100),
                                          0, new Point(0, 0), new Point(3, 1), new Vector2(-3, 0), true, Game, player, bullets, BlockSize, 10, 0, enemies);
                    boss.bossType = BossType.Running;
                    break;
                case 4:
                    boss = new BossSprite(Game.Content.Load<Texture2D>(@"Sprites/Bosses/MetalMan"), new Vector2(BlockSize * 16 + 2, OriginYPos + 8), new Point(196, 128),
                                          0, new Point(0, 0), new Point(1, 1), new Vector2(0, -6), false, Game, player, bullets, BlockSize, 30, 3, enemies);
                    boss.bossType = BossType.Flying;
                    break;
                default:
                    break;
            }
            //Create the Boss
            enemies.Add(boss);
        }
    }
}
