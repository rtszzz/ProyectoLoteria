using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoLoteria
{
    public partial class Form1 : Form
    {
        Stack<int> carta = new Stack<int>();
        const int CANTIDAD_CARTAS = 54;
        private PictureBox[] cartas;
        private PictureBox[] tabla;
       
        Random rnd1 = new Random();
        int i = 0;

        public Form1()
        {
            InitializeComponent();
            cartas = new PictureBox[CANTIDAD_CARTAS];
            tabla = new PictureBox[25];
            inicializarTabla();
        }

        private void inicializarTabla()
        {
            int r = 0, c = 0;

            int[] cartas = new int[34];


            for (int i = 0; i < cartas.Length; i++)
            {
                cartas[i] = i + 1;
            }

            Random rnd = new Random();
            int a, aux;
            for (int i = 0; i < cartas.Length; i++)
            {
                a = rnd.Next(cartas.Length);
                aux = cartas[i];
                cartas[i] = cartas[a];
                cartas[a] = aux;
            }


            for (int i = 0; i < tabla.Length; i++)
            {
                tabla[i] = new PictureBox();
                tabla[i].Location = new System.Drawing.Point(20 + (c * 90), 25 + (r * 130));
                tabla[i].Name = "picTabla1" + 1;
                tabla[i].Size = new System.Drawing.Size(85, 125);
                tabla[i].TabIndex = 0 + i;
                tabla[i].SizeMode = PictureBoxSizeMode.StretchImage;
                tabla[i].TabStop = false;
                tabla[i].Image = Image.FromFile(@"C:\Users\usuario\source\repos\ProyectoLoteria\ProyectoLoteria\bin\Debug" + (cartas[i]) + ".jpg");
                this.Controls.Add(tabla[i]);
                c++;
                if (c == 5)
                {
                    r++;
                    c = 0;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.listView1.View = View.LargeIcon;
            this.imageList1.ImageSize = new Size(150, 220);
            this.listView1.LargeImageList = this.imageList1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = (54 - carta.Count()).ToString();
            bool bandera = false;
            if (carta.Count() == 54)
            {
                bandera = true;
                MessageBox.Show("son todas las cartas", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            while (!bandera)
            {
                int num = rnd1.Next(1, 54);

                if (!carta.Contains(num))
                {
                    pbcarta.Image = Image.FromFile(@"C:\Users\usuario\source\repos\ProyectoLoteria\ProyectoLoteria\bin\Debug" + num + ".jpg");
                    pbcarta.SizeMode = PictureBoxSizeMode.StretchImage;
                    carta.Push(num);

                    ListViewItem item = new ListViewItem();
                    item.ImageIndex = i;
                    this.listView1.Items.Add(item);
                    this.imageList1.Images.Add(Image.FromFile(@"C:\Users\usuario\source\repos\ProyectoLoteria\ProyectoLoteria\bin\Debug" + num + ".jpg"));
                    bandera = true;
                    i++;
                }
            }
        }

        private void btnBuenas_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"Voz 004.wav");
            player.Play();
        }
    }
}
