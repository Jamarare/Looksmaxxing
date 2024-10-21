using Looksmaxxing.Core.Domain;
using Looksmaxxing.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Looksmaxxing.Core.ServiceInterface
{
    public interface IFileServices
    {
        void UploadFilesToDatabase(SigmaDto dto, Sigma domain);
    }
}
