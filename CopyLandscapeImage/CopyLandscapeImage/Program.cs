using ImageProcessor;
using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace CopyLandscapeImage
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"\\vmware-host\Shared Folders\temp\fotos\teste\";
            var subfolder = "";

            if (args.Length > 0)
            {
                path = args[0];
            }

            if (args.Length > 1)
            {
                subfolder = args[1];
            }

            if (path != "")
            {
                var destPath = @$"\\vmware-host\Shared Folders\temp\fotos\{subfolder}";

                if (!Directory.Exists(destPath))
                {
                    try
                    {
                        Directory.CreateDirectory(destPath);
                    }
                    catch (IOException e)
                    {
                        MyConsole.WriteError("Criar diretório", e);

                        return;
                    }
                }

                CopyFiles(path, destPath);
            }
            else
            {
                MyConsole.WriteWarning("O caminho deve ser informado.");
            }
        }

        private static void CopyFiles(string path, string destPath)
        {
            var filesCopied = 0;
            var filesIgnored = 0;
            var filesProcessed = 0;

            var height = 0;
            var width = 0;

            var exts = new string[] { ".jpg", ".jpeg", ".png" };

            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).OrderBy(p => p);
            foreach (var file in files)
            {
                var fileDest = Path.Combine(destPath, Path.GetFileName(file));

                filesProcessed++;

                if (exts.Any(e => e == Path.GetExtension(file).ToLower())) // && !File.Exists(fileDest))
                {

                    try
                    {
                        MyConsole.Write($"{file}... ");

                        // FOI NECESSÁRIO USAR O IMAGEFACTORY, POIS ALGUMAS IMAGENS (do iPhone)
                        // TEM O WIDTH/HEIGHT TROCADO NAS INFORMAÇÕES
                        using (var imageFactory = new ImageFactory())
                        {
                            imageFactory
                                .Load(file)
                                .AutoRotate(); //takes care of ex-if

                            height = imageFactory.Image.Height;
                            width = imageFactory.Image.Width;
                        }

                        var ignore = height > width;

                        if (ignore)
                        {
                            MyConsole.WriteWarning($" ({width} x {height}). Não copiado.");
                            filesIgnored++;
                        }
                        else
                        {
                            filesCopied++;
                        }

                        if (!ignore)
                        {
                            while (File.Exists(fileDest))
                            {
                                fileDest = Path.GetFileNameWithoutExtension(fileDest) + "_" + Path.GetExtension(fileDest);
                                fileDest = Path.Combine(destPath, Path.GetFileName(fileDest));
                            }

                            MyConsole.Write($"Copiando...");

                            try
                            {
                                File.Copy(file, fileDest);

                                MyConsole.Write(" Ok.");
                            }
                            catch (Exception e)
                            {
                                MyConsole.WriteError("Erro ao copiar", e);
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        MyConsole.WriteError("Processando", e);
                    }                    
                    
                    MyConsole.WriteLine("");
                }
            }
        }

        const int BYTES_TO_READ = sizeof(Int64);

        static bool FilesAreEqual(FileInfo first, FileInfo second)
        {
            if (first.Length != second.Length)
                return false;

            if (string.Equals(first.FullName, second.FullName, StringComparison.OrdinalIgnoreCase))
                return true;

            int iterations = (int)Math.Ceiling((double)first.Length / BYTES_TO_READ);

            using (FileStream fs1 = first.OpenRead())
            using (FileStream fs2 = second.OpenRead())
            {
                byte[] one = new byte[BYTES_TO_READ];
                byte[] two = new byte[BYTES_TO_READ];

                for (int i = 0; i < iterations; i++)
                {
                    fs1.Read(one, 0, BYTES_TO_READ);
                    fs2.Read(two, 0, BYTES_TO_READ);

                    if (BitConverter.ToInt64(one, 0) != BitConverter.ToInt64(two, 0))
                        return false;
                }
            }

            return true;
        }

    }

    public static class MyConsole
    {

        public static void WriteLine(string message)
        {
            SetColorStandard();

            Console.WriteLine(message);
        }

        public static void WriteError(string title, Exception e)
        {
            SetColorError();

            Console.WriteLine($"\n{title}:");
            Console.WriteLine(e.Message);

            SetColorStandard();
        }

        public static void WriteWarning(string message)
        {
            SetColorWarning();

            Console.Write(message);

            SetColorStandard();
        }

        public static void Write(string message)
        {
            SetColorStandard();

            Console.Write(message);

            SetColorStandard();
        }

        private static void SetColorWarning()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        private static void SetColorStandard()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private static void SetColorError()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkRed;
        }

    }
}
