using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcShared;
using GrpcTestService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GrpcTestService.Controllers
{
    [ApiVersion( "1.0" )]
    [ApiController]
    [Route( "v{version:apiVersion}/poc" )]
    //[Route( "test" )]
    [Produces( "application/json" )]
    public class PocController : Controller
    {
        private readonly ILogger<PocController> _logger;
        private readonly IMicroPoc _service;

        public PocController( ILogger<PocController> logger , IMicroPoc service )
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet( "SayHello/{name}" )]
        [ProducesResponseType( StatusCodes.Status200OK , Type = typeof( HelloReply ) )]
        [ProducesResponseType( StatusCodes.Status400BadRequest )]
        [ProducesResponseType( StatusCodes.Status500InternalServerError )]
        public async Task<IActionResult> Hello( string name )
        {
            if ( string.IsNullOrEmpty( name ) )
                return BadRequest();

            var response = await _service.Hello( new HelloRequest { Name = name } , null );
            return Ok( response );
        }

        [HttpPost( "Sum" )]
        [ProducesResponseType( StatusCodes.Status200OK , Type = typeof( SumReply ) )]
        [ProducesResponseType( StatusCodes.Status400BadRequest )]
        [ProducesResponseType( StatusCodes.Status500InternalServerError )]
        public async Task<IActionResult> Sum( [FromBody] SumRequest request )
        {
            if ( request == null )
                return BadRequest();

            var response = await _service.Sum( request , null );
            return Ok( response );
        }

        [HttpGet( "Ping/{name}" )]
        [ProducesResponseType( StatusCodes.Status200OK , Type = typeof( string ) )]
        [ProducesResponseType( StatusCodes.Status400BadRequest )]
        [ProducesResponseType( StatusCodes.Status500InternalServerError )]
        public IActionResult Ping( string name )
        {
            if ( string.IsNullOrEmpty( name ) )
                return BadRequest();

            return Ok( $"Ping {name}" );
        }
    }
}
