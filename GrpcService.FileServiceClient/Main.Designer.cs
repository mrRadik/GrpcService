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
        groupBox1 = new GroupBox();
        txtBody = new TextBox();
        label3 = new Label();
        txtSubject = new TextBox();
        txtTo = new TextBox();
        label2 = new Label();
        label1 = new Label();
        btnSend = new Button();
        txtNewName = new TextBox();
        label4 = new Label();
        txtRename = new Button();
        ((System.ComponentModel.ISupportInitialize)dgvFiles).BeginInit();
        groupBox1.SuspendLayout();
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
        // groupBox1
        // 
        groupBox1.Controls.Add(txtBody);
        groupBox1.Controls.Add(label3);
        groupBox1.Controls.Add(txtSubject);
        groupBox1.Controls.Add(txtTo);
        groupBox1.Controls.Add(label2);
        groupBox1.Controls.Add(label1);
        groupBox1.Location = new Point(12, 494);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(581, 204);
        groupBox1.TabIndex = 7;
        groupBox1.TabStop = false;
        groupBox1.Text = "SendEmail";
        // 
        // txtBody
        // 
        txtBody.Location = new Point(61, 85);
        txtBody.Multiline = true;
        txtBody.Name = "txtBody";
        txtBody.Size = new Size(514, 113);
        txtBody.TabIndex = 5;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(18, 88);
        label3.Name = "label3";
        label3.Size = new Size(37, 15);
        label3.TabIndex = 4;
        label3.Text = "Body:";
        // 
        // txtSubject
        // 
        txtSubject.Location = new Point(61, 56);
        txtSubject.Name = "txtSubject";
        txtSubject.Size = new Size(514, 23);
        txtSubject.TabIndex = 3;
        // 
        // txtTo
        // 
        txtTo.Location = new Point(61, 27);
        txtTo.Name = "txtTo";
        txtTo.Size = new Size(514, 23);
        txtTo.TabIndex = 2;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(6, 59);
        label2.Name = "label2";
        label2.Size = new Size(49, 15);
        label2.TabIndex = 1;
        label2.Text = "Subject:";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(33, 30);
        label1.Name = "label1";
        label1.Size = new Size(22, 15);
        label1.TabIndex = 0;
        label1.Text = "To:";
        // 
        // btnSend
        // 
        btnSend.Location = new Point(593, 521);
        btnSend.Name = "btnSend";
        btnSend.Size = new Size(75, 23);
        btnSend.TabIndex = 8;
        btnSend.Text = "Send";
        btnSend.UseVisualStyleBackColor = true;
        btnSend.Click += btnSend_Click;
        // 
        // txtNewName
        // 
        txtNewName.Location = new Point(82, 452);
        txtNewName.Name = "txtNewName";
        txtNewName.Size = new Size(505, 23);
        txtNewName.TabIndex = 10;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(12, 455);
        label4.Name = "label4";
        label4.Size = new Size(64, 15);
        label4.TabIndex = 9;
        label4.Text = "New name";
        // 
        // txtRename
        // 
        txtRename.Location = new Point(593, 452);
        txtRename.Name = "txtRename";
        txtRename.Size = new Size(75, 23);
        txtRename.TabIndex = 11;
        txtRename.Text = "Rename";
        txtRename.UseVisualStyleBackColor = true;
        txtRename.Click += txtRename_Click;
        // 
        // frmMain
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(675, 706);
        Controls.Add(txtRename);
        Controls.Add(txtNewName);
        Controls.Add(label4);
        Controls.Add(btnSend);
        Controls.Add(groupBox1);
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
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private DataGridView dgvFiles;
    private Button btnAdd;
    private Button btnDelete;
    private Button btnSave;
    private OpenFileDialog dlgOpen;
    private SaveFileDialog dlgSave;
    private GroupBox groupBox1;
    private TextBox txtBody;
    private Label label3;
    private TextBox txtSubject;
    private TextBox txtTo;
    private Label label2;
    private Label label1;
    private Button btnSend;
    private TextBox txtNewName;
    private Label label4;
    private Button txtRename;
}