using Looksmaxxing.Core.Domain;
using Looksmaxxing.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Looksmaxxing.Core.ServiceInterface
{
    public interface ISigmasServices
    {
        Task<Sigma> DetailsAsync(Guid id);

        Task<Sigma> Create(SigmaDto dto);
        Task<Sigma> Update(SigmaDto dto);
        Task<Sigma> Delete(Guid id);
    }
}
