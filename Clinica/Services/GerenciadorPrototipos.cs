using Clinica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Services
{
    public class GerenciadorPrototipos
    {
        // Dicionário para armazenar os protótipos
        private Dictionary<string, PacoteExame> _prototipos =
            new Dictionary<string, PacoteExame>();

        public void CadastrarPrototipo(string chave, PacoteExame prototipo)
        {
            _prototipos[chave] = prototipo;
        }

        public PacoteExame ObterClone(string chave)
        {
            if (_prototipos.ContainsKey(chave))
            {
                // Busca o modelo original e cria uma cópia
                PacoteExame modeloOriginal = _prototipos[chave];

                return modeloOriginal.Clonar();
            }

            return null;
        }
    }
}
