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
    
    public partial class Subject
    {
        public Subject()
        {
            this.Classes = new HashSet<Classes>();
            this.StudentSubject = new HashSet<StudentSubject>();
            this.TeacherSubject = new HashSet<TeacherSubject>();
        }
    
        public int id_subject { get; set; }
        public string name { get; set; }
    
        public virtual ICollection<Classes> Classes { get; set; }
        public virtual ICollection<StudentSubject> StudentSubject { get; set; }
        public virtual ICollection<TeacherSubject> TeacherSubject { get; set; }
    }
}