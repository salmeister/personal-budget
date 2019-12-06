
namespace MyBudget.DAL.Repositories
{
    public interface IPropertiesRepository : IRepository<Properties>
    {
    }

    public class PropertiesRepository : Repository<Properties>, IPropertiesRepository
    {
        public PropertiesRepository(MyBudgetContext context) : base(context)
        {
        }
    }
}
