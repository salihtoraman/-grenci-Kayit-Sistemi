using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OgrenciKayitSistemi_Entity
{
    internal class EntityContext : DbContext
    {
        // public EntityContext() metodu sayesinde oluşturduğumuz EntityDB'ye bağlanmış olduk.
        public EntityContext() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ogrenci_Ekle;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {

        }
        public DbSet<Ogrenci_Ekle> Products { get; set; }
    }
}
