using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGame.Code.GameObjects.Solids
{
    class Wall : Solid
    {
        bool isGrass = true;
        bool checkAdjecent = true;

        bool up;
        bool down;
        bool right;
        bool left;

        public Wall(float x, float y) : base(x, y)
        {
            X = x;
            Y = y;
        }

        public override void Init()
        {
            numberOfFrames = 1;
            Texture = TextureAssets.WallM;
            ScaleX = 2f;
            ScaleY = 2f;
            base.Init();
            Depth = Y;
        }

        public override void Update()
        {
            if (checkAdjecent)
            {
                up = ObjectPosition(X, Y - 32, typeof(Wall));
                down = ObjectPosition(X, Y + 32, typeof(Wall));
                left = ObjectPosition(X - 32, Y, typeof(Wall));
                right = ObjectPosition(X + 32, Y, typeof(Wall));
                if(isGrass)
                {
                    if(up && down && !left && right)
                    {
                        Texture = TextureAssets.WallL;
                    }
                    else if (up && !down && !left && right)
                    {
                        Texture = TextureAssets.WallLD;
                    }
                    else if (up && !down && left && right)
                    {
                        Texture = TextureAssets.WallMD;
                    }
                    else if (up && down && left && !right)
                    {
                        Texture = TextureAssets.WallR;
                    }
                    else if (up && !down && left && !right)
                    {
                        Texture = TextureAssets.WallRD;
                    }
                    else if (up && down && left && right)
                    {
                        Texture = TextureAssets.WallM;
                    }
                    else if (!up && !down && !left && !right)
                    {
                        Texture = TextureAssets.WallMD;
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
