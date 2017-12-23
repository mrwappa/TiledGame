using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace TileGame.Code.GameObjects
{
    class Dust : GameObject
    {
        public Dust(float x, float y, float rotation) : base(x, y)
        {
            Texture = TextureAssets.Dust;
            numberOfFrames = 7;
            X = x;
            Y = y;
            base.Init();
            Alpha = 0.26f;
            Depth = Y - 50;
            AnimationSpeed = 0.2f;
            Rotation = rotation;
            ScaleX = 1;
            ScaleY = 1;
        }

        public override void Update()
        {
            
            base.Update();
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if(AnimationIndex == numberOfFrames - 1)
            {
                RemoveInstance(this);
            }
        }
    }
}
