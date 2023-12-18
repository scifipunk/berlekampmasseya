using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using bmaLibrary;
using Microsoft.Extensions.Logging;
using dbLibrary;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Diagnostics;



//справка
namespace bmaForm
{

    public partial class lfsrForm : Form
    {

        public XDocument document;
        public bool needDB = true;
        public bool seqCheck = false;
        public lfsrForm()
        {
            InitializeComponent();

        }

        public lfsrDBForm lfsrDBForm
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
                    int id = db.BmaTables.OrderByDescending(u => u.Id).FirstOrDefault().Id;
                    BmaTable resultData = new BmaTable { Id = ++id, Data = document.ToString(), Feedback = feedBack, Sequence = sequence, State = state, Date = DateTime.Now, Length = Convert.ToString(sequence.Length) };
                    db.BmaTables.Add(resultData);
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

        public void UpdateDocument(XElement root, Polynomial C, Polynomial B, Polynomial T, int L, int m, int N, bool discr, bool Sn)
        {
            XElement iteration = new XElement("Iteration");
            iteration.Add(new XElement("Sn", Sn));
            iteration.Add(new XElement("Discrepancy", discr));
            iteration.Add(new XElement("Td", T.ToString()));
            iteration.Add(new XElement("Cd", C.ToString()));
            iteration.Add(new XElement("L", L));
            iteration.Add(new XElement("m", m));
            iteration.Add(new XElement("Bd", B.ToString()));
            iteration.Add(new XElement("N", N - 1));
            root.Add(iteration);
        }

        public LFSR FindLFSR(bool[] sequence)
        {
            int n = sequence.Length;
            bool[] init = { true };
            Polynomial C = new Polynomial(init);
            Polynomial B = C;
            int L = 0;
            int m = -1;
            int N = 0;
            Polynomial T = new Polynomial(0);
            XElement root = new XElement("Iterations");
            while (N < n)
            {
                bool Sn = sequence[N];
                bool discrepancy = Sn;
                for (int i = 1; i <= L; i++)
                {
                    if (L > C.Degree)
                        C.Expand(L);

                    if (N >= i)
                    {
                        discrepancy ^= C.Coefficients[i] & sequence[N - i];
                    }
                }

                if (discrepancy)
                {
                    T = C;
                    C = C + B.Shift(N - m);

                    if (2 * L <= N)
                    {
                        L = N + 1 - L;
                        m = N;
                        B = T;
                    }
                }
                N++;
                UpdateDocument(root, C, B, T, L, m, N, discrepancy, Sn);
            }
            bool[] seq = new bool[L];
            for (int i = 0; i < L; i++)
            {
                seq[i] = sequence[i];
            }
            document = new XDocument(root);
            return new LFSR(L, C, seq);
        }

        public static bool[] StrToBoolArray(string input)
        {
            return input.Select(c => c == '1').ToArray();
        }


        public int[] CheckSeq(bool[] seq)
        {
            int one = 0;
            int indR = 0;
            int N = seq.Length;
            int indL = 0;
            for (int i = 0; i < N; i++)
                if (seq[i])
                {
                    indL = i;
                    one++;
                    break;
                }
            for (int i = N - 1; i >= 0; i--)
                if (seq[i])
                {
                    indR = i;
                    one++;
                    break;
                }
            int[] ind = new int[] { 0, 0 };
            if (indR == indL || indR <= seq.Length/2)
            {
                seqCheck = true;
                ind[0] = indL;
                ind[1] = indR;
                return ind;
            }
            else
                seqCheck = false;
            return ind;
        }


        public bool[] sequenceChange(bool[] seq, int[] index)
        {
            bool[] resultSeq = seq;
            for (int i = 0; i<seq.Length; i++)
            {
                resultSeq[seq.Length - 1 - i] = seq[i];
            }
            return resultSeq;
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                /*Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();*/

                bool[] sequence = StrToBoolArray(seqBox.Text);
                int[] index = CheckSeq(sequence);
                if (seqCheck)
                  sequence = sequenceChange(sequence, index);
                LFSR register = FindLFSR(sequence);
                resultBox.Text = register.ToString() + "\nSequence: " + seqBox.Text;
                /*stopwatch.Stop();
                TimeSpan ts = stopwatch.Elapsed;
                MessageBox.Show($"Время выполнения: {ts.TotalMilliseconds} секунд\n {sequence.Length}");*/
                if (needDB)
                    addToDB();

            }
            catch (Exception ex)
            {
                addErrorMessage(ex);
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

        public void loadFromFile(RichTextBox richTextBox, string filePath)
        {
            try
            {
                string content = File.ReadAllText(filePath);
                string[] terms = content.Split('\n');
                foreach (string term in terms)
                {
                    if (term.StartsWith("Sequence"))
                        seqBox.Text = term.Split(' ')[1];
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
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {

                        loadFromFile(seqBox, openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        addErrorMessage(ex);
                    }
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

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            helpForm helpForm = new helpForm();
            helpForm.checker = true;
            helpForm.ShowDialog();
        }

        private void openDBMenuItem_Click(object sender, EventArgs e)
        {
            lfsrDBForm lfsrDBForm = new lfsrDBForm();
            lfsrDBForm.ShowDialog();
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
    }
}
