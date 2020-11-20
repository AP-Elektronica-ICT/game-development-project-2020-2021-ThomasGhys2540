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
using GameDev.GamePlay;
using GameDev.Source.Engine;
using GameDev.Source;
#endregion

namespace GameDev.GamePlay.WorldData
{
    public class UserInterface
    {
        public SpriteFont Font;
        
        public UserInterface()
        {
            Font = Globals.contentManager.Load<SpriteFont>("Fonts\\Arial16");
        }

        public void Update()
        {

        }

        public void Draw()
        {
            string ShowOnScreen = "Coinage = " + Globals.Coinage;
            Vector2 StringDimensions = Font.MeasureString(ShowOnScreen);
            Globals.spriteBatch.DrawString(Font, ShowOnScreen, new Vector2(5, 5), Color.Black); ;
        }
    }
}
