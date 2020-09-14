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
    public partial class frmadd : Form
    {
        public frmadd()
        {
            InitializeComponent();
        }


        private void FrmAdd_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //将注册信息写入数据库
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source= GATEWAY-PC;Initial Catalog=xiaoyuanka;User ID=sa;Password=niit#1234";
            connection.Open(); 
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("必填信息不能为空！");
                return;
            }
            string sSQL = "select * from student";
            SqlCommand cmd = new SqlCommand(sSQL, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr[0].ToString().Trim() == textBox1.Text)
                {
                    MessageBox.Show("该用户已存在，不可重复注册！");
                    return;
                }
            }
            dr.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from student ", connection);
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet("student");
            adapter.Fill(ds, "student");
            DataRow row = ds.Tables["student"].NewRow();
            row["account"] = textBox1.Text;
            row["password"] = textBox2.Text;
            row["passwordagain"] = textBox3.Text;
            row["sex"] = textBox4.Text;
            row["name"] = textBox5.Text;
            row["collge"] = comboBox1.Text;
            row["speciality"] = comboBox2.Text;
            row["phone"] = textBox8.Text; 
            row["email"] = textBox9.Text;
            row["balance"] = 0;
            row["states"] = "正常";
            ds.Tables["student"].Rows.Add(row);
            adapter.Update(ds, "student");
            connection.Close();
            MessageBox.Show("注册成功！");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
