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
    
    public partial class results
    {
        public int id { get; set; }
        public int id_car { get; set; }
        public Nullable<int> id_officer { get; set; }
        public int id_employee { get; set; }
        public int id_owner { get; set; }
        public int id_inspection { get; set; }
    
        public virtual Car Car { get; set; }
        public virtual CarOwner CarOwner { get; set; }
        public virtual CompanyEmployee CompanyEmployee { get; set; }
        public virtual Officer Officer { get; set; }
        public virtual TechnicalInspection TechnicalInspection { get; set; }
    }
}