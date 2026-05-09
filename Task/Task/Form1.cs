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

        private bool _isEditMode = false;   
        private int _editRowIndex = -1;
        private List<(string name, string desc, string date, string priority, string status)> _allRows
    = new List<(string, string, string, string, string)>();

        public Form1()
        {
            InitializeComponent();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите задачу(и) для удаления.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string msg = lstTasks.SelectedRows.Count == 1
                ? "Удалить выбранную задачу?"
                : $"Удалить выбранные задачи ({lstTasks.SelectedRows.Count} шт.)?";

            DialogResult result = MessageBox.Show(msg, "Подтверждение удаления",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            var indices = new System.Collections.Generic.List<int>();
            foreach (DataGridViewRow row in lstTasks.SelectedRows)
            {
                if (!row.IsNewRow)
                    indices.Add(row.Index);
            }

            indices.Sort((a, b) => b.CompareTo(a));
            foreach (int idx in indices)
                lstTasks.Rows.RemoveAt(idx);
        }



        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter = cmbFilter.SelectedItem?.ToString() ?? "все задачи";

            // Сохраняем все строки при первом фильтре
            if (_allRows.Count == 0)
                foreach (DataGridViewRow row in lstTasks.Rows)
                    if (!row.IsNewRow)
                        _allRows.Add((
                            row.Cells["name"].Value?.ToString() ?? "",
                            row.Cells["description"].Value?.ToString() ?? "",
                            row.Cells["date"].Value?.ToString() ?? "",
                            row.Cells["priority"].Value?.ToString() ?? "",
                            row.Cells["status"].Value?.ToString() ?? ""
                        ));

            lstTasks.Rows.Clear();
            foreach (var item in _allRows)
            {
                if (filter == "все задачи" ||
                   (filter == "выполненные" && item.status == "Выполнено") ||
                   (filter == "невыполненные" && item.status == "Не выполнено"))
                {
                    lstTasks.Rows.Add(item.name, item.desc, item.date, item.priority, item.status);
                    ColorPriorityCell(lstTasks.Rows[lstTasks.Rows.Count - 2]);
                }
            }
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

            if (_isEditMode && _editRowIndex >= 0)
            {

                DataGridViewRow row = lstTasks.Rows[_editRowIndex];
                row.Cells["name"].Value = title;
                row.Cells["description"].Value = description;
                row.Cells["date"].Value = dueDate;
                row.Cells["priority"].Value = priority;
                row.Cells["status"].Value = status;

                ColorPriorityCell(lstTasks.Rows[_editRowIndex]);
                _isEditMode = false;
                _editRowIndex = -1;
                btnAdd.Text = "Добавить";
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {  
                lstTasks.Rows.Add(title, description, dueDate, priority, status);
                ColorPriorityCell(lstTasks.Rows[lstTasks.Rows.Count - 2]);
            }

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
            if (lstTasks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите задачу для редактирования.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (lstTasks.SelectedRows.Count > 1)
            {
                MessageBox.Show("Для редактирования выберите только одну задачу.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow row = lstTasks.SelectedRows[0];
            _editRowIndex = row.Index;

           
            txtTitle.Text = row.Cells["name"].Value?.ToString() ?? "";
            txtDescription.Text = row.Cells["description"].Value?.ToString() ?? "";

            string dateStr = row.Cells["date"].Value?.ToString() ?? "";
            if (DateTime.TryParseExact(dateStr, "dd.MM.yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
            {
                dtpDueDate.Value = parsedDate;
            }

            string priorityVal = row.Cells["priority"].Value?.ToString() ?? "";
            cmbPriority.SelectedIndex = cmbPriority.FindStringExact(priorityVal);

            string statusVal = row.Cells["status"].Value?.ToString() ?? "";
            chkCompleted.Checked = statusVal == "Выполнено";

            
            _isEditMode = true;
            btnAdd.Text = "Сохранить";
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            txtTitle.Focus();
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnApplySort_Click(object sender, EventArgs e)
        {
            if (cmbSort.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите тип сортировки.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Собираем данные как список кортежей
            var data = new List<(string name, string desc, string date, string priority, string status)>();
            foreach (DataGridViewRow row in lstTasks.Rows)
            {
                if (row.IsNewRow) continue;
                data.Add((
                    row.Cells["name"].Value?.ToString() ?? "",
                    row.Cells["description"].Value?.ToString() ?? "",
                    row.Cells["date"].Value?.ToString() ?? "",
                    row.Cells["priority"].Value?.ToString() ?? "",
                    row.Cells["status"].Value?.ToString() ?? ""
                ));
            }

            var priorityOrder = new System.Collections.Generic.Dictionary<string, int>
    {
        { "низкий", 0 }, { "средний", 1 }, { "сложный", 2 }
    };

            switch (cmbSort.SelectedItem.ToString())
            {
                case "по дате":
                    data.Sort((a, b) =>
                    {
                        DateTime.TryParseExact(a.date, "dd.MM.yyyy",
                            System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None, out DateTime dA);
                        DateTime.TryParseExact(b.date, "dd.MM.yyyy",
                            System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None, out DateTime dB);
                        return dA.CompareTo(dB);
                    });
                    break;

                case "по приоритету":
                    data.Sort((a, b) =>
                    {
                        int pA = priorityOrder.TryGetValue(a.priority, out int vA) ? vA : -1;
                        int pB = priorityOrder.TryGetValue(b.priority, out int vB) ? vB : -1;
                        return pA.CompareTo(pB);
                    });
                    break;

                case "по названию":
                    data.Sort((a, b) => string.Compare(a.name, b.name, StringComparison.OrdinalIgnoreCase));
                    break;

                case "по статусу":
                    data.Sort((a, b) => string.Compare(a.status, b.status, StringComparison.OrdinalIgnoreCase));
                    break;
            }

            lstTasks.Rows.Clear();
            foreach (var item in data)
            {
                lstTasks.Rows.Add(item.name, item.desc, item.date, item.priority, item.status);
                ColorPriorityCell(lstTasks.Rows[lstTasks.Rows.Count - 2]);
            }
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            if (_allRows.Count > 0)
            {
                lstTasks.Rows.Clear();
                foreach (var item in _allRows)
                {
                    lstTasks.Rows.Add(item.name, item.desc, item.date, item.priority, item.status);
                    ColorPriorityCell(lstTasks.Rows[lstTasks.Rows.Count - 2]);
                }
                _allRows.Clear();
            }

            cmbFilter.SelectedIndex = -1;
            cmbSort.SelectedIndex = -1;
        }


        private void lstTasks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ColorPriorityCell(DataGridViewRow row)
        {
            string p = row.Cells["priority"].Value?.ToString() ?? "";
            Color back, fore;

            switch (p)
            {
                case "низкий":
                    back = Color.FromArgb(198, 239, 206); 
                    fore = Color.FromArgb(0, 97, 0);
                    break;
                case "средний":
                    back = Color.FromArgb(255, 235, 156); 
                    fore = Color.FromArgb(156, 101, 0);
                    break;
                case "сложный":
                    back = Color.FromArgb(255, 199, 206); 
                    fore = Color.FromArgb(156, 0, 6);
                    break;
                default:
                    back = Color.White;
                    fore = Color.Black;
                    break;
            }

            row.Cells["priority"].Style.BackColor = back;
            row.Cells["priority"].Style.ForeColor = fore;
        }
    }
}
