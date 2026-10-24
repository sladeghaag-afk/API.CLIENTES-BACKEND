using Api.Cliente.Entities;
using Api.Cliente.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Api.Cliente.Controllers
{
    [Route("api/v1/clientes")]
    [ApiController]
    public class ClienteController (ClienteRepository clienteRepository) : ControllerBase
    {
       [HttpPost]

        public IActionResult Post([FromBody] Dictionary<string, object> request) 
        {

            var cliente = new Entities.Cliente();

            cliente.Nome = request["nome"].ToString()!;
            cliente.Email = request["email"].ToString()!;
            cliente.CPF = request["cpf"].ToString()!;

            clienteRepository.Inserir(cliente);


            return Ok( new{ 
            
              mensagem = "Cliente cadastrado com sucesso!",
              dados = cliente
            
            });


        }

       [HttpPut("{id}")]

        public IActionResult Put(Guid id, [FromBody] Dictionary<string, object> request)
        {

            var cliente = clienteRepository.ObterPorId(id);
            if( cliente == null)
            {

                return NotFound(new {mensagem = "Cliente não encontrado para edição."});  
         
            }

            cliente.Nome = request["nome"].ToString()!;
            cliente.Email = request["email"].ToString()!;
            cliente.CPF = request["cpf"].ToString()!;

            clienteRepository.Atualizar(cliente);


            return Ok(new
            {

                mensagem = "Cliente Atualizado com sucesso!",
                dados = cliente

            });


            


        }
       [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {
            var cliente = clienteRepository.ObterPorId(id);
            if (cliente == null)
            {

                return NotFound(new { mensagem = "Cliente não encontrado para edição." });

            }

            clienteRepository.Excluir(id);

            return Ok(new
            {

                mensagem = "Cliente Excluido com sucesso!",
                dados = cliente

            });


        }
       [HttpGet]

        public IActionResult Get()
        {
            var cliente = clienteRepository.ObterTodos();
            return Ok(cliente);


        }



    }
}
