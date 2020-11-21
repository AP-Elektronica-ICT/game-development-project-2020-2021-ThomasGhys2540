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
using GameDev.GamePlay.UserInterface;
#endregion

namespace GameDev.GameStates
{
    public class MainMenuState : State
    {
        private List<Component> Items;
        
        public MainMenuState(Main main, GraphicsDevice graphicsDevice) : base (main, graphicsDevice)
        {
            var ButtonTexture = Globals.contentManager.Load<Texture2D>("Sprites\\Button");
            var ButtonFont = Globals.contentManager.Load<SpriteFont>("Fonts\\Arial16");

            var NewGameButton = new Button(ButtonTexture, ButtonFont)
            {
                position = new Vector2((Globals.ScreenWidth / 2) - 200, 200),
                Text = "New Game",
                
            };
            NewGameButton.Click += NewGameButtonClick;

            var LoadGameButton = new Button(ButtonTexture, ButtonFont)
            {
                position = new Vector2((Globals.ScreenWidth / 2) - 200, 350),
                Text = "Load Game"
            };
            LoadGameButton.Click += LoadGameButtonClick;

            var QuitGameButton = new Button(ButtonTexture, ButtonFont)
            {
                position = new Vector2((Globals.ScreenWidth / 2) - 200, 500),
                Text = "Quit Game"
            };
            QuitGameButton.Click += QuitGameButtonClick;

            Items = new List<Component>()
            {
                NewGameButton,
                LoadGameButton,
                QuitGameButton,
            };
        }

        private void NewGameButtonClick(object sender, EventArgs e)
        {
            _Main.ChangeState(new Level001State(_Main, Graphics));
        }
        private void LoadGameButtonClick(object sender, EventArgs e)
        {

        }

        private void QuitGameButtonClick(object sender, EventArgs e)
        {
            _Main.Exit();
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (var component in Items)
            {
                component.Draw(gameTime);
            }
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in Items)
            {
                component.Update(gameTime);
            }
        }
    }
}
