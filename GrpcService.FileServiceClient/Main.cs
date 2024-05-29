using System.ComponentModel;
using GrpcService.FileServiceClient.Services;
using File = GrpcService.FileServiceClient.Models.File;

namespace GrpcService.FileServiceClient;

internal partial class frmMain : Form
{
    private readonly IFileService _fileService;

    public frmMain(IFileService fileService)
    {
        _fileService = fileService;
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
}