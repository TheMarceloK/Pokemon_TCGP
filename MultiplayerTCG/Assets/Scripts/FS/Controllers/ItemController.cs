using UnityEngine;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

public class ItemController : NewConnectDB
{
    public void AddCardInDack(Item item)
    {
        string sql = "INSERT INTO ITEM (BARALHO, CARTA) " +
                     "VALUES (@BARALHO, @CARTA)";

        cmd = new SqlCommand(sql, conectar());
        par = new SqlParameter("@BARALHO", item.baralho);
        par.SqlDbType = System.Data.SqlDbType.Int;
        cmd.Parameters.Add(par);
        par = new SqlParameter("@CARTA", item.carta);
        par.SqlDbType = System.Data.SqlDbType.Int;
        cmd.Parameters.Add(par);
        
        reader = cmd.ExecuteReader();

    }
}
