//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Teacher
    {
        public Teacher()
        {
            this.SubjectGroup = new HashSet<SubjectGroup>();
        }
    
        public int idTeacher { get; set; }
        public string name { get; set; }
        public string lastName1 { get; set; }
        public string lastName2 { get; set; }
        public int telephone { get; set; }
    
        public virtual ICollection<SubjectGroup> SubjectGroup { get; set; }
    }
}