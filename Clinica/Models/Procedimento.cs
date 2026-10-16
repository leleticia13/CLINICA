using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class Procedimento : ICloneable
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public Procedimento(string nome, decimal valor)
        {
            Nome = nome;
            Valor = valor;
        }

        // Clonagem Manual: Criamos uma NOVA instância usando 'new' com os mesmos dados
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
