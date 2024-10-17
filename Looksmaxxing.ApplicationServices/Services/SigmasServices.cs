using Looksmaxxing.Core.Domain;
using Looksmaxxing.Core.ServiceInterface;
using Looksmaxxing.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Looksmaxxing.ApplicationServices.Services
{
    public class SigmasServices : ISigmasServices
    {
        private readonly LooksmaxxingContext _context;

        public SigmasServices(LooksmaxxingContext context /*IFileServices fileServices*/)
        {
            _context = context;
        }

        ///<summary>
        ///Get Dtails for one Sigma
        ///</summary>
        ///<param name="id">Id of Sigma to show details of</param>
        ///<returns>resulting sigma</returns>
        
        public async Task<Sigma> DetailsAsync(Guid id)
        {
            var result = await _context.Sigmas
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}
