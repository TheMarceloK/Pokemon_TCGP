using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonTCGP_01.DAO.Model
{
    public class Acao
    {
        public int cod { get; set; }
        public Jogada jogada { get; set; }
        public Jogada alvo { get; set; }
        public string efeito { get; set; }
        public int valorEfeito { get; set; }
    }
}