using Empresas.Dominio.Commands;
using Empresas.Dominio.Commands.Empresas.Input;
using Empresas.Dominio.Commands.Empresas.Output;
using Empresas.Dominio.Interfaces.Handlers;
using Empresas.Dominio.Interfaces.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Empresas.API.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]

    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaHandler _handler;
        private readonly IEmpresaRepositorio _empresaRepositorio;

        public EmpresaController(IEmpresaHandler handler, IEmpresaRepositorio empresaRepositorio)
        {
            _handler = handler;
            _empresaRepositorio = empresaRepositorio;
        }

        /// <summary>
        /// Incluir Empresa 
        /// </summary>
        /// <remarks><h2><b>Incluir nova Empresa na base de dados.</b></h2></remarks>
        /// <param name="command">Parâmetro requerido command de Insert</param>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="422">Unprocessable Entity</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [Route("v1/empresas")]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status500InternalServerError)]

        public IActionResult InserirEmpresa([FromBody] AddEmpresaCommand command)
        {
            var retorno = _handler.Handle(command);
            return StatusCode(200, retorno);
        }

        /// <summary>
        /// Alterar Empresa 
        /// </summary>                
        /// <remarks><h2><b>Alterar uma Empresa na base de dados.</b></h2></remarks>
        /// <param name="cnpj">Número de identificação da Empresa</param>
        /// <param name="command">Parâmetro requerido command de Update</param>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="422">Unprocessable Entity</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut]
        [Route("v1/empresas/{cnpj}")]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status500InternalServerError)]
        public IActionResult AlterarTarefa(string cnpj, [FromBody] UpdateEmpresaCommand command)
        {
            command.CNPJ = cnpj;
            var retorno = _handler.Handle(command);
            return StatusCode(200, retorno);
        }

        /// <summary>
        /// Excluir Empresa 
        /// </summary>                
        /// <remarks><h2><b>Excluir uma Empresa na base de dados.</b></h2></remarks>
        /// <param name="cnpj">Número de identificação da Empresa</param>
        /// <response code="200">OK Request</response>
        /// <response code="422">Unprocessable Entity</response>
        /// <response code="500">Internal Server Error</response>
        [HttpDelete]
        [Route("v1/empresas/{cnpj}")]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteEmpresaCommand(string cnpj)
        {
            var retorno = _handler.Handle(cnpj);
            return StatusCode(200, retorno);
        }

        /// <summary>
        /// Listar TODAS Empresas 
        /// </summary>                
        /// <remarks><h2><b>Listar todas as Empresas na base de dados.</b></h2></remarks>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="422">Unprocessable Entity</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("v1/empresas")]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status500InternalServerError)]
        public IActionResult ListarEmpresas()
        {
            return Ok(_empresaRepositorio.ListarEmpresas());
        }

        /// <summary>
        /// Listar Empresa por CNPJ 
        /// </summary>                
        /// <remarks><h2><b>Listar Empresa por CNPJ na base de dados.</b></h2></remarks>
        /// <param name="cnpj">Número de identificação da Empresa</param>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="422">Unprocessable Entity</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("v1/empresas/{cnpj}")]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status500InternalServerError)]
        public IActionResult ListarEmpresa(string cnpj)
        {
            return Ok(_empresaRepositorio.ListarEmpresa(cnpj));
        }
    }
}
