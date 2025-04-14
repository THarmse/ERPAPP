using System.ComponentModel.DataAnnotations;

namespace ERPAPP.Data
{
    public class MyItem
    {
        [Key]
        public int ItemID { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
