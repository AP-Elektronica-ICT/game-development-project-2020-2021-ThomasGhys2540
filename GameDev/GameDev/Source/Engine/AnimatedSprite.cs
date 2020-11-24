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
    public class AnimatedSprite
    {
        public Vector2 position;
        public Vector2 dimensions;
        public CollisionBox colBox;
        public Texture2D model;
        public int Speed = 10;
        public SpriteEffects Rotation = SpriteEffects.None;
        public int UpdateSize;
        public int SpriteSize;
        public Rectangle Spritesheet;
        
        
        public AnimatedSprite(Vector2 Pos, Vector2 Dim, Rectangle spritesheet)
        {
            position = Pos;
            dimensions = Dim;

            Spritesheet = spritesheet;

            colBox = new CollisionBox(new Rectangle((int)position.X, (int)position.Y, (int)dimensions.X, (int)dimensions.Y));
        }

        public virtual void Update()
        {
            Spritesheet.X += UpdateSize;
            if (Spritesheet.X >= SpriteSize)
            {
                Spritesheet.X = 0;
            }

            colBox.TransformCollision(new Rectangle((int)position.X, (int)position.Y, (int)dimensions.X, (int)dimensions.Y));
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
                    Spritesheet,
                    Color.White,
                    0.0f,
                    new Vector2
                    (
                        model.Bounds.Width / 2,
                        model.Bounds.Height / 2
                    ),
                    Rotation,
                    0
                );
            }
        }
    }
}
