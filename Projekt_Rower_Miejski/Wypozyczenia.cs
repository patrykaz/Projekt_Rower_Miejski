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
    
    public partial class Wypozyczenia
    {
        public int ID_wypozyczenia { get; set; }
        public Nullable<int> ID_roweru_FK { get; set; }
        public Nullable<int> ID_klienta_FK { get; set; }
        public Nullable<int> ID_pracownika_FK { get; set; }
        public Nullable<System.DateTime> Data_czas_wypozyczenia { get; set; }
        public Nullable<System.DateTime> Data_czas_oddania { get; set; }
        public Nullable<System.TimeSpan> Czas_wypozyczenia { get; set; }
        public decimal Cena_wypozyczenia_za_godzine { get; set; }
    
        public virtual Klienci Klienci { get; set; }
        public virtual Pracownicy Pracownicy { get; set; }
        public virtual Rowery Rowery { get; set; }
    }
}
