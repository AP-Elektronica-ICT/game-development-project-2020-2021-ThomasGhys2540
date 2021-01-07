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
    class World
    {
        #region Variables
        public EndFlag Checkpoint;
        public List<Platform> WorldObjects;
        public List<MovingPlatform> WorldMovingPlatforms;
        public List<EnemyEntity> Enemies;
        public MainHero PlayerCharacter;
        #endregion

        #region Constructors
        public World(List<Platform> worldPlatforms, Vector2 checkpoint, List<MovingPlatform> movingPlatforms, List<EnemyEntity> enemies)
        {
            #region Instantiate World Variables
            WorldObjects = new List<Platform>();
            PlayerCharacter = new MainHero();
            WorldMovingPlatforms = new List<MovingPlatform>();
            Enemies = new List<EnemyEntity>();
            #endregion

            #region Create Platforms
            foreach(Platform platform in worldPlatforms)
            {
                WorldObjects.Add(platform);
            }

            foreach (MovingPlatform platform in movingPlatforms)
            {
                WorldMovingPlatforms.Add(platform);
            }

            foreach (EnemyEntity enemy in enemies)
            {
                Enemies.Add(enemy);
            }
            #endregion

            #region SetCheckpoint
            Checkpoint = new EndFlag((int)checkpoint.X, (int)checkpoint.Y);
            #endregion
        }
        #endregion

        #region Draw
        public virtual void Draw(GameTime gameTime)
        {
            DrawEnemies(gameTime);
            DrawWorldObjects(gameTime);
            PlayerCharacter.Draw(gameTime);
            Checkpoint.Draw(gameTime);
        }
        #endregion

        #region Update
        public virtual void Update(GameTime gameTime)
        {
            UpdateEnemies(gameTime);
            UpdateWorldObjects(gameTime);
            PlayerCharacter.Update(gameTime);
            Checkpoint.Update(gameTime);
        }
        #endregion

        #region Methods
        private void DrawEnemies(GameTime gameTime)
        {
            foreach (EnemyEntity enemy in Enemies)
            {
                enemy.Draw(gameTime);
            }
        }
        private void DrawWorldObjects(GameTime gameTime)
        {
            foreach (Platform platform in WorldObjects)
            {
                platform.Draw(gameTime);
            }

            foreach (MovingPlatform platform in WorldMovingPlatforms)
            {
                platform.Draw(gameTime);
            }
        }
        private void UpdateEnemies(GameTime gameTime)
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                if (CollisionDetection.EnemyTopCollision(Enemies[i].HitBox))
                {
                    Enemies.RemoveAt(i);
                }
                else if (!CollisionDetection.EnemyTopCollision(Enemies[i].HitBox) && Enemies[i].HitBox.Intersects(PlayerCharacter.Hitbox))
                {
                    Globals.ChangeGameState(new GameOverState(Globals.CurrentGameState.Main, Globals.CurrentGameState.Graphics));
                }
            }

            foreach (EnemyEntity enemy in Enemies)
            {
                enemy.Update(gameTime);
            }
        }
        private void UpdateWorldObjects(GameTime gameTime)
        {
            foreach (Platform platform in WorldObjects)
            {
                platform.Update(gameTime);
            }

            foreach (MovingPlatform platform in WorldMovingPlatforms)
            {
                platform.Update(gameTime);
            }
        }
        #endregion
    }
}
