using System;

namespace WebApplication.Models
{
    public class Students
    {
        public int IdStudent { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string IndexNumer { get; set; }
        
        public DateTime Birthdate { get; set; }
        public string Studies { get; set; }
        public int Semester { get; set; }
    }
}