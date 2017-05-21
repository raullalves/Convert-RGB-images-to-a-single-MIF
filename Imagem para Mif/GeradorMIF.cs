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

    class GeradorMIF
    {
        private System.IO.StreamWriter file;
        string location;
        private Imagem[] imagens;
        private int qtdImagens;
        private int totalDEPTH;

        public GeradorMIF(string location, Imagem[] imagens, int qtdImagens)
        {
            this.location = location;
            this.imagens = imagens;
            this.qtdImagens = qtdImagens;
            totalDEPTH = 0;
            file = new System.IO.StreamWriter(this.location);

        }

        private int calcDEPTH()
        {
            try {
                for (int i = 0; i < qtdImagens; i++)
                {
                    Size s = imagens[i].getSize();
                    this.totalDEPTH += s.Height * s.Width;
                }
            }catch (Exception e)
            {
                return -1;
            }

            return 1;
        }
        public int gerarMIF()
        {
            if (calcDEPTH() < 0) return -1;

            file.WriteLine("WIDTH=24;");

            file.WriteLine("DEPTH="+totalDEPTH+";");
            file.WriteLine("ADDRESS_RADIX=UNS;");
            file.WriteLine("DATA_RADIX = BIN;");
            file.WriteLine("CONTENT BEGIN");

            try {
                long contador = 0;
                for (int k = 0; k < qtdImagens; k++)
                {
                    
                    Bitmap img = imagens[k].getBitmap();
                    for (int i = 0; i < img.Width; i++)
                    {
                        for (int j = 0; j < img.Height; j++)
                        {
                            string pixelHexa = "";
                            Color pixel = img.GetPixel(i, j);
                            byte R = pixel.R;
                            pixelHexa += Convert.ToString(R, 2).PadLeft(8, '0');
                            byte G = pixel.G;
                            pixelHexa += Convert.ToString(G, 2).PadLeft(8, '0');
                            byte B = pixel.B;
                            pixelHexa += Convert.ToString(B, 2).PadLeft(8, '0');

                            file.Write(contador.ToString().PadLeft(8, '0'));

                            file.Write(" : ");
                            file.Write(pixelHexa);
                            file.Write(";");
                            contador++;
                            string linha2 = "\n";
                            file.Write(linha2);

                        }
                    }
                }
            } catch(Exception e)
            {
                return -1;
            }

            file.Write("END;");
            file.Close();
            return 1;
        }

    }
}
