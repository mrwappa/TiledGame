using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGame.Code
{
    static class TextureAssets
    {
        public static GraphicsDevice GraphicsDevice;

        public static Texture2D[] PlayerSprite { get; private set; }
        public enum PlayerSPRIndex { Back, Back_left, Back_right, Front, Front_left, Front_right, Left, Right }
        public static Texture2D PlayerAttack { get; set; }
        
        public static Texture2D Pixel { get; private set; }
        public static Texture2D Circle { get; private set; }

        public static Texture2D Dust { get; private set; }
        
        public static Texture2D BlockBLANK0 { get; private set; }
        public static Texture2D BlockBLANK1 { get; private set; }
        public static Texture2D BlockBLANK2 { get; private set; }
        public static Texture2D BlockBLANK3 { get; private set; }
        public static Texture2D BlockL { get; private set; }
        public static Texture2D BlockR { get; private set; }
        public static Texture2D BlockD { get; private set; }
        public static Texture2D BlockDL { get; private set; }
        public static Texture2D BlockDR { get; private set; }
        public static Texture2D BlockU { get; private set; }
        public static Texture2D BlockUL { get; private set; }
        public static Texture2D BlockUR { get; private set; }
        public static Texture2D BlockDD { get; private set; }

        public static Texture2D GrassBLANK { get; private set; }
        public static Texture2D GrassFILLED { get; private set; }
        public static Texture2D GrassL { get; private set; }
        public static Texture2D GrassR { get; private set; }
        public static Texture2D GrassD { get; private set; }
        public static Texture2D GrassDL { get; private set; }
        public static Texture2D GrassDR { get; private set; }
        public static Texture2D GrassU { get; private set; }
        public static Texture2D GrassUL { get; private set; }
        public static Texture2D GrassUR { get; private set; }
        public static Texture2D GrassUDR { get; private set; }
        public static Texture2D GrassUDL { get; private set; }

        public static Texture2D WallL { get; private set; }
        public static Texture2D WallLD { get; private set; }
        public static Texture2D WallM { get; private set; }
        public static Texture2D WallMD { get; private set; }
        public static Texture2D WallR { get; private set; }
        public static Texture2D WallRD { get; private set; }

        public static Texture2D PillarL { get; private set; }
        public static Texture2D PillarM { get; private set; }
        public static Texture2D PillarR { get; private set; }

        public static Texture2D BoxTest { get; private set; }
        public static Texture2D LineTest { get; private set; }

        public static void LoadTextures() 
        {
            Pixel = LoadTexture("Assets/Sprites/spr_pixel.png");

            PlayerSprite = new Texture2D[8];
            PlayerSprite[(int)PlayerSPRIndex.Back] = LoadTexture("Assets/Sprites/Player/spr_player_back.png");
            PlayerSprite[(int)PlayerSPRIndex.Back_left] = LoadTexture("Assets/Sprites/Player/spr_player_back_left.png");
            PlayerSprite[(int)PlayerSPRIndex.Back_right] = LoadTexture("Assets/Sprites/Player/spr_player_back_right.png");
            PlayerSprite[(int)PlayerSPRIndex.Front] = LoadTexture("Assets/Sprites/Player/spr_player_front.png");
            PlayerSprite[(int)PlayerSPRIndex.Front_left] = LoadTexture("Assets/Sprites/Player/spr_player_front_left.png");
            PlayerSprite[(int)PlayerSPRIndex.Front_right] = LoadTexture("Assets/Sprites/Player/spr_player_front_right.png");
            PlayerSprite[(int)PlayerSPRIndex.Left] = LoadTexture("Assets/Sprites/Player/spr_player_left.png");
            PlayerSprite[(int)PlayerSPRIndex.Right] = LoadTexture("Assets/Sprites/Player/spr_player_right.png");

            PlayerAttack = LoadTexture("Assets/Sprites/Player/spr_playerattack.png");
            
            BlockBLANK0 = LoadTexture("Assets/Sprites/Blocks/Dirt/spr_blockBLANK0.png");
            BlockBLANK1 = LoadTexture("Assets/Sprites/Blocks/Dirt/spr_blockBLANK1.png");
            BlockBLANK2 = LoadTexture("Assets/Sprites/Blocks/Dirt/spr_blockBLANK2.png");
            BlockBLANK3 = LoadTexture("Assets/Sprites/Blocks/Dirt/spr_blockBLANK3.png");
            //BlockD = LoadTexture("Assets/Sprites/Blocks/Dirt/spr_blockD.png");
            BlockL = LoadTexture("Assets/Sprites/Blocks/Dirt/spr_blockL.png");
            BlockR = LoadTexture("Assets/Sprites/Blocks/Dirt/spr_blockR.png");
            //BlockDL = LoadTexture("Assets/Sprites/Blocks/Dirt/spr_blockDL.png");
            //BlockDR = LoadTexture("Assets/Sprites/Blocks/Dirt/spr_blockDR.png");
            BlockU = LoadTexture("Assets/Sprites/Blocks/Dirt/spr_blockU.png");
            BlockUL = LoadTexture("Assets/Sprites/Blocks/Dirt/spr_blockUL.png");
            BlockUR = LoadTexture("Assets/Sprites/Blocks/Dirt/spr_blockUR.png");

            BlockDD = LoadTexture("Assets/Sprites/Blocks/Dirt/spr_blockDD.png");

            GrassBLANK = LoadTexture("Assets/Sprites/Blocks/Grass/spr_grassBLANK.png");
            GrassFILLED = LoadTexture("Assets/Sprites/Blocks/Grass/spr_grassFILLED.png");
            GrassD = LoadTexture("Assets/Sprites/Blocks/Grass/spr_grassD.png");
            GrassDL = LoadTexture("Assets/Sprites/Blocks/Grass/spr_grassDL.png");
            GrassDR = LoadTexture("Assets/Sprites/Blocks/Grass/spr_grassDR.png");
            GrassL = LoadTexture("Assets/Sprites/Blocks/Grass/spr_grassL.png");
            GrassR = LoadTexture("Assets/Sprites/Blocks/Grass/spr_grassR.png");
            GrassU = LoadTexture("Assets/Sprites/Blocks/Grass/spr_grassU.png");
            GrassUL = LoadTexture("Assets/Sprites/Blocks/Grass/spr_grassUL.png");
            GrassUR = LoadTexture("Assets/Sprites/Blocks/Grass/spr_grassUR.png");
            GrassUDL = LoadTexture("Assets/Sprites/Blocks/Grass/spr_grassUDL.png");
            GrassUDR = LoadTexture("Assets/Sprites/Blocks/Grass/spr_grassUDR.png");

            WallL = LoadTexture("Assets/Sprites/Blocks/Grass/spr_wallL.png");
            WallLD = LoadTexture("Assets/Sprites/Blocks/Grass/spr_wallLD.png");
            WallM = LoadTexture("Assets/Sprites/Blocks/Grass/spr_wallM.png");
            WallMD = LoadTexture("Assets/Sprites/Blocks/Grass/spr_wallMD.png");
            WallR = LoadTexture("Assets/Sprites/Blocks/Grass/spr_wallR.png");
            WallRD = LoadTexture("Assets/Sprites/Blocks/Grass/spr_wallRD.png");

            PillarL = LoadTexture("Assets/Sprites/Blocks/Grass/spr_pillarL.png");
            PillarM = LoadTexture("Assets/Sprites/Blocks/Grass/spr_pillarM.png");
            PillarR = LoadTexture("Assets/Sprites/Blocks/Grass/spr_pillarR.png");

            Circle = LoadTexture("Assets/Sprites/Player/spr_circle.png");

            Dust = LoadTexture("Assets/Sprites/spr_dust.png");

            BoxTest = LoadTexture("Assets/Sprites/spr_boxtest.png");

            LineTest = LoadTexture("Assets/Sprites/spr_linetest.png");
        }

        public static Texture2D LoadTexture(string path)
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
