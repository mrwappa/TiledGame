using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGame.Code.GameObjects.Solids
{
    class Block : Solid
    {
        bool isGrass;
        bool checkAdjecent = true;

        bool up;
        bool down;
        bool right;
        bool left;
        public Block(float x, float y, bool grass) : base(x, y)
        {
            isGrass = grass;
            
            X = x;
            Y = y;
        }

        public override void Init()
        {
            numberOfFrames = 1;
            Texture = TextureAssets.GrassFILLED;
            ScaleX = 2f;
            ScaleY = 2f;
            base.Init();
            Depth = Y;
        }

        public override void Update()
        {
            
            if (checkAdjecent)
            {
                up = ObjectPosition(X, Y - 32, typeof(Block));
                down = ObjectPosition(X, Y + 32, typeof(Block));
                left = ObjectPosition(X - 32, Y, typeof(Block));
                right = ObjectPosition(X + 32, Y, typeof(Block));
                if (isGrass)
                {
                    if (up && !down && left && right)
                    {
                        Texture = TextureAssets.GrassD;
                    }
                    else if (up && !down && !left && right)
                    {
                        Texture = TextureAssets.GrassDL;
                    }
                    else if (up && !down && left && !right)
                    {
                        Texture = TextureAssets.GrassDR;
                    }
                    else if (up && down && !left && right)
                    {
                        Texture = TextureAssets.GrassL;
                    }
                    else if (up && down && left && !right)
                    {
                        Texture = TextureAssets.GrassR;
                    }
                    else if (!up && down && left && right)
                    {
                        Texture = TextureAssets.GrassU;
                    }
                    else if (!up && down && !left && right)
                    {
                        Texture = TextureAssets.GrassUL;
                    }
                    else if (!up && down && left && !right)
                    {
                        Texture = TextureAssets.GrassUR;
                    }
                    else if (!up && !down && left && !right)
                    {
                        Texture = TextureAssets.GrassUDR;
                    }
                    else if (!up && !down && !left && right)
                    {
                        Texture = TextureAssets.GrassUDL;
                    }
                    else if (up && down && left && right)
                    {
                        Texture = TextureAssets.GrassBLANK;
                    }
                    else if (!up && !down && !left && !right)
                    {
                        Texture = TextureAssets.GrassFILLED;
                    }
                }
                else
                {

                }
                checkAdjecent = false;
            }
            base.Update();
        }
    }
}
