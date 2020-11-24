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
using GameDev.GamePlay.UserInterface;
#endregion

namespace GameDev.Source.Engine
{   
    public class CollisionBox
    {
        public Rectangle ColBox { get; set; }

        public CollisionBox(Rectangle spriteBounds)
        {
            ColBox = spriteBounds;
        }

        public void TransformCollision(Rectangle newCol)
        {
            ColBox = newCol;
        }

        public bool Collides(CollisionBox CollidesWith)
        {
            return ColBox.Intersects(CollidesWith.ColBox);
        }
    }
}
