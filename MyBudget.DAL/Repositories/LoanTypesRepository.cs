
namespace MyBudget.DAL.Repositories
{
    public interface ILoanTypesRepository : IRepository<LoanTypes>
    {
    }

    public class LoanTypesRepository : Repository<LoanTypes>, ILoanTypesRepository
    {
        public LoanTypesRepository(MyBudgetContext context) : base(context)
        {
        }
    }
}
