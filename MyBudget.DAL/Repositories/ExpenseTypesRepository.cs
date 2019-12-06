
namespace MyBudget.DAL.Repositories
{
    public interface IExpenseTypesRepository : IRepository<ExpenseTypes>
    {
    }

    public class ExpenseTypesRepository : Repository<ExpenseTypes>, IExpenseTypesRepository
    {
        public ExpenseTypesRepository(MyBudgetContext context) : base(context)
        {
        }
    }
}
