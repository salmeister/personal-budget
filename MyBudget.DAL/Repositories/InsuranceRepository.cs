
namespace MyBudget.DAL.Repositories
{
    public interface IInsuranceRepository : IRepository<Insurance>
    {
    }

    public class InsuranceRepository : Repository<Insurance>, IInsuranceRepository
    {
        public InsuranceRepository(MyBudgetContext context) : base(context)
        {
        }
    }
}
