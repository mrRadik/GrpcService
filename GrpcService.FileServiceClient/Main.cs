using System.ComponentModel;
using GrpcService.FileServiceClient.Models;
using GrpcService.FileServiceClient.Services;
using File = GrpcService.FileServiceClient.Models.File;

namespace GrpcService.FileServiceClient;

internal partial class frmMain : Form
{
    private readonly IFileService _fileService;
    private readonly IEmailService _mailService;

    public frmMain(IFileService fileService, IEmailService mailService)
    {
        _fileService = fileService;
        _mailService = mailService;
        InitializeComponent();
    }

    private async void btnAdd_Click(object sender, EventArgs e)
    {
        if (dlgOpen.ShowDialog() == DialogResult.Cancel)
        {
            return;
        }

        await AddFile(dlgOpen.FileName);
        await RefreshDataGrid();
    }

    protected virtual async void frmMain_Load(object sender, EventArgs e)
    {
        btnDelete.Enabled = btnSave.Enabled = dgvFiles.Rows.Count > 0;
        await RefreshDataGrid();
    }

    private async void btnDelete_Click(object sender, EventArgs e)
    {
        var guid = GetFileGuid();
        await _fileService.DeleteFile(guid);
        await RefreshDataGrid();
    }

    private async void btnSave_Click(object sender, EventArgs e)
    {
        var guid = GetFileGuid();
        var file = await _fileService.GetFile(guid);

        dlgSave.FileName = file.Name;
        if (dlgSave.ShowDialog() == DialogResult.Cancel)
        {
            return;
        }

        var filePath = dlgSave.FileName + file.Extension;
        await System.IO.File.WriteAllBytesAsync(filePath, file.Data);

        MessageBox.Show("Файл сохранен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private async Task RefreshDataGrid()
    {
        try
        {
            var filesData = new BindingList<File>(await _fileService.GetAllFiles());

            var data = from f in filesData
                       select new
                       {
                           Guid = f.FileGuid,
                           Name = f.Name,
                           Extension = f.Extension,
                           CreationTime = f.CreationTime
                       };

            dgvFiles.DataSource = data.ToList();
            btnDelete.Enabled = btnSave.Enabled = dgvFiles.Rows.Count > 0;
        }
        catch (Exception e) { }
    }

    private async Task AddFile(string fileName)
    {
        var file = new File
        {
            Name = Path.GetFileNameWithoutExtension(fileName),
            Extension = Path.GetExtension(fileName).Trim('.'),
            Data = await System.IO.File.ReadAllBytesAsync(fileName)
        };

        await _fileService.AddFile(file);
    }

    private string GetFileGuid()
    {
        return dgvFiles.SelectedRows.Count == 0
            ? string.Empty
            : dgvFiles.SelectedRows[0].Cells["Guid"].Value.ToString()!;
    }

    private async void btnSend_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTo.Text))
        {
            MessageBox.Show("Не заполнено поле To", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        var guid = GetFileGuid();
        var file = await _fileService.GetFile(guid);

        var emailMessage = new EmailMessageDto
        {
            MailTo = txtTo.Text,
            Subject = txtSubject.Text,
            Body = txtBody.Text,
            File = file
        };

        var response = await _mailService.SendEmail(emailMessage);

        MessageBox.Show($@"{response}", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private async void txtRename_Click(object sender, EventArgs e)
    {
        await _fileService.RenameFile(GetFileGuid(), txtNewName.Text);
        await RefreshDataGrid();
    }
}