using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaCutter
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = new System.IO.DirectoryInfo(@"C:\Users\wilson.deoliveira\Downloads\").GetFiles();
            foreach (var file in files)
            {
                if (file.Extension == ".mp4")
                {
                    Separar_Arquivos(file);
                }
            }
        }
        private static void Separar_Arquivos(System.IO.FileInfo file)
        {
            using (var engine = new Engine())
            {
                var fileName = file.Name.Replace(file.Extension, string.Empty);
                var inputFile = new MediaFile { Filename = file.FullName };
                engine.GetMetadata(inputFile);
                var outputName = @"C:\Users\wilson.deoliveira\Downloads\temp\";
                var outputExtension = ".mp4";
                double Duration = inputFile.Metadata.Duration.TotalMilliseconds;
                double currentPosition = 0;
                int counter = 0;
                while (currentPosition < Duration)
                {
                    currentPosition = counter * 30000;
                    counter++;

                    if (currentPosition > Duration) continue;

                    var options = new ConversionOptions();
                    var outputFile = new MediaFile(outputName + fileName + "-" +  counter.ToString("00") + outputExtension);

                    options.CutMedia(TimeSpan.FromMilliseconds(currentPosition), TimeSpan.FromSeconds(30));

                    engine.Convert(inputFile, outputFile, options);


                }
            }
        }
    }
}
