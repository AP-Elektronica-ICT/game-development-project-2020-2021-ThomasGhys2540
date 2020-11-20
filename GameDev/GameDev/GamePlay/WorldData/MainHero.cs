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

namespace GameDev.GamePlay.WorldData
{
    public class MainHero: Animated2D
    {
        public Boolean HasJumped;

        public Texture2D Idle;
        public Texture2D Running;

        public MainHero(Vector2 Pos, Vector2 Dim, Rectangle spritesheet): base(Pos, Dim, spritesheet)
        {
            HasJumped = false;

            Idle = Globals.contentManager.Load<Texture2D>("Sprites\\IdleHero");
            Running = Globals.contentManager.Load<Texture2D>("Sprites\\RunHero");

            model = Idle;
        }

        public override void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                RunningAnimation();

                Rotation = SpriteEffects.FlipHorizontally;
                position = new Vector2(position.X - Speed, position.Y);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                RunningAnimation();
                
                Rotation = SpriteEffects.None;
                position = new Vector2(position.X + Speed, position.Y);
            }

            if (Keyboard.GetState().IsKeyUp(Keys.D) && Keyboard.GetState().IsKeyUp(Keys.Q))
            {
                IdleAnimation();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.LeftControl))
            {
                Speed = 5;
            }
            else
            {
                Speed = 1;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.P))
            {
                Globals.Coinage++;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                HasJumped = true;
            }

            if (HasJumped)
            {
                Jump();
            }

            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
        }

        public void RunningAnimation()
        {
            SpriteSize = 384;
            UpdateSize = 32;

            model = Running;
        }

        public void IdleAnimation()
        {
            SpriteSize = 352;
            UpdateSize = 32;

            model = Idle;
        }

        public void Jump()
        {
            
        }
    }
}
