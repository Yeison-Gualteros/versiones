using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions;
public class DireccionAcudienteNotFoundException : NotFoundException
{
	public DireccionAcudienteNotFoundException(Guid documentoId)
        : base($"Employee with id: {documentoId} doesn't exist in the database.")
    {
    }
}

