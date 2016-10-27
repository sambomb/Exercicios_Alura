using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CaixaEletronico
{
    public partial class TrataTexto : Form
    {
        string caminho = @"C:\CSharp\Teste.txt";//-- Variável para armazenar o nome do arquivo
        string linha = ""; //-- Variável para armazenar a linha 

        public TrataTexto()
        {
            InitializeComponent();
        }

        private void TrataTexto_Load(object sender, EventArgs e)
        {         

            if (File.Exists(caminho)) //-- Verificar se o arquivo existe
            {
                using (Stream arquivo = File.Open(caminho, FileMode.Open)) //-- Acessar o arquivo
                using (StreamReader leitor = new StreamReader(arquivo))    //-- Instanciar leitor
                {
                    texto.Text = leitor.ReadToEnd();
                }

                //while (linha != null) 
                //{
                //    linha = leitor.ReadLine(); //-- Ler a próxima linha
                //    texto.Text += linha; //-- Adiconar a linha ao TextBox
                //    texto.Text += "\r\n"; //-- Quebrar a linha

                //}

                //leitor.Close();
                //arquivo.Close();
            }
            else
            {
                MessageBox.Show("Arquivo: {0} não existe", caminho); //-- Caso não exista o arquivo, gerar mensagem de retorno.
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            using (Stream arquivo = File.Open(caminho, FileMode.Create))
            using (StreamWriter escritor = new StreamWriter(arquivo))
            {
                foreach (var escreveLinha in texto.Lines)
                {
                    if (!string.IsNullOrEmpty(escreveLinha))
                    {
                        escritor.Write(escreveLinha + "\r\n");
                    }
                }
            }

            //escritor.Close();
            //arquivo.Close();

            TrataTexto.ActiveForm.Close();
        }
    }
}
