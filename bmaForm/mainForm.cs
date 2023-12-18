using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace bmaForm
{
    public partial class mainForm : Form
    {

        public mainForm()
        {
            InitializeComponent();
        }

        public generateForm generateForm
        {
            get => default;
            set
            {
            }
        }

        public lfsrForm lfsrForm
        {
            get => default;
            set
            {
            }
        }

        private void btnFindLFSR_Click(object sender, EventArgs e)
        {
            lfsrForm lfsrForm = new lfsrForm();
            lfsrForm.ShowDialog();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            generateForm generateForm = new generateForm();
            generateForm.ShowDialog();
        }
    }
}
