namespace WebApplication1.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IEmployeeService EmployeeService { get; }

        void Save();
    }
}
