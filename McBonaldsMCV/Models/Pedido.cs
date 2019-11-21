using System;
namespace McBonaldsMCV.Models
{
    public class Pedido
    {
        public Cliente cliente {get;set;}
        public DateTime DataDoPedido {get;set;}
        public Hamburguer hamburguer {get;set;}
        public Shake shake {get;set;}
        public double PrecoTotal {get;set;}

        public Pedido(){
            this.cliente = new Cliente();
            this.hamburguer = new Hamburguer();
            this.shake = new Shake();
        }
    }
}