using System.Drawing;

namespace MoodApp
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.MoodcomboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LogMoodbutton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.AffirmationLabel = new System.Windows.Forms.Label();
            this.NewAffbutton = new System.Windows.Forms.Button();
            this.moodChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.moodDataGridView = new System.Windows.Forms.DataGridView();
            this.lblPageNumber = new System.Windows.Forms.Label();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnJournal = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCheerUp = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moodChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moodDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1488, 168);
            this.panel1.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Font = new System.Drawing.Font("Constantia", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(1233, 56);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(129, 48);
            this.btnLogout.TabIndex = 13;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Constantia", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(530, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(505, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "How Are You Feeling?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MoodcomboBox
            // 
            this.MoodcomboBox.FormattingEnabled = true;
            this.MoodcomboBox.Items.AddRange(new object[] {
            "Happy",
            "Grateful",
            "Relaxed",
            "Excited",
            "Confident",
            "Inspired",
            "Loved",
            "Hopeful",
            "Content",
            "Proud",
            "Calm",
            "Thoughtful",
            "Focused",
            "Tired",
            "Indifferent",
            "Nostalgic",
            "Stressed",
            "Anxious",
            "Overwhelmed",
            "Lonely",
            "Sad",
            "Frustrated",
            "Angry",
            "Unmotivated",
            "Disappointed",
            "Drained"});
            this.MoodcomboBox.Location = new System.Drawing.Point(65, 326);
            this.MoodcomboBox.Name = "MoodcomboBox";
            this.MoodcomboBox.Size = new System.Drawing.Size(242, 47);
            this.MoodcomboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Constantia", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(348, 53);
            this.label2.TabIndex = 1;
            this.label2.Text = "Today, I\'m feeling";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LogMoodbutton
            // 
            this.LogMoodbutton.Font = new System.Drawing.Font("Constantia", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogMoodbutton.Location = new System.Drawing.Point(65, 379);
            this.LogMoodbutton.Name = "LogMoodbutton";
            this.LogMoodbutton.Size = new System.Drawing.Size(211, 48);
            this.LogMoodbutton.TabIndex = 2;
            this.LogMoodbutton.Text = "Log Mood";
            this.LogMoodbutton.UseVisualStyleBackColor = true;
            this.LogMoodbutton.Click += new System.EventHandler(this.LogMoodbutton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Font = new System.Drawing.Font("Constantia", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(522, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 53);
            this.label3.TabIndex = 4;
            this.label3.Text = "Past Moods";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AffirmationLabel
            // 
            this.AffirmationLabel.AutoSize = true;
            this.AffirmationLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.AffirmationLabel.Font = new System.Drawing.Font("Constantia", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AffirmationLabel.Location = new System.Drawing.Point(1061, 260);
            this.AffirmationLabel.Name = "AffirmationLabel";
            this.AffirmationLabel.Size = new System.Drawing.Size(384, 53);
            this.AffirmationLabel.TabIndex = 5;
            this.AffirmationLabel.Text = "Today\'s Affirmation";
            this.AffirmationLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // NewAffbutton
            // 
            this.NewAffbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NewAffbutton.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewAffbutton.Location = new System.Drawing.Point(1070, 325);
            this.NewAffbutton.Name = "NewAffbutton";
            this.NewAffbutton.Size = new System.Drawing.Size(375, 67);
            this.NewAffbutton.TabIndex = 6;
            this.NewAffbutton.Text = "Get New Affirmation";
            this.NewAffbutton.UseVisualStyleBackColor = true;
            this.NewAffbutton.Click += new System.EventHandler(this.NewAffbutton_Click);
            // 
            // moodChart
            // 
            this.moodChart.BackColor = System.Drawing.Color.Transparent;
            this.moodChart.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(199)))), ((int)(((byte)(231)))));
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.moodChart.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Name = "Legend1";
            this.moodChart.Legends.Add(legend1);
            this.moodChart.Location = new System.Drawing.Point(63, 433);
            this.moodChart.Name = "moodChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.moodChart.Series.Add(series1);
            this.moodChart.Size = new System.Drawing.Size(359, 346);
            this.moodChart.TabIndex = 7;
            this.moodChart.Text = "moodChart";
            // 
            // moodDataGridView
            // 
            this.moodDataGridView.AllowUserToAddRows = false;
            this.moodDataGridView.AllowUserToDeleteRows = false;
            this.moodDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.moodDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(211)))), ((int)(((byte)(196)))));
            this.moodDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.moodDataGridView.Location = new System.Drawing.Point(531, 326);
            this.moodDataGridView.Name = "moodDataGridView";
            this.moodDataGridView.ReadOnly = true;
            this.moodDataGridView.RowHeadersWidth = 82;
            this.moodDataGridView.RowTemplate.Height = 33;
            this.moodDataGridView.Size = new System.Drawing.Size(443, 395);
            this.moodDataGridView.TabIndex = 8;
            // 
            // lblPageNumber
            // 
            this.lblPageNumber.AutoSize = true;
            this.lblPageNumber.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblPageNumber.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageNumber.Location = new System.Drawing.Point(596, 736);
            this.lblPageNumber.Name = "lblPageNumber";
            this.lblPageNumber.Size = new System.Drawing.Size(203, 39);
            this.lblPageNumber.TabIndex = 9;
            this.lblPageNumber.Text = "Page Number";
            this.lblPageNumber.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Font = new System.Drawing.Font("Constantia", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevPage.Location = new System.Drawing.Point(805, 727);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(86, 48);
            this.btnPrevPage.TabIndex = 10;
            this.btnPrevPage.Text = "prev";
            this.btnPrevPage.UseVisualStyleBackColor = true;
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Font = new System.Drawing.Font("Constantia", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextPage.Location = new System.Drawing.Point(888, 727);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(86, 48);
            this.btnNextPage.TabIndex = 11;
            this.btnNextPage.Text = "next";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(56, 782);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(542, 39);
            this.label4.TabIndex = 12;
            this.label4.Text = "Here\'s how you been feeling this week!";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnJournal
            // 
            this.btnJournal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJournal.Location = new System.Drawing.Point(1070, 545);
            this.btnJournal.Name = "btnJournal";
            this.btnJournal.Size = new System.Drawing.Size(375, 73);
            this.btnJournal.TabIndex = 13;
            this.btnJournal.Text = "Journal Entries";
            this.btnJournal.UseVisualStyleBackColor = true;
            this.btnJournal.Click += new System.EventHandler(this.btnJournal_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.Font = new System.Drawing.Font("Constantia", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1061, 489);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(406, 53);
            this.label5.TabIndex = 14;
            this.label5.Text = "Your Journal Entries!";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCheerUp
            // 
            this.btnCheerUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheerUp.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheerUp.Location = new System.Drawing.Point(1070, 408);
            this.btnCheerUp.Name = "btnCheerUp";
            this.btnCheerUp.Size = new System.Drawing.Size(375, 67);
            this.btnCheerUp.TabIndex = 15;
            this.btnCheerUp.Text = "Cheer Up! (Try me)";
            this.btnCheerUp.UseVisualStyleBackColor = true;
            this.btnCheerUp.Click += new System.EventHandler(this.btnCheerUp_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 39F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(199)))), ((int)(((byte)(231)))));
            this.ClientSize = new System.Drawing.Size(1488, 933);
            this.Controls.Add(this.btnCheerUp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnJournal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnPrevPage);
            this.Controls.Add(this.lblPageNumber);
            this.Controls.Add(this.moodDataGridView);
            this.Controls.Add(this.moodChart);
            this.Controls.Add(this.NewAffbutton);
            this.Controls.Add(this.AffirmationLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LogMoodbutton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MoodcomboBox);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log Your Mood";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moodChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moodDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        


        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox MoodcomboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button LogMoodbutton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label AffirmationLabel;
        private System.Windows.Forms.Button NewAffbutton;
        private System.Windows.Forms.DataVisualization.Charting.Chart moodChart;
        private System.Windows.Forms.DataGridView moodDataGridView;
        private System.Windows.Forms.Label lblPageNumber;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnJournal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCheerUp;
    }
}