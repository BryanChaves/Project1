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
    
    public partial class StudentSubject
    {
        public int Id { get; set; }
        public int Student { get; set; }
        public string Subject { get; set; }
    
        public virtual Student Student1 { get; set; }
        public virtual Subject Subject1 { get; set; }
    }
}
