using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OgrenciKayitSistemi_Entity
{
    internal class Ogrenci_EkleDal
    {
        public List<Ogrenci_Ekle> GetAll()
        {
            using (EntityContext context = new EntityContext())
            {
                return context.Products.ToList();
            }
        }
        public void Add(Ogrenci_Ekle ogrenci_Ekle)
        {
            using (EntityContext context = new EntityContext())
            {
                var ent = context.Entry(ogrenci_Ekle);
                ent.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Update(Ogrenci_Ekle ogrenci_Ekle)
        {
            using (EntityContext context = new EntityContext())
            {
                var ent = context.Entry(ogrenci_Ekle);
                ent.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(Ogrenci_Ekle ogrenci_Ekle)
        {
            using (EntityContext context = new EntityContext())
            {
                var ent = context.Entry(ogrenci_Ekle);
                ent.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public List<Ogrenci_Ekle> Arama(string aranan)
        {
            using (EntityContext context = new EntityContext())
            {
                return context.Products.Where(b => b.Isim.Contains(aranan)).ToList();
            }
        }
    }
}
