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
    class Imagem
    {

        private Size size;
        private string location;
        private Bitmap img;

        public Imagem(string location, Size size)
        {

            this.location = location;
            this.size = size;

            this.img = new Bitmap(Image.FromFile(this.location), this.size);

        }

        public Size getSize()
        {
            return this.size;
        }

        public Bitmap getBitmap()
        {
            return this.img;
        }

    }
    
}
