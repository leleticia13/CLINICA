using Clinica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class PacoteExame : IPrototipo<PacoteExame>
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
        public PacoteExame Clonar()
        {
            // Copia os dados básicos do pacote
            PacoteExame pacoteClonado = (PacoteExame)this.MemberwiseClone();

            // Cria uma nova lista independente
            pacoteClonado.Procedimentos = new List<Procedimento>();

            // Clona cada procedimento
            foreach (Procedimento item in this.Procedimentos)
            {
                Procedimento itemCopia = item.Clonar();
                pacoteClonado.Procedimentos.Add(itemCopia);
            }

            return pacoteClonado;
        }

        // Cópia superficial para fins de comparação
        public PacoteExame ClonarSuperficial()
        {
            PacoteExame pacoteRaso = (PacoteExame)this.MemberwiseClone();

            // A lista será compartilhada com o pacote original
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