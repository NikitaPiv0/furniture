namespace Мебель
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShopList")]
    public partial class ShopList : EntityValidator, IEntity<ShopList>
    {
        [NotMapped]
        public int Id { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ChequeId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FurnitureId { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Sum { get; set; }

        public virtual Cheque Cheque { get; set; }

        public virtual Furniture Furniture { get; set; }

        public void Set(ShopList shopList)
        {
            this.Quantity = shopList.Quantity;
            this.Sum = shopList.Sum;
            this.Cheque = shopList.Cheque;
            this.Furniture = shopList.Furniture;
            this.ChequeId = this.Cheque.Id;
            this.FurnitureId = this.Furniture.Id;
        }
    }
}
