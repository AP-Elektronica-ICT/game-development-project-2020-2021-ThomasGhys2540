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
    public class Sprites
    {
        public Vector2 position;
        public Vector2 dimensions;
        public Texture2D model;
        public SpriteEffects Rotation = SpriteEffects.None;
        public Rectangle Spritesheet;
        public CollisionBox colBox;


        public Sprites(string Path, Vector2 Pos, Vector2 Dim, Rectangle spritesheet)
        {
            position = Pos;
            dimensions = Dim;
            model = Globals.contentManager.Load<Texture2D>(Path);
            Spritesheet = spritesheet;

            colBox = new CollisionBox(new Rectangle((int)position.X, (int)position.Y, (int)dimensions.X, (int)dimensions.Y));
        }

        public virtual void Update()
        {
            
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
