//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Parking
{
    using System;
    using System.Collections.Generic;
    
    public partial class VLASNIK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VLASNIK()
        {
            this.PARKINGs = new HashSet<PARKING>();
        }
    
        public int id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PARKING> PARKINGs { get; set; }
        public override string ToString()
        {
            return $"{Ime} {Prezime}"; // Customize the format as needed
        }
    }
}