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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Baitaplon
{
    public partial class FormDangKy : Form

    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-5DF9QTR\\SQLEXPRESS;Initial Catalog=BAITAPLON;Integrated Security=True");
        private string maHocPhan;

        private Giaodienchinh giaodienchinh;
        private int stc;
        private int stt;
        public FormDangKy(Giaodienchinh giaodienchinh, string maHocPhan, int stc, int stt)
        {
            InitializeComponent();
            this.giaodienchinh = giaodienchinh;
            this.maHocPhan = maHocPhan;
            this.stc = stc;
            this.stt = stt;
        }


        private void FormDangKy_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "";
            switch (maHocPhan)
            {
                case "DC2HT26":
                    sql = "Select loai,malhp,sltoida,sldangky,slconlai,gv,lichhoc,ghichu from DC2HT26";
                    lbl.Text = "DC2HT26 - Cấu trúc dữ liệu và giải thuật";
                    lbl.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold); 
                    break;
                case "DC2HT38":
                    sql = "Select loai,malhp,sltoida,sldangky,slconlai,gv,lichhoc,ghichu from DC2HT38";
                    lbl.Text = "DC2HT38 - Công nghệ phần mềm";
                    lbl.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
                    break;
                case "DC2HT42":
                    sql = "Select loai,malhp,sltoida,sldangky,slconlai,gv,lichhoc,ghichu from DC2HT42";
                    lbl.Text = "DC2HT42 - Toán học rời rạc";
                    lbl.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
                    break;
                case "DC3HT21":
                    sql = "Select loai,malhp,sltoida,sldangky,slconlai,gv,lichhoc,ghichu from DC3HT21";
                    lbl.Text = "DC3HT21 - Hệ quản trị Cơ sở dữ liệu";
                    lbl.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
                    break;
                case "DC3HT51":
                    sql = "Select loai,malhp,sltoida,sldangky,slconlai,gv,lichhoc,ghichu from DC3HT51";
                    lbl.Text = "DC3HT51 - An toàn và bảo mật hệ thống thông tin";
                    lbl.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
                    break;
                default:
                    MessageBox.Show("Mã học phần không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            // Thực thi SQL
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);

            // Giải phóng tài nguyên và đóng kết nối
            cmd.Dispose();
            con.Close();

            // Gán kết quả vào DataGridView
            dataGridView1.DataSource = tb;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.Refresh();
        }

        private void quaylai_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem ô được click có phải là cột checkbox hay không
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    // Bỏ chọn tất cả checkbox khác ngoại trừ checkbox vừa click
                    if (row.Index != e.RowIndex)
                    {
                        row.Cells[0].Value = false; // "Chon" là tên cột checkbox
                    }
                }

                // Đảm bảo checkbox hiện tại được chọn
                dataGridView1.Rows[e.RowIndex].Cells[0].Value = !(bool)dataGridView1.Rows[e.RowIndex].Cells[0].EditedFormattedValue;
            }
        }
        public (DateTime? tungay, DateTime? denngay) GetNgayByMalhp(string malhp)
        { 

            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-5DF9QTR\\SQLEXPRESS;Initial Catalog=BAITAPLON;Integrated Security=True"))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string sql = "";
                switch (maHocPhan)
                {
                    case "DC2HT26":
                        sql = "Select tungay,denngay from DC2HT26 WHERE malhp = @malhp";
                        lbl.Text = "DC2HT26 - Cấu trúc dữ liệu và giải thuật";
                        lbl.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
                        break;
                    case "DC2HT38":
                        sql = "Select tungay,denngay from DC2HT38 WHERE malhp = @malhp";
                        lbl.Text = "DC2HT38 - Công nghệ phần mềm";
                        lbl.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
                        break;
                    case "DC2HT42":
                        sql = "Select tungay,denngay from DC2HT42 WHERE malhp = @malhp";
                        lbl.Text = "DC2HT42 - Toán học rời rạc";
                        lbl.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
                        break;
                    case "DC3HT21":
                        sql = "Select tungay,denngay from DC3HT21 WHERE malhp = @malhp";
                        lbl.Text = "DC3HT21 - Hệ quản trị Cơ sở dữ liệu";
                        lbl.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
                        break;
                    case "DC3HT51":
                        sql = "Select tungay,denngay from DC3HT51 WHERE malhp = @malhp";
                        lbl.Text = "DC3HT51 - An toàn và bảo mật hệ thống thông tin";
                        lbl.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
                        break;
                }

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@malhp", malhp);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DateTime? tungay = null; 
                            DateTime? denngay = null; 
                            if (reader["tungay"] != DBNull.Value) 
                            { 
                                tungay = ((DateTime)reader["tungay"]).Date; 
                            }
                            if (reader["denngay"] != DBNull.Value)
                            {
                                denngay = ((DateTime)reader["denngay"]).Date;
                            }
                            return (tungay, denngay);
                        }
                        else
                        {
                            return (null, null);
                        }
                    }
                }
            }
        }
        private void dangky_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-5DF9QTR\\SQLEXPRESS;Initial Catalog=BAITAPLON;Integrated Security=True"))
            {
                con.Open();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];

                    if (chk.Value != null && (bool)chk.Value == true)
                    {
                        string malhp = row.Cells["MaLHP"].Value.ToString();
                        string loai = row.Cells["Loai"].Value.ToString();
                        string tenlhp = lbl.Text.ToString();
                        string gv = row.Cells["GV"].Value.ToString();
                        string lichhoc = row.Cells["Lichhoc"].Value.ToString();
                        string tungay = GetNgayByMalhp(malhp).tungay.Value.ToString("yyyy-MM-dd");
                        string denngay = GetNgayByMalhp(malhp).denngay.Value.ToString("yyyy-MM-dd");
                        string mahocphan = maHocPhan;
                        string query = "INSERT INTO Ketquadangky (mahocphan, loai, malhp, tenlhp, stc, gv, lichhoc, tungay, denngay) " +
                                       "VALUES (@mahocphan, @loai, @malhp, @tenlhp, @stc, @gv, @lichhoc, @tungay, @denngay)";
                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.AddWithValue("@mahocphan", mahocphan);
                        cmd.Parameters.AddWithValue("@loai", loai);
                        cmd.Parameters.AddWithValue("@malhp", malhp);
                        cmd.Parameters.AddWithValue("@tenlhp", tenlhp);
                        cmd.Parameters.AddWithValue("@gv", gv);
                        cmd.Parameters.AddWithValue("@stc", stc);
                        cmd.Parameters.AddWithValue("@lichhoc", lichhoc);
                        cmd.Parameters.AddWithValue("@tungay", tungay);
                        cmd.Parameters.AddWithValue("@denngay", denngay);

                        cmd.ExecuteNonQuery();

                        if (giaodienchinh != null && giaodienchinh.dataGridView2 != null)
                        {
                            giaodienchinh.dataGridView2.Rows.Add(stt, mahocphan, loai, malhp, tenlhp, stc, gv, lichhoc, tungay, denngay);
                            giaodienchinh.CheckDuplicateAndDisableButtons();
                        }
                        else
                        {
                            MessageBox.Show("Giaodienchinh hoặc dataGridView2 chưa được khởi tạo", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        this.Hide();
                    }
                }

                MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void LoadCourses()
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-5DF9QTR\\SQLEXPRESS;Initial Catalog=BAITAPLON;Integrated Security=True"))
            {
                con.Open();

                string query = "SELECT MaLHP, Loai, GV, Lichhoc, STC FROM Courses";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                // Kiểm tra trạng thái đăng ký
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string malhp = row.Cells["MaLHP"].Value.ToString();
                    string checkQuery = "SELECT COUNT(*) FROM Ketquadangky WHERE malhp = @malhp";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                    checkCmd.Parameters.AddWithValue("@malhp", malhp);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0) // Nếu môn học đã được đăng ký
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["Chon"];
                        chk.Value = false;
                        chk.FlatStyle = FlatStyle.Flat;
                        row.DefaultCellStyle.ForeColor = Color.Gray; // Tô màu xám để biết rằng môn học đã được đăng ký
                    }
                }

                con.Close();
            }
        }

    }
}
