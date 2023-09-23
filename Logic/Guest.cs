using System.ComponentModel.DataAnnotations;

namespace mba.apiref
{
    public partial class Guest {
        public Guest(string dni, string name)
        {
            this.DNI = dni;
            this.Name = name;
            this.Emails = new List<Email>();

        }
        public override string ToString()
        {

            return $"DNI: {DNI}, Name: {Name}";
        }

        
    }
}