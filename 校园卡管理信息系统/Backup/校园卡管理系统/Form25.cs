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
    public partial class Form25 : Form
    {
        public static string account;
        public Form25()
        {
            InitializeComponent();
        }

        private void 开始查询_Click(object sender, EventArgs e)
        {
            string connectionstring = "Data Source= GATEWAY-PC;Initial Catalog=xiaoyuanka;User ID=sa;Password=niit#1234";
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlConnection cn = new SqlConnection(connectionstring);
            cn.Open();
            SqlParameter sq;
            string str = "select account,sex,name,collge,states,speciality,phone,email,balance from student  where account = '" + account + "' ";
            SqlCommand cmd = new SqlCommand(str, cn);
            sq = cmd.Parameters.Add("account", SqlDbType.VarChar);
            sq.Value = account;
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
