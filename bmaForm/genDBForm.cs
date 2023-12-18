using dbLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System.Data;


namespace bmaForm
{
    public partial class genDBForm : Form
    {
        public bool needDB;

        public genDBForm()
        {
            InitializeComponent();
            GetData();
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

        private async void GetData()
        {
            try
            {
                await Task.Run(() =>
                {
                    List<GenTable> rows;
                    using (BmaDbContext db = new BmaDbContext())
                    {
                        db.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());
                        rows = db.GenTables.ToList();
                    }
                    this.Invoke((MethodInvoker)delegate
                    {
                        dataGrid.Rows.Clear();

                        foreach (GenTable row in rows)
                        {
                            dataGrid.Rows.Add(row.Id, row.Feedback, row.Length, row.State, row.Sequence, row.Date);
                        }
                    });
                });
            }
            catch (Exception ex)
            {
                addErrorMessage(ex);
            }
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGrid.Columns[4].Index && e.RowIndex >= 0)
            {
                try
                {
                    int selectedRow = Convert.ToInt32(dataGrid[0, e.RowIndex].Value);


                    using (BmaDbContext db = new BmaDbContext())
                    {
                        db.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());
                        GenTable genTable = db.GenTables.Find(selectedRow);
                        if (genTable != null)
                            db.GenTables.Remove(genTable);
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
    }
}