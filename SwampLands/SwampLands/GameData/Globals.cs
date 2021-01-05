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

public enum Levels { Clear, level01, level02, level03, level04}

namespace SwampLands
{
    class Globals
    {
        #region GameData
        //Loads in the images
        public static ContentManager ContentLoader;

        //Draws the images
        public static SpriteBatch SpriteDrawer;

        //Screen Resolution
        public static int ScreenHeight;
        public static int ScreenWidth;

        //GameState
        public static State CurrentGameState;
        public static State NextGameState;

        //Level
        public static Levels Level;

        //Change GameState
        public  static void ChangeGameState(State changeTo)
        {
            NextGameState = changeTo;
        }
        #endregion

        #region World
        public static Boolean IsPaused;
        public static World WorldSystem;
        #endregion
    }
}
