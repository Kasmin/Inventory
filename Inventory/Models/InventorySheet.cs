using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class InventorySheet
    {
        public int Id { get; set; }
        [Display(Name = "Номер счета")]
        public string AccountNumber { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public List<InventoryItem> InventoryItems { get; set; }

        public InventorySheet()
        {

        }
    }
}
