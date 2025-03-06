using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

class Program
{
    static void Main()
    {
        int width = 1024;
        int height = 1024;
        Random rand = new Random();

        using (Image<Rgba32> image = new Image<Rgba32>(width, height))
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    image[x, y] = new Rgba32(rand.NextSingle(), rand.NextSingle(), rand.NextSingle());
                }
            }

            Console.Write("Введите путь для сохранения изображения (с расширением .png): ");
            string filePath = Console.ReadLine();

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