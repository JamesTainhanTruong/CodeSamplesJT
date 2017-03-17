using Microsoft.Practices.Unity;
using Sabio.Web.Domain;
using Sabio.Web.Models.Requests.company;
using Sabio.Web.Models.Responses;
using Sabio.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sabio.Web.Controllers.Api
{
	[RoutePrefix("api/companyAdmin")]

    public class CompanyAdminApiController : ApiController
	{
        //*********** DEPENDENCY INJECTION ******************


        //Add an instance variable that has the type of the Interface
        [Dependency]
        public ICompanyAdminService _CompanyAdminService { get; set; }


        //*********** DEPENDENCY INJECTION ******************

        [Route(), HttpGet]
		public HttpResponseMessage GetAllComAndAdd()
		{
			if (!ModelState.IsValid)
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}

			ItemsResponse<CompanyAdminDomain> response = new ItemsResponse<CompanyAdminDomain>();


            // Add a public constructor that has a parameter for Interface that needs to be injected

            //modify  call to service method to call method on the injected service by using the object reference instead of the class name.

            List<CompanyAdminDomain> companyList = _CompanyAdminService.GetAllCompaniesAndAddress();


            response.Items = companyList;


            return Request.CreateResponse(HttpStatusCode.OK, response);
		}

		//==========================================================================================
		[Route("{id:int}"), HttpGet]

		public HttpResponseMessage CompanyGetById(int id)
		{
			if (!ModelState.IsValid)
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}
      
            CompanyAdminDomain singleCompany = _CompanyAdminService.CompanyAndAddressGetId(id);

            ItemResponse<CompanyAdminDomain> response = new ItemResponse<CompanyAdminDomain>();

            response.Item = singleCompany;

			return Request.CreateResponse(HttpStatusCode.OK, response);

		}

		//==========================================================================================
		[Route("{id:int}"), HttpPut]
		public HttpResponseMessage CompanyAdminEdit(CompanyAdminDomain model, int id)
		{
			if (!ModelState.IsValid)
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}

            bool isSuccessful = _CompanyAdminService.UpdateCompanyAdmin(model);

			ItemResponse<bool> response = new ItemResponse<bool>();

            response.Item = isSuccessful;

			return Request.CreateResponse(HttpStatusCode.OK, response);
		}

	}
}
