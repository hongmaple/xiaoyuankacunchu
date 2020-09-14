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
    public partial class selcz : Form
    {
        public selcz()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionstring = "Data Source= GATEWAY-PC;Initial Catalog=xiaoyuanka;User ID=sa;Password=niit#1234";
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlConnection cn = new SqlConnection(connectionstring);
            cn.Open();
            SqlParameter sq, time1, time2;
            string str = "select * from recharge  where account = @account and  time > =@time1 and time < =@time2 ";
            SqlCommand cmd = new SqlCommand(str, cn);
            sq = cmd.Parameters.Add("@account", SqlDbType.VarChar);
            time1 = cmd.Parameters.Add("@time1", SqlDbType.Int);
            time2 = cmd.Parameters.Add("@time2", SqlDbType.Int);
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("请填写完整的查询条件！");
                return;
            }
            sq.Value = textBox1.Text;
            time1.Value = Convert.ToInt64(textBox2.Text);
            time2.Value = Convert.ToInt64(textBox3.Text);
            
            adapter.SelectCommand = cmd;
            SqlCommandBuilder cmdbuilder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet("recharge");
            adapter.Fill(ds, "recharge");

            BindingSource bs = new BindingSource(ds, "recharge");
            dataGridView1.DataSource = bs;
            cn.Close();
        }
    }
}
