using Looksmaxxing.Core.Domain;
using Looksmaxxing.Core.Dto;
using Looksmaxxing.Core.ServiceInterface;
using Looksmaxxing.Data;
using Microsoft.EntityFrameworkCore;


namespace Looksmaxxing.ApplicationServices.Services
{
    public class SigmasServices : ISigmasServices
    {
        private readonly LooksmaxxingContext _context;
        private readonly IFileServices _fileServices;

        public SigmasServices(LooksmaxxingContext context , IFileServices fileServices)
        {
            _context = context;
            _fileServices = fileServices;
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

        public async Task<Sigma> Create(SigmaDto dto)
        {
            Sigma sigma = new Sigma();

            sigma.Id = Guid.NewGuid();
            sigma.SigmaXP = 0;
            sigma.SigmaXPNextLevel = 100;
            sigma.SigmaLevel = 0;
            sigma.SigmaStatus = Core.Domain.SigmaStatus.Alive;
            sigma.SigmaWasBorn = DateTime.Now;
            sigma.SigmaDied = DateTime.Parse("01/01/9999, 00:00:00");

            //set by user
            sigma.SigmaName = dto.SigmaName;
            sigma.SigmaType = (Core.Domain.SigmaType)dto.SigmaType;
            sigma.SigmaMove = dto.SigmaMove;
            sigma.SigmaMovePower = dto.SigmaMovePower;
            sigma.SpecialSigmaMove = dto.SpecialSigmaMove;
            sigma.SpecialSigmaMovePower = dto.SpecialSigmaMovePower;

            //set for db
            sigma.CreatedAt = DateTime.Now;
            sigma.UpdatedAt = DateTime.Now;

            //files
            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, sigma);
            }

            await _context.Sigmas.AddAsync(sigma);
            await _context.SaveChangesAsync();

            return sigma;
        }
    }
}
