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
    /// <summary>
    /// Главная форма приложения для управления задачами.
    /// Предоставляет интерфейс добавления, редактирования, удаления,
    /// сортировки и фильтрации задач в таблице.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Флаг, указывающий, находится ли форма в режиме редактирования задачи.
        /// </summary>
        private bool _isEditMode = false;

        /// <summary>
        /// Индекс строки таблицы, которая редактируется в данный момент.
        /// Равен -1, если редактирование не активно.
        /// </summary>
        private int _editRowIndex = -1;

        /// <summary>
        /// Резервная копия всех строк таблицы, используемая при фильтрации.
        /// Хранит кортежи (название, описание, дата, приоритет, статус).
        /// </summary>
        private List<(string name, string desc, string date, string priority, string status)> _allRows
            = new List<(string, string, string, string, string)>();

        /// <summary>
        /// Инициализирует новый экземпляр формы <see cref="Form1"/>
        /// и создаёт все дочерние элементы управления.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки удаления задач.
        /// Запрашивает подтверждение и удаляет все выбранные строки из таблицы.
        /// </summary>
        /// <param name="sender">Источник события — кнопка удаления.</param>
        /// <param name="e">Данные события.</param>
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

            // Удаляем с конца, чтобы индексы не сдвигались
            indices.Sort((a, b) => b.CompareTo(a));
            foreach (int idx in indices)
                lstTasks.Rows.RemoveAt(idx);
        }

        /// <summary>
        /// Обрабатывает событие входа фокуса в groupBox2.
        /// </summary>
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Обрабатывает нажатие на метку label7.
        /// </summary>
        private void label7_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Обрабатывает изменение выбранного элемента в комбобоксе фильтра.
        /// Фильтрует строки таблицы по статусу выполнения задачи.
        /// При первом применении фильтра сохраняет все строки в <see cref="_allRows"/>.
        /// </summary>
        /// <param name="sender">Источник события — комбобокс фильтра.</param>
        /// <param name="e">Данные события.</param>
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

        /// <summary>
        /// Обрабатывает событие входа фокуса в groupBox1.
        /// </summary>
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Обрабатывает нажатие кнопки «Добавить» / «Сохранить».
        /// В обычном режиме добавляет новую задачу в таблицу.
        /// В режиме редактирования (<see cref="_isEditMode"/> == true) сохраняет
        /// изменения в существующей строке и возвращает форму в обычный режим.
        /// </summary>
        /// <param name="sender">Источник события — кнопка добавления/сохранения.</param>
        /// <param name="e">Данные события.</param>
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
                // Режим редактирования: обновляем существующую строку
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
                // Обычный режим: добавляем новую строку
                lstTasks.Rows.Add(title, description, dueDate, priority, status);
                ColorPriorityCell(lstTasks.Rows[lstTasks.Rows.Count - 2]);
            }

            txtTitle.Clear();
            txtDescription.Clear();
            dtpDueDate.Value = DateTime.Now;
            cmbPriority.SelectedIndex = -1;
            chkCompleted.Checked = false;
        }

        /// <summary>
        /// Обрабатывает изменение выделения строк в таблице задач.
        /// </summary>
        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Обрабатывает изменение текста в поле названия задачи.
        /// </summary>
        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Обрабатывает нажатие на метку lblTitle.
        /// </summary>
        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Обрабатывает изменение текста в поле описания задачи.
        /// </summary>
        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Обрабатывает изменение значения в поле выбора даты выполнения.
        /// </summary>
        private void dtpDueDate_ValueChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Обрабатывает изменение выбранного приоритета в комбобоксе.
        /// </summary>
        private void cmbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Обрабатывает изменение состояния флажка «Выполнено».
        /// </summary>
        private void chkCompleted_CheckedChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Обрабатывает нажатие кнопки «Редактировать».
        /// Загружает данные выбранной задачи в поля ввода и переключает
        /// форму в режим редактирования (<see cref="_isEditMode"/> = true).
        /// Кнопки «Редактировать» и «Удалить» блокируются до завершения редактирования.
        /// </summary>
        /// <param name="sender">Источник события — кнопка редактирования.</param>
        /// <param name="e">Данные события.</param>
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

            // Заполняем поля ввода данными выбранной строки
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

            // Переключаем форму в режим редактирования
            _isEditMode = true;
            btnAdd.Text = "Сохранить";
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            txtTitle.Focus();
        }

        /// <summary>
        /// Обрабатывает изменение выбранного элемента в комбобоксе сортировки.
        /// </summary>
        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Обрабатывает нажатие кнопки «Применить сортировку».
        /// Сортирует строки таблицы по выбранному критерию:
        /// по дате, приоритету, названию или статусу.
        /// После сортировки перерисовывает таблицу с обновлённой цветовой разметкой приоритетов.
        /// </summary>
        /// <param name="sender">Источник события — кнопка применения сортировки.</param>
        /// <param name="e">Данные события.</param>
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

            // Числовой порядок приоритетов для корректной сортировки
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

        /// <summary>
        /// Обрабатывает нажатие кнопки «Сбросить фильтр».
        /// Восстанавливает все сохранённые строки из <see cref="_allRows"/> в таблицу,
        /// сбрасывает выбор в комбобоксах фильтра и сортировки и очищает резервную копию.
        /// </summary>
        /// <param name="sender">Источник события — кнопка сброса фильтра.</param>
        /// <param name="e">Данные события.</param>
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

        /// <summary>
        /// Обрабатывает нажатие на содержимое ячейки таблицы задач.
        /// </summary>
        private void lstTasks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Устанавливает цвет фона и текста ячейки «Приоритет» в зависимости от значения приоритета.
        /// <list type="bullet">
        ///   <item><description>«низкий» — зелёный фон, тёмно-зелёный текст.</description></item>
        ///   <item><description>«средний» — жёлтый фон, тёмно-оранжевый текст.</description></item>
        ///   <item><description>«сложный» — красный фон, тёмно-красный текст.</description></item>
        ///   <item><description>Остальные значения — белый фон, чёрный текст.</description></item>
        /// </list>
        /// </summary>
        /// <param name="row">Строка таблицы <see cref="DataGridView"/>, у которой нужно обновить цвет ячейки приоритета.</param>
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
