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
    class Level04 : State
    {
        #region Variables
        private List<Platform> Platforms;
        private List<MovingPlatform> MovingPlatforms;
        private List<EnemyEntity> Enemies;
        #endregion

        #region Constructors
        public Level04(MainGame main, GraphicsDevice graphicsDevice) : base(main, graphicsDevice)
        {
            #region Initialise Variables
            Platforms = new List<Platform>();
            MovingPlatforms = new List<MovingPlatform>();
            Enemies = new List<EnemyEntity>();
            #endregion

            #region Creating World Platforms
            Platforms.Add(new Platform(new Vector2(0, 800), 30, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(0, 500), 7, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(250, 750), 7, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(1950, 800), 1, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(2000, 800), 1, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(1950, 750), 2, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(2350, 750), 2, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(2400, 750), 2, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(2350, 700), 2, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(2750, 700), 3, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(2800, 700), 3, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(2750, 650), 2, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(3100, 650), 4, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(3150, 650), 4, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(3100, 600), 2, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(3450, 600), 5, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(3500, 600), 5, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(3450, 550), 2, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(4050, 150), 3, Rotation.Horizontal));
            #endregion

            #region Creating moving platforms
            MovingPlatforms.Add(new MovingPlatform(new Vector2(3800, 150), new Vector2(3800, 150), new Vector2(3800, 600), Direction.Vertical, 3));
            #endregion

            #region Generating enemies
            Enemies.Add(new Bird(new Rectangle(800, 50, 50, 50), new Vector2(100, 50), new Vector2(800, 50), 2));
            Enemies.Add(new Bird(new Rectangle(1200, 150, 50, 50), new Vector2(300, 150), new Vector2(1200, 150), 2));
            Enemies.Add(new Bird(new Rectangle(1500, 350, 50, 50), new Vector2(800, 350), new Vector2(1500, 350), 2));
            Enemies.Add(new Bird(new Rectangle(1450, 325, 50, 50), new Vector2(800, 325), new Vector2(1500, 325), 2));
            Enemies.Add(new Bird(new Rectangle(1450, 375, 50, 50), new Vector2(800, 375), new Vector2(1500, 375), 2));
            Enemies.Add(new Bird(new Rectangle(1700, 200, 50, 50), new Vector2(700, 200), new Vector2(1700, 200), 4));
            Enemies.Add(new Bird(new Rectangle(2000, 150, 50, 50), new Vector2(1350, 150), new Vector2(2000, 150), 3));
            Enemies.Add(new Bird(new Rectangle(1950, 125, 50, 50), new Vector2(1350, 125), new Vector2(2000, 125), 3));
            Enemies.Add(new Bird(new Rectangle(1950, 175, 50, 50), new Vector2(1350, 175), new Vector2(2000, 175), 3));
            Enemies.Add(new Bird(new Rectangle(1900, 100, 50, 50), new Vector2(1350, 100), new Vector2(2000, 100), 3));
            Enemies.Add(new Bird(new Rectangle(1900, 200, 50, 50), new Vector2(1350, 200), new Vector2(2000, 200), 3));
            #endregion

            Globals.WorldSystem = new World(Platforms, new Vector2(4100, 100), MovingPlatforms, Enemies);
            Globals.Level = Levels.level04;
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
