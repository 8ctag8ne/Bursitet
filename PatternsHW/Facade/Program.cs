using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Examples
{
    // Mainapp test application 
    class MainApp
    {
        public static void Main()
        {
            Facade facade = new Facade();
            //string s = Console.ReadLine();
            string s = "CuteFemboySounds";
            facade.ConvertToMP3(s);
            facade.ConvertToWAV(s);
            // Wait for user 
            //Console.Read();
        }
    }


    // "Subsystem ClassA" 
    class UploadSystem
    {
        public string Upload(string name)
        {
            Console.WriteLine("Uploading "+name+" to the server...");
            return name;
        }
    }

    // Subsystem ClassB" 
    class MP3Converter
    {
        public string Convert(string name)
        {
            Console.WriteLine("Converting file to mp3 format...");
            return name+".mp3";
        }
    }


    // Subsystem ClassC" 
    class WAVConverter
    {
        public string Convert(string name)
        {
            Console.WriteLine("Converting file to wav format...");
            return name+".wav";
        }
    }
    // Subsystem ClassD" 
    class DownloadSystem
    {
        public void Download(string name)
        {
            Console.WriteLine("Downloading "+name);
            Console.Write("Success!\n");
        }
    }
    // "Facade" 
    class Facade
    {
        UploadSystem uploader;
        MP3Converter mp3Converter;
        WAVConverter wavConverter;
        DownloadSystem downloader;

        public Facade()
        {
            uploader = new UploadSystem();
            mp3Converter = new MP3Converter();
            wavConverter = new WAVConverter();
            downloader = new DownloadSystem();
        }

        public void ConvertToMP3(string name)
        {
            Console.WriteLine("\n------------ Convertation proccess ------------ ");
            downloader.Download(mp3Converter.Convert(uploader.Upload(name)));
        }

        public void ConvertToWAV(string name)
        {
            Console.WriteLine("\n------------ Convertation proccess ------------ ");
            downloader.Download(wavConverter.Convert(uploader.Upload(name)));
        }
    }
}
