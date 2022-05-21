namespace Subtitle_Offset
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.seconds = new System.Windows.Forms.NumericUpDown();
            this.minutes = new System.Windows.Forms.NumericUpDown();
            this.negative = new System.Windows.Forms.CheckBox();
            this.add_subtitles = new System.Windows.Forms.Button();
            this.remove_subtitles = new System.Windows.Forms.Button();
            this.add_offset = new System.Windows.Forms.Button();
            this.subtitles = new System.Windows.Forms.ListView();
            this.outputDir = new System.Windows.Forms.TextBox();
            this.browse = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.seconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seconds : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Minutes : ";
            // 
            // seconds
            // 
            this.seconds.Location = new System.Drawing.Point(72, 11);
            this.seconds.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.seconds.Name = "seconds";
            this.seconds.Size = new System.Drawing.Size(44, 20);
            this.seconds.TabIndex = 3;
            // 
            // minutes
            // 
            this.minutes.Location = new System.Drawing.Point(192, 11);
            this.minutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.minutes.Name = "minutes";
            this.minutes.Size = new System.Drawing.Size(44, 20);
            this.minutes.TabIndex = 5;
            // 
            // negative
            // 
            this.negative.AutoSize = true;
            this.negative.Location = new System.Drawing.Point(254, 13);
            this.negative.Name = "negative";
            this.negative.Size = new System.Drawing.Size(69, 17);
            this.negative.TabIndex = 6;
            this.negative.Text = "Negative";
            this.negative.UseVisualStyleBackColor = true;
            // 
            // add_subtitles
            // 
            this.add_subtitles.Location = new System.Drawing.Point(13, 293);
            this.add_subtitles.Name = "add_subtitles";
            this.add_subtitles.Size = new System.Drawing.Size(115, 23);
            this.add_subtitles.TabIndex = 7;
            this.add_subtitles.Text = "Add Subtitles";
            this.add_subtitles.UseVisualStyleBackColor = true;
            this.add_subtitles.Click += new System.EventHandler(this.add_subtitles_Click);
            // 
            // remove_subtitles
            // 
            this.remove_subtitles.Location = new System.Drawing.Point(385, 293);
            this.remove_subtitles.Name = "remove_subtitles";
            this.remove_subtitles.Size = new System.Drawing.Size(115, 23);
            this.remove_subtitles.TabIndex = 7;
            this.remove_subtitles.Text = "Remove Subtitles";
            this.remove_subtitles.UseVisualStyleBackColor = true;
            this.remove_subtitles.Click += new System.EventHandler(this.remove_subtitles_Click);
            // 
            // add_offset
            // 
            this.add_offset.Location = new System.Drawing.Point(13, 348);
            this.add_offset.Name = "add_offset";
            this.add_offset.Size = new System.Drawing.Size(487, 23);
            this.add_offset.TabIndex = 7;
            this.add_offset.Text = "Add Offset";
            this.add_offset.UseVisualStyleBackColor = true;
            this.add_offset.Click += new System.EventHandler(this.add_offset_Click);
            // 
            // subtitles
            // 
            this.subtitles.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.subtitles.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.subtitles.HotTracking = true;
            this.subtitles.HoverSelection = true;
            this.subtitles.Location = new System.Drawing.Point(13, 40);
            this.subtitles.Name = "subtitles";
            this.subtitles.ShowGroups = false;
            this.subtitles.Size = new System.Drawing.Size(487, 247);
            this.subtitles.TabIndex = 8;
            this.subtitles.UseCompatibleStateImageBehavior = false;
            this.subtitles.View = System.Windows.Forms.View.List;
            // 
            // outputDir
            // 
            this.outputDir.Location = new System.Drawing.Point(13, 323);
            this.outputDir.Name = "outputDir";
            this.outputDir.Size = new System.Drawing.Size(412, 20);
            this.outputDir.TabIndex = 9;
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(431, 323);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(69, 23);
            this.browse.TabIndex = 7;
            this.browse.Text = "Browse";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 377);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(487, 23);
            this.progressBar1.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(512, 409);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.outputDir);
            this.Controls.Add(this.subtitles);
            this.Controls.Add(this.add_offset);
            this.Controls.Add(this.remove_subtitles);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.add_subtitles);
            this.Controls.Add(this.negative);
            this.Controls.Add(this.minutes);
            this.Controls.Add(this.seconds);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(528, 448);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(528, 448);
            this.Name = "Form1";
            this.Text = "Subtitle_Offset";
            ((System.ComponentModel.ISupportInitialize)(this.seconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown seconds;
        private System.Windows.Forms.NumericUpDown minutes;
        private System.Windows.Forms.CheckBox negative;
        private System.Windows.Forms.Button add_subtitles;
        private System.Windows.Forms.Button remove_subtitles;
        private System.Windows.Forms.Button add_offset;
        private System.Windows.Forms.ListView subtitles;
        private System.Windows.Forms.TextBox outputDir;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

