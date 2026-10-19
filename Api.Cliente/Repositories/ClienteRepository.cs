namespace Api.Cliente.Repositories;

using Api.Cliente.Entities;
using Dapper;
using Microsoft.Data.SqlClient;

public class ClienteRepository(string connectionString)
{


    public void Inserir(Cliente cliente)

    {
        var sql = """
            
                 INSERT INTO CLIENTES (ID, NOME, EMAIL, CPF, DATACADASTRO)
                 VALUES(@Id, @Email, @Cpf, @DataCadastro)
            
            """;
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Execute(sql, cliente);


        }



    }

    public void Atualizar(Cliente cliente)
    {
        var sql = """
                UPDATE CLIENTES
                SET    
                       NOME = @Nome
                       EMAIL = @Email
                       CPF = @Cpf
                WHERE 
                       ID = @Id
                     
            """;
        using (var connection = new SqlConnection(connectionString))
        {

            connection.Execute(sql, cliente);



        }



    }

    public void Excluir(Guid Id)
    {

        var sql = """

             DELETE FROM CLIENTES 
             WHERE ID = @Id

            """;

        using (var connection = new SqlConnection(connectionString))
        {

            connection.Execute(sql, new { @Id = Id });


        }

        
    }
    public List<Cliente> ObterTodos()
    {
        var sql = """

                SELECT * FROM CLIENTES
                ORDER BY NOMES

            """;
        using (var connection = new SqlConnection(connectionString)) 
        {

            return connection.Query<Cliente>(sql).ToList();
                       
        }
        


    }
    public Cliente? ObterPorId(Guid Id)
    {
        var sql = """
             
              SELECT * CLIENTES
              WHERE ID = @Id

            """;
        using (var connection = new SqlConnection(connectionString))
        { 
         
         return connection.QueryFirstOrDefault(sql, new {Id = @Id});

        }
 

    }


}

