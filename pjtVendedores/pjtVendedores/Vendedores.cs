using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjtVendedores
{
    internal class Vendedores
    {
        private int max;
        public Vendedor[] vendedores;
        private int qtde;

        public int Max { get => this.max; }
        public int Qtde { get => this.qtde; }
        public Vendedores()
        {
            this.qtde = 0;
            this.max = 10;
            this.vendedores = new Vendedor[this.max];
            for (int ii = 0; ii < this.max; ii++)
            {
                this.vendedores[ii] = new Vendedor();
            }
        }
       
        public bool addVendedor(Vendedor vendedor)
        {
            bool adicionou = false;
            if (qtde < max)
            {
                this.vendedores[this.qtde++] = vendedor;
                adicionou = true;
            }
                return adicionou;
        }

        public bool delVendedor(Vendedor vendedor)
        {
            bool deletou = false;

            for (int ii = 0; ii < this.qtde; ii++)
            {
                if (this.vendedores[ii].Id == vendedor.Id && vendedor.Id != -1)
                {
                    bool semVenda = true;
                    foreach (Venda venda in this.vendedores[ii].Vendas)
                    {
                        if (venda.Qtde > 0)
                        {
                            semVenda = false;
                            break;
                        }
                    }
                    if (semVenda)
                    {
                        deletou = true;
                        for (int jj = ii; jj < this.qtde - 1; jj++)
                        {
                            this.vendedores[jj] = this.vendedores[jj + 1];
                            this.vendedores[jj].Id--;
                        }
                        this.vendedores[this.qtde - 1] = new Vendedor();
                        this.qtde--;
                        break;
                    }
                }
            }
            return deletou;
        }

        public Vendedor searchVendedor(Vendedor vendedor)
        {
            Vendedor pesquisado = new Vendedor();
            foreach (Vendedor v in vendedores)
            {
                if (v.Equals(vendedor))
                {
                    pesquisado = v;
                }
            }
            return pesquisado;
        }

        public double ValorVendas()
        {
            double total = 0;
            foreach(Vendedor v in vendedores)
            {
                total += v.ValorVendas();            
            }
            return total;
        }

        public double ValorComissao()
        {
            double total = 0;
            foreach(Vendedor v in vendedores)
            {
                total += v.ValorComissao();
            }
            return total;
        }

        
    }
}
