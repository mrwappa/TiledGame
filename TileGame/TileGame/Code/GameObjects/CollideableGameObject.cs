using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TileGame.Code.GameObjects
{
    abstract class CollideableGameObject : GameObject
    {
        public static Dictionary<Type, List<CollideableGameObject>> CollisionList = new Dictionary<Type, List<CollideableGameObject>>();

        public Rectangle BoundingBox { get; private set; }

        public float BoxX { get; protected set; }
        public float BoxY { get; protected set; }
        public int BoxWidth { get; protected set; }
        public int BoxHeight { get; protected set; }

        public Vector2 BoxPosition => new Vector2(BoxX, BoxY);


        public bool Collision { get; set; }

        public Texture2D Pixel { get; set; }

        public CollideableGameObject(float x, float y) : base(x,y)
        {
            X = x;
            Y = y;
        }

        public Matrix Transform
        {
            get
            {
                return Matrix.CreateTranslation(new Vector3(-new Vector2(BoxWidth / 2, BoxHeight / 2), 0.0f)) *
                                        Matrix.CreateScale(BoxWidth, BoxHeight, 1.0f) * 
                                        Matrix.CreateRotationZ(Rotation) *
                                        Matrix.CreateTranslation(new Vector3(new Vector2(BoxX, BoxY), 0.0f));
            }
        }

        List<GameObject> list;

        public CollideableGameObject BoxCollision(int ExtraX, int ExtraY, Type type)
        {
            if (SuperList.TryGetValue(type, out list) && list.Count != 0)
            {
                foreach (CollideableGameObject obj in list)
                {
                    if (obj == this)
                    {
                        continue;
                    }
                    if (BoxX + ExtraX + BoxWidth > obj.BoxX && BoxX - ExtraX * Math.Sign(ExtraX) < obj.BoxX + obj.BoxWidth &&
                        BoxY + ExtraY + BoxHeight > obj.BoxY && BoxY - ExtraY * Math.Sign(ExtraY) < obj.BoxY + obj.BoxHeight)
                    {
                        obj.Collision = true;
                        return obj;
                    }
                }
            }
            return null;
        }

        List<CollideableGameObject> cList;

        public void AddCollidableInstance(CollideableGameObject gameObject, Type type)
        {
            if (!CollisionList.ContainsKey(type))
            {
                CollisionList.Add(type, new List<CollideableGameObject>());
            }
            CollisionList.TryGetValue(type, out cList);
            cList.Add(gameObject);
        }

        public CollideableGameObject BoxCollisionList(float ExtraX, float ExtraY, Type type)
        {
            if (CollisionList.TryGetValue(type, out cList) && cList.Count != 0)
            {
                foreach (CollideableGameObject obj in cList)
                {
                    if (obj == this)
                    {
                        continue;
                    }
                    if (BoxX + ExtraX + BoxWidth > obj.BoxX && BoxX - ExtraX * Math.Sign(ExtraX) < obj.BoxX + obj.BoxWidth &&
                        BoxY + ExtraY + BoxHeight > obj.BoxY && BoxY - ExtraY * Math.Sign(ExtraY) < obj.BoxY + obj.BoxHeight)
                    {
                        obj.Collision = true;
                        return obj;
                    }
                }
            }
            return null;
        }

        public bool BoxRotateCollision(Type type)
        {
            if (SuperList.TryGetValue(type, out list) && list.Count != 0)
            {
                foreach (CollideableGameObject obj in list)
                {
                    if (obj == this)
                    {
                        continue;
                    }
                    if( CheckEdges(this, obj))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ObjectPosition(float x, float y, Type type)
        {
            if (SuperList.TryGetValue(type, out list) && list.Count != 0)
            {
                foreach (CollideableGameObject obj in list)
                {
                    if(obj.X == x && obj.Y == y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        bool CheckEdges(CollideableGameObject t , CollideableGameObject o)
        {
            //This whole operation of checking edges is expensive and therefore we make sure
            //that the box is actually within the possible viscinity of collision
            
            //BoundingPoints This
            Vector2 TBottomRight = t.BoxPosition + new Vector2(t.BoxWidth,t.BoxHeight);
            Vector2 TBottomLeft = t.BoxPosition + new Vector2(0, t.BoxHeight);
            Vector2 TTopLeft = t.BoxPosition + new Vector2(0, 0);
            Vector2 TTopRight =  t.BoxPosition + new Vector2(t.BoxWidth, 0);

            //BoundingPoints Other
            Vector2 OBottomRight = o.BoxPosition + new Vector2(o.BoxWidth, o.BoxHeight);
            Vector2 OBottomLeft = o.BoxPosition + new Vector2(0, o.BoxHeight);
            Vector2 OTopLeft = o.BoxPosition + new Vector2(0, 0);
            Vector2 OTopRight = o.BoxPosition + new Vector2(o.BoxWidth, 0);

            //RotatePoints This
            TBottomRight = Rotate(t.BoxX + t.BoxWidth /2, t.BoxY + t.BoxHeight /2,t.Rotation,TBottomRight + new Vector2(-0.5f, -0.5f));
            TBottomLeft = Rotate(t.BoxX + t.BoxWidth / 2, t.BoxY + t.BoxHeight / 2, t.Rotation, TBottomLeft + new Vector2(0.5f, -0.5f));
            TTopLeft = Rotate(t.BoxX + t.BoxWidth / 2, t.BoxY + t.BoxHeight / 2, t.Rotation, TTopLeft + new Vector2(0.5f, 0.5f));
            TTopRight = Rotate(t.BoxX + t.BoxWidth / 2, t.BoxY + t.BoxHeight / 2, t.Rotation, TTopRight + new Vector2(-0.5f, 0.5f));

            //RotatePoints Other
            OBottomRight = Rotate(o.BoxX + o.BoxWidth / 2, o.BoxY + o.BoxHeight / 2, o.Rotation, OBottomRight + new Vector2(-0.5f, -0.5f));
            OBottomLeft = Rotate(o.BoxX + o.BoxWidth / 2, o.BoxY + o.BoxHeight / 2, o.Rotation, OBottomLeft + new Vector2(0.5f, -0.5f));
            OTopLeft = Rotate(o.BoxX + o.BoxWidth / 2, o.BoxY + o.BoxHeight / 2, o.Rotation, OTopLeft + new Vector2(0.5f, 0.5f));
            OTopRight = Rotate(o.BoxX + o.BoxWidth / 2, o.BoxY + o.BoxHeight / 2, o.Rotation, OTopRight + new Vector2(-0.5f, 0.5f));

            Vector2[] TRectangleEdges = new Vector2[4];
            Vector2[] ORectangleEdges = new Vector2[4];

            Vector2[] TRectangleDiagonals = new Vector2[4];
            Vector2[] ORectangleDiagonals = new Vector2[4];

            TRectangleEdges[0] = TBottomRight;
            TRectangleEdges[1] = TBottomLeft;
            TRectangleEdges[2] = TTopLeft;
            TRectangleEdges[3] = TTopRight;

            ORectangleEdges[0] = OBottomRight;
            ORectangleEdges[1] = OBottomLeft;
            ORectangleEdges[2] = OTopLeft;
            ORectangleEdges[3] = OTopRight;

            TRectangleDiagonals[0] = TTopLeft;
            TRectangleDiagonals[1] = TBottomRight;
            TRectangleDiagonals[2] = TBottomLeft;
            TRectangleDiagonals[3] = TTopRight;

            ORectangleDiagonals[0] = OTopLeft;
            ORectangleDiagonals[1] = OBottomRight;
            ORectangleDiagonals[2] = OBottomLeft;
            ORectangleDiagonals[3] = OTopRight;

            //Check Intersection for rectangle edges
            for (int i = 0; i < TRectangleEdges.Length; i++)
            {
                for (int j = 0; j < ORectangleEdges.Length; j++)
                {
                    if (LineIntersection(TRectangleEdges[i], TRectangleEdges[(i + 1) % TRectangleEdges.Length], ORectangleEdges[j], ORectangleEdges[(j + 1) % ORectangleEdges.Length]))
                        return true;
                }
            }

            //Check Intersection for internal diagonal lines
            for (int i = 0; i < TRectangleDiagonals.Length; i++)
            {
                for (int j = 0; j < ORectangleDiagonals.Length; j++)
                {
                    if (LineIntersection(TRectangleDiagonals[i], TRectangleDiagonals[(i + 1) % TRectangleDiagonals.Length], ORectangleDiagonals[j], ORectangleDiagonals[(j + 1) % ORectangleDiagonals.Length]))
                        return true;
                }
            }

            return false;
        }

        

        public override void Init()
        {
            base.Init();
            Pixel = TextureAssets.Pixel;

            BoxX = X - (ScaledWidth / 2);
            BoxY = Y - (ScaledHeight / 2);
            BoxWidth = (int)ScaledHeight;
            BoxHeight = (int)ScaledWidth;
            BoundingBox = new Rectangle((int)BoxX, (int)BoxY, BoxWidth, BoxHeight);

        }

        public override void Update()
        {
            base.Update();
        }

        public override void EndUpdate()
        {
            BoundingBox = new Rectangle((int)BoxX, (int)BoxY, BoxWidth, BoxHeight);
            base.EndUpdate();
            Collision = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //Draw BoundingBox
           /* spriteBatch.Draw(Pixel, new Vector2(BoundingBox.X + BoundingBox.Width/2, BoundingBox.Y + BoundingBox.Height/2), null, Color.Black * 0.4f, Rotation, new Vector2(0.5f, 0.5f), 
                new Vector2(BoundingBox.Width, BoundingBox.Height), SpriteEffects.None, Depth + 1);*/
                
            //Draw Object Texture
            base.Draw(spriteBatch);
        }
        
        public bool LineIntersection(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4)
        {
            bool isIntersecting = false;
            

            float denominator = (p4.Y - p3.Y) * (p2.X - p1.X) - (p4.X - p3.X) * (p2.Y - p1.Y);

            //Make sure the denominator is > 0, if so the lines are parallel
            if (denominator != 0)
            {
                float u_a = ((p4.X - p3.X) * (p1.Y - p3.Y) - (p4.Y - p3.Y) * (p1.X - p3.X)) / denominator;
                float u_b = ((p2.X - p1.X) * (p1.Y - p3.Y) - (p2.Y - p1.Y) * (p1.X - p3.X)) / denominator;

                //Is intersecting if u_a and u_b are between 0 and 1
                if (u_a >= 0 && u_a <= 1 && u_b >= 0 && u_b <= 1)
                {
                    isIntersecting = true;
                }
            }

            return isIntersecting;
        }

        public Vector2 Rotate(float cx, float cy, float angle, Vector2 point)
        {
            return new Vector2((float)Math.Cos(angle) * (point.X - cx) - (float)Math.Sin(angle) * (point.Y - cy) + cx,
                               (float)Math.Sin(angle) * (point.X - cx) + (float)Math.Cos(angle) * (point.Y - cy) + cy);
        }
    }
}
