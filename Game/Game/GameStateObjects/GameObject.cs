﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MyGame.GameStateObjects
{
    public abstract class GameObject
    {

        static GameState localGameState = null;
        public static GameState LocalGameState
        {
            get { return localGameState; }
            set { localGameState = value; }
        }

        public GameObject()
        {
            if (localGameState == null)
            {
                throw new Exception("No Game State");
            }
            this.gameState = localGameState;
        }

        GameState gameState = null;

        public GameState GameState
        {
            get { return gameState; }
        }

        public GameObject(GameState gameState)
        {
            this.gameState = gameState;
        }

        protected abstract void UpdateSubclass(GameTime gameTime);

        public void Update(GameTime gameTime)
        {
            if (gameState != null)
            {
                this.UpdateSubclass(gameTime);
            }
        }

        public abstract void Draw(GameTime gameTime, DrawingUtils.MyGraphicsClass graphics);

        public virtual Boolean IsPhysicalObject
        {
            get { return false; }
        }
    }
}
