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
    public partial class Form36 : Form
    {
        public static string account;
        public Form36()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionstring = "Data Source= GATEWAY-PC;Initial Catalog=xiaoyuanka;User ID=sa;Password=niit#1234";
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlConnection cn = new SqlConnection(connectionstring);
            cn.Open();
            SqlParameter sq;
            string str = "select account,sex,name,collge,states,speciality,phone,email,balance from teacher  where account = '" + account + "' ";
            SqlCommand cmd = new SqlCommand(str, cn);
            sq = cmd.Parameters.Add("account", SqlDbType.VarChar);
            sq.Value = account;
            adapter.SelectCommand = cmd;
            SqlCommandBuilder cmdbuilder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet("teacher");
            adapter.Fill(ds, "teacher");

            BindingSource bs = new BindingSource(ds, "teacher");
            dataGridView1.DataSource = bs;
            cn.Close();
        }
        }
    }

