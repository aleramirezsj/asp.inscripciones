using System.ComponentModel.DataAnnotations.Schema;
using Inscripciones.Models.MesasExamenes;

namespace Inscripciones.Models
{
    public class DetalleMesaExamen
    {
        public int Id { get; set; }
        public int MesaExamenId { get; set; }
        public MesaExamen? MesaExamen { get; set; }
        public int DocenteId { get; set; }
        public Docente? Docente { get; set; }
        public TipoIntegranteEnum TipoIntegrante { get; set; }
        public override string ToString()
        {
            return $"{Docente?.Nombre} {TipoIntegrante}" ?? string.Empty;
        }

    }
}
