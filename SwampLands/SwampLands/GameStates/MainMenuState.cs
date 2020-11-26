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
    class MainMenuState : State
    {
        #region Variables
        private List<Component> MenuItems;
        #endregion

        #region Constructor
        public MainMenuState(MainGame main, GraphicsDevice graphicsDevice) : base (main, graphicsDevice)
        {
            var PlayButton = new Button("Sprites\\UI\\PlayButton", new Rectangle(((int)Globals.ScreenWidth / 2) - 75, 100, 150, 150));
            var SettingsButton = new Button("Sprites\\UI\\SettingsButton", new Rectangle(((int)Globals.ScreenWidth / 2) - 75, 350, 150, 150)); 
            var QuitButton = new Button("Sprites\\UI\\QuitButton", new Rectangle(((int)Globals.ScreenWidth / 2) - 75, 600, 150, 150));

            PlayButton.ClickButton += PlayGameButtonClick;
            SettingsButton.ClickButton += SettingsButtonClick;
            QuitButton.ClickButton += QuitGameButtonClick;

            MenuItems = new List<Component>()
            {
                PlayButton,
                SettingsButton,
                QuitButton
            };
        }
        #endregion

        #region Draw
        public override void Draw(GameTime gameTime)
        {
            foreach (Component button in MenuItems)
            {
                button.Draw(gameTime);
            }
        }
        #endregion

        #region Update
        public override void Update(GameTime gameTime)
        {
            foreach (Component button in MenuItems)
            {
                button.Update(gameTime);
            }
        }
        #endregion

        #region Methods
        private void PlayGameButtonClick(object sender, EventArgs e)
        {
            Main.ChangeGameState(new LevelSelectState(Main, Graphics));
        }

        private void SettingsButtonClick(object sender, EventArgs e)
        {

        }

        private void QuitGameButtonClick(object sender, EventArgs e)
        {
            Main.Exit();
        }
        #endregion
    }
}
