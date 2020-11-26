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
        private Texture2D ButtonSprite;
        #endregion

        #region Constructors
        public Button(string path, Rectangle configuration)
        {
            ButtonSprite = Globals.ContentLoader.Load<Texture2D>(path);
            Configuration = configuration;
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
