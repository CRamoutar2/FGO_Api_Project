using System;
using System.ComponentModel.DataAnnotations;

namespace FGO.Models
{
    public class NoblePhantasm
    {
        [Key]
        public int NpID { get; set; }
        public string? NpName { get; set; }
        public int NpLevel { get; set; }
        public int CorrespondingServantNumber { get; set; }
    }
}
