using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiddleWare_Sample.ActionFilter;
using MiddleWare_Sample.ResultViewModel;

namespace MiddleWare_Sample.Controllers
{
    [Route("api/[controller]/[action]")]
    [FixStatusCodeFilter]
    public class GenericController: ControllerBase
    {

    }



    public class OperationController : GenericController
    {
        private readonly Services.Service _services;
        public OperationController(Services.Service service)
        {
            _services = service;
        }


        [HttpGet]
        public FuncResult CompanyList()
        {
           return _services.GetAllCompanies();
            
        }

        [HttpGet("{Id}")]

        public FuncResult CompanyById([FromRoute]int Id )
        {
            return _services.CompanyById(Id);
             
        }

        [HttpGet("{Name}")]
        public FuncResult CompanyByName([FromRoute] string name)
        {
            return _services.CompanyByName(name);
            
        }

        [HttpGet("{Id}")]
        public FuncResult DeleteCompany([FromRoute] int Id)
        {
            return _services.DeleteCompanyId(Id);

        }

        [HttpGet("{Id}")]
        [FixStatusCodeFilter]

        public FuncResult DeleteEmployeeById([FromRoute] int Id)
        {
            return _services.DeleteEmployeeById(Id);

        }

        [HttpGet]
        public FuncResult EmployeesList()
        {
            return  _services.Employees();

        }

        [HttpGet]
        public FuncResult DoSomething([FromQuery]int companyId)
        {
            return _services.DoSomething(companyId);
        }


    }
}
