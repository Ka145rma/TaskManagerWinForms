using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Task
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();

            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Введите название задачи!");
                return;
            }

            string description = txtDescription.Text.Trim();
            string dueDate = dtpDueDate.Value.ToString("dd.MM.yyyy");
            string priority = cmbPriority.SelectedItem?.ToString() ?? "Не указан";
            string status = chkCompleted.Checked ? "Выполнено" : "Не выполнено";

            string taskEntry = $"{title} | {description} | Дата: {dueDate} | Приоритет: {priority} | Статус: {status}";

            lstTasks.Items.Add(taskEntry);

            // Очистка полей
            txtTitle.Clear();
            txtDescription.Clear();
            dtpDueDate.Value = DateTime.Now;
            cmbPriority.SelectedIndex = -1;
            chkCompleted.Checked = false;
        }

        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpDueDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkCompleted_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnApplySort_Click(object sender, EventArgs e)
        {

        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {

        }
    }
}
