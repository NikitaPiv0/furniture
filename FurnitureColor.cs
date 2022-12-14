namespace Мебель
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FurnitureColor : EntityValidator, IEntity<FurnitureColor>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FurnitureColor()
        {
            Furnitures = new HashSet<Furniture>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Строка не может быть пустой.")]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Furniture> Furnitures { get; set; }

        public void Set(FurnitureColor furnitureColor)
        {
            this.Name = furnitureColor.Name;
        }
    }
}
