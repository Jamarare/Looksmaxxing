﻿using Looksmaxxing.Core.Domain;
using Looksmaxxing.Core.Dto;
using Looksmaxxing.Core.ServiceInterface;
using Looksmaxxing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Looksmaxxing.ApplicationServices.Services
{
    public class FileServices : IFileServices
    {
        private readonly IHostEnvironment _webHost;
        private readonly LooksmaxxingContext _context;

        public FileServices
            (
                IHostEnvironment webHost,
                LooksmaxxingContext context
            )
        {
            _webHost = webHost;
            _context = context;
        }

        public void UploadFilesToDatabase(SigmaDto dto, Sigma domain)
        {
            if (dto.Files != null && dto.Files.Count > 0) 
            { 
                foreach (var image in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase files = new FileToDatabase()
                        {
                            ID = Guid.NewGuid(),
                            ImageTitle = image.FileName,
                            SigmaID = domain.Id,
                        };

                        image.CopyTo( target );
                        files.ImageData = target.ToArray();
                        _context.FilesToDatabase.Add( files );
                    }
                }
            }
        }

        public async Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto)
        {
            var imageID = await _context.FilesToDatabase
                .FirstOrDefaultAsync(x => x.ID == dto.ID);
            var filePath = _webHost.ContentRootPath + "\\multipleFileUpload\\" + imageID.ImageData;
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            _context.FilesToDatabase.Remove( imageID );
            await _context.SaveChangesAsync();

            return null;
        }
    } 
}
