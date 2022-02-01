using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Newtonsoft.Json;
using System.IO;

namespace PictureView
{
    class PictureHelper<T> where T : new()
    {

       // private string _filePath;


        public PictureHelper()//string filePath)
        {
          //  _filePath = filePath;
        }


        public string ChooseFileName()
        {
            OpenFileDialog open = new OpenFileDialog();
            string filePath = "";

            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png" ;
            if (open.ShowDialog() == DialogResult.OK)
            {
                filePath = open.FileName;
              
            }

            return filePath;
        }


        public string ChoosePictureFilePath(bool saveOrRead)
        {
            string filePicPath ="";

            if (saveOrRead)
            {

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                
                saveFileDialog1.InitialDirectory = @"C:\";
                saveFileDialog1.Title = "Save text Files";
                saveFileDialog1.CheckPathExists = true;
                saveFileDialog1.DefaultExt = "txt";
                saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.FileName = "picture.txt";
                
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filePicPath = saveFileDialog1.FileName;
                }
            }
            else
            {
                OpenFileDialog open = new OpenFileDialog();

                open.Filter = "Text Files(*.csv; *.txt; *.json)|*.csv; *.txt; *.json";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    filePicPath = open.FileName;

                }
            }

            return filePicPath;
        }
        

        public void SerializeToFile(T Files,string FilePath)
        {
            // var files = Files;
            //string filePath = (string)Files.GetType().GetProperty("FilePath").GetValue(Files);

            var serializer = new JsonSerializer();
            var streamWriter = new StreamWriter(FilePath);

            try
            {
                serializer.Serialize(streamWriter, Files);
                streamWriter.Close();
                streamWriter.Dispose();

            }
            finally
            {
                streamWriter.Dispose();

            }

        }
        
        public T DeserializeFromFile(string filePath)
        {

            if (!File.Exists(filePath))
            {
                return new T();
            }

            
            using (var streamReader = new StreamReader(filePath))
            using (JsonTextReader jsonReader = new JsonTextReader(streamReader))
            {
                var serializer = new JsonSerializer();
                var Files = serializer.Deserialize<T>(jsonReader);

                return Files;
            }
        }
        

    }
}
