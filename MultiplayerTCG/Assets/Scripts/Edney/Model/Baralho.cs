using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonTCGP_01.DAO.Model
{
    public class Baralho
    {
        
        public int cod { get; set; }
        public string nome { get; set; }
        public bool ativo { get; set; }
        public Jogador jogador { get; set; }
        public List<Item> cartas { get; set; }
    }
}