namespace UniversalReports.NG2Statistic.Data.GrandTotal
{
    public class GrandTotalServiceImp : GrandTotalService
    {
        private Repository repository;

        public GrandTotalServiceImp(Repository repository)
        {
            this.repository = repository;
        }

        public GrandTotalModel Query(QueryModel queryModel)
        {
            return repository.Query(queryModel);
        }
    }
}