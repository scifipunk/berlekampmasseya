namespace bmaForm
{
    partial class generateForm
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
            resultBox = new RichTextBox();
            enterBox = new RichTextBox();
            btnGenerate = new Button();
            enterLabel = new Label();
            label2 = new Label();
            label1 = new Label();
            stateBox = new RichTextBox();
            countNumeric = new NumericUpDown();
            label3 = new Label();
            menuStrip = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            saveMenuItem = new ToolStripMenuItem();
            loadMenuItem = new ToolStripMenuItem();
            printMenuItem = new ToolStripMenuItem();
            aboutMenuItem = new ToolStripMenuItem();
            DBMenuItem = new ToolStripMenuItem();
            openDBMenuItem = new ToolStripMenuItem();
            записыватьВБДToolStripMenuItem = new ToolStripMenuItem();
            yesDBMenuItem = new ToolStripMenuItem();
            noDBMenuItem = new ToolStripMenuItem();
            openFileDialog = new OpenFileDialog();
            printDialog = new PrintDialog();
            saveFileDialog = new SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)countNumeric).BeginInit();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // resultBox
            // 
            resultBox.Location = new Point(12, 242);
            resultBox.Name = "resultBox";
            resultBox.Size = new Size(767, 97);
            resultBox.TabIndex = 0;
            resultBox.Text = "";
            // 
            // enterBox
            // 
            enterBox.Location = new Point(328, 88);
            enterBox.Name = "enterBox";
            enterBox.Size = new Size(460, 29);
            enterBox.TabIndex = 1;
            enterBox.Text = "x^4+x^1+1";
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(555, 169);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(224, 29);
            btnGenerate.TabIndex = 2;
            btnGenerate.Text = "Сгенерировать последовательность";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // enterLabel
            // 
            enterLabel.AutoSize = true;
            enterLabel.Location = new Point(12, 88);
            enterLabel.Name = "enterLabel";
            enterLabel.Size = new Size(263, 20);
            enterLabel.TabIndex = 3;
            enterLabel.Text = "Введите многочлен над полем GF(2)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(291, 213);
            label2.Name = "label2";
            label2.Size = new Size(193, 20);
            label2.TabIndex = 4;
            label2.Text = "Ваша последовательность";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 126);
            label1.Name = "label1";
            label1.Size = new Size(286, 20);
            label1.TabIndex = 8;
            label1.Text = "Введите начальное состояние регистра";
            // 
            // stateBox
            // 
            stateBox.Location = new Point(328, 123);
            stateBox.Name = "stateBox";
            stateBox.Size = new Size(451, 29);
            stateBox.TabIndex = 7;
            stateBox.Text = "0111";
            // 
            // countNumeric
            // 
            countNumeric.Location = new Point(376, 171);
            countNumeric.Name = "countNumeric";
            countNumeric.Size = new Size(150, 27);
            countNumeric.TabIndex = 9;
            countNumeric.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 173);
            label3.Name = "label3";
            label3.Size = new Size(347, 20);
            label3.TabIndex = 10;
            label3.Text = "Введите длину нужной вам последовательности";
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, aboutMenuItem, DBMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 28);
            menuStrip.TabIndex = 11;
            menuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveMenuItem, loadMenuItem, printMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(59, 24);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // saveMenuItem
            // 
            saveMenuItem.Name = "saveMenuItem";
            saveMenuItem.Size = new Size(166, 26);
            saveMenuItem.Text = "Сохранить";
            saveMenuItem.Click += saveMenuItem_Click;
            // 
            // loadMenuItem
            // 
            loadMenuItem.Name = "loadMenuItem";
            loadMenuItem.Size = new Size(166, 26);
            loadMenuItem.Text = "Загрузить";
            loadMenuItem.Click += loadMenuItem_Click;
            // 
            // printMenuItem
            // 
            printMenuItem.Name = "printMenuItem";
            printMenuItem.Size = new Size(166, 26);
            printMenuItem.Text = "Печать";
            printMenuItem.Click += printMenuItem_Click;
            // 
            // aboutMenuItem
            // 
            aboutMenuItem.Name = "aboutMenuItem";
            aboutMenuItem.Size = new Size(81, 24);
            aboutMenuItem.Text = "Справка";
            aboutMenuItem.Click += aboutMenuItem_Click;
            // 
            // DBMenuItem
            // 
            DBMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openDBMenuItem, записыватьВБДToolStripMenuItem });
            DBMenuItem.Name = "DBMenuItem";
            DBMenuItem.Size = new Size(42, 24);
            DBMenuItem.Text = "БД";
            // 
            // openDBMenuItem
            // 
            openDBMenuItem.Name = "openDBMenuItem";
            openDBMenuItem.Size = new Size(224, 26);
            openDBMenuItem.Text = "Просмотр записей";
            openDBMenuItem.Click += openDBMenuItem_Click;
            // 
            // записыватьВБДToolStripMenuItem
            // 
            записыватьВБДToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { yesDBMenuItem, noDBMenuItem });
            записыватьВБДToolStripMenuItem.Name = "записыватьВБДToolStripMenuItem";
            записыватьВБДToolStripMenuItem.Size = new Size(224, 26);
            записыватьВБДToolStripMenuItem.Text = "Записывать в БД";
            // 
            // yesDBMenuItem
            // 
            yesDBMenuItem.Checked = true;
            yesDBMenuItem.CheckState = CheckState.Checked;
            yesDBMenuItem.Name = "yesDBMenuItem";
            yesDBMenuItem.Size = new Size(117, 26);
            yesDBMenuItem.Text = "Да";
            yesDBMenuItem.Click += yesDBMenuItem_Click;
            // 
            // noDBMenuItem
            // 
            noDBMenuItem.Name = "noDBMenuItem";
            noDBMenuItem.Size = new Size(117, 26);
            noDBMenuItem.Text = "Нет";
            noDBMenuItem.Click += noDBMenuItem_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // printDialog
            // 
            printDialog.UseEXDialog = true;
            // 
            // generateForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 347);
            Controls.Add(label3);
            Controls.Add(countNumeric);
            Controls.Add(label1);
            Controls.Add(stateBox);
            Controls.Add(label2);
            Controls.Add(enterLabel);
            Controls.Add(btnGenerate);
            Controls.Add(enterBox);
            Controls.Add(resultBox);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            MaximumSize = new Size(818, 394);
            MinimumSize = new Size(818, 394);
            Name = "generateForm";
            Text = "Имитатор РСЛОС";
            ((System.ComponentModel.ISupportInitialize)countNumeric).EndInit();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox resultBox;
        private RichTextBox enterBox;
        private Button btnGenerate;
        private Label enterLabel;
        private Label label2;
        private Label label1;
        private RichTextBox stateBox;
        private NumericUpDown countNumeric;
        private Label label3;
        private MenuStrip menuStrip;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem saveMenuItem;
        private ToolStripMenuItem loadMenuItem;
        private ToolStripMenuItem printMenuItem;
        private OpenFileDialog openFileDialog;
        private PrintDialog printDialog;
        private ToolStripMenuItem aboutMenuItem;
        private ToolStripMenuItem DBMenuItem;
        private ToolStripMenuItem openDBMenuItem;
        private ToolStripMenuItem записыватьВБДToolStripMenuItem;
        private ToolStripMenuItem yesDBMenuItem;
        private ToolStripMenuItem noDBMenuItem;
        private SaveFileDialog saveFileDialog;
    }
}