//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClonestoneMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbllogin
    {
        public int idlogin { get; set; }
        public string email { get; set; }
        public string passcode { get; set; }
    
        public virtual tblperson tblperson { get; set; }
    }
}
