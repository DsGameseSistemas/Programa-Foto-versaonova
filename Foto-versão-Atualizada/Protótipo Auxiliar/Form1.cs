using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protótipo_Auxiliar
{
    public partial class Form1 : Form
    {
        Image mundo;
        Bitmap img;
        Image imagemOriginal;
        public Form1()
        {

            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void arquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            //filtro: parte escrita para o usuário entender quais arquivos ele pode abrir | parte escrita para o sistema operacional entender quais arquivos ele pode abrir
            open.Filter = "arquivos jpg (* .jpg) | * .jpg | Todos os arquivos (*. *) | *. *"; //filtra tipo de arquivo

            if (open.ShowDialog() == DialogResult.OK) //showdialog
            {
                lbl_status.Text = open.SafeFileName; // escreve o nome do arquivo na label
                pictureBox1.ImageLocation = open.FileName; // faz a função do botão ok abrindo local do arquivo e gerando a imagem
                //(image)copia converte para image e salva
                //image.FromFile(open.FileName) abre a imagem do arquivo
                //.clone clona 
                imagemOriginal = (Image)Image.FromFile(open.FileName).Clone();
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rotacionarA90GrausToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Refresh();

        }

        private void rotacionarA180GrausToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            pictureBox1.Refresh();
        }

        private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Size Tamanho = new Size(pictureBox1.Width, pictureBox1.Height); //pega altura e largura
            Bitmap Bitmap = new Bitmap(pictureBox1.Image, Tamanho); // bitmap manipula imagem baseada em pixel e salva permitindo carregar
            Color BitmapColor; //iniciou o bitmap
            mundo = pictureBox1.Image; //captura a imagem da picture box

            // modifica pixel por pixel deixando cinza
            for (int ContH = 0; ContH < Tamanho.Height; ContH++)
            {
                for (int contW = 0; contW < Tamanho.Width; contW++)
                {
                    BitmapColor = Bitmap.GetPixel(contW, ContH);
                    int GrayScale = Convert.ToInt32(BitmapColor.R * 0.3 + BitmapColor.G * 0.59 + BitmapColor.B * 0.11);
                    Bitmap.SetPixel(contW, ContH, Color.FromArgb(GrayScale, GrayScale, GrayScale));

                }
            }
            pictureBox1.Image = Bitmap; //passa a parte ja manipulada.
        }

        private void voltarAoOriginalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = (Image)imagemOriginal.Clone();
            pictureBox1.Refresh();
        }

        private void negativoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            img = new Bitmap(pictureBox1.Image);
            int red = 0;
            int green = 0;
            int blue = 0;
            for (int i = 0; i < img.Height; i++)
            {
                for (int j = 0; j < img.Width; j++)
                {
                    red = 255 - img.GetPixel(j, i).R;
                    green = 255 - img.GetPixel(j, i).G;
                    blue = 255 - img.GetPixel(j, i).B;

                    img.SetPixel(j, i, Color.FromArgb(red, green, blue));


                }
                pictureBox1.Image = img;
            }

    }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Abrir imagem: OpenFileDialog + ImageLocation
            //Salvar imagem: SaveFileDialog + Image.Save()
            SaveFileDialog saveFile = new SaveFileDialog(); //abre a janela para escolher onde salvar (Classe windows forms)
            saveFile.Filter = "Arquivos JPG (*.jpg)|*.jpg|Todos os arquivos (*.*)|*.*"; //Define o tipo de arquivos 

            if (saveFile.ShowDialog() == DialogResult.OK) //showdialog abre a janela e se o usuário apertar salvar ele retorna o dialog ok se cancelar não entra no if.
            {
                lbl_status.Text = saveFile.FileName; // mostra a label do caminho 
                pictureBox1.Image.Save(saveFile.FileName); //save vai salvar a imagem no caminho acima da label: Image.Save(string filename);
                
                //Mostrando mensagem de confirmação que foi salva:
                //Show( texto, titulo, botoes, icone )
                MessageBox.Show("Imagem salva com sucesso!","Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        /* Código antigo de salvar comentado:
         * 
         * private void salvarToolStripMenuItem_Click(object sender, EventArgs e) { 
         * SaveFileDialog saveFile = new SaveFileDialog(); OK 
         * saveFile.Filter = "arquivos jpg (* .jpg) | * .jpg | Todos os arquivos (*. *) | *. *"; OK
         * if (saveFile.ShowDialog() == DialogResult.OK) OK
         * { 
         * lbl_status.Text = saveFile.FileName; Ok
         * pictureBox1.ImageLocation = saveFile.FileName; ERROR!
         * } 
         * }
        */
        private void opçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
