
using WebApplication1.DataAccess.Repository.IRepository;

namespace WebApplication1.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEmployeeService EmployeeService { get; private set; }

        private ApplicationDbContext _db;

        IConfiguration _config;

        public UnitOfWork(ApplicationDbContext db, IConfiguration config)
        {
            _config = config;
            _db = db;


            EmployeeService = new EmployeeService(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
