using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rd = new Random();
            Bitmap image1;
        
            image1 = new Bitmap(@"test.png", true);

            MemoryStream stream = new MemoryStream();
            image1.Save(stream, ImageFormat.Png);

            using (FileStream file = new FileStream(@"output.png", FileMode.OpenOrCreate, FileAccess.Write))
            {
                stream.WriteTo(file);
            }


        }
    }
}
