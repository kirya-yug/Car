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
    
    public partial class CarOwner
    {
        public CarOwner()
        {
            this.results = new HashSet<results>();
        }
    
        public int id { get; set; }
        public string full_name { get; set; }
        public string address { get; set; }
        public string gender { get; set; }
        public int driver_license_no { get; set; }
        public System.DateTime DOB { get; set; }
    
        public virtual ICollection<results> results { get; set; }
    }
}
