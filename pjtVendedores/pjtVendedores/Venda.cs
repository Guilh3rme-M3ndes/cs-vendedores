using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjtVendedores
{
    internal class Venda
    {
        private double valor;
        private int qtde;

        public double Valor
        {
            get => this.valor;
            set => this.valor = value;
        }

        public int Qtde
        {
            get => this.qtde;
            set => this.qtde = value;
        }

        public Venda(int qtde, double valor)
        {
            this.qtde = qtde;
            this.valor = valor;
        }

        public Venda() : this(0, 0) { }

        public double ValorMedio() => (this.qtde != 0? this.valor / this.qtde : 0);
    }

}
