using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

class Program
{
    static void Main()
    {
        int width = 1024;
        int height = 1024;
        string fileName = "";
        string letterSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghIjklmnopqrstuvwxyz";
        Random rand = new Random();

        for (int i = 0; i < 8; i++)
        {
            if (i % 2 == 0)
                fileName += letterSet[rand.Next(0, 52)];
            else
                fileName += Convert.ToString(rand.Next(0,10));
        }
        Console.WriteLine(fileName);

        using (Image<Rgba32> image = new Image<Rgba32>(width, height))
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    image[x, y] = new Rgba32(rand.NextSingle(), rand.NextSingle(), rand.NextSingle());
                }
            }

            Console.Write("Введите путь для сохранения изображения: ");
            string filePath = Console.ReadLine();
            filePath += $"\\{fileName}.png";

            try
            {
                image.SaveAsPng(filePath);
                Console.WriteLine($"Изображение сохранено: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка сохранения изображения: {ex.Message}");
            }
        }
    }
}