using ITI.MVC.BLL.Interface;
using ITI.MVC.DAL.Context;
using ITI.MVC.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.BLL.Repo
{
    public class StudentRepo : IEntityType<Student>
    {
        private readonly SchoolDBContext schoolDbContext;

        public StudentRepo(SchoolDBContext _schoolDbContext)
        {
            schoolDbContext = _schoolDbContext;
        }
        public IEnumerable<Student> GetAll() => schoolDbContext.Students.Include(d=>d.Departments).ToList();

        public Student Get(int id) => schoolDbContext.Students.Include(d=>d.Departments).FirstOrDefault(s => s.Id == id);


        public void Add(Student model) => schoolDbContext.Students.Add(model);
        
        public void Update(Student model)=>schoolDbContext.Students.Update(model);

        public void Delete(Student model) => schoolDbContext.Students.Remove(model);

        public int Save() => schoolDbContext.SaveChanges();
        public bool EmailExist(string email) 
        {
            return schoolDbContext.Students.Any(s => s.Email == email);
        }
       
    }
}
