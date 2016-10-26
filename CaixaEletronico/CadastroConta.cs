using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaixaEletronico
{
    public partial class CadastroConta : Form
    {
        private Form1 aplicacaoPrincipal;

        public CadastroConta(Form1 aplicacaoPrincipal)
        {
            this.aplicacaoPrincipal = aplicacaoPrincipal;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conta novaConta = new ContaCorrente();

            if (comboTipo.SelectedIndex == 0)
            {
                novaConta = new ContaCorrente();
            }else
            {
                novaConta = new ContaPoupanca();
            }
            
            Cliente novoCliente = new Cliente();
            novoCliente.Nome = titularConta.Text;
            novaConta.Titular = novoCliente;
            novaConta.Nome = novaConta.Titular.Nome;
            novaConta.Numero = Convert.ToInt32(numeroDaConta.Text);

            this.aplicacaoPrincipal.AdicionaConta(novaConta);

        }

        private void CadastroConta_Load(object sender, EventArgs e)
        {
            comboTipo.SelectedIndex = 0;
        }
    }
}
