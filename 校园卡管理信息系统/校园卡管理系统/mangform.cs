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
    public partial class mangform : Form
    {
        public static string account;
        public mangform()
        {
            InitializeComponent();
        }
            

        private void 为学生办理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox2.Parent = this;
            groupBox2.Visible = true;
            groupBox1.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
            groupBox8.Visible = false;
        }

        private void 删除学生卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox3.Parent = this;
            groupBox3.Visible = true;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
            groupBox8.Visible = false;
            
        }

        private void mangform_Load(object sender, EventArgs e)
        {

        }

        private void 挂失ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void 挂失学生卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            groupBox1.Parent = this;
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
            groupBox8.Visible = false;
        }

        private void 查询消费记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox4.Parent = this;
            groupBox4.Visible = true;
            groupBox1.Visible = false;
            groupBox3.Visible = false;
            groupBox2.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
            groupBox8.Visible = false;
           
        }

        private void 查询充值记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            groupBox5.Parent = this;
            groupBox5.Visible = true;
            groupBox1.Visible = false;
            groupBox3.Visible = false;
            groupBox2.Visible = false;
            groupBox4.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
            groupBox8.Visible = false;
        }

        private void 修改学生密码ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            groupBox7.Parent = this;
            groupBox7.Visible = true;
            groupBox1.Visible = false;
            groupBox3.Visible = false;
            groupBox2.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox8.Visible = false;
        }


        private void 删除卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login f = new login();
            f.Show();
            this.Hide();
        }

        private void 查询学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            groupBox6.Parent = this;
            groupBox6.Visible = true;
            groupBox1.Visible = false;
            groupBox3.Visible = false;
            groupBox2.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox7.Visible = false;
            groupBox8.Visible = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "挂失";
            string lastp = textBox1.Text;
            using (SqlConnection conn = new SqlConnection(@"Data Source= PC-20140530JSPN;Initial Catalog=xiaoyuanka;User ID=sa;Password=wjn021221"))
            {
                conn.Open();//连接数据库

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from student where account='" + lastp + "'";
                    //查找数据库里是否有该用户名

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            {

                                if (lastp == reader[0].ToString().Trim())
                                {
                                    cmd.CommandText = "update student set states ='" + s + "'where account ='" + lastp + "'";
                                    reader.Close();
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("挂失成功！");
               
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = "正常";
            string lastp = textBox1.Text;
            using (SqlConnection conn = new SqlConnection(@"Data Source= PC-20140530JSPN;Initial Catalog=xiaoyuanka;User ID=sa;Password=wjn021221"))
            {
                conn.Open();//连接数据库

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from student where account='" + lastp + "'";
                    //查找数据库里是否有该用户名

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            {

                                if (lastp == reader[0].ToString().Trim())
                                {
                                    cmd.CommandText = "update student set states ='" + s + "'where account ='" + lastp + "'";
                                    reader.Close();
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("解挂成功！");
                                    
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //将注册信息写入数据库
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source= PC-20140530JSPN;Initial Catalog=xiaoyuanka;User ID=sa;Password=wjn021221";
            connection.Open();
            if (textBox7.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("必填信息不能为空！");
                return;
            }
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("两次输入密码不一致！");
            }
            string sSQL = "select * from student";
            SqlCommand cmd = new SqlCommand(sSQL, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr[0].ToString().Trim() == textBox7.Text)
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
            row["account"] = textBox7.Text;
            row["password"] = textBox2.Text;
            row["sex"] = textBox4.Text;
            row["name"] = textBox5.Text;
            row["collge"] = comboBox1.Text;
            row["speciality"] = comboBox2.Text;
            row["phone"] = textBox8.Text;
            row["email"] = textBox6.Text;
            row["balance"] = 0;
            row["states"] = "正常";
            ds.Tables["student"].Rows.Add(row);
            adapter.Update(ds, "student");
            connection.Close();
            MessageBox.Show("注册成功！");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=PC-20140530JSPN;Initial Catalog=xiaoyuanka;User ID=sa;Password=wjn021221"))
            {
                conn.Open();//连接数据库
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    string userdeleteID = textBox9.Text;
                    if (userdeleteID == "")
                    {
                        MessageBox.Show("请先输入要删除的用户ID！");
                    }
                    else
                    {
                        cmd.CommandText = "select * from student where account='" + userdeleteID + "'";
                        //查找数据库里是否有该用户名
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                string username = reader.GetString(1);
                                reader.Close();
                                if (MessageBox.Show("确定要删除用户“" + userdeleteID + "”吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    if (textBox9.Text == "")
                                    {
                                        MessageBox.Show("请先输入要删除的用户ID！");
                                        return;
                                    }
                                    try
                                    {
                                        cmd.CommandText = "delete  from student where account='" + userdeleteID + "'";
                                        cmd.ExecuteNonQuery();
                                        cmd.CommandText = "delete  from consume where account='" + userdeleteID + "'";
                                        cmd.ExecuteNonQuery();
                                        cmd.CommandText = "delete  from recharge where account='" + userdeleteID + "'";
                                        cmd.ExecuteNonQuery();
                                        MessageBox.Show("删除成功！");
                                        return;
                                    }
                                    catch (SqlException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }

                                    this.Close();
                                }
                            }

                        }
                    }
                }

                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            groupBox8.Parent = this;
            groupBox8.Visible = true;
            groupBox1.Visible = false;
            groupBox3.Visible = false;
            groupBox2.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string connectionstring = "Data Source= PC-20140530JSPN;Initial Catalog=xiaoyuanka;User ID=sa;Password=wjn021221";
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlConnection cn = new SqlConnection(connectionstring);
            cn.Open();
            SqlParameter sq, time1, time2;
            string str = "select * from consume  where account = @account and  time > =@time1 and time < =@time2 ";
            SqlCommand cmd = new SqlCommand(str, cn);
            sq = cmd.Parameters.Add("@account", SqlDbType.VarChar);
            time1 = cmd.Parameters.Add("@time1", SqlDbType.Int);
            time2 = cmd.Parameters.Add("@time2", SqlDbType.Int);
            if (textBox12.Text == "" || textBox11.Text == "" || textBox10.Text == "")
            {
                MessageBox.Show("请填写完整的查询条件！");
                return;
            }
            sq.Value = textBox12.Text;
            time1.Value = Convert.ToInt64(textBox11.Text);
            time2.Value = Convert.ToInt64(textBox10.Text);
            adapter.SelectCommand = cmd;
            SqlCommandBuilder cmdbuilder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet("consume");
            adapter.Fill(ds, "consume");

            BindingSource bs = new BindingSource(ds, "consume");
            dataGridView1.DataSource = bs;
            cn.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string connectionstring = "Data Source=PC-20140530JSPN;Initial Catalog=xiaoyuanka;User ID=sa;Password=wjn021221";
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlConnection cn = new SqlConnection(connectionstring);
            cn.Open();
            SqlParameter sq, time1, time2;
            string str = "select * from recharge  where account = @account and  time > =@time1 and time < =@time2 ";
            SqlCommand cmd = new SqlCommand(str, cn);
            sq = cmd.Parameters.Add("@account", SqlDbType.VarChar);
            time1 = cmd.Parameters.Add("@time1", SqlDbType.Int);
            time2 = cmd.Parameters.Add("@time2", SqlDbType.Int);
            if (textBox15.Text == "" || textBox14.Text == "" || textBox13.Text == "")
            {
                MessageBox.Show("请填写完整的查询条件！");
                return;
            }
            sq.Value = textBox15.Text;
            time1.Value = Convert.ToInt64(textBox14.Text);
            time2.Value = Convert.ToInt64(textBox13.Text);

            adapter.SelectCommand = cmd;
            SqlCommandBuilder cmdbuilder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet("recharge");
            adapter.Fill(ds, "recharge");

            BindingSource bs = new BindingSource(ds, "recharge");
            dataGridView2.DataSource = bs;
            cn.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string connectionstring = "Data Source= PC-20140530JSPN;Initial Catalog=xiaoyuanka;User ID=sa;Password=wjn021221";
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlConnection cn = new SqlConnection(connectionstring);
            cn.Open();
            SqlParameter sq;
            string str = "select account,sex,name,collge,states,speciality,phone,email,balance from student  where account = @account";
            SqlCommand cmd = new SqlCommand(str, cn);
            sq = cmd.Parameters.Add("@account", SqlDbType.VarChar);
            if (textBox16.Text == "")
            {
                MessageBox.Show("请填写完整的查询条件！");
                return;
            }
            sq.Value = textBox16.Text;
            adapter.SelectCommand = cmd;
            SqlCommandBuilder cmdbuilder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet("student");
            adapter.Fill(ds, "student");

            BindingSource bs = new BindingSource(ds, "student");
            dataGridView3.DataSource = bs;
            cn.Close();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void button13_Click_1(object sender, EventArgs e)
        {
            string lastp = textBox19.Text;
            string newp = textBox18.Text;
            string newp2 = textBox17.Text;
            using (SqlConnection conn = new SqlConnection(@"Data Source=PC-20140530JSPN;Initial Catalog=xiaoyuanka;User ID=sa;Password=wjn021221"))
            {
                conn.Open();//连接数据库

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from student where account='" + lastp + "'";
                    //查找数据库里是否有该用户名
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (lastp != "")
                            {
                                if (reader[0].ToString().Trim() == lastp)
                                {
                                    if (newp == newp2)
                                    {
                                        cmd.CommandText = "update student set password ='" + newp + "'where account ='" + lastp + "'";
                                        reader.Close();
                                        cmd.ExecuteNonQuery();
                                        MessageBox.Show("修改密码成功！");
                                    
                                    }
                                    else
                                    {
                                        MessageBox.Show("您两次输入的密码不同！请重新输入！");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("您输入的当前密码错误！请重新输入！");
                                }
                            }
                            else
                            {
                                MessageBox.Show("请先输入当前密码！");
                            }
                        }
                    }
                }
                conn.Close();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            groupBox8.Parent = this;
            groupBox8.Visible = true;
            groupBox1.Visible = false;
            groupBox3.Visible = false;
            groupBox2.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            groupBox8.Parent = this;
            groupBox8.Visible = true;
            groupBox1.Visible = false;
            groupBox3.Visible = false;
            groupBox2.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            groupBox8.Parent = this;
            groupBox8.Visible = true;
            groupBox1.Visible = false;
            groupBox3.Visible = false;
            groupBox2.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBox8.Parent = this;
            groupBox8.Visible = true;
            groupBox1.Visible = false;
            groupBox3.Visible = false;
            groupBox2.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            groupBox8.Parent = this;
            groupBox8.Visible = true;
            groupBox1.Visible = false;
            groupBox3.Visible = false;
            groupBox2.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox8.Parent = this;
            groupBox8.Visible = true;
            groupBox1.Visible = false;
            groupBox3.Visible = false;
            groupBox2.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
        }


       
    }
}
