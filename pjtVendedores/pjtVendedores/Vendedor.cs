using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjtVendedores
{
    internal class Vendedor
    {
        private int id;
        private string nome;
        private double percComissao;
        private Venda[] vendas = new Venda[31];

        public int Id { get => this.id; set => this.id = value; }
        public string Nome { get => this.nome; set => this.nome = value; }
        public double PercComissao { get => this.percComissao; }

        public Venda[] Vendas { get => this.vendas; }

        public Vendedor(int id, string nome, double percComissao)
        {
            this.id = id;
            this.nome = nome;
            this.percComissao = percComissao;
            for (int ii = 0; ii < 31; ii++)
            {
                this.vendas[ii] = new Venda();
            }
        }

        public Vendedor()
        {
            this.id = -1;
            this.nome = "";
            this.percComissao = 0;
            for (int ii = 0; ii < 31; ii++)
            {
                this.vendas[ii] = new Venda();
            }

        }

        public Vendedor(int id) : this(id, "", 0)
        {

        }
        public override bool Equals(object? obj)
        {
            return ((Vendedor)obj).Id == this.Id;
        }
        public void RegistrarVenda(int dia, Venda venda)
        {
                this.vendas[dia - 1] = venda;
            
        }

        public double ValorVendas()
        {
            double valorAcumulado = 0;
            foreach (var venda in this.vendas)
            {
                valorAcumulado += venda.Valor;
            }
            return valorAcumulado;
        }

        public double ValorComissao()
        {
            return (this.percComissao/100) * ValorVendas();
        }
    }

}
