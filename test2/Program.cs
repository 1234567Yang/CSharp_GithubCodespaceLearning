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

        int x, y;

        // Loop through the images pixels to reset color.
        for(x=0; x<image1.Width; x++)
        {
            for(y=0; y < image1.Height; y++)
            {
                Color pixelColor = image1.GetPixel(x, y);
                Color newColor = Color.FromArgb((pixelColor.R - 50 > 0) ? (pixelColor.R - 50 + rd.Next(0,50)) : (pixelColor.R), (pixelColor.G - 50 > 0) ? (pixelColor.G - 50 + rd.Next(0,50)) : (pixelColor.G), (pixelColor.B - 50 > 0) ? (pixelColor.B - 50 + rd.Next(0,50)) : (pixelColor.B));
                image1.SetPixel(x, y, newColor);
            }
        }
        MemoryStream stream = new MemoryStream();
        image1.Save(stream, ImageFormat.Png);

        using (FileStream file = new FileStream(@"output.png", FileMode.OpenOrCreate, FileAccess.Write))
            {
                stream.WriteTo(file);
            }


        }
    }
}
