using UnityEngine;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

public class JogadorController : NewConnectDB
{

    public void CreatePlayer(Jogador jogador)
    {
        string sql = "INSERT INTO JOGADOR (NOME, USUARIO, SENHA) " +
                     "VALUES (@NOME, @USUARIO, @SENHA)";

        cmd = new SqlCommand(sql, conectar());
        par = new SqlParameter("@NOME", jogador.nome);
        par.SqlDbType = System.Data.SqlDbType.VarChar;
        cmd.Parameters.Add(par);
        par = new SqlParameter("@USUARIO", jogador.usuario);
        par.SqlDbType = System.Data.SqlDbType.VarChar;
        cmd.Parameters.Add(par);
        par = new SqlParameter("@SENHA", HashMd5(jogador.senha));
        par.SqlDbType = System.Data.SqlDbType.VarChar;
        cmd.Parameters.Add(par);
        
        reader = cmd.ExecuteReader();

    }

    public Jogador CheckPlayer(string usuario, string senha){
    
        string sql = "SELECT COD, NOME, USUARIO FROM JOGADOR WHERE USUARIO = @USUARIO AND SENHA = @SENHA";
        
        cmd = new SqlCommand(sql, conectar());
        
        par = new SqlParameter("@USUARIO", usuario);
        par.SqlDbType = System.Data.SqlDbType.VarChar;
        cmd.Parameters.Add(par);
        par = new SqlParameter("@SENHA", HashMd5(senha));
        par.SqlDbType = System.Data.SqlDbType.VarChar;
        cmd.Parameters.Add(par);
        reader = cmd.ExecuteReader();
        
        if (reader.Read())
        {
            Jogador jogadores = new Jogador();

            jogadores.cod  = Int32.Parse(reader.GetValue(reader.GetOrdinal("COD")).ToString());
            jogadores.nome = reader.GetValue(reader.GetOrdinal("NOME")).ToString();
            jogadores.usuario = reader.GetValue(reader.GetOrdinal("USUARIO")).ToString();    
            
            return jogadores;
        }
        return null;
    } 


}