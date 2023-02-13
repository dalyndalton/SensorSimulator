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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AddBigScreenObserverButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.BigScreenList = new System.Windows.Forms.ListBox();
            this.CurrentObserverBox = new System.Windows.Forms.ListBox();
            this.CheaterScreenList = new System.Windows.Forms.ListBox();
            this.AvailableRacers = new System.Windows.Forms.ListBox();
            this.racerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.racerBindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.label2.Size = new System.Drawing.Size(146, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Currently Observed Racers";
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
            // AddBigScreenObserverButton
            // 
            this.AddBigScreenObserverButton.Location = new System.Drawing.Point(13, 272);
            this.AddBigScreenObserverButton.Name = "AddBigScreenObserverButton";
            this.AddBigScreenObserverButton.Size = new System.Drawing.Size(61, 23);
            this.AddBigScreenObserverButton.TabIndex = 7;
            this.AddBigScreenObserverButton.Text = "Add";
            this.AddBigScreenObserverButton.UseVisualStyleBackColor = true;
            this.AddBigScreenObserverButton.Click += new System.EventHandler(this.BigScreenAdd);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(488, 180);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(54, 42);
            this.button3.TabIndex = 8;
            this.button3.Text = "←";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ActivateObserver);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button4.Location = new System.Drawing.Point(488, 230);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(54, 42);
            this.button4.TabIndex = 9;
            this.button4.Text = "→";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(139, 272);
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
            // BigScreenList
            // 
            this.BigScreenList.DisplayMember = "ObsName";
            this.BigScreenList.FormattingEnabled = true;
            this.BigScreenList.ItemHeight = 15;
            this.BigScreenList.Location = new System.Drawing.Point(13, 52);
            this.BigScreenList.Name = "BigScreenList";
            this.BigScreenList.Size = new System.Drawing.Size(120, 214);
            this.BigScreenList.TabIndex = 13;
            this.BigScreenList.SelectedIndexChanged += new System.EventHandler(this.BigScreenList_SelectedIndexChanged);
            this.BigScreenList.DoubleClick += new System.EventHandler(this.BigScreenReopen);
            // 
            // CurrentObserverBox
            // 
            this.CurrentObserverBox.FormattingEnabled = true;
            this.CurrentObserverBox.ItemHeight = 15;
            this.CurrentObserverBox.Location = new System.Drawing.Point(290, 52);
            this.CurrentObserverBox.Name = "CurrentObserverBox";
            this.CurrentObserverBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.CurrentObserverBox.Size = new System.Drawing.Size(192, 394);
            this.CurrentObserverBox.TabIndex = 15;
            // 
            // CheaterScreenList
            // 
            this.CheaterScreenList.FormattingEnabled = true;
            this.CheaterScreenList.ItemHeight = 15;
            this.CheaterScreenList.Location = new System.Drawing.Point(139, 52);
            this.CheaterScreenList.Name = "CheaterScreenList";
            this.CheaterScreenList.Size = new System.Drawing.Size(120, 214);
            this.CheaterScreenList.TabIndex = 14;
            // 
            // AvailableRacers
            // 
            this.AvailableRacers.DisplayMember = "Name";
            this.AvailableRacers.FormattingEnabled = true;
            this.AvailableRacers.ItemHeight = 15;
            this.AvailableRacers.Location = new System.Drawing.Point(548, 52);
            this.AvailableRacers.Name = "AvailableRacers";
            this.AvailableRacers.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.AvailableRacers.Size = new System.Drawing.Size(192, 394);
            this.AvailableRacers.TabIndex = 16;
            this.AvailableRacers.ValueMember = "Name";
            // 
            // racerBindingSource
            // 
            this.racerBindingSource.DataSource = typeof(SharedClasses.Racer);
            // 
            // RaceMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 478);
            this.Controls.Add(this.AvailableRacers);
            this.Controls.Add(this.CurrentObserverBox);
            this.Controls.Add(this.CheaterScreenList);
            this.Controls.Add(this.BigScreenList);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.AddBigScreenObserverButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RaceMonitor";
            this.Text = "Race Monitor";
            ((System.ComponentModel.ISupportInitialize)(this.racerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private Button AddBigScreenObserverButton;
        private Button button3;
        private Button button4;
        private Button button1;
        private Label label4;
        private ListBox BigScreenList;
        private ListBox CheaterScreenList;
        private ListBox CurrentObserverBox;
        private ListBox AvailableRacers;
        private BindingSource racerBindingSource;
    }
}