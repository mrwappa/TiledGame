namespace TileLevelEditor
{
    partial class frmEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_block_brush = new System.Windows.Forms.Button();
            this.btn_enemy_tile = new System.Windows.Forms.Button();
            this.btn_player_tile = new System.Windows.Forms.Button();
            this.btn_wall_tile = new System.Windows.Forms.Button();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(1043, 24);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // btn_block_brush
            // 
            this.btn_block_brush.Location = new System.Drawing.Point(969, 84);
            this.btn_block_brush.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_block_brush.Name = "btn_block_brush";
            this.btn_block_brush.Size = new System.Drawing.Size(65, 19);
            this.btn_block_brush.TabIndex = 1;
            this.btn_block_brush.Text = "Block Tile";
            this.btn_block_brush.UseVisualStyleBackColor = true;
            this.btn_block_brush.Click += new System.EventHandler(this.btn_block_brush_Click);
            // 
            // btn_enemy_tile
            // 
            this.btn_enemy_tile.Location = new System.Drawing.Point(969, 268);
            this.btn_enemy_tile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_enemy_tile.Name = "btn_enemy_tile";
            this.btn_enemy_tile.Size = new System.Drawing.Size(65, 19);
            this.btn_enemy_tile.TabIndex = 2;
            this.btn_enemy_tile.Text = "Enemy";
            this.btn_enemy_tile.UseVisualStyleBackColor = true;
            this.btn_enemy_tile.Click += new System.EventHandler(this.btn_enemy_tile_Click);
            // 
            // btn_player_tile
            // 
            this.btn_player_tile.Location = new System.Drawing.Point(969, 204);
            this.btn_player_tile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_player_tile.Name = "btn_player_tile";
            this.btn_player_tile.Size = new System.Drawing.Size(65, 19);
            this.btn_player_tile.TabIndex = 3;
            this.btn_player_tile.Text = "Player";
            this.btn_player_tile.UseVisualStyleBackColor = true;
            this.btn_player_tile.Click += new System.EventHandler(this.btn_player_tile_Click);
            // 
            // btn_wall_tile
            // 
            this.btn_wall_tile.Location = new System.Drawing.Point(969, 135);
            this.btn_wall_tile.Margin = new System.Windows.Forms.Padding(2);
            this.btn_wall_tile.Name = "btn_wall_tile";
            this.btn_wall_tile.Size = new System.Drawing.Size(65, 19);
            this.btn_wall_tile.TabIndex = 4;
            this.btn_wall_tile.Text = "Wall Tile";
            this.btn_wall_tile.UseVisualStyleBackColor = true;
            this.btn_wall_tile.Click += new System.EventHandler(this.btn_wall_tile_Click);
            // 
            // frmEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1043, 564);
            this.Controls.Add(this.btn_wall_tile);
            this.Controls.Add(this.btn_player_tile);
            this.Controls.Add(this.btn_enemy_tile);
            this.Controls.Add(this.btn_block_brush);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmEditor";
            this.Text = "Tile Level Editor";
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.Button btn_block_brush;
        private System.Windows.Forms.Button btn_enemy_tile;
        private System.Windows.Forms.Button btn_player_tile;
        private System.Windows.Forms.Button btn_wall_tile;
    }
}

