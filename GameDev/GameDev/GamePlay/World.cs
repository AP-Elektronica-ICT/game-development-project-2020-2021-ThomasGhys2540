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
using GameDev.GamePlay.WorldData;
#endregion

namespace GameDev.Source
{
    public class World
    {
        public MainHero Hero;
        public List<Platform> WorldObjects;

        public World(List<Platform> objecten)
        {
            Hero = new MainHero(new Vector2(300, 500), new Vector2(48, 48), new Rectangle(0, 0, 32, 32));

            WorldObjects = new List<Platform>();

            foreach (Platform item in objecten)
            {
                WorldObjects.Add(item);
            }

            Globals.Coinage = 0;
            Globals.IsPaused = false;
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (Platform item in WorldObjects)
            {
                item.Update();
            }

            if (!Globals.IsPaused)
            {
                Hero.Update(gameTime);
            }

            Keyboard.GetState();
            if (Keyboard.HasBeenPressed(Keys.P))
            {
                Globals.IsPaused = !Globals.IsPaused;
            }
        }

        public virtual void Draw()
        {
            Hero.Draw();

            foreach (Platform item in WorldObjects)
            {
                item.Draw();
            }
        }

        public Boolean CheckCollision(CollisionBox colBox)
        {
            foreach (Platform item in WorldObjects)
            {
                if (item.PlatformCollision.Collides(colBox))
                {
                    return true;
                }
            }

            return false;
        }

        public CollisionBox GetCollisonBox(CollisionBox colBox)
        {
            foreach (Platform item in WorldObjects)
            {
                if (item.PlatformCollision.Collides(colBox))
                {
                    return item.PlatformCollision;
                }
            }

            return null;
        }

        public Vector2 CheckCollisionSide(CollisionBox heroColBox)
        {
            Vector2 colSide = new Vector2();
            Rectangle Hero = heroColBox.ColBox;
            Rectangle compareTo;

            if (GetCollisonBox(heroColBox) != null)
            {
                compareTo = GetCollisonBox(heroColBox).ColBox;
            }
            else
            {
                return Vector2.Zero;
            }
            
            if (Hero.Right > compareTo.Left && Hero.Left < compareTo.Left)
            {
                colSide.X = compareTo.Left - Hero.Right;
            }
            else if (Hero.Left < compareTo.Right && Hero.Right > compareTo.Right)
            {
                colSide.X = compareTo.Right - Hero.Left;
            }
            else
            {
                colSide.X = 0;
            }
            
            if (Hero.Bottom > compareTo.Top && Hero.Top < compareTo.Top)
            {
                colSide.Y = compareTo.Top - Hero.Bottom;
            }
            else if (Hero.Top < compareTo.Bottom && Hero.Bottom > compareTo.Bottom)
            {
                colSide.Y = compareTo.Bottom - Hero.Top;
            }
            else
            {
                colSide.Y = 0;
            }

            return colSide;
        }
    }
}
