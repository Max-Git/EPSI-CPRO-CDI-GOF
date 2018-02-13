using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Avec adapter FR !");

            LecteurMediaFrancais lecteurFR = new LecteurMediaFrancais();
            AdapterMediaFrancais adapterFR = new AdapterMediaFrancais(lecteurFR);
            ReaderService rs = new ReaderService(adapterFR);
            rs.play();
        }
    }

    public class ReaderService
    {
        public IGenericReader genericReader;
        
        public ReaderService(IGenericReader genericReader)
        {
            this.genericReader = genericReader;
        }
        public void play()
        {
            genericReader.Play();
        }
    }

    public class AdapterMediaFrancais : IGenericReader 
    {
        LecteurMediaFrancais lecteurFR;
        public AdapterMediaFrancais(LecteurMediaFrancais lecteurFR)
        {
            this.lecteurFR = lecteurFR;
        }
        public void Play()
        {
            lecteurFR.Demarrer();
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
    
    public interface IGenericReader{
        void Play();
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
