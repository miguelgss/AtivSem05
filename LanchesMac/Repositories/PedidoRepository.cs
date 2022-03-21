using LanchesMac.Context;
using LanchesMac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchesMac.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(AppDbContext context, CarrinhoCompra carrinhoCompra)
        {
            _context = context;
            _carrinhoCompra = carrinhoCompra;
        }

        public void CriarPedido(Pedido pedido)
        {
            // Armazena em uma variavel uma lista dos itens no carrinho de compras
            var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItens;

            pedido.PedidoEnviado = DateTime.Now;
            pedido.PedidoTotal = _carrinhoCompra.GetCarrinhoCompraTotal();

            _context.Pedidos.Add(pedido);
            // Persiste o "pedido" no banco de dados, permitindo que o pedidoDetalhe busque um PedidoId que exista
            _context.SaveChanges(); 

            foreach(var carrinhoItem in carrinhoCompraItens)
            {
                var pedidoDetalhe = new PedidoDetalhe()
                {
                    Quantidade = carrinhoItem.Quantidade,
                    LancheId = carrinhoItem.Lanche.LancheId,
                    PedidoId = pedido.PedidoId,
                    Preco = carrinhoItem.Lanche.Preco
                };
                // Pedido detalhes armazena os pedidos específicos item por item
                _context.PedidoDetalhes.Add(pedidoDetalhe);
            }

            _context.SaveChanges();
        }
    }
}
