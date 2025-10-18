using ITI.MVC.BLL.Interface;
using ITI.MVC.DAL.Context;
using ITI.MVC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.BLL.Repo
{
    public class DepartmentRepo : IEntityType<Department>
    {
        private readonly SchoolDBContext schoolDbContext;

        public DepartmentRepo(SchoolDBContext _schoolDbContext)
        {
            schoolDbContext = _schoolDbContext;
        }
        public IEnumerable<Department> GetAll() => schoolDbContext.Departments.ToList();


        public Department Get(int id) => schoolDbContext.Departments.FirstOrDefault(d => d.Id == id);
        
        public void Add(Department model)=>schoolDbContext.Departments.Add(model);


        public void Update(Department model) => schoolDbContext.Departments.Update(model);

        public void Delete(Department model) => schoolDbContext.Departments.Remove(model);

        public int Save() => schoolDbContext.SaveChanges();
       
    }
}
