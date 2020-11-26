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
    class Canvas : Component
    {
        #region Variables
        public Rectangle Configuration;
        private Texture2D CanvasSprite;
        #endregion

        #region Cosntructors
        public Canvas(string path, Rectangle configuration)
        {
            CanvasSprite = Globals.ContentLoader.Load<Texture2D>(path);
            Configuration = configuration;
        }
        #endregion

        #region Draw
        public override void Draw(GameTime gameTime)
        {
            Globals.SpriteDrawer.Draw(CanvasSprite, Configuration, Color.White);
        }
        #endregion

        #region Update
        public override void Update(GameTime gameTime)
        {
            
        }
        #endregion
    }
}
