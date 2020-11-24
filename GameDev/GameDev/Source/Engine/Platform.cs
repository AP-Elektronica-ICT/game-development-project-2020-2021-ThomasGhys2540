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
using GameDev.Source;
using GameDev.GamePlay;
using GameDev.GamePlay.WorldData;
using GameDev.GameStates;
#endregion

namespace GameDev.Source.Engine
{
    public class Platform
    {
        public List<Sprites> PlatformComponents = new List<Sprites>();
        public CollisionBox PlatformCollision;

        private Vector2 temppos;
        private Vector2 tempdim;

        public Platform(List<Sprites> components, string rotation)
        {
            PlatformCollision = new CollisionBox(new Rectangle(0, 0, 0, 0));
            
            foreach (Sprites item in components)
            {
                PlatformComponents.Add(item);
            }

            switch (rotation)
            {
                case "vertical":
                    temppos = PlatformComponents[0].position;
                    tempdim = Vector2.Zero;
                    tempdim.X = PlatformComponents[0].dimensions.X;

                    foreach (Sprites item in PlatformComponents)
                    {
                        tempdim.Y += item.dimensions.Y;
                    }

                    PlatformCollision.ColBox = new Rectangle((int)temppos.X, (int)temppos.Y, (int)tempdim.X, (int)tempdim.Y);
                    break;
                case "horizontal":
                    temppos = PlatformComponents[0].position;
                    tempdim = Vector2.Zero;
                    tempdim.X = PlatformComponents[0].dimensions.Y;

                    foreach (Sprites item in PlatformComponents)
                    {
                        tempdim.X += item.dimensions.X;
                    }

                    PlatformCollision.ColBox = new Rectangle((int)temppos.X, (int)temppos.Y, (int)tempdim.X, (int)tempdim.Y);
                    break;
                default:
                    break;
            }
        }

        public void Draw()
        {
            foreach (Sprites item in PlatformComponents)
            {
                item.Draw();
            }
        }

        public void Update()
        {

        }
    }
}
