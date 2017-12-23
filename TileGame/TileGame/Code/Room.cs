using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TileGame.Code.GameObjects.Solids;
using TileGame.Code.GameObjects;


namespace TileGame.Code
{
    class Room
    {
        public static Player player;
        public int Width { get; set; }
        public int Height { get; set; }
        public Random Random;

        public Room(int width, int height)
        {
            Random = new Random();
            Width = width;
            Height = height;
        }

       
        int row = 0;
        int column = 0;
        int random = 0;
        int maxRows = 22 - 1;
        int maxColumns = 28 - 1;

        void grassBlock()
        {
            string s = File.ReadAllText("Assets/Maps/test1.map");
            for (int i = 0; i < s.Length; i++)
            {

                if (s[i] == '\n')
                {
                    row++;
                    column = 0;
                }
                else
                {
                    if (row == 0)
                    {
                        if (column == 0)
                        {
                            //blockUL
                            new Ground((i % 29) * 32, (i / 29) * 32, TextureAssets.GrassUL);
                        }
                        else if (column == 27)
                        {
                            //blockUR
                            new Ground((i % 29) * 32, (i / 29) * 32, TextureAssets.GrassUR);
                        }
                        else
                        {
                            //BlockU
                            new Ground((i % 29) * 32, (i / 29) * 32, TextureAssets.GrassU);
                        }
                    }
                    else if (row == maxRows)
                    {
                        if (column == 1)
                        {
                            //blockDL
                            new Ground((i % 29) * 32, (i / 29) * 32, TextureAssets.GrassDL);
                            new Ground((i % 29) * 32, (i / 29) * 32 + 48 + 16, TextureAssets.PillarL);
                        }
                        else if (column == 28)
                        {
                            //blockDR
                            new Ground((i % 29) * 32, (i / 29) * 32, TextureAssets.GrassDR);
                            new Ground((i % 29) * 32, (i / 29) * 32 + 48 + 16, TextureAssets.PillarR);
                        }
                        else
                        {
                            //BlockD
                            new Ground((i % 29) * 32, (i / 29) * 32, TextureAssets.GrassD);
                            new Ground((i % 29) * 32, (i / 29) * 32 + 48 + 16, TextureAssets.PillarM);
                        }
                    }
                    else if (column == 1 && row != 0 && row != maxRows)
                    {
                        //BlockL
                        new Ground((i % 29) * 32, (i / 29) * 32, TextureAssets.GrassL);
                    }
                    else if (column == maxColumns + 1 && row != 0 && row != maxRows)
                    {
                        //BlockR
                        new Ground((i % 29) * 32, (i / 29) * 32, TextureAssets.GrassR);
                    }
                    else
                    {
                        //blockBLANK
                        new Ground((i % 29) * 32, (i / 29) * 32, TextureAssets.GrassBLANK);
                    }
                }
                if (s[i] == '0')
                {
                    //blank
                }
                if (s[i] == '1')
                {
                    new Block((i % 29) * 32, (i / 29) * 32,true);
                }
                if (s[i] == '4')
                {
                    new Wall((i % 29) * 32, (i / 29) * 32);
                }
                if (s[i] == '2')
                {
                    player = new Player((i % 29) * 32, (i / 29) * 32);
                }

                column++;
            }
            row = 0;
            column = 0;
        }
        void dirtBlock()
        {
            string s = File.ReadAllText("Assets/Maps/test.map");
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '\n')
                {
                    row++;
                    column = 0;
                }
                if (s[i] == '0')
                {
                    if (row == 0)
                    {
                        if (column == 0)
                        {
                            //blockUL
                            new Ground((i % 29) * 32, (i / 29) * 32, TextureAssets.BlockUL);
                        }
                        else if (column == 27)
                        {
                            //blockUR
                            new Ground((i % 29) * 32, (i / 29) * 32, TextureAssets.BlockUR);
                        }
                        else
                        {
                            //BlockU
                            new Ground((i % 29) * 32, (i / 29) * 32, TextureAssets.BlockU);
                        }
                    }
                    else if (row == maxRows)
                    {
                        //BlockD
                        new Ground((i % 29) * 32, (i / 29) * 32, TextureAssets.BlockDD);
                    }
                    else if (column == 1 && row != 0 && row != maxRows)
                    {
                        //BlockL
                        new Ground((i % 29) * 32, (i / 29) * 32, TextureAssets.BlockL);

                    }
                    else if (column == maxColumns + 1 && row != 0 && row != maxRows)
                    {
                        //BlockR
                        new Ground((i % 29) * 32 - 1, (i / 29) * 32, TextureAssets.BlockR);
                    }
                    else
                    {
                        //random blockBLANK
                        random = Random.Next(0, 4);
                        if (random == 0)
                        {
                            new Ground((i % 29) * 32, (i / 29) * 32, TextureAssets.BlockBLANK0);
                        }
                        if (random == 1)
                        {
                            new Ground((i % 29) * 32, (i / 29) * 32, TextureAssets.BlockBLANK1);
                        }
                        if (random == 2)
                        {
                            new Ground((i % 29) * 32, (i / 29) * 32, TextureAssets.BlockBLANK2);
                        }
                        if (random == 3)
                        {
                            new Ground((i % 29) * 32, (i / 29) * 32, TextureAssets.BlockBLANK3);
                        }
                    }
                }
                if (s[i] == '1')
                {
                    
                }
                if(s[i] == '4')
                {

                }
                if (s[i] == '2')
                {
                    player = new Player((i % 29) * 32, (i / 29) * 32);
                    new Ground((i % 29) * 32, (i / 29) * 32, TextureAssets.BlockBLANK0);
                }
                column++;
            }
            row = 0;
            column = 0;
        }
        public void InitObjects()
        {
            /*random = Random.Next(0, 2);
            if(random == 1)
            {
                grassBlock();
            }
            else
            {
                dirtBlock();
            }*/
            grassBlock();
           

            foreach (KeyValuePair<Type, List<GameObject>> list in GameObject.SuperList)
            {
                foreach (GameObject obj in list.Value.ToList())
                {
                    obj.X += 800;
                    obj.Y += 800;
                    if(obj.GetType().BaseType == typeof(Solid))
                    {
                        obj.Init();
                    }
                }
            }

            /*for (int i = 0; i < 10000; i++)
            {
                new Ground(0, 0,);
            }*/
            /*player = new Player(100, 100);
            new Ground(200, 190);
            new Ground(240, 190);
            new Ground(280, 190);
            new Ground(360, 190);*/
        }

    }
}
