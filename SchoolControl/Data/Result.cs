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
    
    public partial class Result
    {
        public Result()
        {
            this.StudentSubject = new HashSet<StudentSubject>();
        }
    
        public int id_result { get; set; }
        public int id_student { get; set; }
        public int id_subject { get; set; }
        public int result1 { get; set; }
    
        public virtual ICollection<StudentSubject> StudentSubject { get; set; }
    }
}