using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TileLevelEditor
{

    
    public partial class frmEditor : Form
    {
        private Tile[,] level;
        private Point offset = new Point(40, 40);

        private Color Brush = Color.Purple;


        public frmEditor()
        {
            InitializeComponent();
            level = new Tile[28, 22];

            for (int i = 0; i < level.GetLength(0); i++)
            {
                for (int j = 0; j < level.GetLength(1); j++)
                {
                    level[i, j] = new Tile();
                    level[i, j].BorderStyle = BorderStyle.FixedSingle;
                    level[i, j].Location = new Point(i * 32 + offset.X, j * 32 + offset.Y);
                    level[i, j].Size = new Size(32, 32);
                    level[i, j].MouseClick += new MouseEventHandler(this.TileClick);
                   
                    this.Controls.Add(level[i, j]);
                }
            }
        }

        private void TileClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                (sender as Tile).BackColor = Brush;
            }
            else if(e.Button == MouseButtons.Right)
            {
                (sender as Tile).BackColor = Color.Empty;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Data Files (*.map)|*.map";
            sfd.DefaultExt = "map";
            sfd.AddExtension = true;

            DialogResult s = sfd.ShowDialog();

            if(s == DialogResult.OK)
            {
                string data = "";

                for (int i = 0; i < level.GetLength(1); i++)
                {
                    for (int j = 0; j < level.GetLength(0); j++)
                    {
                        if (level[j, i].BackColor == Color.Purple)
                        {
                            data += "1";
                        }
                        else if (level[j, i].BackColor == Color.Green)
                        {
                            data += "2";
                        }
                        else if (level[j, i].BackColor == Color.Red)
                        {
                            data += "3";
                        }
                        else if(level[j, i].BackColor == Color.Blue)
                        {
                            data += "4";
                        }
                        else
                        {
                            data += "0";
                        }
                    }
                    data += "\n";
                }

                File.WriteAllText(sfd.FileName, data);
            }
            

        }

        private void btn_block_brush_Click(object sender, EventArgs e)
        {
            Brush = Color.Purple;
        }

        private void btn_enemy_tile_Click(object sender, EventArgs e)
        {
            Brush = Color.Red;
        }

        private void btn_player_tile_Click(object sender, EventArgs e)
        {
            Brush = Color.Green;
        }

        private void btn_wall_tile_Click(object sender, EventArgs e)
        {
            Brush = Color.Blue;
        }

        int sIndex;
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Data Files (*.map)|*.map";
            DialogResult o = ofd.ShowDialog();

            if (o == DialogResult.OK)
            {
                string s = File.ReadAllText(ofd.FileName);

                sIndex = 0;
                for (int i = 0; i < level.GetLength(1); i++)
                {
                    for (int j = 0; j < level.GetLength(0); j++)
                    {

                        if (s[sIndex] == '0')
                        {
                            level[j, i].BackColor = Color.Empty;
                        }
                        else if (s[sIndex] == '1')
                        {
                            level[j, i].BackColor = Color.Purple;
                        }
                        else if (s[sIndex] == '2')
                        {
                            level[j, i].BackColor = Color.Green;
                        }
                        else if (s[sIndex] == '3')
                        {
                            level[j, i].BackColor = Color.Red;
                        }
                        else if (s[sIndex] == '4')
                        {
                            level[j, i].BackColor = Color.Blue;
                        }
                        sIndex++;
                    }
                    sIndex++;
                }
            }
            
        }

        
    }
}
