
namespace MyBudget.DAL.Repositories
{
    public interface IPaymentsRepository : IRepository<Payments>
    {
    }

    public class PaymentsRepository : Repository<Payments>, IPaymentsRepository
    {
        public PaymentsRepository(MyBudgetContext context) : base(context)
        {
        }
    }
}
