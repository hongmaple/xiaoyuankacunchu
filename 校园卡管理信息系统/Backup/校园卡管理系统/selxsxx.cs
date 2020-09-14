using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 校园卡管理系统
{
    public partial class selxsxx : Form
    {
        public selxsxx()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionstring = "Data Source= GATEWAY-PC;Initial Catalog=xiaoyuanka;User ID=sa;Password=niit#1234";
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlConnection cn = new SqlConnection(connectionstring);
            cn.Open();
            SqlParameter sq;// time1, time2;
            string str = "select account,sex,name,collge,states,speciality,phone,email,balance from student  where account = @account";
            SqlCommand cmd = new SqlCommand(str, cn);
            sq = cmd.Parameters.Add("@account", SqlDbType.VarChar);
            if (textBox1.Text == "")
            {
                MessageBox.Show("请填写完整的查询条件！");
                return;
            }
            sq.Value = textBox1.Text;
            adapter.SelectCommand = cmd;
            SqlCommandBuilder cmdbuilder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet("student");
            adapter.Fill(ds, "student");

            BindingSource bs = new BindingSource(ds, "student");
            dataGridView1.DataSource = bs;
            cn.Close();
        }
    }
}
  
   
