using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Application.DTOs
{
    public class RestricaoAlimentarClienteDTO
    {
        public int ClienteId { get; set; }
        public RestricaoAlimentarDTO RestricaoAlimentar { get; set; }
    }
}
