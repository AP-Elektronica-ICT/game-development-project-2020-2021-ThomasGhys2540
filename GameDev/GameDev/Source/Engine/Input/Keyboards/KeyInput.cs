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

namespace GameDev.Source.Engine.Input.Keyboards
{
    public class KeyInput
    {
        public int state;
        public string key;
        public string print;
        public string display;

        public KeyInput(string Key, int State)
        {
            key = Key;
            state = State;

            MakePrint(key);
        }

        public virtual void Update()
        {
            state = 2;
        }

        public void MakePrint(string Key)
        {
            display = Key;

            string ConnectKey = "";

            if (Key == "A" || Key == "B" || Key == "C" || Key == "D" || Key == "E" || Key == "F" || Key == "G" || Key == "H" || Key == "I" || Key == "J" || Key == "K" || Key == "L" || Key == "M" || Key == "N" || Key == "O" || Key == "P" || Key == "Q" || Key == "R" || Key == "S" || Key == "T" || Key == "U" || Key == "V" || Key == "W" || Key == "X" || Key == "Y" || Key == "Z")
            {
                ConnectKey = Key;
            }

            if (Key == "Space")
            {
                ConnectKey = " ";
            }

            if (Key == "OemCloseBrackets")
            {
                ConnectKey = "]";

                display = ConnectKey;
            }

            if (Key == "OemOpenBrackets")
            {
                ConnectKey = "[";

                display = ConnectKey;
            }

            if (Key == "OemMinus")
            {
                ConnectKey = "-";

                display = ConnectKey;
            }

            if (Key == "OemPeriod" || Key == "Decimal")
            {
                ConnectKey = ".";
            }

            if (Key == "NumPad0" || Key == "NumPad1" || Key == "NumPad2" || Key == "NumPad3" || Key == "NumPad4" || Key == "NumPad5" || Key == "NumPad6" || Key == "NumPad7" || Key == "NumPad8" || Key == "NumPad9")
            {
                ConnectKey = Key.Substring(6);
            }

            print = ConnectKey;
        }
    }
}
