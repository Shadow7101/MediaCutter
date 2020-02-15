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
            Separar_Arquivos();
        }
        private void Juntar_Arquivos()
        {
            string[] files = new string[] {
                    "75827614_1020729014938936_8791711126376427222_n.mp4",
                    "72709672_177936833345686_3309992862822149750_n.mp4",
                    "77178595_150753886323197_8625749720430450148_n.mp4"
                };


            using (var engine = new Engine())
            {
                //engine.




            }
        }
        private static void Separar_Arquivos()
        {
            using (var engine = new Engine())
            {
                string file = @"D:\doc\mp4\HITS-2019\31-Rubel, ANAVITÓRIA - Partilhar.mp4";
                var inputFile = new MediaFile { Filename = file };
                engine.GetMetadata(inputFile);
                var outputName = @"C:\Users\wilso\Downloads\31_";
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
                    var outputFile = new MediaFile(outputName + counter.ToString("00") + outputExtension);

                    options.CutMedia(TimeSpan.FromMilliseconds(currentPosition), TimeSpan.FromSeconds(30));

                    engine.Convert(inputFile, outputFile, options);


                }
            }
        }
    }
}
