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
    class PlatformTiles
    {
        #region Variables
        private Rectangle Configuration;
        private Texture2D TileSprite;
        #endregion

        #region Constructors
        public PlatformTiles(Texture2D tile, Vector2 position, Vector2 dimension)
        {
            TileSprite = tile;
            Configuration = new Rectangle((int)position.X, (int)position.Y, (int)dimension.X, (int)dimension.Y);
        }
        #endregion

        #region Draw
        public virtual void Draw(GameTime gameTime)
        {
            Globals.SpriteDrawer.Draw(TileSprite, Configuration, Color.White);
        }
        #endregion
    }
}
