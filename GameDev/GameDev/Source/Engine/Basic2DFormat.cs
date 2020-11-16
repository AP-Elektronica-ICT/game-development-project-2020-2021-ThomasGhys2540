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
    public class Basic2DFormat
    {
        public Vector2 position;
        public Vector2 dimensions;
        public Texture2D model;

        private Rectangle IdleHeroSpritesheet;
        
        public Basic2DFormat(string Path, Vector2 Pos, Vector2 Dim)
        {
            position = Pos;
            dimensions = Dim;
            model = Globals.contentManager.Load<Texture2D>(Path);

            IdleHeroSpritesheet = new Rectangle(0, 0, 32, 32);
        }

        public virtual void Update()
        {
            IdleHeroSpritesheet.X += 32;
            if (IdleHeroSpritesheet.X >= 352)
            {
                IdleHeroSpritesheet.X = 0;
            }
        }

        public virtual void Draw()
        {
            if (model != null)
            {
                Globals.spriteBatch.Draw
                (
                    model,
                    new Rectangle
                    (
                        (int)position.X,
                        (int)position.Y,
                        (int)dimensions.X,
                        (int)dimensions.Y
                    ),
                    IdleHeroSpritesheet,
                    Color.White,
                    0.0f,
                    new Vector2
                    (
                        model.Bounds.Width / 2,
                        model.Bounds.Height / 2
                    ),
                    new SpriteEffects(),
                    0
                );
            }
        }
    }
}
