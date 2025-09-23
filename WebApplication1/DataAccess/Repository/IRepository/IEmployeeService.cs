using WebApplication1.Models;

namespace WebApplication1.DataAccess.Repository.IRepository
{
    public interface IEmployeeService
    {
        public List<Employees> GetEmpList();
        public Employees GetEmpById(int Id);
        public int addEmp(Employees emp);
        public int updateEmp(Employees emp);
        public int deleteEmp(int id);

        public Employees loginEmp(string Name, int Age);
    }
}
