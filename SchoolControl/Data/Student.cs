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
    
    public partial class Student
    {
        public Student()
        {
            this.ResultSubjectStudent = new HashSet<ResultSubjectStudent>();
            this.StudentLevel = new HashSet<StudentLevel>();
            this.StudentSection = new HashSet<StudentSection>();
            this.StudentSubject = new HashSet<StudentSubject>();
        }
    
        public int Id { get; set; }
        public int Identification { get; set; }
        public string Name { get; set; }
        public string Lastname1 { get; set; }
        public string Lastname2 { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int Telephone { get; set; }
    
        public virtual ICollection<ResultSubjectStudent> ResultSubjectStudent { get; set; }
        public virtual ICollection<StudentLevel> StudentLevel { get; set; }
        public virtual ICollection<StudentSection> StudentSection { get; set; }
        public virtual ICollection<StudentSubject> StudentSubject { get; set; }
    }
}
