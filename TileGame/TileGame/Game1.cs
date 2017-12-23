using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TileGame.Code;
using TileGame.Code.GameObjects;

namespace TileGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        private static SpriteBatch spriteBatch;

        MouseState mouse;
        KeyboardState keyboard;

        SpriteFont font;
        Random random;

        Room room;

        Camera camera;
        int monitorWidth;
        int monitorHeight;

        Color Background = new Color(41, 38, 52);
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            random = new Random();

            monitorWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            monitorHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.PreferredBackBufferWidth = monitorWidth;
            graphics.PreferredBackBufferHeight = monitorHeight;

            Window.Position = new Point(0, 0);
            graphics.SynchronizeWithVerticalRetrace = true;
            Window.IsBorderless = true;
            //graphics.IsFullScreen = true;
            IsMouseVisible = true;
            


        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            base.Initialize();

            

        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            TextureAssets.GraphicsDevice = GraphicsDevice;
            TextureAssets.LoadTextures();

            // TODO: use this.Content to load your game content here
            font = Content.Load<SpriteFont>("PixelFont");
            GameObject.InitGame(graphics, GraphicsDevice, random,font);

            room = new Room(2000, 2000);
            room.InitObjects();
            GameObject.CurrentRoom = room;

            camera = new Camera(monitorWidth, monitorHeight);
            GameObject.Camera = camera;

            
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            mouse = Mouse.GetState();
            keyboard = Keyboard.GetState();
            GameObject.Keyboard = keyboard;
            GameObject.Mouse = mouse;
            Camera.Mouse = mouse;

            foreach (KeyValuePair<Type, List<GameObject>> list in GameObject.SuperList.ToList())
            {
                foreach (GameObject obj in list.Value.ToList())
                {
                    obj.Update();
                }
            }

            foreach (KeyValuePair<Type, List<GameObject>> list in GameObject.SuperList.ToList())
            {
                foreach (GameObject obj in list.Value.ToList())
                {
                    obj.EndUpdate();
                }
            }
            GameObject.Previous_KeyboardState = keyboard;
            GameObject.Previous_MouseState = mouse;

            foreach (Alarm alarm in Alarm.Alarms)
            {
                alarm.Decrement();
            }

            camera.Update(new Vector2(Room.player.X, Room.player.Y), room);

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Background);
            
            //DRAW GAME OBJECTS
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend,SamplerState.PointClamp,null,null,null,camera.Transform);

            foreach (KeyValuePair<Type, List<GameObject>> list in GameObject.SuperList.ToList())
            {
                foreach (GameObject obj in list.Value.ToList())
                {
                    obj.Draw(spriteBatch);
                }
            }
            spriteBatch.End();

            //DRAW GUI ON GUI LAYER
            spriteBatch.Begin(SpriteSortMode.FrontToBack,
           BlendState.AlphaBlend,
           SamplerState.PointClamp, null, null, null, Matrix.CreateTranslation(new Vector3(0 - monitorWidth, 0 - monitorHeight, 0)) * Matrix.CreateRotationZ(0) * Matrix.CreateScale(new Vector3(1, 1, 0)) *
                Matrix.CreateTranslation(new Vector3(monitorWidth, monitorHeight, 0)));


            foreach (KeyValuePair<Type, List<GameObject>> list in GameObject.SuperList)
            {
                foreach (GameObject obj in list.Value)
                {
                    obj.DrawGUI(spriteBatch);
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public static void DrawLine(Vector2 start, Vector2 end, Color color)
        {
            Vector2 delta = end - start;
            spriteBatch.Draw(TextureAssets.Pixel, start, null, color, (float)Math.Atan2(delta.Y, delta.X), Vector2.UnitY * 0.5f, new Vector2(delta.Length(), 1.0f), SpriteEffects.None, 999999999999);
        }
        
    }
}
