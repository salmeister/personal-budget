
namespace MyBudget.DAL.Repositories
{
    public interface IIncomeSourcesRepository : IRepository<IncomeSources>
    {
    }

    public class IncomeSourcesRepository : Repository<IncomeSources>, IIncomeSourcesRepository
    {
        public IncomeSourcesRepository(MyBudgetContext context) : base(context)
        {
        }
    }
}
