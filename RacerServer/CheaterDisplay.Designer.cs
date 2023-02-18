namespace RacerServer
{
    partial class CheaterDisplay
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
            this.CheaterList = new System.Windows.Forms.ListView();
            this.Sensor = new System.Windows.Forms.ColumnHeader();
            this.Racer1 = new System.Windows.Forms.ColumnHeader();
            this.Racer2 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // CheaterDisplay
            // 
            this.CheaterList.AllowColumnReorder = true;
            this.CheaterList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Sensor,
            this.Racer1,
            this.Racer2});
            this.CheaterList.Location = new System.Drawing.Point(12, 12);
            this.CheaterList.Name = "CheaterDisplay";
            this.CheaterList.ShowItemToolTips = true;
            this.CheaterList.Size = new System.Drawing.Size(483, 497);
            this.CheaterList.TabIndex = 0;
            this.CheaterList.UseCompatibleStateImageBehavior = false;
            this.CheaterList.View = System.Windows.Forms.View.Details;
            // 
            // Sensor
            // 
            this.Sensor.Text = "Sensor";
            this.Sensor.Width = 100;
            // 
            // Racer1
            // 
            this.Racer1.Text = "Racer";
            this.Racer1.Width = 200;
            // 
            // Racer2
            // 
            this.Racer2.Text = "Racer 2";
            this.Racer2.Width = 200;
            // 
            // CheaterScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 521);
            this.Controls.Add(this.CheaterList);
            this.Name = "CheaterScreen";
            this.Text = "Cheater Screen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private ListView CheaterList;
        private ColumnHeader Sensor;
        private ColumnHeader Racer1;
        private ColumnHeader Racer2;
    }
}