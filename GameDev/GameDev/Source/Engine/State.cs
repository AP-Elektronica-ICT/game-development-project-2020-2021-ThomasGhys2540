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
using GameDev.Source.Engine;
#endregion

namespace GameDev.Source.Engine
{
    public abstract class State
    {
        protected GraphicsDevice Graphics;
        protected Main _Main;

        public State(Main main, GraphicsDevice graphicsDevice)
        {
            Graphics = graphicsDevice;
            _Main = main;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
    }
}
