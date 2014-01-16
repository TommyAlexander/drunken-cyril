﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using MyGame.Utils;
using MyGame.DrawingUtils;
namespace MyGame.GameStateObjects.Ships
{
    public class NPCShip : Ship
    {
        Gun gun;
        public NPCShip(GameState gameState, Vector2 position)
            : base(gameState, position, new Drawable(Textures.Enemy, position, Color.White, 0, new Vector2(30, 25), 1))
        {
            gun = new Gun(gameState, this, new Vector2(70, 0), 0);
        }

        protected override void UpdateSubclass(GameTime gameTime)
        {
            if (this.flyingStrategy == null)
            {
                PlayerShip player = GameState.GetPlayerShip();
                if (player != null)
                {
                    this.flyingStrategy = new NPCBasicAttackStrategy(this, player);
                }
            }
            else
            {
                this.flyingStrategy.ExecuteStrategy(gameTime);
            }
            base.UpdateSubclass(gameTime);
        }

        public void Reload()
        {
            gun.Ammo = 4;
        }

        public void FireCoaxialWeapon()
        {
            gun.Fire();
        }


        public override Boolean IsNPCShip
        {
            get { return true; }
        }

        FlyingStrategy flyingStrategy;
    }
}
