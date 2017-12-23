using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TileGame.Code.GameObjects
{
    class PlayerAttack : CollideableGameObject
    {
        public PlayerAttack(float x, float y) : base(x, y)
        {
            X = x;
            Y = y;
            numberOfFrames = 8;
            Texture = TextureAssets.PlayerAttack;
            Init();
        }

        public override void Init()
        {
            ScaleX = 2;
            ScaleY = 2;
            base.Init();
            AnimationSpeed = 0.6f;
            FlipY = Convert.ToBoolean(Random.Next(0, 2));
        }

        public override void Update()
        {
            if(AnimationIndex == numberOfFrames - 1)
            {
                RemoveInstance(this);
            }

            base.Update();
        }

        public override void EndUpdate()
        {
            Rotation = G.PointDirection(GetObject(typeof(Player)).X, GetObject(typeof(Player)).Y, Camera.MouseX, Camera.MouseY);
            X = GetObject(typeof(Player)).X + G.LengthDirX(20, Rotation);
            Y = GetObject(typeof(Player)).Y + G.LengthDirY(20, Rotation);

            if(BoxRotateCollision(typeof(BoxRotationTest)))
            {
                Color = Color.Black;
            }
            else
            {
                Color = new Color(134,20,8);
            }

            Depth = Y;
            BoxX = X - (ScaledWidth / 2) + 20 + G.LengthDirX(20,Rotation);
            BoxY = Y - (ScaledHeight / 2) + G.LengthDirY(20, Rotation);
            BoxWidth = (int)ScaledWidth - 40;
            BoxHeight = (int)ScaledHeight;
            base.EndUpdate();
        }
        
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
