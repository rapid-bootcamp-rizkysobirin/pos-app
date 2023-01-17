using POS.Repository;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class EmployeeService
    {
        private readonly ApplicationDBContext _context;
        private EmployeeModel EntityToModel(EmployeesEntity entity)
        {
            EmployeeModel result= new EmployeeModel();
            result.Id= entity.Id;
            result.FirstName= entity.FirstName;
            result.LastName= entity.LastName;
            result.Title= entity.Title;
            result.TitleOfCourtesy= entity.TitleOfCourtesy;
            result.BirthDate= entity.BirthDate;
            result.HireDate= entity.HireDate;
            result.Address= entity.Address;
            result.City= entity.City;
            result.Region= entity.Region;
            result.PostalCode= entity.PostalCode;
            result.Country= entity.Country;
            result.HomePhone= entity.HomePhone;
            result.Extension= entity.Extension;
            result.Notes= entity.Notes;
            result.ReportTo= entity.ReportTo;
            result.PhotoPath= entity.PhotoPath;
            return result;
        }

        private void ModelToEntity(EmployeeModel model, EmployeesEntity entity)
        {
            entity.LastName= model.LastName;
            entity.FirstName= model.FirstName;
            entity.Title= model.Title;
            entity.TitleOfCourtesy= model.TitleOfCourtesy;
            entity.BirthDate= model.BirthDate;
            entity.HireDate= model.HireDate;
            entity.Address= model.Address;
            entity.City= model.City;
            entity.Region= model.Region;
            entity.PostalCode= model.PostalCode;
            entity.Country= model.Country;
            entity.HomePhone= model.HomePhone;
            entity.Extension= model.Extension;
            entity.Notes= model.Notes;
            entity.ReportTo= model.ReportTo;
            entity.PhotoPath= model.PhotoPath;
        }

        public EmployeeService(ApplicationDBContext context)
        {
            _context= context;
        }

        public List<EmployeesEntity> GetEmployees()
        {
            return _context.employeeEntities.ToList();
        }

        public void Add(EmployeesEntity employee)
        {
            _context.employeeEntities.Add(employee);
            _context.SaveChanges();
        }

        public EmployeeModel View(int? id)
        {
            var employee = _context.employeeEntities.Find(id);
            return EntityToModel(employee);
        }

        public void Update(EmployeeModel employee)
        {
            var entity = _context.employeeEntities.Find(employee.Id);
            ModelToEntity(employee, entity);
            _context.employeeEntities.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var entity = _context.employeeEntities.Find(id);
            _context.employeeEntities.Remove(entity);
            _context.SaveChanges();
        }
    }
}
