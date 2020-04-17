using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using WebApplication.DAL;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private const string ConString = "Data Source=jdbc:mysql://sql.zacard.nazwa.pl:3306;Initial Catalog=zacard_pjatk;Integrated Security=True";
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }
        
        
        [HttpGet]
        public IActionResult GetStudents([FromServices] IDbService dbService)
        {
            var list = new List<Students>();
            
            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "Select * from students";
                con.Open();
                var dr = com.ExecuteReader();
                while(dr.Read())
                {
                    var st = new Students();
                    st.FirstName = dr["FirstName"].ToString();
                }
            }

            return Ok(list);
        }
        
        [HttpGet("{indexNumber}")]
        public IActionResult GetStudent(string indexNumber)
        {
            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select * from students where indexnumber=@index";
                com.Parameters.AddWithValue("index", indexNumber);

                con.Open();
                var dr = com.ExecuteReader();
                if (dr.Read())
                {
                    var st = new Students();
                    st.IndexNumer = dr["IndexNumber"].ToString();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    return Ok(st);
                }

            }

            return NotFound();
        }
        [HttpPost]
        public IActionResult CreateStudent(Students student)
        {
            student.IndexNumer = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            return Ok($"Student o id:{id} zostal usunięty");
        }

        [HttpPut("{id}")]
        public IActionResult AddStudentPhoto(int id)
        {
            return Ok($"Aktualizacja zdjęcia dla studenta o id={id} została zakończona");
        }
        
    }
}