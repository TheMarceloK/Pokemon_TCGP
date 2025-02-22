using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonTCGP_01.DAO.Model
{
    public class Item
    {
        public int cod { get; set; }
        public Baralho baralho { get; set; }
        public Carta carta { get; set; }

    }
}