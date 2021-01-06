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
            #endregion

            #region Creating moving platforms

            #endregion

            #region Generating enemies

            #endregion

            Globals.WorldSystem = new World(Platforms, Vector2.Zero, new List<MovingPlatform>(), new List<EnemyEntity>());
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
