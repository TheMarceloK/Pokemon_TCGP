using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonTCGP_01.DAO.Model
{
    public class Jogador
    {
        public Jogador()
        {
            this.baralhos = new List<Baralho>();
        }
        public int cod { get; set; }
        public string nome { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }
        public List<Baralho> baralhos { get; set; }
    }
}