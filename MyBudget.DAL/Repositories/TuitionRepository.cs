
namespace MyBudget.DAL.Repositories
{
    public interface ITuitionRepository : IRepository<Tuition>
    {
    }

    public class TuitionRepository : Repository<Tuition>, ITuitionRepository
    {
        public TuitionRepository(MyBudgetContext context) : base(context)
        {
        }
    }
}
