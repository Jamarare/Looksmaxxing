using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Looksmaxxing.Core.Domain
{
    public class SigmaOwnership : Sigma
    {
        public Guid OwnershipID { get; set; }
        public int SigmaHealth { get; set; }
        public int SigmaXP { get; set; }
        public int SigmaXPNextLevel { get; set; }
        public int SigmaLevel { get; set; }
        public SigmaStatus SigmaStatus { get; set; }
        public int SigmaMovePower { get; set; }
        public int SpecialSigmaMovePower { get; set; }
        public DateTime SigmaWasBorn { get; set; }
        public DateTime SigmaDied { get; set; }
        //public string OwnedByPlayerProfile { get; set; } //is string but holds guid
        //db only
        public DateTime OwnershipCreatedAt { get; set; }
        public DateTime OwnershipUpdatedAt { get; set; }
    }
}
