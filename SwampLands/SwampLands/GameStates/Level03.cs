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
    class Level03 : State
    {
        #region Variables
        private List<Platform> Platforms;
        private List<MovingPlatform> MovingPlatforms;
        private List<EnemyEntity> Enemies;
        #endregion

        #region Constructors
        public Level03(MainGame main, GraphicsDevice graphicsDevice) : base(main, graphicsDevice)
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
            Platforms.Add(new Platform(new Vector2(2000, 300), 1, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(2000, 350), 2, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(2000, 400), 3, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(2000, 450), 4, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(2000, 500), 5, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(2000, 550), 6, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(2000, 600), 7, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(2000, 650), 8, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(2000, 700), 9, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(2000, 750), 10, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(2000, 800), 15, Rotation.Horizontal));
            #endregion

            #region Creating moving platforms

            #endregion

            #region Generating enemies

            #endregion


            Globals.WorldSystem = new World(Platforms, Vector2.Zero, MovingPlatforms, Enemies);
            Globals.Level = Levels.level03;
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
