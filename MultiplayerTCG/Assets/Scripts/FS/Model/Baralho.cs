using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Baralho
{
    public int cod { get; set; }

    public string nome { get; set; }
    public bool ativo { get; set; }

    public int jogador { get; set; }

    public List<Item> cartas { get; set; }
}