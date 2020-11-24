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
    public class MainHero: AnimatedSprite
    {
        public Boolean HasJumped;
        public float Jumpforce = 10;
        public Vector2 StartPos;
        public Boolean JumpFlag = true;
        public Texture2D Idle;
        public Texture2D Running;

        public MainHero(Vector2 Pos, Vector2 Dim, Rectangle spritesheet): base(Pos, Dim, spritesheet)
        {
            HasJumped = false;

            Idle = Globals.contentManager.Load<Texture2D>("Sprites\\IdleHero");
            Running = Globals.contentManager.Load<Texture2D>("Sprites\\RunHero");

            model = Idle;
        }

        public override void Update(GameTime gameTime)
        {
            var testcolbox = Globals._World.CheckCollisionSide(colBox);


            if (Keyboard.GetState().IsKeyDown(Keys.Q) && testcolbox.X > 0)
            {
                RunningAnimation();

                Rotation = SpriteEffects.FlipHorizontally;

                if (Globals._World.CheckCollision(colBox))
                {
                    velocity.X = testcolbox.X;
                }
                else
                {
                    velocity = new Vector2(position.X - Speed, position.Y);
                }

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                RunningAnimation();
                
                Rotation = SpriteEffects.None;

                if (Globals._World.CheckCollision(colBox) && testcolbox.X < 0)
                {
                    velocity.X = testcolbox.X;
                }
                else
                {
                    velocity = new Vector2(position.X + Speed, position.Y);
                }
            }

            if (Keyboard.GetState().IsKeyUp(Keys.D) && Keyboard.GetState().IsKeyUp(Keys.Q))
            {
                IdleAnimation();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.LeftControl))
            {
                Speed = 20;
            }
            else
            {
                Speed = 10;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.O))
            {
                Globals.Coinage++;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && HasJumped == false)
            {
                HasJumped = true;
                velocity = new Vector2(position.X, position.Y - Jumpforce);
            }

            if (HasJumped)
            {
                Jump();
            }

            if (Globals._World.CheckCollision(colBox) && testcolbox.Y < 0)
            {
                velocity.Y = testcolbox.Y;
            }

            base.Update(gameTime);
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
            if (JumpFlag)
            {
                StartPos.Y = position.Y;
            }

            JumpFlag = false;     

            if (position.Y >= StartPos.Y)
            {
                position.Y = StartPos.Y;
                HasJumped = false;
                JumpFlag = true;
            }
        }
    }
}
