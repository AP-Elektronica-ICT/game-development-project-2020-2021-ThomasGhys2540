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

namespace GameDev.Source
{
    public class Keyboard
    {
        public static KeyboardState CurrentState;
        public static KeyboardState OldState;

        public static KeyboardState GetState()
        {
            OldState = CurrentState;
            CurrentState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
            return CurrentState;
        }

        public static Boolean IsPressed(Keys Key)
        {
            return CurrentState.IsKeyDown(Key);
        }

        public static bool HasBeenPressed(Keys Key)
        {
            return CurrentState.IsKeyDown(Key) && !OldState.IsKeyDown(Key);
        }
    }
}
