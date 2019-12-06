using System;
using System.Collections.Generic;
using System.Text;

namespace IntelligentCheckout.Frontend.Shared
{
    public sealed class Produto
    {
        public Produto(string nome, string descricao, decimal preco, List<string> fotos)
            : this(Guid.NewGuid(), nome, descricao, preco, fotos)
        {

        }

        public Produto(Guid id, string nome, string descricao, decimal preco, List<string> fotos)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Fotos = fotos;
        }


        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public List<string> Fotos { get; private set; }

        public string ObterPrecoFormatado()
        {
            return $"R$ {Preco:C2}";
        }
    }
}
