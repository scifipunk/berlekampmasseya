namespace bmaForm
{
    partial class lfsrDBForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dataGrid = new DataGridView();
            IdColumn = new DataGridViewTextBoxColumn();
            feedbackColumn = new DataGridViewTextBoxColumn();
            lengthColumn = new DataGridViewTextBoxColumn();
            dateColumn = new DataGridViewTextBoxColumn();
            stepColumn = new DataGridViewButtonColumn();
            deleteColumn = new DataGridViewButtonColumn();
            bmaTableBindingSource1 = new BindingSource(components);
            bmaTableBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bmaTableBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bmaTableBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGrid
            // 
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.AllowUserToResizeColumns = false;
            dataGrid.AllowUserToResizeRows = false;
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid.Columns.AddRange(new DataGridViewColumn[] { IdColumn, feedbackColumn, lengthColumn, dateColumn, stepColumn, deleteColumn });
            dataGrid.Location = new Point(7, 7);
            dataGrid.Name = "dataGrid";
            dataGrid.RowHeadersWidth = 51;
            dataGrid.RowTemplate.Height = 29;
            dataGrid.Size = new Size(807, 431);
            dataGrid.TabIndex = 6;
            dataGrid.CellContentClick += dataGrid_CellContentClick;
            // 
            // IdColumn
            // 
            IdColumn.DataPropertyName = "Id";
            IdColumn.HeaderText = "ID";
            IdColumn.MinimumWidth = 6;
            IdColumn.Name = "IdColumn";
            IdColumn.Width = 125;
            // 
            // feedbackColumn
            // 
            feedbackColumn.DataPropertyName = "Feedback";
            feedbackColumn.HeaderText = "Обратная связь";
            feedbackColumn.MinimumWidth = 6;
            feedbackColumn.Name = "feedbackColumn";
            feedbackColumn.Width = 125;
            // 
            // lengthColumn
            // 
            lengthColumn.DataPropertyName = "Length";
            lengthColumn.HeaderText = "Длина регистра";
            lengthColumn.MinimumWidth = 6;
            lengthColumn.Name = "lengthColumn";
            lengthColumn.Width = 125;
            // 
            // dateColumn
            // 
            dateColumn.HeaderText = "Дата";
            dateColumn.MinimumWidth = 6;
            dateColumn.Name = "dateColumn";
            dateColumn.Width = 125;
            // 
            // stepColumn
            // 
            stepColumn.DataPropertyName = "Data";
            stepColumn.HeaderText = "";
            stepColumn.MinimumWidth = 6;
            stepColumn.Name = "stepColumn";
            stepColumn.Text = "Шаги";
            stepColumn.UseColumnTextForButtonValue = true;
            stepColumn.Width = 125;
            // 
            // deleteColumn
            // 
            deleteColumn.HeaderText = "";
            deleteColumn.MinimumWidth = 6;
            deleteColumn.Name = "deleteColumn";
            deleteColumn.Text = "Удалить";
            deleteColumn.UseColumnTextForButtonValue = true;
            deleteColumn.Width = 125;
            // 
            // bmaTableBindingSource1
            // 
            bmaTableBindingSource1.DataSource = typeof(dbLibrary.BmaTable);
            // 
            // bmaTableBindingSource
            // 
            bmaTableBindingSource.DataSource = typeof(dbLibrary.BmaTable);
            // 
            // lfsrDBForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(823, 447);
            Controls.Add(dataGrid);
            MaximumSize = new Size(841, 494);
            MinimumSize = new Size(841, 494);
            Name = "lfsrDBForm";
            Padding = new Padding(4);
            Text = "База Данных";
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)bmaTableBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bmaTableBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataGrid;
        private BindingSource bmaTableBindingSource;
        private BindingSource bmaTableBindingSource1;
        private DataGridViewTextBoxColumn IdColumn;
        private DataGridViewTextBoxColumn feedbackColumn;
        private DataGridViewTextBoxColumn lengthColumn;
        private DataGridViewTextBoxColumn dateColumn;
        private DataGridViewButtonColumn stepColumn;
        private DataGridViewButtonColumn deleteColumn;
    }
}