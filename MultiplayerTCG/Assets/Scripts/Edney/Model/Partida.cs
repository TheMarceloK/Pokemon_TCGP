using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonTCGP_01.DAO.Model
{
    public class Partida
    {
        public int cod { get; set; }
        public DateTime data { get; set; }
        public Baralho baralho01 { get; set; }
        public Baralho baralho02 { get; set; }
    }
}