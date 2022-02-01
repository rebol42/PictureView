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

namespace PictureView
{
    public partial class frmPictureView : Form
    {
        PictureHelper<Files> pictureHelper;
        Bitmap bitmap = null;
        string fileName;


        public frmPictureView()
        {
            InitializeComponent();
            InitPictureHelper();
            InitDelButton();
            InitPictureFile();

        }

        private void btAddPicture_Click(object sender, EventArgs e)
        {
            fileName = pictureHelper.ChooseFileName();
            bitmap = new Bitmap(fileName);

            pictureBox1.Image = bitmap;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            InitDelButton();
        }

        public void InitPictureHelper()
        {
            pictureHelper = new PictureHelper<Files>();
        }

        private void btDelPicture_Click(object sender, EventArgs e)
        {
            var confirmDelete =
               MessageBox.Show($"Czy na pewno chcesz usunać zdjęcie", "Usuwanie ucznia", MessageBoxButtons.OKCancel);

            if (confirmDelete == DialogResult.OK)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }

            InitDelButton();
        }

        public void InitDelButton()
        {
            if (pictureBox1.Image == null)
                btDelPicture.Enabled = false;
            else
                btDelPicture.Enabled = true;
        }


        public void InitPictureFile()
        {

            var confirmRead = MessageBox.Show($"Czy pobrać ścieżkę obrazu", "Czytanie obrazu", MessageBoxButtons.OKCancel);


            if (confirmRead == DialogResult.OK)
            {

                var filePicturePath = pictureHelper.ChoosePictureFilePath(false);

                Files file = pictureHelper.DeserializeFromFile(filePicturePath);

                fileName = file.FilePath;
                if (fileName != "")
                {
                    //  InitPictureBox();
                    bitmap = new Bitmap(fileName);
                    if(bitmap != null)
                        pictureBox1.Image = bitmap;
                  //  pictureBox1.ImageLocation = fileName;// bitmap;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                InitDelButton();
            }
        }

        private void frmPictureView_FormClosed(object sender, FormClosedEventArgs e)
        {
            

            if (pictureBox1.Image != null)
            {
                var confirmSave = MessageBox.Show($"Czy zapisać ścieżkę obrazu", "Zapisanie ścieżki", MessageBoxButtons.OKCancel);


                if (confirmSave == DialogResult.OK)
                {
                    var filePicturePath = pictureHelper.ChoosePictureFilePath(true);

                    if(filePicturePath != "")
                        pictureHelper.SerializeToFile(AddFiles(filePicturePath), filePicturePath);
  
                }
            }

            Application.Exit();


        }
        
        private Files AddFiles(string filePicName)
        {
            var files = new Files
            {
                FileName = filePicName,
                FilePath = fileName
            };


            return files;
        }

        private void InitPictureBox()
        {
            bitmap = new Bitmap(fileName);

          ///   pictureBox1.Image = bitmap;

            PictureBox pictureBox1 = new PictureBox
            {
                Location = new Point(380, 12),
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(300, 300),
                Image = bitmap
            };
        }



    }
}

