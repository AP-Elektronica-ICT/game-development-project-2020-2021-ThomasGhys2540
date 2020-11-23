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

namespace GameDev.Source.Engine
{
    public class Camera
    {
        public Matrix transform;
        public Viewport view;
        public Vector2 center;

        public Camera(Viewport View)
        {
            view = View;
        }

        public void Update(GameTime gameTime, World world)
        {
            center = new Vector2(/*world.Hero.position.X + (world.Hero.dimensions.X/2) - 400*/ 0, 0);
            transform = Matrix.CreateScale(new Vector3(1, 1, 0)) * Matrix.CreateTranslation(new Vector3(-center.X, -center.Y, 0));
        }
    }
}
