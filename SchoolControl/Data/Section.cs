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
    
    public partial class Section
    {
        public Section()
        {
            this.SectionLevel = new HashSet<SectionLevel>();
            this.StudentSection = new HashSet<StudentSection>();
        }
    
        public int Id { get; set; }
        public string Section1 { get; set; }
    
        public virtual ICollection<SectionLevel> SectionLevel { get; set; }
        public virtual ICollection<StudentSection> StudentSection { get; set; }
    }
}
