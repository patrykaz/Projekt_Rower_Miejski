//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projekt_Rower_Miejski
{
    using System;
    using System.Collections.Generic;
    
    public partial class Serwis_roweru
    {
        public int ID_serwisu { get; set; }
        public Nullable<int> ID_roweru_FK { get; set; }
        public Nullable<int> ID_pracownika_FK { get; set; }
        public string Opis_usterki { get; set; }
        public decimal Kwota_naprawy { get; set; }
        public Nullable<System.DateTime> Data_naprawy { get; set; }
    
        public virtual Pracownicy Pracownicy { get; set; }
        public virtual Rowery Rowery { get; set; }
    }
}
