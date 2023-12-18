namespace bmaForm
{
    partial class lfsrForm
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
            seqBox = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            btnStart = new Button();
            openFileDialog = new OpenFileDialog();
            printDialog = new PrintDialog();
            menuStrip = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            saveMenuItem = new ToolStripMenuItem();
            loadMenuItem = new ToolStripMenuItem();
            printMenuItem = new ToolStripMenuItem();
            aboutMenuItem = new ToolStripMenuItem();
            бДToolStripMenuItem = new ToolStripMenuItem();
            openDBMenuItem = new ToolStripMenuItem();
            записыватьВБДToolStripMenuItem = new ToolStripMenuItem();
            yesDBMenuItem = new ToolStripMenuItem();
            noDBMenuItem = new ToolStripMenuItem();
            saveFileDialog = new SaveFileDialog();
            helpProvider1 = new HelpProvider();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // resultBox
            // 
            resultBox.Location = new Point(11, 317);
            resultBox.Name = "resultBox";
            resultBox.Size = new Size(389, 120);
            resultBox.TabIndex = 0;
            resultBox.Text = "";
            // 
            // seqBox
            // 
            seqBox.Location = new Point(11, 107);
            seqBox.Name = "seqBox";
            seqBox.Size = new Size(389, 72);
            seqBox.TabIndex = 1;
            seqBox.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(105, 65);
            label1.Name = "label1";
            label1.Size = new Size(212, 20);
            label1.TabIndex = 2;
            label1.Text = "Введите последовательность";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(159, 285);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 3;
            label2.Text = "Результат";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(54, 185);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(315, 52);
            btnStart.TabIndex = 4;
            btnStart.Text = "Запустить генератор";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // printDialog
            // 
            printDialog.UseEXDialog = true;
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, aboutMenuItem, бДToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(6, 3, 0, 3);
            menuStrip.Size = new Size(416, 30);
            menuStrip.TabIndex = 5;
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
            // бДToolStripMenuItem
            // 
            бДToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openDBMenuItem, записыватьВБДToolStripMenuItem });
            бДToolStripMenuItem.Name = "бДToolStripMenuItem";
            бДToolStripMenuItem.Size = new Size(42, 24);
            бДToolStripMenuItem.Text = "БД";
            // 
            // openDBMenuItem
            // 
            openDBMenuItem.Name = "openDBMenuItem";
            openDBMenuItem.Size = new Size(216, 26);
            openDBMenuItem.Text = "Открыть";
            openDBMenuItem.Click += openDBMenuItem_Click;
            // 
            // записыватьВБДToolStripMenuItem
            // 
            записыватьВБДToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { yesDBMenuItem, noDBMenuItem });
            записыватьВБДToolStripMenuItem.Name = "записыватьВБДToolStripMenuItem";
            записыватьВБДToolStripMenuItem.Size = new Size(216, 26);
            записыватьВБДToolStripMenuItem.Text = "Записывать в БД?";
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
            // lfsrForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(416, 451);
            Controls.Add(btnStart);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(seqBox);
            Controls.Add(resultBox);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            MaximumSize = new Size(434, 498);
            MinimumSize = new Size(434, 498);
            Name = "lfsrForm";
            Text = "Алгорит Бэрлекэмпа-Месси";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox resultBox;
        private RichTextBox seqBox;
        private Label label1;
        private Label label2;
        private Button btnStart;
        private OpenFileDialog openFileDialog;
        private PrintDialog printDialog;
        private MenuStrip menuStrip;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem saveMenuItem;
        private ToolStripMenuItem loadMenuItem;
        private ToolStripMenuItem printMenuItem;
        private ToolStripMenuItem aboutMenuItem;
        private ToolStripMenuItem бДToolStripMenuItem;
        private ToolStripMenuItem openDBMenuItem;
        private ToolStripMenuItem записыватьВБДToolStripMenuItem;
        private ToolStripMenuItem yesDBMenuItem;
        private ToolStripMenuItem noDBMenuItem;
        private SaveFileDialog saveFileDialog;
        private HelpProvider helpProvider1;
    }
}