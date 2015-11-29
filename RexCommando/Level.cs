using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace RexCommando
{
    class Level : Microsoft.Xna.Framework.DrawableGameComponent
    {
        public UserControlledSprite player;
        public List<Sprite> platforms;
        public List<Sprite> ladders;
        public List<Sprite> enemies;
        public List<Sprite> bullets;
        public List<Layer> backgrounds;
        public SoundEffect levelMusic;
        SoundEffectInstance LevelMusicIns;

        Rectangle exitLocation;

        public Level(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
            ((Game1)Game).NumberofLives = 5;
        }

        public override void Initialize()
        {
            // TODO: Add your initialization code here
            base.Initialize();
        }

        public void InitLevel(UserControlledSprite Player,List<Sprite> Platforms, List<Sprite> Ladders,
                             List<Sprite> Enemies, List<Layer> Backgrounds, List<Sprite> Bullets,
                             SoundEffect LevelMusic)
        {
            player = Player;
            platforms = Platforms;
            ladders = Ladders;
            enemies = Enemies;
            bullets = Bullets;
            backgrounds = Backgrounds;
            levelMusic = LevelMusic;
        }

        protected override void LoadContent()
        {
            CreateBackground();
            CreatePlatforms();
            CreateEnemies();
            //// Play Level Music in continous mode
            //SoundEffectInstance LevelMusicIns = levelMusic.CreateInstance();
            //LevelMusicIns.IsLooped = true;
            //LevelMusicIns.Play();

            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            LevelMusicIns.Stop();
                // TODO: Unload any non ContentManager content here
        }

        public Rectangle ExitLocation
        {
            get { return exitLocation; }
            set { exitLocation = value; }
        }

        protected virtual void CreateBackground()
        {}

        protected virtual void CreatePlatforms()
        {}

        protected virtual void CreateEnemies()
        {}
    }
}
