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
    class Snail : EnemyEntity
    {
        #region Variables
        
        #endregion

        #region Constructors
        public Snail(Rectangle position, Vector2 start, Vector2 end, int speed) : base (position, start, end, speed)
        {
            Sprite = Globals.ContentLoader.Load<Texture2D>("Sprites\\Enemies\\Snail");

            Spritesheet = new Rectangle(0, 0, 38, 24);
            SpriteSheetSize = 380;
            UpdateSpriteAnimation = 38;
        }
        #endregion

        #region Methods
        public void Draw(GameTime gameTime)
        {
            Globals.SpriteDrawer.Draw(Sprite, Position, Spritesheet, Spriteshade, SpriteRotation, DrawOrigin, EnemySpriteEffect, 0);
        }

        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        #endregion
    }
}
