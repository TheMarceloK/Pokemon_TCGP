using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UnityEngine;


public class AcaoController : NewConnectDB
{

    public void CreateAcao(Acao acao)
    {
        
        string sql = "INSERT INTO ACAO (JOGADA, ALVO, EFEITO, VALOR_EFEITO) " +
                     "VALUES (@JOGADA, @ALVO, @EFEITO, @VALOR_EFEITO)";

        cmd = new SqlCommand(sql, conectar());
        par = new SqlParameter("@JOGADA", acao.jogada);
        par.SqlDbType = System.Data.SqlDbType.Int;
        cmd.Parameters.Add(par);
        par = new SqlParameter("@ALVO", acao.alvo);
        par.SqlDbType = System.Data.SqlDbType.Int;
        cmd.Parameters.Add(par);
        par = new SqlParameter("@EFEITO", acao.efeito);
        par.SqlDbType = System.Data.SqlDbType.VarChar;
        cmd.Parameters.Add(par);
        par = new SqlParameter("@VALOR_EFEITO", acao.valor_efeito);
        par.SqlDbType = System.Data.SqlDbType.Int;
        cmd.Parameters.Add(par);
        
        reader = cmd.ExecuteReader();
        
    }
    
}
