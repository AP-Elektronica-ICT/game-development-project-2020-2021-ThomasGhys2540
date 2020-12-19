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
    class LevelSelectState : State
    {
        #region Variables
        private List<Component> LevelSelectItems;
        #endregion

        #region Constructors
        public LevelSelectState(MainGame main, GraphicsDevice graphicsDevice) : base(main, graphicsDevice)
        {
            var LevelSelectCanvas = new Canvas("Sprites\\UI\\UICanvas", new Rectangle(((int)Globals.ScreenWidth /2) - 250, ((int)Globals.ScreenHeight / 2) - 175, 500, 350));
            var LevelSelectTable = new Canvas("Sprites\\UI\\UITable", new Rectangle(((int)Globals.ScreenWidth / 2) - 200, ((int)Globals.ScreenHeight / 2) - 125, 400, 250));
            var LevelSelectTitle = new Canvas("Sprites\\UI\\Titles\\LevelSelect", new Rectangle(((int)Globals.ScreenWidth / 2) - 225, ((int)Globals.ScreenHeight / 2) - 275, 500, 200));
            var Level01 = new Button("Sprites\\UI\\Buttons\\LevelButton", new Rectangle(LevelSelectCanvas.Configuration.Left + 125, LevelSelectCanvas.Configuration.Top + 75, 100, 100), "1");
            var Level02 = new Button("Sprites\\UI\\Buttons\\LevelButton", new Rectangle(LevelSelectCanvas.Configuration.Left + 275, LevelSelectCanvas.Configuration.Top + 75, 100, 100), "2");
            var Level03 = new Button("Sprites\\UI\\Buttons\\LevelButton", new Rectangle(LevelSelectCanvas.Configuration.Left + 125, LevelSelectCanvas.Configuration.Top + 175, 100, 100), "3");
            var Level04 = new Button("Sprites\\UI\\Buttons\\LevelButton", new Rectangle(LevelSelectCanvas.Configuration.Left + 275, LevelSelectCanvas.Configuration.Top + 175, 100, 100), "4");

            Level01.ClickButton += Level01ButtonClick;
            Level02.ClickButton += Level02ButtonClick;
            Level03.ClickButton += Level03ButtonClick;
            Level04.ClickButton += Level04ButtonClick;

            LevelSelectItems = new List<Component>()
            {
                LevelSelectCanvas,
                LevelSelectTable,
                LevelSelectTitle,
                Level01,
                Level02,
                Level03,
                Level04
            };
        }
        #endregion

        #region Draw
        public override void Draw(GameTime gameTime)
        {
            foreach (Component components in LevelSelectItems)
            {
                components.Draw(gameTime);
            }
        }
        #endregion

        #region
        public override void Update(GameTime gameTime)
        {
            foreach (Component components in LevelSelectItems)
            {
                components.Update(gameTime);
            }
        }
        #endregion

        #region Methods
        private void Level01ButtonClick(object sender, EventArgs e)
        {
            Globals.ChangeGameState(new Level01(Main, Graphics));
        }
        private void Level02ButtonClick(object sender, EventArgs e)
        {
            Globals.ChangeGameState(new Level02(Main, Graphics));
        }
        private void Level03ButtonClick(object sender, EventArgs e)
        {
            Globals.ChangeGameState(new Level03(Main, Graphics));
        }
        private void Level04ButtonClick(object sender, EventArgs e)
        {
            Globals.ChangeGameState(new Level04(Main, Graphics));
        }
        #endregion
    }
}
