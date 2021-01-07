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
            Platforms.Add(new Platform(new Vector2(3000, 550), 5, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(3350, 700), 3, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(4500, 650), 3, Rotation.Horizontal));
            #endregion

            #region Creating moving platforms
            MovingPlatforms.Add(new MovingPlatform(new Vector2(3850, 800), new Vector2(3850, 800), new Vector2(4250, 800), Direction.Horizontal, 4));
            #endregion

            #region Generating enemies
            Enemies.Add(new Bird(new Rectangle(800, 50, 50, 50), new Vector2(100, 50), new Vector2(800, 50), 2));
            Enemies.Add(new Bird(new Rectangle(1200, 150, 50, 50), new Vector2(300, 150), new Vector2(1200, 150), 2));
            Enemies.Add(new Rino(new Rectangle(2700, 730, 100, 70), new Vector2(2500, 730), new Vector2(2700, 730), 4));
            Enemies.Add(new Rino(new Rectangle(3200, 480, 100, 70), new Vector2(3000, 480), new Vector2(3200, 480), 3));
            Enemies.Add(new Rino(new Rectangle(3150, 480, 100, 70), new Vector2(3000, 730), new Vector2(3200, 730), 3));
            Enemies.Add(new Bird(new Rectangle(4500, 200, 50, 50), new Vector2(3500, 200), new Vector2(4500, 200), 2));
            Enemies.Add(new Bird(new Rectangle(4000, 300, 50, 50), new Vector2(3000, 300), new Vector2(4000, 300), 3));
            #endregion


            Globals.WorldSystem = new World(Platforms, new Vector2(4550, 600), MovingPlatforms, Enemies);
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
