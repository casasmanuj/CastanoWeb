namespace Castano.Service.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ValidationResult
    {
        public ValidationResult()
        {
            this.Errores = new List<string>();
        }
        public List<string> Errores { get; set; }
        public bool IsValid => !Errores.Any();

        public void AddError(string error)
        {
            this.Errores.Add(error);
        }

        public string MensajeErrores
        {
            get
            {
                var stringBuilder = new StringBuilder();

                Errores.ForEach(e => stringBuilder.AppendLine(e));

                return stringBuilder.ToString();
            }
        }
    }
}
