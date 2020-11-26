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
        #endregion

        #region Constructors
        public Level01(MainGame main, GraphicsDevice graphicsDevice) : base(main, graphicsDevice)
        {
            #region Initialise Variables
            Platforms = new List<Platform>();
            #endregion

            #region Creating World Platforms
            Platforms.Add(new Platform(new Vector2(200, 600), 3, Rotation.Horizontal));
            Platforms.Add(new Platform(new Vector2(300, 500), 2, Rotation.Vertical));
            #endregion
        }
        #endregion

        #region Draw
        public override void Draw(GameTime gameTime)
        {
            foreach (Platform _Platform in Platforms)
            {
                _Platform.Draw(gameTime);
            }
        }
        #endregion

        #region Update
        public override void Update(GameTime gameTime)
        {
            
        }
        #endregion
    }
}
