namespace Мебель
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Payment : EntityValidator, IEntity<Payment>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Payment()
        {
            Cheques = new HashSet<Cheque>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Строка не может быть пустой.")]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cheque> Cheques { get; set; }

        public void Set(Payment payment)
        {
            this.Name = payment.Name;
        }
    }
}
