using System.Collections;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.DAL
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Students> _students;

        static MockDbService()
        {
            _students = new List<Students>
            {
                new Students{IdStudent=1, FirstName="Jan", LastName="Kowalski"},
                new Students{IdStudent=2, FirstName="Piotr", LastName="Skrzypczak"},
                new Students{IdStudent=3, FirstName="Michal", LastName="Lewandowski"}
            };
        }

        public IEnumerable<Students> GetStudents()
        {
            return _students;
        }
    }
}