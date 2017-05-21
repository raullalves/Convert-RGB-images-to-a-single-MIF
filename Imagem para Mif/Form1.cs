using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Imagem_para_Mif
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public static Image resizeImage(string endereco, Size size)
        {
            Image img = Image.FromFile(endereco);
            return (Image)(new Bitmap(img, size));
        }

        Imagem[] imagens = new Imagem[4];
        int qtdImagens = 0;

        private int verificarImagens()
        {


            if (!string.IsNullOrWhiteSpace(this.endereco1.Text) )
            {

                Size s = new Size();
                int height, width;

                if (Int32.TryParse(this.altura1.Text, out height))
                {
                    s.Height = height;
                }
                else return -1;

                if (Int32.TryParse(this.largura1.Text, out width))
                {
                    s.Width = width;
                }
                else return -1;



                try
                {
                    imagens[qtdImagens++] = new Imagem(this.endereco1.Text, s);
                }
                catch (Exception e)
                {
                    return -1;
                }


            }

            if (!string.IsNullOrWhiteSpace(this.endereco2.Text))
            {
                Size s = new Size();
                int height, width;

                if (Int32.TryParse(this.altura2.Text, out height))
                {
                    s.Height = height;
                }
                else return -1;

                if (Int32.TryParse(this.largura2.Text, out width))
                {
                    s.Width = width;
                }
                else return -1;


                try
                {
                    imagens[qtdImagens++] = new Imagem(this.endereco2.Text, s);
                }
                catch (Exception e)
                {
                    return -1;
                }

            }

            if (!string.IsNullOrWhiteSpace(this.endereco3.Text))
            {
                Size s = new Size();
                int height, width;

                if (Int32.TryParse(this.altura3.Text, out height))
                {
                    s.Height = height;
                }
                else return -1;

                if (Int32.TryParse(this.largura3.Text, out width))
                {
                    s.Width = width;
                }
                else return -1;


                try
                {
                    imagens[qtdImagens++] = new Imagem(this.endereco3.Text, s);
                }
                catch (Exception e)
                {
                    return -1;
                }

            }

            if (!string.IsNullOrWhiteSpace(this.endereco4.Text))
            {
                Size s = new Size();
                int height, width;

                if (Int32.TryParse(this.altura4.Text, out height))
                {
                    s.Height = height;
                }
                else return -1;

                if (Int32.TryParse(this.largura4.Text, out width))
                {
                    s.Width = width;
                }
                else return -1;


                try
                {
                    imagens[qtdImagens] = new Imagem(this.endereco4.Text, s);
                }
                catch (Exception e)
                {
                    return -1;
                }

            }
            

            if (qtdImagens < 1) return -1;
            
            return 1;
        }

        private void erro()
        {
            this.debug.Text = "Erro nos dados!!!";
            this.debug.Visible = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (verificarImagens() < 0)
            {
                erro();
                return;
            }
            else
            {
                this.debug.Text = "Sucesso!!!";
                this.debug.Visible = true;
            }

            if (!string.IsNullOrWhiteSpace(memoria.Text))
            {
                GeradorMIF gerador = new GeradorMIF(memoria.Text, imagens, qtdImagens);
                if (gerador.gerarMIF() < 0) erro();
                else
                {
                    this.debug.Text = "Sucesso!!!";
                    this.debug.Visible = true;
                }

            }
            else {
                erro();
                return;
            }
            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
