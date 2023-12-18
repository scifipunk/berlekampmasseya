namespace bmaForm
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnFindLFSR = new Button();
            btnGenerate = new Button();
            SuspendLayout();
            // 
            // btnFindLFSR
            // 
            btnFindLFSR.Location = new Point(58, 32);
            btnFindLFSR.Name = "btnFindLFSR";
            btnFindLFSR.Size = new Size(281, 71);
            btnFindLFSR.TabIndex = 0;
            btnFindLFSR.Text = "Найти РСЛОС";
            btnFindLFSR.UseVisualStyleBackColor = true;
            btnFindLFSR.Click += btnFindLFSR_Click;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(58, 209);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(281, 71);
            btnGenerate.TabIndex = 1;
            btnGenerate.Text = "Созадть последовательность";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(387, 338);
            Controls.Add(btnGenerate);
            Controls.Add(btnFindLFSR);
            MaximumSize = new Size(405, 385);
            MinimumSize = new Size(405, 385);
            Name = "mainForm";
            Text = "Главное меню";
            ResumeLayout(false);
        }

        #endregion

        private Button btnFindLFSR;
        private Button btnGenerate;
    }
}