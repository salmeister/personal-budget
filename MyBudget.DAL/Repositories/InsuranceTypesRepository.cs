
namespace MyBudget.DAL.Repositories
{
    public interface IInsuranceTypesRepository : IRepository<InsuranceTypes>
    {
    }

    public class InsuranceTypesRepository : Repository<InsuranceTypes>, IInsuranceTypesRepository
    {
        public InsuranceTypesRepository(MyBudgetContext context) : base(context)
        {
        }
    }
}
