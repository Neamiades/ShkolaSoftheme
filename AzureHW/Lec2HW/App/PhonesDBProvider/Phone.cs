//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhonesDBProvider
{
    using System;
    using System.Collections.Generic;
    
    public partial class Phone
    {
        public int PhoneId { get; set; }
        public int BrandId { get; set; }
        public int ParamsId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    
        public virtual Brand Brand { get; set; }
        public virtual Param Param { get; set; }
    }
}
