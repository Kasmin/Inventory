using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class InventoryItem
    {
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Display(Name = "Инвентар. №")]
        public string InventoryNumber { get; set; }
        [Display(Name = "Количество")]
        public int Count { get; set; }
        [Display(Name = "Стоимость")]
        public double Cost { get; set; }
        [Display(Name = "Дата постановки на учет")]
        [DataType(DataType.Date)]
        public DateTime DateOfRegistration { get; set; }
        [Display(Name = "Срок эксплуатации")]
        public int LifeTime { get; set; }
        [Display(Name = "Примечание")]
        public string Description { get; set; }
        public int InventorySheetId { get; set; }
        public InventorySheet InventorySheet { get; set; }
    }
}
