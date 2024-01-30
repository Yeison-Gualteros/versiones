using Contracts;
using Entities.Models.D_Acudiente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal sealed class DireccionAcudienteRepository : RepositoryBase<DireccionAcudiente>, IDireccionAcudienteRepository
    {
        public DireccionAcudienteRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<DireccionAcudiente> GetAllDireccionAcudientes(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.ColoniaBarrio)
                .ToList();

        public DireccionAcudiente GetDireccionAcudiente(Guid direccionAcudienteId, bool trackChanges) =>
            FindByCondition(c => c.DireccionAcudienteId.Equals(direccionAcudienteId), trackChanges)
                .SingleOrDefault();

        public void CreateDireccionAcudiente(DireccionAcudiente direccionAcudiente) => Create(direccionAcudiente);

        public IEnumerable<DireccionAcudiente> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.DireccionAcudienteId), trackChanges)
                .ToList();

        public void DeleteDireccionAcudiente(DireccionAcudiente direccionAcudiente) => Delete(direccionAcudiente);
    }
}

