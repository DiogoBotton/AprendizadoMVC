namespace McBonaldsMCV.Models
{
    public class Hamburguer : Produto
    {
        public Hamburguer(){

        }
        public Hamburguer(string Nome, double Preco){
            this.Nome = Nome;
            this.Preco = Preco;
        }
    }
}