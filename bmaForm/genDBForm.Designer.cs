using dbLibrary;

namespace bmaForm
{
    partial class genDBForm
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
            idColumn = new DataGridViewTextBoxColumn();
            fbColumn = new DataGridViewTextBoxColumn();
            lenColumn = new DataGridViewTextBoxColumn();
            stateColumn = new DataGridViewTextBoxColumn();
            seqColumn = new DataGridViewTextBoxColumn();
            dateColumn = new DataGridViewTextBoxColumn();
            deleteColumn = new DataGridViewButtonColumn();
            genTableBindingSource = new BindingSource(components);
            bmaTableBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)genTableBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bmaTableBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGrid
            // 
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.AllowUserToResizeColumns = false;
            dataGrid.AllowUserToResizeRows = false;
            dataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid.Columns.AddRange(new DataGridViewColumn[] { idColumn, fbColumn, lenColumn, stateColumn, seqColumn, dateColumn, deleteColumn });
            dataGrid.Location = new Point(7, 7);
            dataGrid.Name = "dataGrid";
            dataGrid.ReadOnly = true;
            dataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            dataGrid.RowTemplate.Height = 29;
            dataGrid.ScrollBars = ScrollBars.Vertical;
            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid.Size = new Size(932, 525);
            dataGrid.TabIndex = 0;
            // 
            // idColumn
            // 
            idColumn.HeaderText = "ID";
            idColumn.MinimumWidth = 6;
            idColumn.Name = "idColumn";
            idColumn.ReadOnly = true;
            idColumn.Width = 50;
            // 
            // fbColumn
            // 
            fbColumn.HeaderText = "Обратная связь";
            fbColumn.MinimumWidth = 6;
            fbColumn.Name = "fbColumn";
            fbColumn.ReadOnly = true;
            fbColumn.Width = 175;
            // 
            // lenColumn
            // 
            lenColumn.HeaderText = "Длина регистра";
            lenColumn.MinimumWidth = 6;
            lenColumn.Name = "lenColumn";
            lenColumn.ReadOnly = true;
            lenColumn.Width = 125;
            // 
            // stateColumn
            // 
            stateColumn.HeaderText = "Начальное стостояние";
            stateColumn.MinimumWidth = 6;
            stateColumn.Name = "stateColumn";
            stateColumn.ReadOnly = true;
            stateColumn.Width = 125;
            // 
            // seqColumn
            // 
            seqColumn.HeaderText = "Выходная последовательность";
            seqColumn.MinimumWidth = 6;
            seqColumn.Name = "seqColumn";
            seqColumn.ReadOnly = true;
            seqColumn.Width = 175;
            // 
            // dateColumn
            // 
            dateColumn.HeaderText = "Дата";
            dateColumn.MinimumWidth = 6;
            dateColumn.Name = "dateColumn";
            dateColumn.ReadOnly = true;
            dateColumn.Width = 125;
            // 
            // deleteColumn
            // 
            deleteColumn.HeaderText = "";
            deleteColumn.MinimumWidth = 6;
            deleteColumn.Name = "deleteColumn";
            deleteColumn.ReadOnly = true;
            deleteColumn.Text = "Удалить";
            deleteColumn.UseColumnTextForButtonValue = true;
            deleteColumn.Width = 125;
            // 
            // genTableBindingSource
            // 
            genTableBindingSource.DataSource = typeof(GenTable);
            // 
            // bmaTableBindingSource
            // 
            bmaTableBindingSource.DataSource = typeof(BmaTable);
            // 
            // genDBForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(946, 542);
            Controls.Add(dataGrid);
            MaximumSize = new Size(964, 589);
            MinimumSize = new Size(964, 589);
            Name = "genDBForm";
            Padding = new Padding(4);
            Text = "База данных";
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)genTableBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)bmaTableBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGrid;
        private BindingSource genTableBindingSource;
        private BindingSource bmaTableBindingSource;
        private DataGridViewTextBoxColumn idColumn;
        private DataGridViewTextBoxColumn fbColumn;
        private DataGridViewTextBoxColumn lenColumn;
        private DataGridViewTextBoxColumn stateColumn;
        private DataGridViewTextBoxColumn seqColumn;
        private DataGridViewTextBoxColumn dateColumn;
        private DataGridViewButtonColumn deleteColumn;
    }
}