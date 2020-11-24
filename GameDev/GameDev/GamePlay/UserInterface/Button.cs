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

namespace GameDev.GamePlay.UserInterface
{
    public class Button : Component
    {
        public event EventHandler Click;
        public Color FontColours { get; set; }
        public Vector2 position { get; set; }
        public Vector2 dimension { get; set; }
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, 200, 200);
            }
        }
        public string Text { get; set; }
        
        private MouseState CurrentMouse;
        private SpriteFont Font;
        private MouseState OldMouse;
        private Boolean IsHovering;
        private Texture2D Texture;

        public Button(Texture2D texture, SpriteFont font)
        {
            Texture = texture;
            Font = font;
            FontColours = Color.Black;
        }

        public override void Update(GameTime gameTime)
        {
            OldMouse = CurrentMouse;
            CurrentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(CurrentMouse.X, CurrentMouse.Y, 1, 1);

            IsHovering = false;

            if (mouseRectangle.Intersects(Rectangle))
            {
                IsHovering = true;

                if (CurrentMouse.LeftButton == ButtonState.Released && OldMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            var colour = Color.White;

            if (IsHovering)
            {
                colour = Color.Gray;
            }

            Globals.spriteBatch.Draw(Texture, Rectangle, colour);

            if (!string.IsNullOrEmpty(Text))
            {
                var X = (Rectangle.X + (Rectangle.Width / 2)) - (Font.MeasureString(Text).X / 2);
                var Y = (Rectangle.Y + (Rectangle.Height / 2)) - (Font.MeasureString(Text).Y / 2);

                Globals.spriteBatch.DrawString(Font, Text, new Vector2(X, Y), FontColours);
            }            
        }
    }
}
