
namespace MyBudget.DAL.Repositories
{
    public interface IFamilyMembersRepository : IRepository<FamilyMembers>
    {
    }

    public class FamilyMembersRepository : Repository<FamilyMembers>, IFamilyMembersRepository
    {
        public FamilyMembersRepository(MyBudgetContext context) : base(context)
        {
        }
    }
}
