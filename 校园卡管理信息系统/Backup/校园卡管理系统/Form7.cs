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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
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
            string sSQL = "select * from teacher";
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
            SqlDataAdapter adapter = new SqlDataAdapter("select * from teacher ", connection);
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet("teacher");
            adapter.Fill(ds, "teacher");
            DataRow row = ds.Tables["teacher"].NewRow();
            row["account"] = textBox1.Text;
            row["password"] = textBox2.Text;
            row["passwordagain"] = textBox3.Text;
            row["sex"] = textBox4.Text;
            row["name"] = textBox5.Text;
            row["collge"] = comboBox1.Text;
            row["speciality"] = comboBox2.Text;
            row["phone"] = textBox8.Text;
            row["email"] = textBox6.Text;
            row["balance"] = 0;
            row["states"] = "正常";
            ds.Tables["teacher"].Rows.Add(row);
            adapter.Update(ds, "teacher");
            connection.Close();
            MessageBox.Show("注册成功！");
            this.Close();
        }
    }
}
