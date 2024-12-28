using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Baitaplon
{

    public partial class Giaodienchinh : Form
    {
        private int sttx;

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-5DF9QTR\\SQLEXPRESS;Initial Catalog=BAITAPLON;Integrated Security=True");
        public static object DataGridView2 { get; internal set; }

        public Giaodienchinh()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = ColorTranslator.FromHtml("#F29F05");
            label2.BackColor = panel1.BackColor;
        }

        private void Giaodienchinh_Load(object sender, EventArgs e)
        {
            // Thiết lập chế độ hiển thị cho DataGridView2
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Mở kết nối nếu đang đóng
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            // Lấy dữ liệu cho DataGridView1
            string sql = "SELECT * FROM Monhoc";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();

            // Gán dữ liệu vào DataGridView1
            dataGridView1.DataSource = tb;
            dataGridView1.Refresh();

            // Tải dữ liệu đã đăng ký vào DataGridView2
            dataGridView2.Rows.Clear();
            LoadData();

            // Thêm cột nút "Hủy đăng ký" vào DataGridView2
            AddCancelButtonColumn();
            // Kiểm tra trùng lặp và vô hiệu hóa các nút trong DataGridView1
            CheckDuplicateAndDisableButtons();
            FormatDataGridView(dataGridView1);
            FormatDataGridView(dataGridView2);
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra chỉ số hàng và cột
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Kiểm tra nếu là cột nút
                if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    // Lấy giá trị nút hiện tại
                    var buttonCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    if (buttonCell.Value != null)
                    {
                        string buttonText = buttonCell.Value.ToString();

                        if (buttonText == "Đã đăng ký")
                        {
                            // Hiển thị thông báo nếu đã đăng ký
                            buttonCell.ReadOnly = true;
                        }
                        else
                        {
                            // Lấy thông tin từ hàng được chọn
                            string maHocPhan = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                            string tenHocPhan = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                            int stc = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                            // Thực hiện logic mở form
                            FormDangKy formDangKy = new FormDangKy(this, maHocPhan, stc, sttx);
                            formDangKy.Show();
                            sttx++;
                        }
                    }
                }
            }
        }   
       
        private void LoadData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-5DF9QTR\\SQLEXPRESS;Initial Catalog=BAITAPLON;Integrated Security=True"))
                {
                    con.Open();
                    string query = "SELECT * FROM Ketquadangky"; // Đảm bảo đây là dữ liệu đã đăng ký
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView2.Rows.Clear(); // Xóa tất cả các dòng cũ trong dataGridView2

                    foreach (DataRow row in dataTable.Rows)
                    {
                        string maHocPhan = row["mahocphan"]?.ToString();
                        if (string.IsNullOrEmpty(maHocPhan))
                            continue;

                        // Kiểm tra xem mã học phần đã tồn tại trong dataGridView2 chưa
                        bool isExist = false;
                        foreach (DataGridViewRow existingRow in dataGridView2.Rows)
                        {
                            if (existingRow.Cells["mahocphankq"]?.Value?.ToString() == maHocPhan)
                            {
                                isExist = true;
                                break;
                            }
                        }

                        // Nếu chưa tồn tại thì thêm vào DataGridView2
                        if (!isExist)
                        {
                            dataGridView2.Rows.Add(row["stt"], row["mahocphan"], row["loai"], row["malhp"], row["tenlhp"], row["stc"], row["gv"], row["lichhoc"], row["tungay"], row["denngay"]);
                        }
                    }

                    // Đặt thuộc tính giao diện
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dataGridView2.DefaultCellStyle.Font = new Font("Segoe UI", 8);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class DataGridViewDisableButtonCell : DataGridViewButtonCell
        {
            public bool Enabled { get; set; } = true;

            protected override void Paint(
                Graphics graphics,
                Rectangle clipBounds,
                Rectangle cellBounds,
                int rowIndex,
                DataGridViewElementStates elementState,
                object value,
                object formattedValue,
                string errorText,
                DataGridViewCellStyle cellStyle,
                DataGridViewAdvancedBorderStyle advancedBorderStyle,
                DataGridViewPaintParts paintParts)
            {
                // Vẽ nút bình thường nếu Enabled = true
                if (this.Enabled)
                {
                    base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
                }
                else
                {
                    // Nếu bị vô hiệu hóa, đổi màu để thể hiện
                    ButtonRenderer.DrawButton(graphics, cellBounds, PushButtonState.Disabled);

                    // Vẽ nội dung văn bản
                    TextRenderer.DrawText(
                        graphics,
                        formattedValue?.ToString(),
                        cellStyle.Font,
                        cellBounds,
                        cellStyle.ForeColor,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                    );
                }
            }
        }
        private void AddCancelButtonColumn()
        {
            DataGridViewButtonColumn cancelColumn = new DataGridViewButtonColumn();
            cancelColumn.Name = "CancelColumn";
            cancelColumn.HeaderText = "Hủy đ.ký";
            cancelColumn.Text = "Hủy";
            cancelColumn.UseColumnTextForButtonValue = true; // Hiển thị chữ "Hủy" trên nút
            cancelColumn.Width = 15; // Đặt chiều rộng cột nhỏ

            // Đặt font chữ và kích thước nhỏ hơn cho nút
            cancelColumn.DefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            cancelColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView2.Columns.Add(cancelColumn);
        }
        private void FormatDataGridView(DataGridView gridView)
        {
            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tự động căn chỉnh cột
            gridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa tiêu đề
            gridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; // Căn trái nội dung
            gridView.DefaultCellStyle.Font = new Font("Segoe UI", 8); // Đặt font chữ
            gridView.DefaultCellStyle.ForeColor = Color.Black; // Màu chữ
            gridView.DefaultCellStyle.BackColor = Color.White; // Màu nền
            gridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // Màu nền xen kẽ
            gridView.EnableHeadersVisualStyles = false; // Tắt hiệu ứng mặc định của header
            gridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue; // Màu nền header
            gridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; // Màu chữ header
        }

        public void CheckDuplicateAndDisableButtons()
        {
            foreach (DataGridViewRow row1 in dataGridView1.Rows)
            {
                string maHocPhan1 = row1.Cells["mahocphan"]?.Value?.ToString()?.Trim();

                if (string.IsNullOrEmpty(maHocPhan1))
                    continue;

                bool isDuplicate = false;

                foreach (DataGridViewRow row2 in dataGridView2.Rows)
                {
                    string maHocPhan2 = row2.Cells["mahocphankq"]?.Value?.ToString()?.Trim();

                    if (maHocPhan1 == maHocPhan2)
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                if (isDuplicate)
                {
                    // Thay đổi giao diện nút
                    var buttonCell = row1.Cells["dangky"] as DataGridViewButtonCell;
                    if (buttonCell != null)
                    {
                        buttonCell.Style.ForeColor = Color.Gray;
                        buttonCell.Style.BackColor = Color.LightGray;
                        buttonCell.Value = "Đã đăng ký";

                        // Vô hiệu hóa nút bằng cách hủy sự kiện
                        buttonCell.Tag = "disabled"; // Gắn cờ để biết nút này đã vô hiệu
                    }
                }
            }
        }
      

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Kiểm tra nếu người dùng click vào cột "CancelColumn"
                if (dataGridView2.Columns[e.ColumnIndex].Name == "CancelColumn")
                {
                    string maLHP = dataGridView2.Rows[e.RowIndex].Cells["mahocphankq"]?.Value?.ToString(); // Lấy mã học phần từ cột "mahocphankq"

                    if (!string.IsNullOrEmpty(maLHP))
                    {
                        DialogResult confirmResult = MessageBox.Show(
                            "Bạn có chắc chắn muốn hủy đăng ký lớp học này?",
                            "Xác nhận hủy đăng ký",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning
                        );

                        if (confirmResult == DialogResult.Yes)
                        {
                            try
                            {
                                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-5DF9QTR\\SQLEXPRESS;Initial Catalog=BAITAPLON;Integrated Security=True"))
                                {
                                    con.Open();
                                    string query = "DELETE FROM Ketquadangky WHERE malhp = @malhp";
                                    using (SqlCommand cmd = new SqlCommand(query, con))
                                    {
                                        cmd.Parameters.AddWithValue("@malhp", maLHP);
                                        cmd.ExecuteNonQuery();
                                    }
                                }

                                // Xóa dòng đã đăng ký trong dataGridView2
                                dataGridView2.Rows.RemoveAt(e.RowIndex);

                                // Cập nhật lại dataGridView1 nếu tìm thấy mã học phần
                                foreach (DataGridViewRow row in dataGridView1.Rows)
                                {
                                    if (row.Cells["mahocphan"]?.Value?.ToString() == maLHP) // So sánh với tên cột "mahocphan" trong dataGridView1
                                    {
                                        var buttonCell = row.Cells["dangky"] as DataGridViewButtonCell;
                                        if (buttonCell != null)
                                        {
                                            buttonCell.Style.ForeColor = Color.Black;
                                            buttonCell.Style.BackColor = Color.White;
                                            buttonCell.Value = "Đăng ký"; // Cập nhật lại nút Đăng ký
                                        }
                                        break;
                                    }
                                }

                                MessageBox.Show("Hủy đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Lỗi khi hủy đăng ký: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy mã lớp học phần.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        }
        }
