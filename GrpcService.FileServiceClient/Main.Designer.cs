namespace GrpcService.FileServiceClient;

partial class frmMain
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        dgvFiles = new DataGridView();
        btnAdd = new Button();
        btnDelete = new Button();
        btnSave = new Button();
        dlgOpen = new OpenFileDialog();
        dlgSave = new SaveFileDialog();
        ((System.ComponentModel.ISupportInitialize)dgvFiles).BeginInit();
        SuspendLayout();
        // 
        // dgvFiles
        // 
        dgvFiles.AllowUserToAddRows = false;
        dgvFiles.AllowUserToDeleteRows = false;
        dgvFiles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvFiles.Location = new Point(12, 12);
        dgvFiles.MultiSelect = false;
        dgvFiles.Name = "dgvFiles";
        dgvFiles.ReadOnly = true;
        dgvFiles.RowHeadersVisible = false;
        dgvFiles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvFiles.Size = new Size(575, 426);
        dgvFiles.TabIndex = 0;
        // 
        // btnAdd
        // 
        btnAdd.Location = new Point(593, 36);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(75, 23);
        btnAdd.TabIndex = 1;
        btnAdd.Text = "Add...";
        btnAdd.UseVisualStyleBackColor = true;
        btnAdd.Click += btnAdd_Click;
        // 
        // btnDelete
        // 
        btnDelete.Location = new Point(593, 65);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(75, 23);
        btnDelete.TabIndex = 3;
        btnDelete.Text = "Delete";
        btnDelete.UseVisualStyleBackColor = true;
        btnDelete.Click += btnDelete_Click;
        // 
        // btnSave
        // 
        btnSave.Location = new Point(593, 94);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(75, 23);
        btnSave.TabIndex = 6;
        btnSave.Text = "Save";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;
        // 
        // dlgOpen
        // 
        dlgOpen.FileName = "openFileDialog1";
        // 
        // frmMain
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(675, 450);
        Controls.Add(btnSave);
        Controls.Add(btnDelete);
        Controls.Add(btnAdd);
        Controls.Add(dgvFiles);
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "frmMain";
        ShowIcon = false;
        Text = "FileService client";
        Load += frmMain_Load;
        ((System.ComponentModel.ISupportInitialize)dgvFiles).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private DataGridView dgvFiles;
    private Button btnAdd;
    private Button btnDelete;
    private Button btnSave;
    private OpenFileDialog dlgOpen;
    private SaveFileDialog dlgSave;
}