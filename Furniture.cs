namespace Мебель
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Furniture : EntityValidator, IEntity<Furniture>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Furniture()
        {
            ShopLists = new HashSet<ShopList>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Строка не может быть пустой.")]
        public string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal PriceIn { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal PriceOut { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Строка не может быть пустой.")]
        public string Warranty { get; set; }

        [Required(ErrorMessage = "Строка не может быть пустой.")]
        public string ArticleNumber { get; set; }

        public string Remarks { get; set; }

        [Range(0, double.MaxValue)]
        public int Discount { get; set; }

        [Required]
        public int FurnitureTypeId { get; set; }

        [Required]
        public int FurnitureColorId { get; set; }

        [Required]
        public int UnitsId { get; set; }

        public virtual FurnitureColor FurnitureColor { get; set; }

        public virtual FurnitureType FurnitureType { get; set; }

        public virtual Unit Unit { get; set; }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShopList> ShopLists { get; set; }
        
        public void Set(Furniture furniture)
        {
            this.Name = furniture.Name;
            this.PriceIn = furniture.PriceIn;
            this.PriceOut = furniture.PriceOut;
            this.Quantity = furniture.Quantity;
            this.Warranty = furniture.Warranty;
            this.ArticleNumber = furniture.ArticleNumber;
            this.Remarks = furniture.Remarks;
            this.Discount = furniture.Discount;
            this.FurnitureType = furniture.FurnitureType;
            this.FurnitureColor = furniture.FurnitureColor;
            this.Unit = furniture.Unit;
            this.FurnitureTypeId = this.FurnitureType.Id;
            this.FurnitureColorId = this.FurnitureColor.Id;
            this.UnitsId = this.Unit.Id;
        }
    }
}
