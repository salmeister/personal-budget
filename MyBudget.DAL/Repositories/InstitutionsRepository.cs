
namespace MyBudget.DAL.Repositories
{
    public interface IInstitutionsRepository : IRepository<Institutions>
    {
    }

    public class InstitutionsRepository : Repository<Institutions>, IInstitutionsRepository
    {
        public InstitutionsRepository(MyBudgetContext context) : base(context)
        {
        }
    }
}
