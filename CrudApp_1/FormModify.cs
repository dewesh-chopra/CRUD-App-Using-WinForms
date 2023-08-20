using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CrudApp_1
{
    public partial class FormModify : Form
    {
        OleDbConnection conn;
        OleDbCommand cmd;
        
        public FormModify()
        {
            InitializeComponent();
        }

        private void FormModify_Load(object sender, EventArgs e)
        {
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source='C:/Users/Dewesh Chopra/Documents/DemoDB.accdb'");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int regnNo = Int32.Parse(tbRegnNo.Text);
            string name = tbName.Text;
            string subject = tbSubject.Text;
            conn.Open();
            string cmdStr = String.Format("insert into student values({0}, '{1}', '{2}');", regnNo, name, subject);
            cmd = new OleDbCommand(cmdStr, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("New record was added!", "SUCCESS");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int regnNo = Int32.Parse(tbRegnNo.Text);
            conn.Open();
            cmd = new OleDbCommand("select * from student where RegnNo = " + regnNo + ";", conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                tbRegnNo.Text = dr.GetInt32(0).ToString();
                tbName.Text = dr.GetString(1).ToString();
                tbSubject.Text = dr.GetString(2).ToString();
            }
            else
            {
                MessageBox.Show("Record was not found!", "ERROR");
            }
            conn.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int regnNo = Int32.Parse(tbRegnNo.Text);
            string name = tbName.Text;
            string subject = tbSubject.Text;
            conn.Open();
            string cmdStr = String.Format("update student set RegnNo = {0}, Name = '{1}', Subject = '{2}' where RegnNo = {3};", regnNo, name, subject, tbRegnNo.Text);
            cmd = new OleDbCommand(cmdStr, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Existing record was updated!", "SUCCESS");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int regnNo = Int32.Parse(tbRegnNo.Text);
            conn.Open();
            cmd = new OleDbCommand("delete from student where RegnNo = " + regnNo + ";", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Existing record was deleted!", "SUCCESS");
            tbRegnNo.Text = tbName.Text = tbSubject.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            FormDisplay formDisplay = new FormDisplay();
            formDisplay.Show();
            this.Dispose();
        }
    }
}
