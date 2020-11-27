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
    class GameOverState : State
    {
        #region Variables
        private List<Component> GameOverItems;
        #endregion

        #region Constructors
        public GameOverState(MainGame main, GraphicsDevice graphicsDevice) : base(main, graphicsDevice)
        {
            var GameOverCanvas = new Canvas("Sprites\\UI\\UICanvas", new Rectangle(((int)Globals.ScreenWidth / 2) - 300, ((int)Globals.ScreenHeight / 2) - 275, 600, 450));
            var GameOverTable = new Canvas("Sprites\\UI\\UITable", new Rectangle(((int)Globals.ScreenWidth / 2) - 250, ((int)Globals.ScreenHeight / 2) - 225, 500, 350));
            var GameOverTitle = new Canvas("Sprites\\UI\\Titles\\GameOver", new Rectangle(((int)Globals.ScreenWidth / 2) - 225, ((int)Globals.ScreenHeight / 2) - 375, 500, 200));
            var RestartButton = new Button("Sprites\\UI\\Buttons\\RestartButton", new Rectangle(((int)Globals.ScreenWidth / 2) - 200, ((int)Globals.ScreenHeight / 2) - 125, 100, 100));
            var LevelSelectButton = new Button("Sprites\\UI\\Buttons\\MenuButton", new Rectangle(((int)Globals.ScreenWidth / 2) - 50, ((int)Globals.ScreenHeight / 2) - 125, 100, 100));
            var SettingsButton = new Button("Sprites\\UI\\Buttons\\SettingsButton", new Rectangle(((int)Globals.ScreenWidth / 2) + 100, ((int)Globals.ScreenHeight / 2) - 125, 100, 100));

            RestartButton.ClickButton += RestartButtonClick;
            LevelSelectButton.ClickButton += LevelSelectButtonClick;
            SettingsButton.ClickButton += SettingsMenuButtonClick;

            GameOverItems = new List<Component>()
            {
                GameOverCanvas,
                GameOverTable,
                GameOverTitle,
                RestartButton,
                LevelSelectButton,
                SettingsButton
            };
        }
        #endregion

        #region Draw
        public override void Draw(GameTime gameTime)
        {
            foreach (Component components in GameOverItems)
            {
                components.Draw(gameTime);
            }
        }
        #endregion

        #region Update
        public override void Update(GameTime gameTime)
        {
            foreach (Component components in GameOverItems)
            {
                components.Update(gameTime);
            }
        }
        #endregion

        #region Methods
        private void RestartButtonClick(object sender, EventArgs e)
        {
            Globals.ChangeGameState(new Level01(Main, Graphics));
        }

        private void LevelSelectButtonClick(object sender, EventArgs e)
        {
            Globals.ChangeGameState(new LevelSelectState(Main, Graphics));
        }

        private void SettingsMenuButtonClick(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
