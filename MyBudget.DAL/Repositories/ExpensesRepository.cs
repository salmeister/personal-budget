
namespace MyBudget.DAL.Repositories
{
    public interface IExpensesRepository : IRepository<Expenses>
    {
    }

    public class ExpensesRepository : Repository<Expenses>, IExpensesRepository
    {
        public ExpensesRepository(MyBudgetContext context) : base(context)
        {
        }
    }
}
