using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGame.Code.GameObjects.Solids;


namespace TileGame.Code.GameObjects
{
    class Player : CollideableGameObject
    {
        public static int nrOfInstances = 1;

        bool W;
        bool S;
        bool A;
        bool D;

        float movement_speed;
        float axis_x_acceleration;
        float axis_y_acceleration;
        float axis_x_restitution;
        float axis_y_restitution;


        float axis_x;
        float axis_y;
        float axis_x_max;
        float axis_y_max;
        int axis_x_dir;
        int axis_y_dir;
        float axis_x_add;
        float axis_y_add;
        float axis_x_sub;
        float axis_y_sub;

        float look_angle;

        CollideableGameObject CollideBlock;

        public Player(float x, float y) : base(x, y)
        {
            Texture = TextureAssets.PlayerSprite[(int)TextureAssets.PlayerSPRIndex.Front];
            numberOfFrames = 3;
            Init();

            movement_speed = 4f;

            axis_x = 0f;
            axis_y = 0f;
            axis_y_max = movement_speed;
            axis_x_max = movement_speed;

            axis_x_acceleration = 1f;
            axis_y_acceleration = 1f;

            axis_x_restitution = 1f;
            axis_y_restitution = 1f;

            new BoxRotationTest(X + 40, Y + 40, true);
            new BoxRotationTest(X -40, Y + 40, false);
        }

        public override void Init()
        {
            ScaleX = 2;
            ScaleY = 2;
            AnimationSpeed = 0;
            base.Init();

            
        }

        void SpriteDirection(float angle)
        {
            if(angle < 25 && angle > 0 || angle > -25 && angle < 0)
            {

                Texture = TextureAssets.PlayerSprite[(int)TextureAssets.PlayerSPRIndex.Right];
            }
            if (angle < -25 && angle > -70)
            {
                Texture = TextureAssets.PlayerSprite[(int)TextureAssets.PlayerSPRIndex.Back_right];
            }
            if(angle < - 70 && angle > -115)
            {
                Texture = TextureAssets.PlayerSprite[(int)TextureAssets.PlayerSPRIndex.Back];
            }
            if(angle < -115 && angle > -160)
            {
                Texture = TextureAssets.PlayerSprite[(int)TextureAssets.PlayerSPRIndex.Back_left];
            }
            if(angle < -160 && angle > -180 || angle > 155 && angle < 180)
            {
                Texture = TextureAssets.PlayerSprite[(int)TextureAssets.PlayerSPRIndex.Left];
            }
            if(angle < 155 && angle > 110)
            {
                Texture = TextureAssets.PlayerSprite[(int)TextureAssets.PlayerSPRIndex.Front_left];
            }
            if(angle < 110 && angle > 65)
            {
                Texture = TextureAssets.PlayerSprite[(int)TextureAssets.PlayerSPRIndex.Front];
            }
            if (angle < 65 && angle > 25)
            {
                Texture = TextureAssets.PlayerSprite[(int)TextureAssets.PlayerSPRIndex.Front_right];
            }
        }

        public override void Update()
        {

            Depth = Y;
            //check keys
            W = Keyboard.IsKeyDown(Keys.W);
            S = Keyboard.IsKeyDown(Keys.S);
            A = Keyboard.IsKeyDown(Keys.A);
            D = Keyboard.IsKeyDown(Keys.D);

            //axes
            axis_x_dir = Convert.ToInt32(D) - Convert.ToInt32(A);
            axis_y_dir = Convert.ToInt32(S) - Convert.ToInt32(W);

            //acceleration
            axis_x_add = axis_x_dir * axis_x_acceleration;
            axis_y_add = axis_y_dir * axis_y_acceleration;

            //restitution
            axis_x_sub = MathHelper.Min(axis_x_restitution, Math.Abs(axis_x)) * Math.Sign(axis_x) * Convert.ToInt32(axis_x_dir == 0);//cause if statements are slow?
            axis_y_sub = MathHelper.Min(axis_y_restitution, Math.Abs(axis_y)) * Math.Sign(axis_y) * Convert.ToInt32(axis_y_dir == 0);

            axis_x = MathHelper.Clamp(axis_x + axis_x_add - axis_x_sub, -axis_x_max, axis_x_max);
            axis_y = MathHelper.Clamp(axis_y + axis_y_add - axis_y_sub, -axis_y_max, axis_y_max);

            //normalize axis_x and axis_y
            if (axis_x != 0 && axis_y != 0)
            {
                var dist = Math.Sqrt((axis_x * axis_x) + (axis_y * axis_y));
                var mdist = MathHelper.Min(movement_speed+1, (float)dist);
                axis_x = (axis_x / (float)dist) * (mdist);
                axis_y = (axis_y / (float)dist) * (mdist);
            }

            CollideBlock = BoxCollisionList((int)axis_x, 0, typeof(Solid));
            if(CollideBlock != null && CollideBlock.Collision)
            {
                if (X > CollideBlock.BoxX && axis_x < 0)
                {
                    axis_x = 0;
                    //prevents clipping into the solid object's collisonbox when moving diagonally
                    X = CollideBlock.BoxX + CollideBlock.BoxWidth + Math.Abs(X - BoxX);

                }

                if (X < CollideBlock.BoxX && axis_x > 0)
                {
                    axis_x = 0;
                    //prevents clipping into the solid object's collisonbox when moving diagonally
                    X = CollideBlock.BoxX + Math.Abs(X - BoxX) - BoxWidth;
                }
                
            }

            CollideBlock = BoxCollisionList(0, (int)axis_y, typeof(Solid));
            if (CollideBlock != null && CollideBlock.Collision)
            {
                if (Y > CollideBlock.BoxY && axis_y < 0)
                {
                    axis_y = 0;
                    Y = CollideBlock.BoxY + CollideBlock.BoxHeight + Math.Abs(Y - BoxY);
                }
                if (Y < CollideBlock.BoxY && axis_y > 0)
                {
                    axis_y = 0;
                    Y = CollideBlock.BoxY + Math.Abs(Y - BoxY) - BoxHeight;
                }
            }

            //move coordinates
            X += (int)axis_x;
            Y += (int)axis_y;

            if(axis_x != 0 || axis_y != 0)
            {
                AnimationSpeed = 0.12f;
            }
            else
            {
                AnimationIndex = (int)MathHelper.Lerp(AnimationIndex,0,0.2f);
                AnimationSpeed = 0;
            }

            look_angle = MathHelper.ToDegrees(G.PointDirection(X, Y, Camera.MouseX, Camera.MouseY));
            SpriteDirection(look_angle);

            /*if (Keyboard.IsKeyDown(Keys.Down))
            {
                Camera.Zoom -= 0.01f * Camera.Zoom;
            }
            if (Keyboard.IsKeyDown(Keys.Up))
            {
                Camera.Zoom += 0.01f * Camera.Zoom;
            }*/
            

            if(GetMousePressed(Mouse.LeftButton))
            {
                new PlayerAttack(X, Y);
            }

            if (GetKeyPressed(Keys.X))
            {
                new Player(X + 20, Y + 20);
                nrOfInstances++;
            }

            if (GetKeyPressed(Keys.Space))
            {
                Camera.ScreenShake += 8;
            }

            if (GetKeyPressed(Keys.R))
            {
                RestartGame();
            }

            
            if(AnimationIndex == numberOfFrames -1 && animationCounter < 0.1f)
            {
                new Dust(X, (int)(Y + ScaledWidth / 2), G.PointDirection(0,0,-axis_x,-axis_y) - MathHelper.ToRadians(90));
            }
            base.Update();
        }

        public override void EndUpdate()
        {
            X = MathHelper.Clamp(X, 0 + (int)ScaledWidth/2, CurrentRoom.Width - (int)ScaledWidth / 2);
            Y = MathHelper.Clamp(Y, 0 + (int)ScaledHeight/2, CurrentRoom.Height - (int)ScaledHeight / 2);
            BoxX = (int)X - ((int)ScaledWidth / 2) + 2;
            BoxY = (int)Y - ((int)ScaledHeight / 2) + 18;
            BoxWidth = (int)ScaledWidth - 4;
            BoxHeight = (int)ScaledHeight - 30;
            base.EndUpdate();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //Draw Shadow
            spriteBatch.Draw(TextureAssets.Circle, new Vector2(X, Y + 10*2), null, Color.Black * 0.6f, 0,
                new Vector2(TextureAssets.Circle.Width/2, TextureAssets.Circle.Height/2), new Vector2(0.8f*2, 0.6f*2), SpriteEffects.None, Depth - 1);

            base.Draw(spriteBatch);
        }

        public override void DrawGUI(SpriteBatch spriteBatch)
        {
             
            spriteBatch.DrawString(Font, Camera.MouseX.ToString() + " " + Camera.MouseY.ToString(), new Vector2(0, 0), Color.White);
            spriteBatch.DrawString(Font, nrOfInstances.ToString(), new Vector2(0, 80), Color.White);
            spriteBatch.DrawString(Font, new Vector2(X,Y).ToString(), new Vector2(0, 140), Color.White);
            spriteBatch.DrawString(Font, new Vector2(Camera.Center.X, Camera.Center.Y).ToString(), new Vector2(0, 220), Color.White);
            spriteBatch.DrawString(Font, new Vector2((int)axis_x, (int)axis_y).ToString(), new Vector2(0, 280), Color.White);
            spriteBatch.DrawString(Font, look_angle.ToString(), new Vector2(0, 360), Color.White);
            base.DrawGUI(spriteBatch);
        }
    }
}
