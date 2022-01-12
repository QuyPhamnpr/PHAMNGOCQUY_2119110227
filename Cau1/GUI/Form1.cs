using Cau1.BAL;
using Cau1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cau1
{
    public partial class Form1 : Form
    {
        Employee_2119110227_BAL EmployBAL = new Employee_2119110227_BAL();
        Department_2119110227_BAL DepartmentBAL = new Department_2119110227_BAL();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Employee_2119110227> lstEmploy = EmployBAL.ReadCustomer();
            foreach (Employee_2119110227 Emp in lstEmploy)
            {
                dgvCustomer.Rows.Add(Emp.IdEmployee, Emp.Name, Emp.DateBirth, Emp.Gender, Emp.PlaceBirth, Emp.Depart);

            }
            List<Department_2119110227> lstDepart = DepartmentBAL.ReadAreaList();
            foreach (Department_2119110227 depart in lstDepart)
            {
                cbDonVi.Items.Add(depart);
            }
            cbDonVi.DisplayMember = "Name_Department";
        }

        private void dgvCustomer_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dgvCustomer.Rows[idx];
            if (row.Cells[0].Value != null)
            {
                tbMa.Text = row.Cells[0].Value.ToString();
                tbHoTen.Text = row.Cells[1].Value.ToString();
                dtNgaySinh.Text = row.Cells[2].Value.ToString();
                cbGioiTinh.Text = row.Cells[3].Value.ToString();
                tbNoiSinh.Text = row.Cells[4].Value.ToString();
                cbDonVi.Text = row.Cells[5].Value.ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult f = MessageBox.Show("Bạn có muốn đóng chương trình không?", "Thong Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (f == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }
        public bool checkDulieu()
        {
            if (string.IsNullOrWhiteSpace(tbMa.Text))
            {
                MessageBox.Show("Chưa Nhập Mã", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbHoTen.Text))
            {
                MessageBox.Show("Chưa nhập Tên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbNoiSinh.Text))
            {
                MessageBox.Show("Chưa nhập Nơi Sinh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrWhiteSpace(dtNgaySinh.Text))
            {
                MessageBox.Show("Chưa nhập Ngày Sinh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbGioiTinh.Text))
            {
                MessageBox.Show("Chưa nhập Giới Tính", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbDonVi.Text))
            {
                MessageBox.Show("Chưa nhập Đơn Vị", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (checkDulieu())
            {
                Employee_2119110227 emp = new Employee_2119110227();
                emp.IdEmployee = tbMa.Text;
                emp.Name = tbHoTen.Text;
                emp.DateBirth = DateTime.Parse(dtNgaySinh.Value.Date.ToString());
                emp.Gender = char.Parse(cbGioiTinh.Text);
                emp.PlaceBirth = tbNoiSinh.Text;
                emp.Department = (Department_2119110227)cbDonVi.SelectedItem;

                EmployBAL.ThemEmployee(emp);
                dgvCustomer.Rows.Add(emp.IdEmployee, emp.Name, emp.DateBirth, emp.Gender, emp.PlaceBirth, emp.Department.Name_Department);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult f = MessageBox.Show("Bạn có muốn xóa dữ liệu không?", "Thong Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (f == DialogResult.Yes)
            {
                Employee_2119110227 emp = new Employee_2119110227();
                emp.IdEmployee = tbMa.Text;
                emp.Name = tbHoTen.Text;
                emp.DateBirth = DateTime.Parse(dtNgaySinh.Value.Date.ToString());
                emp.Gender = char.Parse(cbGioiTinh.Text);
                emp.PlaceBirth = tbNoiSinh.Text;

                EmployBAL.XoaEmployee(emp);
                int idx = dgvCustomer.CurrentCell.RowIndex;
                dgvCustomer.Rows.RemoveAt(idx);
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (checkDulieu())
            {
                DataGridViewRow row = dgvCustomer.CurrentRow;

                Employee_2119110227 empp = new Employee_2119110227();
                empp.IdEmployee = tbMa.Text;
                empp.Name = tbHoTen.Text;
                empp.DateBirth = DateTime.Parse(dtNgaySinh.Value.Date.ToString());
                empp.Gender = char.Parse(cbGioiTinh.Text);
                empp.PlaceBirth = tbNoiSinh.Text;
                empp.Department = (Department_2119110227)cbDonVi.SelectedItem;

                EmployBAL.SuaEmployee(empp);

                row.Cells[0].Value = empp.IdEmployee;
                row.Cells[1].Value = empp.Name;
                row.Cells[2].Value = empp.DateBirth;
                row.Cells[3].Value = empp.Gender;
                row.Cells[4].Value = empp.PlaceBirth;
                row.Cells[5].Value = empp.Department.Name_Department;
            }
        }
    }
}
