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
    class Button : Component
    {
        #region Variables
        private Color ButtonColourFilter { get; set; }

        public Boolean IsHovering;
        public event EventHandler ClickButton;
        public Rectangle Configuration;
        private MouseState CurrentMouseState;
        private MouseState OldeMouseState;
        private SpriteFont Font;
        private String ButtonText;
        private Texture2D ButtonSprite;
        #endregion

        #region Constructors
        public Button(string path, Rectangle configuration)
        {
            ButtonSprite = Globals.ContentLoader.Load<Texture2D>(path);
            Configuration = configuration;
        }

        public Button(string path, Rectangle configuration, string buttonText)
        {
            ButtonSprite = Globals.ContentLoader.Load<Texture2D>(path);
            Configuration = configuration;
            ButtonText = buttonText;
            Font = Globals.ContentLoader.Load<SpriteFont>("Fonts\\Arial48Bold");
        }
        #endregion

        #region Draw
        public override void Draw(GameTime gameTime)
        {
            ButtonColourFilter = Color.White;
            
            if (IsHovering)
            {
                ButtonColourFilter = Color.Gray;
            }

            Globals.SpriteDrawer.Draw(ButtonSprite, Configuration, ButtonColourFilter);

            if (!string.IsNullOrEmpty(ButtonText))
            {
                var X = (Configuration.X + (Configuration.Width / 2)) - (Font.MeasureString(ButtonText).X / 2);
                var Y = (Configuration.Y + (Configuration.Width / 2)) - (Font.MeasureString(ButtonText).Y / 2);

                Globals.SpriteDrawer.DrawString(Font, ButtonText, new Vector2(X, Y), Color.Black);
            }
        }
        #endregion

        #region Update
        public override void Update(GameTime gameTime)
        {
            OldeMouseState = CurrentMouseState;
            CurrentMouseState = Mouse.GetState();

            IsHovering = false;
            
            Rectangle MousePosition = new Rectangle(CurrentMouseState.X, CurrentMouseState.Y, 1, 1);

            if (MousePosition.Intersects(Configuration))
            {
                IsHovering = true;

                if (CurrentMouseState.LeftButton == ButtonState.Released && OldeMouseState.LeftButton == ButtonState.Pressed)
                {
                    ClickButton?.Invoke(this, new EventArgs());
                }
            }
        }
        #endregion
    }
}
