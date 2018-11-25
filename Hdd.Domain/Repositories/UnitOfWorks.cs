
using Hdd.Domain.Models;

namespace Hdd.Domain.Repositories
{
    public class UnitOfWork
    {
        private HddEntities _db;

        public UnitOfWork()
        {
            this._db = new HddEntities();
        }

        public void Save() => _db.SaveChanges();

        private IRepository<Supplier> supplierRepo;

        public IRepository<Supplier> SupplierRepository
        {
            get
            {
                if (this.supplierRepo == null)
                {
                    this.supplierRepo = new Repository<Supplier>(_db);
                }
                return supplierRepo;
            }
        }

        


        

    }
}
