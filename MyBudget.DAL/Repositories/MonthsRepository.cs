
namespace MyBudget.DAL.Repositories
{
    public interface IMonthsRepository : IRepository<Months>
    {
    }

    public class MonthsRepository : Repository<Months>, IMonthsRepository
    {
        public MonthsRepository(MyBudgetContext context) : base(context)
        {
        }
    }
}
