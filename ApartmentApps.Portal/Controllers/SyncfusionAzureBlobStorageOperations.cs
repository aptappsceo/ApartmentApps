using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApartmentApps.Api;
using ApartmentApps.Data;
using Syncfusion.JavaScript;

public class SyncfusionAzureBlobStorageOperations : BasicFileOperations
{

    private IBlobStorageService _blobStorageService;
    private ApplicationUser _user;
    private ApplicationDbContext _context;

    public SyncfusionAzureBlobStorageOperations(IBlobStorageService blobStorageService, ApplicationUser user, ApplicationDbContext context)
    {
        _blobStorageService = blobStorageService;
        _user = user;
        _context = context;
    }

    //RETURN FileExplorerResponse
    public override object Read(string path, string filter, IEnumerable<object> selectedItems = null)
    {
        var response = new FileExplorerResponse()
        {
            cwd = FileExplorerDirectoryContent,
        };

        var guid = Guid.Parse(_user.Id);
        var images = _context.ImageReferences.Where(r => r.GroupId == guid).ToList();

        response.files = images.Select(s => new FileExplorerDirectoryContent()
        {
            name = s.Url,
            size = 1000L,
            type = "File",
            isFile = true,
            dateModified = DateTime.Now.ToString(),
            hasChild = false,
        });

        return response;

    }

    public FileExplorerDirectoryContent FileExplorerDirectoryContent => new FileExplorerDirectoryContent()
    {
        name = "/",
        size = 0L,
        type = "Directory",
        isFile = false,
        dateModified = DateTime.Now.ToString(),
        hasChild = true
    };


    //RETURN FileExplorerResponse
    public override object CreateFolder(string path, string name, IEnumerable<object> selectedItems = null)
    {
        throw new NotImplementedException();
    }

    //RETURNS FileExplorerResponse
    public override object Remove(string[] names, string path, IEnumerable<object> selectedItems = null)
    {
        throw new NotImplementedException();
    }

    //RETURNS FileExplorerResponse
    public override object Rename(string path, string oldName, string newName, IEnumerable<CommonFileDetails> commonFiles, IEnumerable<object> selectedItems = null)
    {
        throw new NotImplementedException();
    }

    //RETURNS FileExplorerResponse
    public override object Paste(string sourceDir, string targetDir, string[] names, string option, IEnumerable<CommonFileDetails> commonFiles,
        IEnumerable<object> selectedItems = null, IEnumerable<object> targetFolder = null)
    {
        throw new NotImplementedException();
    }

    public override void Upload(IEnumerable<HttpPostedFileBase> files, string path, IEnumerable<object> selectedItems = null)
    {

        var guid = Guid.Parse(_user.Id);

        foreach (var file in files)
        {
            var bytes = file.InputStream.ReadFully();
            
            var imageKey = $"{file.FileName}.{_user.UserName.Replace('@', '_').Replace('.', '_')}".ToLowerInvariant();
            var filename = _blobStorageService.UploadPhoto(bytes, imageKey);
            _context.ImageReferences.Add(new ImageReference()
            {
                GroupId = guid,
                Url = filename,
                ThumbnailUrl = filename,
                Name = file.FileName
            });

        }
        _context.SaveChanges();

    }

    public override void Download(string path, string[] names, IEnumerable<object> selectedItems = null)
    {
        throw new NotImplementedException();
    }

    //RETURNS FileExplorerResponse
    public override object GetDetails(string path, string[] names, IEnumerable<object> selectedItems = null)
    {
        throw new NotImplementedException();
    }

    public override void GetImage(string path, IEnumerable<object> selectedItems = null)
    {
        throw new NotImplementedException();
    }

    //RETURNS FileExplorerResponse
    public override object Search(string path, string filter, string searchString, bool caseSensitive, IEnumerable<object> selectedItems = null)
    {
        throw new NotImplementedException();
    }
}