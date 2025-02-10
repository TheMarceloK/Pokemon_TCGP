
using UnityEngine;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

public class PartidaController : NewConnectDB
{
    public Partida CreatePartida(Partida partida)
    {
        string sql = "INSERT INTO PARTIDA (BARALHO_01, BARALHO_02) " +
                     "VALUES (@BARALHO_01, @BARALHO_02);" +
                     "SELECT SCOPE_IDENTITY() AS COD;";

        cmd = new SqlCommand(sql, conectar());
        par = new SqlParameter("@BARALHO_01", partida.baralho_01);
        par.SqlDbType = System.Data.SqlDbType.Int;
        cmd.Parameters.Add(par);
        par = new SqlParameter("@BARALHO_02", partida.baralho_02);
        par.SqlDbType = System.Data.SqlDbType.Int;
        cmd.Parameters.Add(par);
        
        reader = cmd.ExecuteReader();
        
        if (reader.Read())
        {
            partida.cod = Int32.Parse(reader.GetValue(reader.GetOrdinal("COD")).ToString());
            return partida;
        }
        return null;

    }
}
