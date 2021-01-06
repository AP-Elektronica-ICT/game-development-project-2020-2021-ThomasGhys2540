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
            Platforms.Add(new Platform(new Vector2(1950, 800), 18, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(1950, 750), 2, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(2350, 750), 1, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(2400, 750), 1, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(2350, 700), 2, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(2750, 700), 2, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(2800, 700), 2, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(2750, 650), 2, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(3100, 650), 4, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(3150, 650), 4, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(3100, 600), 2, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(3450, 600), 5, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(3500, 600), 5, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(3450, 550), 2, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(5350, 200), 3, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(5850, 550), 7, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(6500, 800), 5, Rotation.Horizontal));
            #endregion

            #region Creating moving platforms
            MovingPlatforms.Add(new MovingPlatform(new Vector2(3800, 300), new Vector2(3800, 200), new Vector2(3800, 700), Direction.Vertical, 3));
            MovingPlatforms.Add(new MovingPlatform(new Vector2(4200, 200), new Vector2(4150, 200), new Vector2(5000, 200), Direction.Horizontal, 4, 250));
            #endregion

            #region Generating enemies
            Enemies.Add(new Snail(new Rectangle(2300, 750, 50, 50), new Vector2(2050, 750), new Vector2(2300, 750), 1));
            Enemies.Add(new Snail(new Rectangle(2700, 750, 50, 50), new Vector2(2450, 750), new Vector2(2700, 750), 2));
            Enemies.Add(new Bird(new Rectangle(4300, 400, 50, 50), new Vector2(3900, 400), new Vector2(4300, 400), 2));
            Enemies.Add(new Bird(new Rectangle(4800, 300, 50, 50), new Vector2(4400, 300), new Vector2(4800, 300), 1));
            Enemies.Add(new Rino(new Rectangle(6150, 480, 100, 70), new Vector2(5850, 480), new Vector2(6150, 480), 4));
            #endregion

            Globals.WorldSystem = new World(Platforms, new Vector2(6600, 750), MovingPlatforms, Enemies);
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
