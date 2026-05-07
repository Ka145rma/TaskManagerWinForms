namespace Task
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTasks = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.grpTaskData = new System.Windows.Forms.GroupBox();
            this.chkCompleted = new System.Windows.Forms.CheckBox();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpAction = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grpFilters = new System.Windows.Forms.GroupBox();
            this.btnResetFilter = new System.Windows.Forms.Button();
            this.btnApplySort = new System.Windows.Forms.Button();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.lblSort = new System.Windows.Forms.Label();
            this.lstTasks = new System.Windows.Forms.ListBox();
            this.pnlRight.SuspendLayout();
            this.grpTaskData.SuspendLayout();
            this.grpAction.SuspendLayout();
            this.grpFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTasks
            // 
            this.lblTasks.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTasks.Location = new System.Drawing.Point(12, 9);
            this.lblTasks.Name = "lblTasks";
            this.lblTasks.Size = new System.Drawing.Size(266, 31);
            this.lblTasks.TabIndex = 1;
            this.lblTasks.Text = "список задач ";
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.grpTaskData);
            this.pnlRight.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pnlRight.Location = new System.Drawing.Point(847, 9);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(754, 341);
            this.pnlRight.TabIndex = 2;
            // 
            // grpTaskData
            // 
            this.grpTaskData.Controls.Add(this.chkCompleted);
            this.grpTaskData.Controls.Add(this.cmbPriority);
            this.grpTaskData.Controls.Add(this.dtpDueDate);
            this.grpTaskData.Controls.Add(this.lblStatus);
            this.grpTaskData.Controls.Add(this.lblPriority);
            this.grpTaskData.Controls.Add(this.lblDate);
            this.grpTaskData.Controls.Add(this.lblDescription);
            this.grpTaskData.Controls.Add(this.txtDescription);
            this.grpTaskData.Controls.Add(this.txtTitle);
            this.grpTaskData.Controls.Add(this.lblTitle);
            this.grpTaskData.Location = new System.Drawing.Point(0, 0);
            this.grpTaskData.Name = "grpTaskData";
            this.grpTaskData.Size = new System.Drawing.Size(754, 344);
            this.grpTaskData.TabIndex = 0;
            this.grpTaskData.TabStop = false;
            this.grpTaskData.Text = "данные задачи ";
            this.grpTaskData.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // chkCompleted
            // 
            this.chkCompleted.AutoSize = true;
            this.chkCompleted.Location = new System.Drawing.Point(189, 291);
            this.chkCompleted.Name = "chkCompleted";
            this.chkCompleted.Size = new System.Drawing.Size(111, 24);
            this.chkCompleted.TabIndex = 19;
            this.chkCompleted.Text = "выполнено";
            this.chkCompleted.UseVisualStyleBackColor = true;
            this.chkCompleted.CheckedChanged += new System.EventHandler(this.chkCompleted_CheckedChanged);
            // 
            // cmbPriority
            // 
            this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Items.AddRange(new object[] {
            "низкий",
            "средний",
            "сложный"});
            this.cmbPriority.Location = new System.Drawing.Point(189, 247);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(200, 28);
            this.cmbPriority.TabIndex = 18;
            this.cmbPriority.SelectedIndexChanged += new System.EventHandler(this.cmbPriority_SelectedIndexChanged);
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDueDate.Location = new System.Drawing.Point(189, 204);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(200, 27);
            this.dtpDueDate.TabIndex = 17;
            this.dtpDueDate.ValueChanged += new System.EventHandler(this.dtpDueDate_ValueChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(33, 291);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(53, 20);
            this.lblStatus.TabIndex = 16;
            this.lblStatus.Text = "статус:";
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Location = new System.Drawing.Point(33, 247);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(86, 20);
            this.lblPriority.TabIndex = 15;
            this.lblPriority.Text = "приоритет:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(33, 204);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(134, 20);
            this.lblDate.TabIndex = 14;
            this.lblDate.Text = "дата выполнения:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(33, 80);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(80, 20);
            this.lblDescription.TabIndex = 13;
            this.lblDescription.Text = "описание:";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(189, 59);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(532, 98);
            this.txtDescription.TabIndex = 12;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(189, 26);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(532, 27);
            this.txtTitle.TabIndex = 11;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(33, 26);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(100, 23);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "название:";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // grpAction
            // 
            this.grpAction.Controls.Add(this.btnDelete);
            this.grpAction.Controls.Add(this.btnEdit);
            this.grpAction.Controls.Add(this.btnAdd);
            this.grpAction.Location = new System.Drawing.Point(847, 356);
            this.grpAction.Name = "grpAction";
            this.grpAction.Size = new System.Drawing.Size(754, 105);
            this.grpAction.TabIndex = 10;
            this.grpAction.TabStop = false;
            this.grpAction.Text = "действия";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.LightCoral;
            this.btnDelete.Location = new System.Drawing.Point(558, 37);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(177, 41);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "удалить";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(277, 37);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(189, 41);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "редактировать";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.LightGreen;
            this.btnAdd.Location = new System.Drawing.Point(18, 37);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(167, 41);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "добавить";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grpFilters
            // 
            this.grpFilters.Controls.Add(this.btnResetFilter);
            this.grpFilters.Controls.Add(this.btnApplySort);
            this.grpFilters.Controls.Add(this.cmbFilter);
            this.grpFilters.Controls.Add(this.cmbSort);
            this.grpFilters.Controls.Add(this.lblFilter);
            this.grpFilters.Controls.Add(this.lblSort);
            this.grpFilters.Location = new System.Drawing.Point(847, 467);
            this.grpFilters.Name = "grpFilters";
            this.grpFilters.Size = new System.Drawing.Size(754, 128);
            this.grpFilters.TabIndex = 11;
            this.grpFilters.TabStop = false;
            this.grpFilters.Text = "сортировка и фильтры";
            this.grpFilters.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnResetFilter
            // 
            this.btnResetFilter.Location = new System.Drawing.Point(469, 81);
            this.btnResetFilter.Name = "btnResetFilter";
            this.btnResetFilter.Size = new System.Drawing.Size(184, 33);
            this.btnResetFilter.TabIndex = 5;
            this.btnResetFilter.Text = "сбросить фильтры ";
            this.btnResetFilter.UseVisualStyleBackColor = true;
            this.btnResetFilter.Click += new System.EventHandler(this.btnResetFilter_Click);
            // 
            // btnApplySort
            // 
            this.btnApplySort.Location = new System.Drawing.Point(41, 83);
            this.btnApplySort.Name = "btnApplySort";
            this.btnApplySort.Size = new System.Drawing.Size(169, 31);
            this.btnApplySort.TabIndex = 4;
            this.btnApplySort.Text = "применить сортировку";
            this.btnApplySort.UseVisualStyleBackColor = true;
            this.btnApplySort.Click += new System.EventHandler(this.btnApplySort_Click);
            // 
            // cmbFilter
            // 
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Items.AddRange(new object[] {
            "все задачи",
            "выполненные",
            "невыполненные"});
            this.cmbFilter.Location = new System.Drawing.Point(469, 51);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(184, 24);
            this.cmbFilter.TabIndex = 3;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // cmbSort
            // 
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.FormattingEnabled = true;
            this.cmbSort.Items.AddRange(new object[] {
            "по дате",
            "по приоритету",
            "по названию"});
            this.cmbSort.Location = new System.Drawing.Point(41, 53);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(169, 24);
            this.cmbSort.TabIndex = 2;
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.cmbSort_SelectedIndexChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(466, 32);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(59, 16);
            this.lblFilter.TabIndex = 1;
            this.lblFilter.Text = "фильтр:";
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.Location = new System.Drawing.Point(38, 32);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(87, 16);
            this.lblSort.TabIndex = 0;
            this.lblSort.Text = "сортировка:";
            this.lblSort.Click += new System.EventHandler(this.label7_Click);
            // 
            // lstTasks
            // 
            this.lstTasks.FormattingEnabled = true;
            this.lstTasks.ItemHeight = 16;
            this.lstTasks.Location = new System.Drawing.Point(12, 35);
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.Size = new System.Drawing.Size(829, 580);
            this.lstTasks.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 853);
            this.Controls.Add(this.lstTasks);
            this.Controls.Add(this.grpFilters);
            this.Controls.Add(this.grpAction);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.lblTasks);
            this.Name = "Form1";
            this.Text = "TaskManager — Управление задачами";
            this.pnlRight.ResumeLayout(false);
            this.grpTaskData.ResumeLayout(false);
            this.grpTaskData.PerformLayout();
            this.grpAction.ResumeLayout(false);
            this.grpFilters.ResumeLayout(false);
            this.grpFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTasks;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.GroupBox grpAction;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox grpFilters;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.Button btnResetFilter;
        private System.Windows.Forms.Button btnApplySort;
        private System.Windows.Forms.GroupBox grpTaskData;
        private System.Windows.Forms.CheckBox chkCompleted;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListBox lstTasks;
    }
}

