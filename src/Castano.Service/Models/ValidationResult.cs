namespace Castano.Service.Models
{
    using System.Collections.Generic;
    using System.Linq;

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
    }
}
