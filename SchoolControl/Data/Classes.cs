//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Classes
    {
        public Classes()
        {
            this.StudentClasses = new HashSet<StudentClasses>();
        }
    
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
    
        public virtual Subject Subject { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<StudentClasses> StudentClasses { get; set; }
    }
}
