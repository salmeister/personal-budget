
namespace MyBudget.DAL.Repositories
{
    public interface IYearsRepository : IRepository<Years>
    {
    }

    public class YearsRepository : Repository<Years>, IYearsRepository
    {
        public YearsRepository(MyBudgetContext context) : base(context)
        {
        }
    }
}
