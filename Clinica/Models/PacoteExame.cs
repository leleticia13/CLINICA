using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class PacoteExame : ICloneable
    {
        public string NomePacote { get; set; }
        public string OrientacoesJejum { get; set; }
        public string NomePaciente { get; set; }
        public List<Procedimento> Procedimentos { get; set; }

        public PacoteExame(string nomePacote, string orientacoesJejum)
        {
            NomePacote = nomePacote;
            OrientacoesJejum = orientacoesJejum;
            NomePaciente = "NÃO ATRIBUÍDO";
            Procedimentos = new List<Procedimento>();
        }

        public void AdicionarProcedimento(Procedimento procedimento)
        {
            Procedimentos.Add(procedimento);
        }

        // Cópia profunda (Deep Copy)
        public object Clone()
        {
            // Cria um novo pacote
            PacoteExame pacoteClonado =
                new PacoteExame(this.NomePacote, this.OrientacoesJejum);

            pacoteClonado.NomePaciente = this.NomePaciente;

            // Clona cada procedimento para criar uma lista independente
            foreach (Procedimento item in this.Procedimentos)
            {
                Procedimento itemCopia = (Procedimento)item.Clone();
                pacoteClonado.Procedimentos.Add(itemCopia);
            }

            return pacoteClonado;
        }

        // Cópia superficial, mantida para fins de comparação
        public PacoteExame ClonarSuperficial()
        {
            PacoteExame pacoteRaso =
                new PacoteExame(this.NomePacote, this.OrientacoesJejum);

            pacoteRaso.NomePaciente = this.NomePaciente;

            // Compartilha a mesma lista de procedimentos
            pacoteRaso.Procedimentos = this.Procedimentos;

            return pacoteRaso;
        }

        public void ExibirResumo()
        {
            Console.WriteLine(
                $"\n[PACOTE]: {NomePacote} | Paciente: {NomePaciente}");

            Console.WriteLine($"  Orientação: {OrientacoesJejum}");
            Console.WriteLine("  Procedimentos inclusos:");

            decimal total = 0;

            foreach (var p in Procedimentos)
            {
                Console.WriteLine($"   - {p.Nome}: R$ {p.Valor:F2}");
                total += p.Valor;
            }

            Console.WriteLine($"  Total: R$ {total:F2}");
        }
    }
}
