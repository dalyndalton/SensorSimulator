namespace RacerServer
{
    partial class RaceMonitor
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
            this.RacerPool = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CurrentRacerPool = new System.Windows.Forms.ListView();
            this.listView3 = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.listView4 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // RacerPool
            // 
            this.RacerPool.Location = new System.Drawing.Point(548, 47);
            this.RacerPool.Name = "RacerPool";
            this.RacerPool.Size = new System.Drawing.Size(193, 419);
            this.RacerPool.TabIndex = 0;
            this.RacerPool.UseCompatibleStateImageBehavior = false;
            this.RacerPool.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(548, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Available Racers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Current Racers";
            // 
            // CurrentRacerPool
            // 
            this.CurrentRacerPool.Location = new System.Drawing.Point(289, 47);
            this.CurrentRacerPool.Name = "CurrentRacerPool";
            this.CurrentRacerPool.Size = new System.Drawing.Size(193, 419);
            this.CurrentRacerPool.TabIndex = 2;
            this.CurrentRacerPool.UseCompatibleStateImageBehavior = false;
            this.CurrentRacerPool.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // listView3
            // 
            this.listView3.Location = new System.Drawing.Point(12, 47);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(121, 223);
            this.listView3.TabIndex = 4;
            this.listView3.UseCompatibleStateImageBehavior = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Race Screens";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 276);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(488, 207);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(54, 42);
            this.button3.TabIndex = 8;
            this.button3.Text = "←";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button4.Location = new System.Drawing.Point(488, 257);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(54, 42);
            this.button4.TabIndex = 9;
            this.button4.Text = "→";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(139, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(139, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Cheater Screens";
            // 
            // listView4
            // 
            this.listView4.Location = new System.Drawing.Point(139, 47);
            this.listView4.Name = "listView4";
            this.listView4.Size = new System.Drawing.Size(121, 223);
            this.listView4.TabIndex = 10;
            this.listView4.UseCompatibleStateImageBehavior = false;
            // 
            // RaceMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 478);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listView4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listView3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CurrentRacerPool);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RacerPool);
            this.Name = "RaceMonitor";
            this.Text = "Race Monitor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView RacerPool;
        private Label label1;
        private Label label2;
        private ListView CurrentRacerPool;
        private ListView listView3;
        private Label label3;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button1;
        private Label label4;
        private ListView listView4;
    }
}