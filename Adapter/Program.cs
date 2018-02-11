using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sans adapter !");

            string typeReader = "UK";

            ReaderService rs = new ReaderService(typeReader);
            rs.play();
        }
    }

    public class ReaderService
    {
        public string TypeReader { get; set; }
        
        public ReaderService(string typeReader)
        {
            TypeReader = typeReader;
        }
        public void play()
        {
            switch (TypeReader.ToUpper())
            {
                case "UK":
                    MediaReaderUk ukMedia = new MediaReaderUk();
                    ukMedia.Start();
                    break;
                case "US":
                    MediaReaderUs usMedia = new MediaReaderUs();
                    usMedia.Read();
                    break;
                case "FR":
                    LecteurMediaFrancais frMedia = new LecteurMediaFrancais();
                    frMedia.Demarrer();
                    break;
                default:
                    return;
            }
        }
    }

    public interface ILecteurMediaFrancais
    {
         void Demarrer();
    }

    public interface IMediaReaderUk
    {
         void Start();
    }

    public interface IMediaReaderUs
    {
         void Read();
    }

    public class LecteurMediaFrancais : ILecteurMediaFrancais
    {
        public void Demarrer()
        {
            Console.Write("LecteurMediaFrancais->Démarrer");
        }
    }
    public class MediaReaderUk : IMediaReaderUk
    {
        public void Start()
        {
            Console.Write("MediaReaderUk->Start");
        }
    }
    public class MediaReaderUs : IMediaReaderUs
    {
        public void Read()
        {
            Console.Write("MediaReaderUs->Read");
        }
    }
}
