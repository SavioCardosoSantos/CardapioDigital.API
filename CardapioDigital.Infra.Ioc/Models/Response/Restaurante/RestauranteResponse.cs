using CardapioDigital.Infra.Ioc.Models.Base;
using CardapioDigital.Util.Enums;

namespace CardapioDigital.API.Models.Response.Restaurante
{
    public class RestauranteResponse : RestauranteBase
    {
        public int Id { get; set; }
        public eStatusRestaurante Status { get; set; }
    }
}
