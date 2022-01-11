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
            cbDonVi.DisplayMember = "Name_department";
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
