namespace Мебель
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User : EntityValidator, IEntity<User>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Cheques = new HashSet<Cheque>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Строка не может быть пустой.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Строка не может быть пустой.")]
        public string Password { get; set; }

        public int EmployeeId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cheque> Cheques { get; set; }

        public virtual Employee Employee { get; set; }

        public void Set(User user)
        {
            this.Login = user.Login;
            this.Password = user.Password;
            this.Employee = user.Employee;
            this.EmployeeId = this.Employee.Id;
        }
    }
}
