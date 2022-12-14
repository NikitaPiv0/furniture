namespace Мебель
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee : EntityValidator, IEntity<Employee>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Строка не может быть пустой.")]
        public string FIO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }

        public void Set(Employee employee)
        {
            this.FIO = employee.FIO;
        }
    }
}
