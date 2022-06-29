using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class ClaseBase
    {
        private readonly IConfiguration _configuration;
        public ClaseBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected string condicion { set; get; }
    }
}
