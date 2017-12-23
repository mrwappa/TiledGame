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
    abstract class GameObject
    {
        public static Dictionary<Type, List<GameObject>> SuperList = new Dictionary<Type, List<GameObject>>();

        public static void InitGame(GraphicsDeviceManager graphics, GraphicsDevice graphicsDevice, Random random, SpriteFont font)
        {
            Graphics = graphics;
            GraphicsDevice = graphicsDevice;
            Random = random;
            Font = font;
        }

        public static GraphicsDeviceManager Graphics;
        public static GraphicsDevice GraphicsDevice;
        public static SpriteFont Font;

        public static MouseState Mouse;
        public static MouseState Previous_MouseState;
        public static KeyboardState Keyboard;
        public static KeyboardState Previous_KeyboardState;
        
        public static Random Random;

        public static Room CurrentRoom;
        public static Camera Camera;

        public Texture2D Texture { get; protected set; }
        public float X { get; set; }
        public float Y { get; set; }
        

        public float Depth { get; set; }
        public Color Color { get; set; }
        public float Alpha { get; set; }
        public float Rotation { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }
        public float ScaleX { get; set; }
        public float ScaleY { get; set; }
        public bool FlipX { get; set; }
        public bool FlipY { get; set; }
        public float ScaledWidth { get; set; }
        public float ScaledHeight { get; set; }

        public int AnimationIndex { get; protected set; }
        public float AnimationSpeed { get; set; }

        protected int numberOfFrames { get; set; }
        protected float animationCounter { get; set; }

        public GameObject(float x, float y)
        {
            X = x;
            Y = y;
            AddInstance(this);
        }

        public virtual void Init()
        {
            
            Alpha = 1;
            Color = Color.White;
            Depth = 0.5f;
            Width = Texture.Width / numberOfFrames;
            Height = Texture.Height;

            ScaledWidth = Width * ScaleX;
            ScaledHeight = Height * ScaleY;
        }
        
        public virtual void Update()
        {

        }

        public virtual void EndUpdate()
        {
            ScaledWidth = Width * ScaleX;
            ScaledHeight = Height * ScaleY;
        }

        SpriteEffects flip = SpriteEffects.None;
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (FlipX == true && FlipY == false)
            {
                flip = SpriteEffects.FlipHorizontally;
            }
            else if (FlipY == true && FlipX == false)
            {
                flip = SpriteEffects.FlipVertically;
            }
            else if (FlipX == true && FlipY == true)
            {
                flip = SpriteEffects.FlipVertically | SpriteEffects.FlipHorizontally;
            }
            else
            {
                flip = SpriteEffects.None;
            }

            //Animation
            AnimationSpeed = MathHelper.Clamp(AnimationSpeed, 0, 1);
            if (AnimationSpeed > 0)
            {
                animationCounter += AnimationSpeed;
                if (animationCounter >= 1)
                {
                    AnimationIndex++;
                    animationCounter--;
                    if (AnimationIndex >= numberOfFrames)
                    {
                        AnimationIndex = 0;
                    }
                }
            }
            //Draw Sprite
            spriteBatch.Draw(Texture, new Vector2(X, Y), new Rectangle(AnimationIndex * Width, 0, Width, Height), Color * Alpha, Rotation,
               new Vector2((Width / 2), (Height / 2)), new Vector2(ScaleX, ScaleY), flip, Depth);
        }

        public virtual void DrawGUI(SpriteBatch spriteBatch)
        {

        }

        List<GameObject> list;
        public void AddInstance(GameObject gameObject)
        {
            Type type = gameObject.GetType();
            if (!SuperList.ContainsKey(type))
            {
                SuperList.Add(type, new List<GameObject>());
            }
            SuperList.TryGetValue(type, out list);
            list.Add(gameObject);
        }

        public void RemoveInstance(GameObject gameObject)
        {
            Type type = gameObject.GetType();
            SuperList.TryGetValue(type, out list);
            list.Remove(gameObject);
        }

        public void RestartGame()
        {
            foreach (KeyValuePair<Type, List<GameObject>> list in SuperList)
            {
                foreach (GameObject obj in list.Value.ToList())
                {
                    RemoveInstance(obj);
                }
            }
            foreach (KeyValuePair<Type, List<CollideableGameObject>> list in CollideableGameObject.CollisionList)
            {
                foreach (CollideableGameObject obj in list.Value.ToList())
                {
                    list.Value.Remove(obj);
                }
            }

            Camera.ReInit();
            CurrentRoom.InitObjects();
        }

        public bool GetKeyPressed(Keys key)
        {
            if(Keyboard.IsKeyDown(key) && Previous_KeyboardState.IsKeyUp(key))
            {
                return true;
            }
            return false;
        }

        public bool GetMousePressed(ButtonState state)
        {
            //detta är dumt, men det funkar och jag orkar inte fixa en optimisering
            if (state == Mouse.RightButton && Mouse.RightButton == ButtonState.Pressed && Previous_MouseState.RightButton == ButtonState.Released)
            {
                return true;
            }
            else if (state == Mouse.LeftButton && Mouse.LeftButton == ButtonState.Pressed && Previous_MouseState.LeftButton == ButtonState.Released)
            {
                return true;
            }
            else if (state == Mouse.MiddleButton && Mouse.MiddleButton == ButtonState.Pressed && Previous_MouseState.MiddleButton == ButtonState.Released)
            {
                return true;
            }
            return false;

        }

        public virtual GameObject GetObject(Type type)
        {
            SuperList.TryGetValue(type, out list);
            if(list.Count != 0)
            {
                return list[0];
            }
            return null;
        }
        
        protected Texture2D LoadTexture(string path)
        {
            //Load image and set it into bitmap
            System.Drawing.Bitmap img = new System.Drawing.Bitmap(path);
            //Create Color array with a dimensions dependent on the image
            Color[] data = new Color[img.Width * img.Height];

            //Set the color array to the colors of the image
            Vector2 pos = Vector2.Zero;
            for (int i = 0; i < data.Length; i++)
            {
                pos = new Vector2(i % img.Width, i / img.Width);
                data[i] = new Color(img.GetPixel((int)pos.X, (int)pos.Y).R,
                                    img.GetPixel((int)pos.X, (int)pos.Y).G,
                                    img.GetPixel((int)pos.X, (int)pos.Y).B,
                                    img.GetPixel((int)pos.X, (int)pos.Y).A);
            }
            //set our texture 
            Texture2D tex = new Texture2D(GraphicsDevice, img.Width, img.Height);
            tex.SetData(data);

            return tex;
        }
    }
}
