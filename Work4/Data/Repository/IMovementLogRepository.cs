using Work4.Models;

namespace Work4.Data.Repository
{
    public interface IMovementLogRepository : IRepository<MovementLog>
    {
        bool Delete(Employe employe);

        bool Delete(Post post);

        bool Delete(StructuralDivision division);
    }
}
