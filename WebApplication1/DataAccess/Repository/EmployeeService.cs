using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;
//using MySql.Data.MySqlClient;
using WebApplication1.DataAccess.Repository.IRepository;
using WebApplication1.Models;

namespace WebApplication1.DataAccess.Repository
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly string? ConnectionString;
        public EmployeeService(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public List<Employees> GetEmpList()
        {
            try
            {              
                var query = $"CALL sp_GetEmployees";

                var empList = _dbContext.Employees.FromSqlRaw(query).ToList();

                return empList;
            }
            catch (Exception ex)
            {
                return new List<Employees>();
            }

        }

        public Employees GetEmpById(int Id)
        {
            try
            {
                var parameter = new List<MySqlParameter>
                {                   
                    new MySqlParameter("@p_Id", Id),
                };
                var query = $"CALL sp_GetEmployeesById(@p_Id)";

                var emp = _dbContext.Employees
    .FromSqlRaw("CALL sp_GetEmployeesById({0})", Id)
    .AsEnumerable() // force execution before FirstOrDefault
    .FirstOrDefault();

                return emp;
            }
            catch (Exception ex)
            {
                return new Employees();
            }

        }

        public int addEmp(Employees emp)
        {
            int status;
            try
            {

                var parameter = new List<MySqlParameter>
                {
                    new MySqlParameter("@p_Name", emp.Name),
                    new MySqlParameter("@p_Age", emp.Age),
                    new MySqlParameter("@p_Degree", emp.Degree)
                };
                var query = $"CALL sp_AddEmployee(@p_Name,@p_Age,@p_Degree)";
                status = _dbContext.Database.ExecuteSqlRaw(query, parameter.ToArray());

                return status;

            }
            catch
            {
                return -1;
            }
        }

        public int updateEmp(Employees emp)
        {
            int status;
            try
            {

                var parameter = new List<MySqlParameter>
                {
                    new MySqlParameter("@p_Name", emp.Name),
                    new MySqlParameter("@p_Age", emp.Age),
                    new MySqlParameter("@p_Degree", emp.Degree),
                    new MySqlParameter("@p_EmpId", emp.EmpId)
                };
                var query = $"CALL sp_UpdateEmployee(@p_Name,@p_Age,@p_Degree,@p_EmpId)";
                status = _dbContext.Database.ExecuteSqlRaw(query, parameter.ToArray());

                return status;

            }
            catch
            {
                return -1;
            }
        }

        public int deleteEmp(int id)
        {
            int status;
            try
            {

                var parameter = new List<MySqlParameter>
                {
                    new MySqlParameter("@p_Id", id)
                };
                var query = $"CALL sp_DeleteEmployees(@p_Id)";
                status = _dbContext.Database.ExecuteSqlRaw(query, parameter.ToArray());

                return status;

            }
            catch
            {
                return -1;
            }
        }


        public Employees loginEmp(string Name, int Age)
        {
            try
            {
                // Parameters
                var parameters = new[]
                {
            new MySqlParameter("@p_Name", Name),
            new MySqlParameter("@p_Age", Age)
        };

                // Execute stored procedure
                var result = _dbContext.Employees
                    .FromSqlRaw("CALL sp_GetLogin(@p_Name, @p_Age)", parameters)
                    .AsEnumerable(); // force execution
                    

              
                // If your SP returns a full Employee entity, you can use its Id or a custom field
                return result.FirstOrDefault(); // example: 1 = found, 0 = not found
            }
            catch
            {
                return new Employees(); // error
            }
        }
    }
}
