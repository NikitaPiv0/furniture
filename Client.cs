namespace Мебель
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Client : EntityValidator, IEntity<Client>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Cheques = new HashSet<Cheque>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Строка не может быть пустой.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Строка не может быть пустой.")]
        public string FIO { get; set; }

        [Required(ErrorMessage = "Строка не может быть пустой.")]
        [StringOfNumber(MinLenght = 6, MaxLenght = 11)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Строка не может быть пустой.")]
        [StringOfNumber(MinLenght = 20, MaxLenght = 20)]
        public string PaymentAccount { get; set; }

        [Required(ErrorMessage = "Строка не может быть пустой.")]
        [StringOfNumber(MinLenght = 20, MaxLenght = 20)]
        public string CorrespondentAccount { get; set; }

        [Required(ErrorMessage = "Строка не может быть пустой.")]
        [StringOfNumber(MinLenght = 6, MaxLenght = 6)]
        public string BIK { get; set; }

        [Required(ErrorMessage = "Строка не может быть пустой.")]
        [StringOfNumber(MinLenght = 12, MaxLenght = 12)]
        public string INN { get; set; }

        [Required(ErrorMessage = "Строка не может быть пустой.")]
        [StringOfNumber(MinLenght = 13, MaxLenght = 13)]
        public string OGRN { get; set; }

        [Required(ErrorMessage = "Строка не может быть пустой.")]
        [StringOfNumber(MinLenght = 4, MaxLenght = 4)]
        public string PassportSeries { get; set; }

        [Required(ErrorMessage = "Строка не может быть пустой.")]
        [StringOfNumber(MinLenght = 6, MaxLenght = 6)]
        public string PassportNumber { get; set; }

        [Required(ErrorMessage = "Строка не может быть пустой.")]
        public string PassportIssued { get; set; }

        [Required(ErrorMessage = "Укажите дату.")]
        [Column(TypeName = "datetime2")]
        public DateTime PassportDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cheque> Cheques { get; set; }

        public void Set(Client client)
        {
            this.Name = client.Name;
            this.FIO = client.FIO;
            this.Phone = client.Phone;
            this.PaymentAccount = client.PaymentAccount;
            this.CorrespondentAccount = client.CorrespondentAccount;
            this.BIK = client.BIK;
            this.INN = client.INN;
            this.OGRN = client.OGRN;
            this.PassportSeries = client.PassportSeries;
            this.PassportNumber = client.PassportNumber;
            this.PassportIssued = client.PassportIssued;
            this.PassportDate = client.PassportDate;
        }
    }
}
