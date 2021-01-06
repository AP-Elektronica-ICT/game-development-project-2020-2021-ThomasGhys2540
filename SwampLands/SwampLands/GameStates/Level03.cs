﻿#region Includes
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
        #endregion

        #region Constructors
        public Level03(MainGame main, GraphicsDevice graphicsDevice) : base(main, graphicsDevice)
        {
            #region Initialise Variables
            Platforms = new List<Platform>();
            #endregion

            #region Creating World Platforms
            Platforms.Add(new Platform(new Vector2(0, 800), 30, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(0, 500), 7, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(1950, 800), 20, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(1950, 750), 2, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(2350, 750), 1, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(2400, 750), 1, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(2350, 700), 2, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(2750, 700), 2, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(2800, 700), 2, Rotation.Vertical));
            Platforms.Add(new Platform(new Vector2(2750, 650), 2, Rotation.Horizontal));
            #endregion


            Globals.WorldSystem = new World(Platforms, Vector2.Zero, new List<MovingPlatform>(), new List<EnemyEntity>());
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
