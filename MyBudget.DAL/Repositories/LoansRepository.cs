
namespace MyBudget.DAL.Repositories
{
    public interface ILoansRepository : IRepository<Loans>
    {
    }

    public class LoansRepository : Repository<Loans>, ILoansRepository
    {
        public LoansRepository(MyBudgetContext context) : base(context)
        {
        }
    }
}
