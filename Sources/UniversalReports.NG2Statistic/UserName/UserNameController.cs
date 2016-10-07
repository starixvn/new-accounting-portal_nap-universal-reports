using System.Web.Http;
using UniversalReports.MVC.Results;
using UniversalReports.NG2Statistic.BaseServices;

namespace UniversalReports.NG2Statistic.UserName
{
    [RoutePrefix("api/ng2-statistic/username")]
    public class UserNameController : ApiController
    {
        private readonly UserNameService service;
        private readonly GridOptionsBuilder builder;
        private readonly GridOptionHeaderColumn header;

        public UserNameController(UserNameService service, GridOptionsBuilder builder, GridOptionHeaderColumn header)
        {
            this.service = service;
            this.builder = builder;
            this.header = header;
        }

        [Route("")]
        public IHttpActionResult UserName(QueryModel queryModel)
        {
            var userNameModel = service.Query(queryModel);
            var gridOptions = builder.Build(userNameModel, queryModel.Title);
            gridOptions = header.Build(gridOptions, queryModel);

            return Json(gridOptions);
        }

        [Route("sort")]
        public IHttpActionResult Sort(QueryModel queryModel)
        {
            var userNameModel = service.SortData(queryModel);
            var gridOptions = builder.Build(userNameModel, queryModel.Title);
            gridOptions = header.Build(gridOptions, queryModel);

            return Json(gridOptions);
        }

        [Route("excel")]
        public IHttpActionResult Excel(QueryModel queryModel)
        {
            var userNameModel = service.Query(queryModel);
            var gridOptions = builder.Build(userNameModel, queryModel.Title);
            gridOptions = header.Build(gridOptions, queryModel);

            return new FanexExcelResult(gridOptions, "NG2 Statistic");
        }
    }
}