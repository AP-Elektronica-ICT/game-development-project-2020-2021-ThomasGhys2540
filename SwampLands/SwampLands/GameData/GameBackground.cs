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
    class GameBackground
    {
        #region Variables
        private Texture2D Sprite;
        private Vector2 Dimension;
        private Vector2 Position;
        #endregion

        #region Constructor
        public GameBackground(string path)
        {
            Sprite = Globals.ContentLoader.Load<Texture2D>(path);
            Dimension = new Vector2(Globals.ScreenWidth, Globals.ScreenHeight);
            Position = Vector2.Zero;
        }
        #endregion

        #region Draw
        public virtual void Draw()
        {
            Globals.SpriteDrawer.Draw(Sprite, new Rectangle((int)Position.X, (int)Position.Y, (int)Dimension.X, (int)Dimension.Y), new Rectangle(0, 0, 1920, 1080), Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, 0);
        }
        #endregion
    }
}
