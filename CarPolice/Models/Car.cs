//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarPolice.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Car
    {
        public Car()
        {
            this.results = new HashSet<results>();
        }
    
        public int id { get; set; }
        public string body_no { get; set; }
        public string license_plate { get; set; }
        public string mark { get; set; }
        public string color { get; set; }
        public string engine_no { get; set; }
        public int pass_no { get; set; }
    
        public virtual ICollection<results> results { get; set; }
    }
}
