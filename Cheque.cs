namespace Мебель
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cheque : EntityValidator, IEntity<Cheque>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cheque()
        {
            ShopLists = new List<ShopList>();
        }

        public int Id { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        [Required]
        public bool Delivery { get; set; }

        [Required]
        public bool Assembly { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Sum { get; set; }

        //[Required]
        //[Range(0, double.MaxValue)]
        //public decimal OddMoney { get; set; }

        public string Remarks { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public int PaymentId { get; set; }

        public virtual Client Client { get; set; }

        public virtual Payment Payment { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<ShopList> ShopLists { get; set; }

        public void Set(Cheque cheque)
        {
            this.Date = cheque.Date;
            this.Remarks = cheque.Remarks;
            this.Delivery = cheque.Delivery;
            this.Assembly = cheque.Assembly;
            this.Sum = cheque.Sum;
            this.User = cheque.User;
            this.Client = cheque.Client;
            this.Payment = cheque.Payment;
            this.UserId = this.User.Id;
            this.ClientId = this.Client.Id;
            this.PaymentId = this.Payment.Id;
        }
    }
}
