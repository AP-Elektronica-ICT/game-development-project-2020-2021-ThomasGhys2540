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

namespace SwampLands
{
    class CollisionDetection
    {
        #region Variables
        private static float Offset = 30;
        #endregion

        #region Methods
        #region Is there a collision with platforms
        #region Left
        public Boolean HasCollidedLeft(string collidedwith)
        {
            switch (collidedwith)
            {
                case "platform":
                    foreach (Platform platform in Globals.WorldSystem.WorldObjects)
                    {
                        if (Globals.WorldSystem.PlayerCharacter.Hitbox.Intersects(platform.HitBox))
                        {
                            if (Globals.WorldSystem.PlayerCharacter.Hitbox.Top > platform.HitBox.Top - Offset &&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Bottom < platform.HitBox.Bottom + Offset &&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Left < platform.HitBox.Right &&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Right > platform.HitBox.Right)
                            {
                                return true;
                            }
                        }
                    }
                    break;
                default:
                    break;
            }

            return false;
        }
        #endregion

        #region Right
        public Boolean HasCollidedRight(string collidedwith)
        {
            switch (collidedwith)
            {
                case "platform":
                    foreach (Platform platform in Globals.WorldSystem.WorldObjects)
                    {
                        if (Globals.WorldSystem.PlayerCharacter.Hitbox.Intersects(platform.HitBox))
                        {
                            if (Globals.WorldSystem.PlayerCharacter.Hitbox.Top > platform.HitBox.Top - Offset &&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Bottom < platform.HitBox.Bottom + Offset &&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Left < platform.HitBox.Left &&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Right > platform.HitBox.Left)
                            {
                               return true;
                            }
                        }
                    }
                    break;
                default:
                    break;
            }

            return false;
        }
        #endregion

        #region Bottom
        public Boolean HasCollidedBottom(string collidedwith)
        {
            switch (collidedwith)
            {
                case "platform":
                    foreach (Platform platform in Globals.WorldSystem.WorldObjects)
                    {
                        if (Globals.WorldSystem.PlayerCharacter.Hitbox.Intersects(platform.HitBox))
                        {
                            if (Globals.WorldSystem.PlayerCharacter.Hitbox.Top < platform.HitBox.Top &&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Bottom > platform.HitBox.Top &&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Left > platform.HitBox.Left - Offset &&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Right < platform.HitBox.Right + Offset)
                            {
                               return true;
                            }
                        }
                    }
                    break;
                case "movingplatform":
                    foreach (MovingPlatform platform in Globals.WorldSystem.WorldMovingPlatforms)
                    {
                        if (Globals.WorldSystem.PlayerCharacter.Hitbox.Intersects(platform.Hitbox))
                        {
                            if (Globals.WorldSystem.PlayerCharacter.Hitbox.Top < platform.Hitbox.Top &&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Bottom > platform.Hitbox.Top &&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Left > platform.Hitbox.Left - Offset &&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Right < platform.Hitbox.Right + Offset)
                            {
                                return true;
                            }
                        }
                    }
                    break;
                default:
                    break;
            }

            return false;
        }
        #endregion

        #region Top
        public Boolean HasCollidedTop(string collidedwith)
        {
            switch (collidedwith)
            {
                case "platform":
                    foreach (Platform platform in Globals.WorldSystem.WorldObjects)
                    {
                        if (Globals.WorldSystem.PlayerCharacter.Hitbox.Intersects(platform.HitBox))
                        {
                            if (Globals.WorldSystem.PlayerCharacter.Hitbox.Top < platform.HitBox.Bottom &&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Bottom > platform.HitBox.Bottom &&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Left > platform.HitBox.Left - Offset &&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Right < platform.HitBox.Right + Offset)
                            {
                               return true;
                            }
                        }
                    }
                    break;
                default:
                    break;
            }

            return false;
        }
        #endregion
        #endregion

        #region Enemy Collision
        public static Boolean EnemyTopCollision(Rectangle enemyhitbox)
        {
            if (Globals.WorldSystem.PlayerCharacter.Hitbox.Top < enemyhitbox.Bottom &&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Bottom > enemyhitbox.Bottom &&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Left > enemyhitbox.Left - Offset&&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Right < enemyhitbox.Right + Offset)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #endregion
    }
}
