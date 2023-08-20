using System;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace CrudApp_1
{
    public partial class FormDisplay : Form
    {
        public FormDisplay()
        {
            InitializeComponent();
        }

        private void FormDisplay_Load(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source='C:/Users/Dewesh Chopra/Documents/DemoDB.accdb'");
            OleDbCommand cmd = new OleDbCommand("select * from student;", conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable studentTable = new DataTable();
            da.Fill(studentTable);
            dgvStudent.DataSource = studentTable;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            FormModify formModify = new FormModify();
            formModify.Show();
            this.Hide();
        }
    }
}
