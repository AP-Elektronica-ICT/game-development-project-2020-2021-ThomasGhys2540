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
    abstract class State
    {
        #region Variables
        protected GraphicsDevice Graphics;
        protected MainGame Main;
        #endregion

        #region Constructors
        public State(MainGame main, GraphicsDevice graphicsDevice)
        {
            Graphics = graphicsDevice;
            Main = main;
        }
        #endregion

        #region Abstract Methods
        public abstract void Draw(GameTime gameTime);
        public abstract void Update(GameTime gameTime);
        #endregion
    }
}
