using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OgrenciKayitSistemi_Entity
{
    internal class Ogrenci_Ekle
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string Telefon { get; set; }
        public string TC { get; set; }
        public string Resim { get; set; }
    }
}
