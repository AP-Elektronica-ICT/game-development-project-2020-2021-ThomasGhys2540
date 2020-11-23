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

namespace GameDev.Source.Engine
{
    public class Globals
    {
        //Loads in images
        public static ContentManager contentManager;
        
        //Helps draw the images
        public static SpriteBatch spriteBatch;

        //Sprite Directions
        public static SpriteEffects MainHeroSpriteffects;

        //ScreenSize
        public static int ScreenHeight;
        public static int ScreenWidth;

        //Coinage system
        public static int Coinage;

        //Pauze
        public static Boolean IsPaused = false;

        //World
        public static World _World;
    }
}
