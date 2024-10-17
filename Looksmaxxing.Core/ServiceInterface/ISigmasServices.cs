using Looksmaxxing.Core.Domain;
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
    }
}
