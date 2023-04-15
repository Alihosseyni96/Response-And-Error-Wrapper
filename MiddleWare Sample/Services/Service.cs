using Microsoft.EntityFrameworkCore;
using MiddleWare_Sample.Model;
using MiddleWare_Sample.ResultViewModel;

namespace MiddleWare_Sample.Services
{
    public class Service
    {
        private readonly MiddleWareDbContext _db = new MiddleWareDbContext();

        public FuncResult GetAllCompanies()
        {
            var res = _db.Companies.ToList();

            return new FuncResult()
            {
                Entity = res,
                IsSuccess = true,
                Status = Status.ok,
                Total = res.Count,
            };
        }

        public FuncResult CompanyById(int id)
        {
            var res = _db.Companies.Single(x => x.Id == id);
            return new FuncResult()
            {
                Entity = res,
                IsSuccess = true,
                Status = Status.ok,
            };
        }

        public FuncResult CompanyByName(string name)
        {
            var res = _db.Companies.Single(x => x.Name == name);
            return new FuncResult()
            {
                Entity = res,
                IsSuccess = true,
                Status = Status.ok,
            };
        }

        public FuncResult DeleteCompanyId(int id)
        {
            var res = _db.Companies.Find(id);
            _db.Companies.Remove(res);
            var r = _db.SaveChanges();
            if (r > 0)
            {
                return new FuncResult()
                {
                    IsSuccess = true,
                    Status = Status.ok,
                };
            }
            return new FuncResult()
            {

                IsSuccess = false,
                Status = Status.InternalServerError,
                Error = new Error() { Message = "something goes wrong try again later" }
            };

        }



        public FuncResult DeleteEmployeeById(int Id)
        {
            var res = _db.Employees.Find(Id);
            _db.Remove(res);
            var s = _db.SaveChanges();
            if (s > 0)
            {
                return new FuncResult()
                {
                    IsSuccess = true,
                    Status = Status.ok,
                };
            }
            return new FuncResult
            {
                IsSuccess = false,
                Status = Status.InternalServerError,
                Error = new Error() { Message = "something goes wrong try again later" }

            };
        }

        public FuncResult Employees()
        {
            var res = _db.Employees.ToList();
            return new FuncResult()
            {
                Entity = res,
                IsSuccess = true,
                Status = Status.ok,
                Total = res.Count
            };
        }

        public FuncResult DoSomething(int companyId)
        {
            if (companyId < 5)
            {
                return new FuncResult()
                {
                    IsSuccess = false,
                    Status = Status.BadRequest,
                    Error = new Error() { Message = "شناسه شرکت نمیتواند کمتر از  5  باشد" }
                };
            }
            if (companyId is 5)
            {
                return new FuncResult()
                {
                    Status = Status.ok,
                };
            }
            return new FuncResult()
            {
                Status = Status.ok,
                IsSuccess = true,
            };

        }


    }
}
