using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitaplon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void login_Click(object sender, EventArgs e)
        {
            // Ẩn mật khẩu khi nhập
            txtPassword.UseSystemPasswordChar = true;

            // Lấy dữ liệu từ TextBox
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Kiểm tra nếu Username hoặc Password trống
            if (string.IsNullOrEmpty(username))
            {
                lblError.Text = "Tên đăng nhập là bắt buộc!";
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Font = new System.Drawing.Font(lblError.Font, System.Drawing.FontStyle.Bold);
                return;
            }
            else if (string.IsNullOrEmpty(password))
            {
                lblError.Text = "Mật khẩu là bắt buộc!";
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Font = new System.Drawing.Font(lblError.Font, System.Drawing.FontStyle.Bold);
                return;
            }

            // Kết nối với cơ sở dữ liệu
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-5DF9QTR\\SQLEXPRESS;Initial Catalog=BAITAPLON;Integrated Security=True"))
            {
                try
                {
                    con.Open();
                    // Truy vấn kiểm tra Username và Password từ CSDL
                    string query = "SELECT UserID FROM Users WHERE Username = @Username AND Password = @Password";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password); // Lưu ý: Hash mật khẩu nếu cần

                    object result = cmd.ExecuteScalar(); // Lấy UserID nếu tìm thấy

                    if (result != null) // Đăng nhập thành công
                    {
                        // Mở Form Giaodienchinh
                        Giaodienchinh mainForm = new Giaodienchinh();
                        mainForm.Show();

                        // Ẩn Form hiện tại
                        this.Hide();
                    }
                    else
                    {
                        // Hiển thị thông báo lỗi
                        lblError.Text = "Tài khoản hoặc mật khẩu không chính xác!";
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Font = new System.Drawing.Font(lblError.Font, System.Drawing.FontStyle.Bold);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(222, 255, 255, 255);  // Màu trắng nhẹ với độ trong suốt
            lbl1.BackColor = panel1.BackColor;
            lbl2.BackColor = panel1.BackColor;
            lbl3.BackColor = panel1.BackColor;
            lbl4.BackColor = panel1.BackColor;
            pictureBox1.BackColor = panel1.BackColor;
            login.BackColor = panel1.BackColor;
            lblError.BackColor = panel1.BackColor;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '●';
        }
    }
}



