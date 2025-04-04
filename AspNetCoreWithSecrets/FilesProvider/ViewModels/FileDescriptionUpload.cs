﻿using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace AspNetCoreWithSecrets.FilesProvider.ViewModels;

public class FileDescriptionUpload
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public string UploadedBy { get; set; }
    public ICollection<IFormFile> File { get; set; }
}