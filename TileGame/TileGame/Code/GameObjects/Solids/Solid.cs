using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGame.Code.GameObjects.Solids
{
    class Solid : CollideableGameObject
    {
        public Solid(float x, float y) : base(x, y)
        {
            X = x;
            Y = y;
            AddCollidableInstance(this, typeof(Solid));
        }

        public override void Init()
        {
            
            base.Init();
        }
    }
}
