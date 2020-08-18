using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test_vue.Models;

namespace test_vue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermitsType : ControllerBase
    {
        private readonly PermitsContext _context = new PermitsContext();

        public IActionResult GetPermitsType()
        {
            return Ok(_context.TiposPermisos.Select(t => new { value = t.Id, text = t.Descripcion }));
        }

    }
}
