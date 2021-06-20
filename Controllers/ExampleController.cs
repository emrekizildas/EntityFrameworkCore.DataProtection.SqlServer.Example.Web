using EntityFrameworkCore.DataProtection.Example.Web.Data;
using EntityFrameworkCore.DataProtection.Example.Web.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.DataProtection.Example.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {

        private readonly ILogger<ExampleController> _logger;
        private readonly ExampleDbContext dbContext;

        public ExampleController(ILogger<ExampleController> logger, ExampleDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var list = dbContext.EncryptExamples.Select(k => k.EncryptArea).ToList();
            return Ok(list);
        }

        [HttpGet("add/{deger}")]
        public IActionResult Post(string deger)
        {
            var model = new EncryptExample(deger);
            dbContext.EncryptExamples.Add(model);
            dbContext.SaveChanges();
            return Ok(model);
        }
    }
}
 