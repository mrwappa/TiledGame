using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace TileGame.Code.GameObjects.Solids
{
    class Ground : Solid
    {
        public Ground(int x, int y,  Texture2D texture) : base(x, y)
        {
            Texture = texture;
            X = x;
            Y = y;
            Init();
        }

        void setCollisionBoundary()
        {
            if(Texture == TextureAssets.BlockDD)
            {
                BoxX = X - ((int)ScaledWidth / 2);
                BoxY = Y - ((int)ScaledHeight / 2) - 6;
                BoxWidth = (int)ScaledWidth;
                BoxHeight = (int)ScaledHeight / 8;
            }
            /*if(Texture == TextureAssets.BlockD || Texture == TextureAssets.BlockDL || Texture == TextureAssets.BlockDR)
            {
                BoxX = X - ((int)ScaledWidth / 2);
                BoxY = Y - ((int)ScaledHeight / 2) - 12;
                BoxWidth = (int)ScaledWidth;
                BoxHeight = (int)ScaledHeight / 8;
            }*/
            if(Texture == TextureAssets.BlockL || Texture == TextureAssets.BlockUL || Texture == TextureAssets.BlockUL)
            {
                BoxX = X - ((int)ScaledWidth / 2) - 4;
                BoxY = Y - ((int)ScaledHeight / 2);
                BoxWidth = (int)ScaledWidth / 8;
                BoxHeight = (int)ScaledHeight;
            }
            if (Texture == TextureAssets.BlockU)
            {
                BoxX = X - ((int)ScaledWidth / 2)  - 20;
                BoxY = Y - ((int)ScaledHeight / 2) - 14;
                BoxWidth = (int)ScaledWidth + 50;
                BoxHeight = (int)ScaledHeight / 8;
            }
            if(Texture == TextureAssets.BlockR)
            {
                BoxX = X - ((int)ScaledWidth / 2) + 32;
                BoxY = Y - ((int)ScaledHeight / 2);
                BoxWidth = (int)ScaledWidth / 8;
                BoxHeight = (int)ScaledHeight;
            }
            if(Texture == TextureAssets.BlockUR)
            {
                BoxX = X - ((int)ScaledWidth / 2) + 31;
                BoxY = Y - ((int)ScaledHeight / 2);
                BoxWidth = (int)ScaledWidth / 8;
                BoxHeight = (int)ScaledHeight;
            }
            ///
            ////////
            ///
            if (Texture == TextureAssets.GrassD || Texture == TextureAssets.GrassDL || Texture == TextureAssets.GrassDR)
            {
                BoxX = X - ((int)ScaledWidth / 2);
                BoxY = Y - ((int)ScaledHeight / 2) + 8;
                BoxWidth = (int)ScaledWidth;
                BoxHeight = (int)ScaledHeight / 8;
            }
            if (Texture == TextureAssets.GrassL || Texture == TextureAssets.GrassUL || Texture == TextureAssets.GrassUL)
            {
                BoxX = X - ((int)ScaledWidth / 2) - 4;
                BoxY = Y - ((int)ScaledHeight / 2);
                BoxWidth = (int)ScaledWidth / 8;
                BoxHeight = (int)ScaledHeight;
            }
            if (Texture == TextureAssets.GrassU)
            {
                BoxX = X - ((int)ScaledWidth / 2) - 20;
                BoxY = Y - ((int)ScaledHeight / 2) - 14;
                BoxWidth = (int)ScaledWidth + 50;
                BoxHeight = (int)ScaledHeight / 8;
            }
            if (Texture == TextureAssets.GrassR)
            {
                BoxX = X - ((int)ScaledWidth / 2) + 31;
                BoxY = Y - ((int)ScaledHeight / 2);
                BoxWidth = (int)ScaledWidth / 8;
                BoxHeight = (int)ScaledHeight;
            }
            if (Texture == TextureAssets.GrassUR)
            {
                BoxX = X - ((int)ScaledWidth / 2) + 31;
                BoxY = Y - ((int)ScaledHeight / 2);
                BoxWidth = (int)ScaledWidth / 8;
                BoxHeight = (int)ScaledHeight;
            }
        }

        public override void Init()
        {
            
            //Texture = TextureAssets.SBlock;
            numberOfFrames = 1;
            ScaleX = 2f;
            ScaleY = 2f;
            base.Init();

            BoxX = 0;
            BoxY = 0;
            BoxWidth = 0;
            BoxHeight = 0;
            Depth = Y - 128;
            setCollisionBoundary();

        }

        public override void EndUpdate()
        {
            base.EndUpdate();
        }

    }
}
