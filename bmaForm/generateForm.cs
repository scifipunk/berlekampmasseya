using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bmaLibrary;
using dbLibrary;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;


namespace bmaForm
{
    public partial class generateForm : Form
    {

        public bool needDB = true;

        public generateForm()
        {
            InitializeComponent();
        }

        public genDBForm genDBForm
        {
            get => default;
            set
            {
            }
        }

        public helpForm helpForm
        {
            get => default;
            set
            {
            }
        }

        public LFSR LFSR
        {
            get => default;
            set
            {
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                

                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();
                
                
                Polynomial polynom = new Polynomial(enterBox.Text);
                LFSR register = new LFSR(stateBox.Text, polynom);
                bool[] sequense = register.Generate(Convert.ToInt32(countNumeric.Value));
                resultBox.Text = register.ToString() + '\n' + "Sequence: ";
                for (int i = 0; i <= sequense.Length - 1; i++)
                {
                    if (sequense[i])
                        resultBox.AppendText("1");
                    else
                        resultBox.AppendText("0");
                }

                stopwatch.Stop();
                TimeSpan ts = stopwatch.Elapsed;
                MessageBox.Show($"Время выполнения: {ts.TotalMilliseconds} секунд");
                if (needDB)
                    addToDB();
            }
            catch (Exception ex)
            {
                addErrorMessage(ex);
            }

        }

        public void addErrorMessage(Exception userEx)
        {
            string exceptionText = $"{DateTime.Now}:{userEx.InnerException},\n{userEx.Message},\n{userEx.Source},\n{userEx.StackTrace},\n{userEx.TargetSite}\n";
            if (!File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "/dataFiles/exceptions.txt"))
                File.Create(Path.GetDirectoryName(Application.ExecutablePath) + "/dataFiles/exceptions.txt");
            File.AppendAllText(Path.GetDirectoryName(Application.ExecutablePath) + "/dataFiles/exceptions.txt", exceptionText);
            MessageBox.Show($"Произошла ошибка: {userEx.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (needDB)
                using (BmaDbContext db = new BmaDbContext())
                {
                    db.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());
                    int id = db.ExcepTables.OrderByDescending(u => u.Id).FirstOrDefault().Id;
                    ExcepTable userException = new ExcepTable { Id = id + 1, TargetSite = userEx.TargetSite.ToString(), DateTime = DateTime.Now, Message = userEx.Message, Form = $"{this.Name}" };
                    db.ExcepTables.Add(userException);
                    db.SaveChanges();
                    db.Dispose();
                }
        }

        public void addToDB()
        {
            try
            {
                string content = resultBox.Text;
                string[] terms = content.Split('\n');
                using (BmaDbContext db = new BmaDbContext())
                {
                    string feedBack = " ", state = " ", sequence = " ";
                    foreach (string term in terms)
                    {
                        if (term.StartsWith("Feedback:"))
                            feedBack = term.Split(' ')[1];
                        if (term.StartsWith("State:"))
                            state = term.Split(' ')[1];
                        if (term.StartsWith("Sequence:"))
                            sequence = term.Split(' ')[1];
                    }
                    int id = db.GenTables.OrderByDescending(u => u.Id).FirstOrDefault().Id;
                    GenTable resultData = new GenTable { Id = ++id, Feedback = feedBack, Sequence = sequence, SequenceLength = Convert.ToString(sequence.Length), State = state, Date = DateTime.Now, Length = Convert.ToString(countNumeric.Value) };
                    db.GenTables.Add(resultData);
                    db.SaveChanges();
                    db.Dispose();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при загрузке файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public static void saveToFile(RichTextBox richTextBox, string filePath)
        {
            try
            {
                string content = richTextBox.Text;
                File.WriteAllText(filePath, content);

                MessageBox.Show("Запись успешно сохранена в файл.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public void loadFromFile(string filePath)
        {
            try
            {
                string content = File.ReadAllText(filePath);
                string[] terms = content.Split('\n');
                foreach (string term in terms)
                {
                    if (term.StartsWith("Feedback:"))
                        enterBox.Text = term.Split(' ')[1];
                    if (term.StartsWith("State:"))
                        stateBox.Text = term.Split(' ')[1];
                    if (term.StartsWith("Sequence Length:"))
                        countNumeric.Value = Convert.ToInt32(term.Split(' ')[2]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при загрузке файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public static void printResult(RichTextBox richTextBox)
        {
            using (PrintDocument printDocument = new PrintDocument())
            {
                using (PrintDialog printDialog = new PrintDialog())
                {
                    printDialog.Document = printDocument;

                    if (printDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (PrintDialog dialog = new PrintDialog())
                        {
                            if (dialog.ShowDialog() == DialogResult.OK)
                            {
                                printDocument.DocumentName = dialog.PrinterSettings.PrintFileName;
                            }
                        }

                        printDocument.PrintPage += (sender, e) =>
                        {
                            string content = richTextBox.Text;
                            Font font = new Font("Arial", 12);
                            RectangleF rect = new RectangleF(e.MarginBounds.Left, e.MarginBounds.Top, e.MarginBounds.Width, e.MarginBounds.Height);
                            e.Graphics.DrawString(content, font, Brushes.Black, rect, StringFormat.GenericTypographic);
                        };
                        printDocument.Print();
                    }
                }
            }
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    saveToFile(resultBox, saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    addErrorMessage(ex);
                }
            }
        }

        private void loadMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Вызываем метод загрузки из файла
                    loadFromFile(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    addErrorMessage(ex);
                }
            }
        }

        private void printMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                printResult(resultBox);
            }
            catch (Exception ex)
            {
                addErrorMessage(ex);
            }

        }

        private void openDBMenuItem_Click(object sender, EventArgs e)
        {
            genDBForm genDBFrom = new genDBForm();
            genDBFrom.ShowDialog();
        }

        private void yesDBMenuItem_Click(object sender, EventArgs e)
        {
            needDB = true;
            yesDBMenuItem.Checked = true;
            noDBMenuItem.Checked = false;
        }

        private void noDBMenuItem_Click(object sender, EventArgs e)
        {
            needDB = false;
            yesDBMenuItem.Checked = false;
            noDBMenuItem.Checked = true;
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            helpForm helpForm = new helpForm();
            helpForm.checker = false;
            helpForm.ShowDialog();
        }
    }
}
