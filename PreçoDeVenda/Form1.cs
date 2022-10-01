using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreçoDeVenda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public static double preçoCompra, baseST0, baseST1, baseST2, baseST, aliqICMS=0, 
            aliqIPI=0, aliqST=0, valorUN, valorICMS, valorICMS1, valorIPI, valorIPI1, valorST, valorTotal, valorTotal1;

        private void tb_limpar_Click(object sender, EventArgs e)
        {
            tb_aliqicms.Text = "";
            tb_aliqipi.Text = "";
            tb_aliqst.Text = "";
            tb_lucro.Text = "";
            tb_porcentovenda.Text = "";
            tb_preçocompra.Text = "";
            tb_quantidade.Text = "";
            tb_valoricms.Text = "";
            tb_valoripi.Text = "";
            tb_valorst.Text = "";
            tb_valortotal.Text = "";
            tb_valorun.Text = "";
            tb_valorvenda.Text = "";
        }

        public static int Qtd;

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public static double porcentoVenda, valorVenda, LucroVenda;


        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }

        
        
        private void bt_calcular_Click(object sender, EventArgs e)
        {

            if (tb_aliqst.Text == "")
            {
                tb_aliqst.Text = "0";
            }

            aliqICMS = double.Parse(tb_aliqicms.Text);
            aliqIPI = double.Parse(tb_aliqipi.Text);
            aliqST = double.Parse(tb_aliqst.Text);
            porcentoVenda = double.Parse(tb_porcentovenda.Text);
            preçoCompra = double.Parse(tb_preçocompra.Text);
            Qtd = int.Parse(tb_quantidade.Text);

            

            valorUN = preçoCompra / Qtd;

            valorICMS1 = preçoCompra * (aliqICMS/100);
            valorICMS = valorICMS1 / Qtd;
            valorIPI1 = preçoCompra * (aliqIPI/100);
            valorIPI = valorIPI1 / Qtd;
           // valorST = valorUN * (aliqST / 100);


            valorTotal1 = valorUN + valorICMS + valorIPI;

            baseST0 = (preçoCompra * (aliqIPI / 100)) + preçoCompra;
            baseST1 = (baseST0 * (aliqST / 100)) + baseST0;
            baseST2 = baseST1 * (aliqICMS / 100);
            baseST = (baseST2 - valorICMS1) / Qtd;
            if(tb_aliqst.Text == "0")
            {
                valorST = 0;
            }
            else
            {
                valorST = baseST;
            }
            

            valorTotal = baseST + valorTotal1;
            //-------------------------------------------------------------

            valorVenda = ((porcentoVenda / 100) * valorTotal) + valorTotal;

            LucroVenda = valorVenda - valorTotal;


            tb_valorst.Text = valorST.ToString("C2");
            tb_valoricms.Text = valorICMS.ToString("C2");
            tb_valoripi.Text = valorIPI.ToString("C2");
            tb_valortotal.Text = valorTotal.ToString("C2");
            tb_valorun.Text = valorUN.ToString("C2");
            tb_lucro.Text = LucroVenda.ToString("C2");
            tb_valorvenda.Text = valorVenda.ToString("C2");
        }


        private bool mover;
        private int cX, cY;

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                mover = false;
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mover)
            {
                this.Left += e.X - (cX - panel1.Left);
                this.Top += e.Y - (cY - panel1.Top);
            }
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cX = e.X;
                cY = e.Y;
                mover = true;
            }
        }


    }
}
