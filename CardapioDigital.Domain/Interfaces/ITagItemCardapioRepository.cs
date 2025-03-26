﻿using CardapioDigital.Domain.Entities;

namespace CardapioDigital.Domain.Interfaces
{
    public interface ITagItemCardapioRepository
    {
        Task Inserir(TagItemCardapio tagItemCardapio);
        Task Alterar(TagItemCardapio tagItemCardapio);
        Task Excluir(TagItemCardapio cliente);
    }
}
