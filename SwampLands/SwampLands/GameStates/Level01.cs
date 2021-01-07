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
    class Level01 : State
    {
        #region Variables
        private List<Platform> Platforms;
        private List<MovingPlatform> MovingPlatforms;
        private List<EnemyEntity> Enemies;
        #endregion

        #region Constructors
        public Level01(MainGame main, GraphicsDevice graphicsDevice) : base(main, graphicsDevice)
        {
            #region Initialise Variables
            Platforms = new List<Platform>();
            MovingPlatforms = new List<MovingPlatform>();
            Enemies = new List<EnemyEntity>();
            #endregion

            #region Creating World Platforms
            Platforms.Add(new Platform(new Vector2(0, 800), 30, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(0, 500), 7, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(450, 750), 3, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(900, 750), 6, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(900, 700), 3, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(1600, 650), 3, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(1900, 100), 4, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(1900, 150), 9, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(1950, 150), 9, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(2000, 150), 9, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(2050, 150), 9, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(2600, 800), 6, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(2300, 650), 4, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(2750, 450), 4, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(3000, 675), 2, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(3250, 534), 3, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(2250, 333), 3, Rotation.Vertical));
            #endregion

            #region Creating World Moving Platforms
            MovingPlatforms.Add(new MovingPlatform(new Vector2(1900, 800), new Vector2(1700, 800), new Vector2(2300, 800), Direction.Horizontal));
            MovingPlatforms.Add(new MovingPlatform(new Vector2(2450, 180), new Vector2(2450, 100), new Vector2(2450, 250), Direction.Vertical));
            #endregion

            #region Generate Enemies
            Enemies.Add(new Snail(new Rectangle(2800, 750, 76, 50), new Vector2(2600, 750), new Vector2(2800, 750), 1));
            Enemies.Add(new Bird(new Rectangle(1100, 100, 50, 50), new Vector2(50, 100), new Vector2(1100, 100), 2));
            Enemies.Add(new Bird(new Rectangle(1400, 200, 50, 50), new Vector2(150, 200), new Vector2(1400, 200), 3));
            #endregion

            Globals.WorldSystem = new World(Platforms, new Vector2(1950, 50), MovingPlatforms, Enemies);
            Globals.Level = Levels.level01;
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
