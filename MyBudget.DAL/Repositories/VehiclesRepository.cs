
namespace MyBudget.DAL.Repositories
{
    public interface IVehiclesRepository : IRepository<Vehicles>
    {
    }

    public class VehiclesRepository : Repository<Vehicles>, IVehiclesRepository
    {
        public VehiclesRepository(MyBudgetContext context) : base(context)
        {
        }
    }
}
