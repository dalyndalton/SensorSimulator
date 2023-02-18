using SharedClasses;

namespace RacerServer
{
    partial class RacerDisplay 
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
            this.Display = new System.Windows.Forms.ListView();
            this.Name = new System.Windows.Forms.ColumnHeader();
            this.Group = new System.Windows.Forms.ColumnHeader();
            this.Position = new System.Windows.Forms.ColumnHeader();
            this.LastSeen = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // Display
            // 
            this.Display.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Name,
            this.Group,
            this.Position,
            this.LastSeen});
            this.Display.Location = new System.Drawing.Point(12, 35);
            this.Display.Name = "Display";
            this.Display.ShowGroups = false;
            this.Display.Size = new System.Drawing.Size(776, 403);
            this.Display.TabIndex = 0;
            this.Display.UseCompatibleStateImageBehavior = false;
            this.Display.View = System.Windows.Forms.View.Details;
            // 
            // Name
            // 
            this.Name.Text = "Name";
            this.Name.Width = 200;
            // 
            // Group
            // 
            this.Group.Text = "Group";
            this.Group.Width = 100;
            // 
            // Position
            // 
            this.Position.Text = "Position";
            this.Position.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LastSeen
            // 
            this.LastSeen.Text = "Total Time";
            this.LastSeen.Width = 100;
            // 
            // BigScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Display);
            this.Name = new ColumnHeader("BigScreen");
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BigScreen_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private ListView Display;
        private ColumnHeader Name;
        private ColumnHeader Group;
        private ColumnHeader Position;
        private ColumnHeader LastSeen;
    }
}