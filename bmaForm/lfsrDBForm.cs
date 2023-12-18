using dbLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;

namespace bmaForm
{
    public partial class lfsrDBForm : Form
    {
        public bool needDB = true;

        public lfsrDBForm()
        {
            InitializeComponent();
            GetData();
        }

        public stepsForm stepsForm
        {
            get => default;
            set
            {
            }
        }

        private async void GetData()
        {
            try
            {
                await Task.Run(() =>
                {
                    List<BmaTable> rows;
                    using (BmaDbContext db = new BmaDbContext())
                    {
                        db.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());
                        rows = db.BmaTables.ToList();
                    }
                    this.Invoke((MethodInvoker)delegate
                    {
                        dataGrid.Rows.Clear();

                        foreach (BmaTable row in rows)
                        {
                            dataGrid.Rows.Add(row.Id, row.Feedback, row.Length, row.Date);
                        }
                    });
                });
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

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGrid.Columns[4].Index && e.RowIndex >= 0)
            {
                try
                {
                    int selectedRow = Convert.ToInt32(dataGrid[0, e.RowIndex].Value);
                    string data = "";
                    using (BmaDbContext db = new BmaDbContext())
                    {
                        db.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());
                        BmaTable bmaTable = db.BmaTables.Find(selectedRow);

                        if (bmaTable != null)
                            data = bmaTable.Data;
                        db.Dispose();
                    }
                    DisplayDataGridView(XDocument.Parse(data));
                }
                catch (Exception ex)
                {
                    addErrorMessage(ex);

                }
            }
            if (e.ColumnIndex == dataGrid.Columns[5].Index && e.RowIndex >= 0)
            {
                try
                {
                    int selectedRow = Convert.ToInt32(dataGrid[0, e.RowIndex].Value);


                    using (BmaDbContext db = new BmaDbContext())
                    {
                        db.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());
                        BmaTable bmaTable = db.BmaTables.Find(selectedRow);
                        if (bmaTable != null)
                            db.BmaTables.Remove(bmaTable);
                        db.SaveChanges();
                        GetData();
                        db.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    addErrorMessage(ex);

                }
            }
        }

        static DataTable CreateDataTableFromXml(XDocument xdoc)
        {
            DataTable dataTable = new DataTable();
            XElement root = xdoc.Root;

            // Устанавливаем имена столбцов вручную
            dataTable.Columns.Add("Sn", typeof(string));
            dataTable.Columns.Add("Discrepancy", typeof(string));
            dataTable.Columns.Add("Td", typeof(string));
            dataTable.Columns.Add("Cd", typeof(string));
            dataTable.Columns.Add("L", typeof(string));
            dataTable.Columns.Add("m", typeof(string));
            dataTable.Columns.Add("Bd", typeof(string));
            dataTable.Columns.Add("N", typeof(string));

            foreach (XElement element in root.Elements("Iteration"))
            {
                DataRow row = dataTable.NewRow();

                row["Sn"] = element.Element("Sn").Value;
                row["Discrepancy"] = element.Element("Discrepancy").Value;
                row["Td"] = element.Element("Td").Value;
                row["Cd"] = element.Element("Cd").Value;
                row["L"] = element.Element("L").Value;
                row["m"] = element.Element("m").Value;
                row["Bd"] = element.Element("Bd").Value;
                row["N"] = element.Element("N").Value;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        static void DisplayDataGridView(XDocument xdoc)
        {
            stepsForm form = new stepsForm();

            DataGridView dataGridView = new DataGridView();
            DataTable dataTable = CreateDataTableFromXml(xdoc);

            dataGridView.DataSource = dataTable;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.DataMember = dataTable.TableName;

            form.Controls.Add(dataGridView);
            form.ShowDialog();
        }

    }
}
