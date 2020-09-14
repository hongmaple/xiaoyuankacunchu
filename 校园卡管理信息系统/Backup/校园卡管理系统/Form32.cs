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
    public partial class Form32 : Form
    {
        public static string account;
        public static string str;
        public Form32()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            str = textBox1.Text;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source= GATEWAY-PC;Initial Catalog=xiaoyuanka;User ID=sa;Password=niit#1234";
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from recharge ", connection);
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet("recharge");
            adapter.Fill(ds, "recharge");
            //adapter.Fill(ds, "student");
            DataRow row = ds.Tables["recharge"].NewRow();
            row["account"] = account;
            row["amount"] = textBox1.Text;
            row["time"] = Convert.ToInt32(textBox2.Text);
            ds.Tables["recharge"].Rows.Add(row);
            adapter.Update(ds, "recharge");
            connection.Close();

            using (SqlConnection conn = new SqlConnection(@"Data Source= GATEWAY-PC;Initial Catalog=xiaoyuanka;User ID=sa;Password=niit#1234"))
            {
                conn.Open();//连接数据库

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    SqlParameter sq;
                    cmd.CommandText = "select * from teacher where account='" + account + "'";
                    sq = cmd.Parameters.Add(account, SqlDbType.VarChar);
                    sq.Value =Form32.account;
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
                                    int cfe = Int32.Parse(Form32.str);
                                    int bookresultnum = yue + cfe;
                                    cmd.CommandText = "update teacher set balance =" + bookresultnum + " where account='" + account + "'";
                                    reader.Close();
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("充值成功！");
                                    this.Close();
                                }
                            }
                        }
                    }
                }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        }
    }

        
    

