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
    class BoxRotationTest : CollideableGameObject
    {
        int speed;
        bool Form;
        public BoxRotationTest(float x, float y, bool form) : base(x, y)
        {
            Texture = TextureAssets.BoxTest;
            numberOfFrames = 1;
            Init();
            speed = 1;
            
            
            Form = form;
        }

        public override void Init()
        {
            ScaleX = 3;
            ScaleY = 3;
            Rotation = MathHelper.ToRadians(90);
            base.Init();
        }

        public override void Update()
        {
            Depth = Y;
            if (Form)
            {
                if (Keyboard.IsKeyDown(Keys.Up))
                {
                    Y -= speed;
                }
                if (Keyboard.IsKeyDown(Keys.Down))
                {
                    Y += speed;
                }
                if (Keyboard.IsKeyDown(Keys.Left))
                {
                    X -= speed;
                }
                if (Keyboard.IsKeyDown(Keys.Right))
                {
                    X += speed;
                }

                if (Keyboard.IsKeyDown(Keys.N))
                {
                    Rotation += MathHelper.ToRadians(3);
                }
            }
            else
            {
                
                if (Keyboard.IsKeyDown(Keys.I))
                {
                    Y -= speed;
                }
                if (Keyboard.IsKeyDown(Keys.K))
                {
                    Y += speed;
                }
                if (Keyboard.IsKeyDown(Keys.J))
                {
                    X -= speed;
                }
                if (Keyboard.IsKeyDown(Keys.L))
                {
                    X += speed;
                }

                if(Keyboard.IsKeyDown(Keys.M))
                {
                    Rotation += MathHelper.ToRadians(3);
                }
            }
            
            if(BoxRotateCollision(typeof(BoxRotationTest)))
            {
                Color = Color.Red;
            }
            else
            {
                Color = Color.White;
            }

            base.Update();
        }

        public override void EndUpdate()
        {
            BoxX = (int)X - ((int)ScaledWidth / 2);
            BoxY = (int)Y - ((int)ScaledHeight / 2);
            BoxWidth = (int)ScaledWidth;
            BoxHeight = (int)ScaledHeight;
            base.EndUpdate();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
