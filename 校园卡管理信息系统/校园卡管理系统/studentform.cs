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
    public partial class studentform : Form
    {
        public static string account;
        public static string str;
        public studentform()
        {
            InitializeComponent();
        }

        private void 消费ToolStripMenuItem_Click(object sender, EventArgs e)
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
            groupBox9.Visible = false;
        }

        private void 充值ToolStripMenuItem_Click(object sender, EventArgs e)
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
            groupBox9.Visible = false;
        }

        private void 挂失解挂ToolStripMenuItem_Click(object sender, EventArgs e)
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
            groupBox9.Visible = false;
        }

        private void 查询消费ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            groupBox4.Parent = this;
            groupBox4.Visible = true;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
            groupBox8.Visible = false;
            groupBox9.Visible = false;
        }

        private void 查询充值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox5.Parent = this;
            groupBox5.Visible = true;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
            groupBox8.Visible = false;
            groupBox9.Visible = false;
        }

        private void 查询个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            groupBox6.Parent = this;
            groupBox6.Visible = true;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox7.Visible = false;
            groupBox8.Visible = false;
            groupBox9.Visible = false;
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            groupBox7.Parent = this;
            groupBox7.Visible = true;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox8.Visible = false;
            groupBox9.Visible = false;
        }

        private void 修改个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            groupBox8.Parent = this;
            groupBox8.Visible = true;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
            groupBox9.Visible = false;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login f = new login();
            f.Show();
            this.Hide();
        }

        private void studentform_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("请输入完整的消费信息！");
                return;
            }
            str = textBox1.Text;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source= PC-20140530JSPN;Initial Catalog=xiaoyuanka;User ID=sa;Password=wjn021221";
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from consume ", connection);
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet("consume");
            adapter.Fill(ds, "consume");
            //adapter.Fill(ds, "student");
            DataRow row = ds.Tables["consume"].NewRow();
            row["account"] = account;
            row["amount"] = textBox1.Text;
            row["time"] = Convert.ToInt32(textBox2.Text);
            row["address"] = textBox3.Text;
            ds.Tables["consume"].Rows.Add(row);
            adapter.Update(ds, "consume");
            connection.Close();
            using (SqlConnection conn = new SqlConnection(@"Data Source= PC-20140530JSPN;Initial Catalog=xiaoyuanka;User ID=sa;Password=wjn021221"))
            {
                conn.Open();//连接数据库

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    SqlParameter sq;
                    cmd.CommandText = "select * from student where account='" + account + "'";
                    sq = cmd.Parameters.Add(account, SqlDbType.VarChar);
                    sq.Value = studentform.account;
                    //查找数据库里是否有该用户名
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {


                        if (reader.Read())
                        {

                            if (@account == reader[0].ToString().Trim())
                            {
                                if (reader[6].ToString().Trim() == "挂失")
                                {
                                    MessageBox.Show("已挂失！");
                                    return;
                                }
                                int yue = reader.GetInt32(reader.GetOrdinal("balance"));
                                if (yue == 0)
                                {
                                    MessageBox.Show("余额不足，请充值!");
                                    return;
                                }
                                int xfe = Int32.Parse(studentform.str);
                                int bookresultnum = yue - xfe;
                                if (bookresultnum < 0)
                                {
                                    MessageBox.Show("余额不足，请充值!");
                                    return;
                                }
                                cmd.CommandText = "update student set balance =" + bookresultnum + " where account='" + account + "'";
                                reader.Close();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("消费成功！");
                                
                            }
                        }
                    }
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox9.Parent = this;
            groupBox9.Visible = true;
            groupBox8.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            str = textBox5.Text;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=PC-20140530JSPN;Initial Catalog=xiaoyuanka;User ID=sa;Password=wjn021221";
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from recharge ", connection);
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet("recharge");
            adapter.Fill(ds, "recharge");
            //adapter.Fill(ds, "student");
            DataRow row = ds.Tables["recharge"].NewRow();
            row["account"] = account;
            row["amount"] = textBox5.Text;
            row["time"] = Convert.ToInt32(textBox4.Text);
            ds.Tables["recharge"].Rows.Add(row);
            adapter.Update(ds, "recharge");
            connection.Close();

            using (SqlConnection conn = new SqlConnection(@"Data Source= PC-20140530JSPN;Initial Catalog=xiaoyuanka;User ID=sa;Password=wjn021221"))
            {
                conn.Open();//连接数据库

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    SqlParameter sq;
                    cmd.CommandText = "select * from student where account='" + account + "'";
                    sq = cmd.Parameters.Add(account, SqlDbType.VarChar);
                    sq.Value = studentform.account;
                    //查找数据库里是否有该用户名
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            if (@account == reader[0].ToString().Trim())
                            {
                                if (reader[6].ToString().Trim() == "挂失")
                                {
                                    MessageBox.Show("已挂失！");
                                    return;
                                }

                                int yue = reader.GetInt32(reader.GetOrdinal("balance"));
                                int cfe = Int32.Parse(studentform.str);
                                int bookresultnum = yue + cfe;
                                cmd.CommandText = "update student set balance =" + bookresultnum + " where account='" + account + "'";
                                reader.Close();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("充值成功！");
                                
                            }
                        }
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string s = "挂失";
            using (SqlConnection conn = new SqlConnection(@"Data Source= PC-20140530JSPN;Initial Catalog=xiaoyuanka;User ID=sa;Password=wjn021221"))
            {
                conn.Open();//连接数据库

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from student where account='" + account + "'";
                    //查找数据库里是否有该用户名

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            {

                                if (account == reader[0].ToString().Trim())
                                {
                                    cmd.CommandText = "update student set states ='" + s + "'where account ='" + account + "'";
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

        private void button6_Click(object sender, EventArgs e)
        {
            string s = "正常";
            using (SqlConnection conn = new SqlConnection(@"Data Source= PC-20140530JSPN;Initial Catalog=xiaoyuanka;User ID=sa;Password=wjn021221"))
            {
                conn.Open();//连接数据库

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from student where account='" + account + "'";
                    //查找数据库里是否有该用户名

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            {

                                if (account == reader[0].ToString().Trim())
                                {
                                    cmd.CommandText = "update student set states ='" + s + "'where account ='" + account + "'";
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

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
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
            sq.Value = studentform.account;
            time1.Value = Convert.ToInt64(textBox7.Text);
            time2.Value = Convert.ToInt64(textBox6.Text);
            adapter.SelectCommand = cmd;
            SqlCommandBuilder cmdbuilder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet("consume");
            adapter.Fill(ds, "consume");

            BindingSource bs = new BindingSource(ds, "consume");
            dataGridView1.DataSource = bs;
            cn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            string connectionstring = "Data Source= PC-20140530JSPN;Initial Catalog=xiaoyuanka;User ID=sa;Password=wjn021221";
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlConnection cn = new SqlConnection(connectionstring);
            cn.Open();
            SqlParameter sq, time1, time2;
            string str = "select * from recharge  where account = @account and  time > =@time1 and time < =@time2 ";
            SqlCommand cmd = new SqlCommand(str, cn);
            sq = cmd.Parameters.Add("@account", SqlDbType.VarChar);
            time1 = cmd.Parameters.Add("@time1", SqlDbType.Int);
            time2 = cmd.Parameters.Add("@time2", SqlDbType.Int);
            sq.Value = studentform.account;
            time1.Value = Convert.ToInt64(textBox9.Text);
            time2.Value = Convert.ToInt64(textBox8.Text);
            adapter.SelectCommand = cmd;
            SqlCommandBuilder cmdbuilder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet("recharge");
            adapter.Fill(ds, "recharge");

            BindingSource bs = new BindingSource(ds, "recharge");
            dataGridView2.DataSource = bs;
            cn.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            string connectionstring = "Data Source= PC-20140530JSPN;Initial Catalog=xiaoyuanka;User ID=sa;Password=wjn021221";
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
            dataGridView3.DataSource = bs;
            cn.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string lastp = textBox12.Text;
            string newp = textBox11.Text;
            string newp2 = textBox10.Text;
            using (SqlConnection conn = new SqlConnection(@"Data Source= PC-20140530JSPN;Initial Catalog=xiaoyuanka;User ID=sa;Password=wjn021221"))
            {
                conn.Open();//连接数据库

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from student where account='" + account + "'";
                    //查找数据库里是否有该用户名
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (lastp != "")
                            {
                                if (reader[1].ToString().Trim() == lastp)
                                {
                                    if (newp == newp2)
                                    {
                                        cmd.CommandText = "update student set password ='" + newp + "'where account ='" + account + "'";
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

        private void button17_Click(object sender, EventArgs e)
        {
            string a = textBox17.Text;
            string b = textBox16.Text;
            string c = textBox15.Text;
            string d = textBox14.Text;
            string g = textBox13.Text;
            using (SqlConnection conn = new SqlConnection(@"Data Source= PC-20140530JSPN;Initial Catalog=xiaoyuanka;User ID=sa;Password=wjn021221"))
            {
                conn.Open();//连接数据库
                string str = "update  student  set collge=@b, name =@a,speciality= @c, phone=@d,email =@g  where account =@account";
                SqlCommand cmd = new SqlCommand(str, conn);

                //   cmd.CommandText = "select * from student where account='" + account + "'";
                //查找数据库里是否有该用户名

                SqlParameter a1, b1, c1, d1, g1, acc;
                a1 = cmd.Parameters.Add("@a", SqlDbType.Char);
                b1 = cmd.Parameters.Add("@b", SqlDbType.Char);
                c1 = cmd.Parameters.Add("@c", SqlDbType.Char);
                d1 = cmd.Parameters.Add("@d", SqlDbType.Char);
                g1 = cmd.Parameters.Add("@g", SqlDbType.Char);
                acc = cmd.Parameters.Add("@account", SqlDbType.Char);
                a1.Value = a;
                b1.Value = b; c1.Value = c; d1.Value = d; g1.Value = g; acc.Value = studentform.account;

                cmd.ExecuteNonQuery();
                MessageBox.Show("修改成功");



            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox9.Parent = this;
            groupBox9.Visible = true;
            groupBox8.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox9.Parent = this;
            groupBox9.Visible = true;
            groupBox8.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBox9.Parent = this;
            groupBox9.Visible = true;
            groupBox8.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            groupBox9.Parent = this;
            groupBox9.Visible = true;
            groupBox8.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            groupBox9.Parent = this;
            groupBox9.Visible = true;
            groupBox8.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            groupBox9.Parent = this;
            groupBox9.Visible = true;
            groupBox8.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            groupBox9.Parent = this;
            groupBox9.Visible = true;
            groupBox8.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
        }
    }
}
