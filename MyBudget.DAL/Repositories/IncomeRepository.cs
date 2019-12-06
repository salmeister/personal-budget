
namespace MyBudget.DAL.Repositories
{
    public interface IIncomeRepository : IRepository<Income>
    {
    }

    public class IncomeRepository : Repository<Income>, IIncomeRepository
    {
        public IncomeRepository(MyBudgetContext context) : base(context)
        {
        }
    }
}
