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
    
    public partial class StudentClasses
    {
        public int id { get; set; }
        public int id_student { get; set; }
        public int id_class { get; set; }
    
        public virtual Classes Classes { get; set; }
        public virtual Student Student { get; set; }
    }
}
