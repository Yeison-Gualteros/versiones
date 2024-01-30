using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Shared.DataTransferObjects;
using System.Text;

namespace CompanyEmployees;

public class CsvOutputFormatter : TextOutputFormatter
{
    public CsvOutputFormatter()
    {
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
        SupportedEncodings.Add(Encoding.UTF8);
        SupportedEncodings.Add(Encoding.Unicode);
    }

    protected override bool CanWriteType(Type? type)
    {
        if (typeof(CandidatoEstudianteDto).IsAssignableFrom(type)
            || typeof(IEnumerable<CandidatoEstudianteDto>).IsAssignableFrom(type))
        {
            return base.CanWriteType(type);
        }

        return false;
    }

    public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context,
        Encoding selectedEncoding)
    {
        var response = context.HttpContext.Response;
        var buffer = new StringBuilder();

        if (context.Object is IEnumerable<CandidatoEstudianteDto>)
        {
            foreach (var candidatoEstudiante in (IEnumerable<CandidatoEstudianteDto>)context.Object)
            {
                FormatCsv(buffer, candidatoEstudiante);
            }
        }
        else
        {
            FormatCsv(buffer, (CandidatoEstudianteDto)context.Object);
        }

        await response.WriteAsync(buffer.ToString());
    }

    private static void FormatCsv(StringBuilder buffer, CandidatoEstudianteDto candidatoEstudiante)
    {
        buffer.AppendLine($"{candidatoEstudiante.CandidatoEstudianteId},\"{candidatoEstudiante.Nombre}\",\"{candidatoEstudiante.Apellido}\",{FormatNullableDate(candidatoEstudiante.FechaNacimiento)},\"{candidatoEstudiante.TipoPersona}\"");
    }

    private static string FormatNullableDate(DateTime? date)
    {
        return date.HasValue ? date.Value.ToString("yyyy-MM-dd") : string.Empty;
    }




}
