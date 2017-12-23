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
    class EdgeCollision : CollideableGameObject
    {
        int speed;
        bool Form;
        public EdgeCollision(float x, float y, bool form) : base(x, y)
        {
            numberOfFrames = 1;
            Texture = TextureAssets.LineTest;
            speed = 1;
            Init();
            Form = form;
        }

        public override void Init()
        {
            ScaleX = 1;
            ScaleY = 1;
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

                if (Keyboard.IsKeyDown(Keys.M))
                {
                    Rotation += MathHelper.ToRadians(3);
                }
            }

            List<GameObject> list;
            if (SuperList.TryGetValue(typeof(EdgeCollision), out list))
            {
                foreach (CollideableGameObject obj in list)
                {
                    if (obj == this)
                    {
                        continue;
                    }
                    
                    Vector2 LineALeft = new Vector2(X - ScaledWidth /2, Y);
                    Vector2 LineARight = new Vector2(X + ScaledWidth /2, Y);
                    Vector2 LineBLeft = new Vector2(obj.X - obj.ScaledWidth /2,obj.Y );
                    Vector2 LineBRight = new Vector2(obj.X + obj.ScaledWidth /2, obj.Y );

                    LineALeft = Rotate(X, Y, Rotation, LineALeft);
                    LineARight = Rotate(X, Y, Rotation, LineARight);
                    LineBLeft = Rotate(obj.X, obj.Y, obj.Rotation, LineBLeft);
                    LineBRight = Rotate(obj.X, obj.Y, obj.Rotation, LineBRight);

                    if (LineIntersection(LineALeft, LineARight, LineBLeft, LineBRight))
                    {
                        Color = Color.Red;
                    }
                    else
                    {
                        Color = Color.White;
                    }
                }
            }
            base.Update();
        }



        public override void EndUpdate()
        {
            BoxX = (int)X - ((int)ScaledWidth / 2);
            BoxY = (int)Y - ((int)ScaledHeight / 2);
            BoxWidth = 0;
            BoxHeight = 0;
            base.EndUpdate();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 v1 = new Vector2(200, 400);
            Vector2 v2 = new Vector2(500, 400);
            Vector2 v3 = new Vector2(600, 401);
            Vector2 v4 = new Vector2(Camera.MouseX, Camera.MouseY);
            if (LineIntersection(/*new Vector2(X - ScaledWidth / 2, Y )*/v1, /*new Vector2(X + ScaledWidth / 2, Y )*/v2, v3, v4))
            {
                Color = Color.Red;
            }
            Game1.DrawLine(v1, v2, Color);
            Game1.DrawLine(v3, v4, Color);

            Vector2 left = new Vector2(X - ScaledWidth / 2, Y);
            Vector2 right = new Vector2(X + ScaledWidth / 2, Y);

            left = Rotate(X, Y, Rotation, left);
            right = Rotate(X, Y, Rotation, right);

            spriteBatch.Draw(TextureAssets.Pixel, new Vector2(X, Y), null, Color.Purple, Rotation, Vector2.Zero, new Vector2(1, 1),SpriteEffects.None , Depth + 1);
            spriteBatch.Draw(TextureAssets.Pixel, left, null, Color.Purple, Rotation, Vector2.Zero, new Vector2(1, 1), SpriteEffects.None, Depth + 1);
            spriteBatch.Draw(TextureAssets.Pixel, right, null, Color.Purple, Rotation, Vector2.Zero, new Vector2(1, 1), SpriteEffects.None, Depth + 1);
            base.Draw(spriteBatch);
        }

        
    }
}
