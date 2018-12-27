using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public class EmployeeStorage : IEmployeeStorage
    {
        private EmployeeContext _db;

        public EmployeeStorage()
        {
            _db = new EmployeeContext();
        }

        public void DeleteEmployee(int id)
        {
            var employee = _db.Employees.Find(id); // Try to find the employee by the ID

            if (employee == null) return;

            _db.Employees.Remove(employee); // Mark for deletion
            _db.SaveChanges(); // Save. Sends to database, employee gets deleted

        }
    }
}
