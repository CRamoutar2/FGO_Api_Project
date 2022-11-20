using System;
using System.ComponentModel.DataAnnotations;

namespace FGO.Models
{
    public class Servants
    {
        [Key]
        public int ServantNumber { get; set; }
        public string? ServantName { get; set; }
        public bool isOwned { get; set; }
        public int StarRarity { get; set; }
    }
}
