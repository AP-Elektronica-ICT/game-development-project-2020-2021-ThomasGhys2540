#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#endregion

namespace SwampLands
{
    class Level02 : State
    {
        #region Variables
        private List<Platform> Platforms;
        private List<MovingPlatform> MovingPlatforms;
        private List<EnemyEntity> Enemies;
        #endregion

        #region Constructors
        public Level02(MainGame main, GraphicsDevice graphicsDevice) : base(main, graphicsDevice)
        {
            #region Initialise Variables
            Platforms = new List<Platform>();
            MovingPlatforms = new List<MovingPlatform>();
            Enemies = new List<EnemyEntity>();
            #endregion

            #region Creating World Platforms
            Platforms.Add(new Platform(new Vector2(0, 800), 30, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(0, 500), 7, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(1000, 750), 10, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(1050, 700), 9, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(1100, 650), 8, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(1150, 600), 7, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(1200, 550), 6, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(1250, 500), 5, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(1300, 450), 4, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(1350, 400), 3, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(1400, 350), 2, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(1450, 300), 1, Rotation.Horizontal));

            Platforms.Add(new Platform(new Vector2(2700, 800), 10, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(6000, 800), 3, Rotation.Horizontal));
            #endregion

            #region Create World Moving Platforms
            MovingPlatforms.Add(new MovingPlatform(new Vector2(2200, 600), new Vector2(1600, 600), new Vector2(2500, 600), Direction.Horizontal, 2, 250));
            MovingPlatforms.Add(new MovingPlatform(new Vector2(4600, 800), new Vector2(3500, 800), new Vector2(5800, 800), Direction.Horizontal, 4, 250));
            #endregion

            #region Generating Enemies
            Enemies.Add(new Rino(new Rectangle(2700, 730, 102, 70), new Vector2(2700, 730), new Vector2(3100, 730), 5));
            Enemies.Add(new Bird(new Rectangle(4600, 500, 50, 50), new Vector2(4200, 500), new Vector2(5000, 500), 5));
            Enemies.Add(new Bird(new Rectangle(3000, 300, 50, 50), new Vector2(2500, 300), new Vector2(3600, 300), 3));
            Enemies.Add(new Bird(new Rectangle(5000, 100, 50, 50), new Vector2(4700, 100), new Vector2(5000, 100), 1));
            Enemies.Add(new Bird(new Rectangle(5200, 400, 50, 50), new Vector2(5000, 400), new Vector2(5800, 400), 4));
            #endregion

            Globals.WorldSystem = new World(Platforms, new Vector2(6050, 750), MovingPlatforms, Enemies);
            Globals.Level = Levels.level02;
        }
        #endregion

        #region Draw
        public override void Draw(GameTime gameTime)
        {
            Globals.WorldSystem.Draw(gameTime);
        }
        #endregion

        #region Update
        public override void Update(GameTime gameTime)
        {
            Globals.WorldSystem.Update(gameTime);
        }
        #endregion
    }
}
