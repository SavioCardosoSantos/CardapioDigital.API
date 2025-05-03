using CardapioDigital.Infra.Ioc.Models.Base;

namespace CardapioDigital.Infra.Ioc.Models.Response.ItemCardapio
{
    public class ItemCardapioResponse : ItemCardapioBase
    {
        public int Id { get; set; }
        public int RestauranteId { get; set; }
        public int Disponivel {  get; set; }
    }
}