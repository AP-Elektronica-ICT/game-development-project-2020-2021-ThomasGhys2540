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
using GameDev.Source.Engine.Input.Keyboards;
#endregion

namespace GameDev.Source.Engine.Input
{
    public class InputKeyboard
    {
        public KeyboardState newKeyboardState;
        public KeyboardState oldKeyBoardState;
        public List<KeyInput> pressedKeys = new List<KeyInput>();
        public List<KeyInput> PreviouslyPressedKeys = new List<KeyInput>();

        public InputKeyboard()
        {

        }

        public virtual void Update()
        {
            newKeyboardState = Keyboard.GetState();

            GetPressedKeys();
        }

        public void UpdateOld()
        {
            oldKeyBoardState = newKeyboardState;

            PreviouslyPressedKeys = new List<KeyInput>();

            for (int i = 0; i < pressedKeys.Count; i++)
            {
                PreviouslyPressedKeys.Add(pressedKeys[i]);
            }
        }

        public bool GetPress(string PressedKey)
        {
            for (int i = 0; i < pressedKeys.Count; i++)
            {
                if (pressedKeys[i].key == PressedKey)
                {
                    return true;
                }
            }

            return false;
        }

        public virtual void GetPressedKeys()
        {
            bool found = false;

            pressedKeys.Clear();

            for (int i = 0; i < newKeyboardState.GetPressedKeys().Length; i++)
            {
                pressedKeys.Add(new KeyInput(newKeyboardState.GetPressedKeys()[i].ToString(), 1));
            }
        }
    }
}
