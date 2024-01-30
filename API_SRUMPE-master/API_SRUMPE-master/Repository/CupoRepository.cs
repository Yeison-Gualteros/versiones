using Contracts;
using Entities.Models.D_Estudiante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal sealed class CupoRepository : RepositoryBase<Cupo>, ICupoRepository
    {
        public CupoRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Cupo> GetAllCupos(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.Duracion)
                .ToList();

        public Cupo GetCupo(Guid cupoId, bool trackChanges) =>
            FindByCondition(c => c.CupoId.Equals(cupoId), trackChanges)
            .SingleOrDefault();

        public void CreateCupo(Cupo cupo) => Create(cupo);

        public IEnumerable<Cupo> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.CupoId), trackChanges)
        .ToList();

        public void DeleteCupo(Cupo cupo) => Delete(cupo);
    }
}
