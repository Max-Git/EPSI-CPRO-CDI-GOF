using System;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Proxy démo !");

            Image highResolutionImageNoProxy1 = new HighResolutionImage("sample/veryHighResPhoto1.jpeg");
            Image highResolutionImageNoProxy2 = new HighResolutionImage("sample/veryHighResPhoto2.jpeg");
            Image highResolutionImageBoProxy3 = new HighResolutionImage("sample/veryHighResPhoto3.jpeg");
	
            highResolutionImageNoProxy2.showImage();

            // Image highResolutionImage1 = new ImageProxy("sample/veryHighResPhoto1.jpeg");
            // Image highResolutionImage2 = new ImageProxy("sample/veryHighResPhoto2.jpeg");
            // Image highResolutionImage3 = new ImageProxy("sample/veryHighResPhoto3.jpeg");
            
            // highResolutionImage1.showImage();
        }
    }

    public interface Image 
    {
        void showImage();
    }

    public class HighResolutionImage : Image 
    {
        public string ImageFilePath { get; set; }
        
        public HighResolutionImage(String imageFilePath) 
        {
            ImageFilePath = imageFilePath;
            loadImage(imageFilePath);
        }

        private void loadImage(String imageFilePath) {
            Console.WriteLine("Chargement long de l'image haute def, depuis le disque dur : "+ImageFilePath);
        }

        public void showImage() {

            Console.WriteLine("Affichage de l'image haute def : "+ImageFilePath);
        }

    }

    public class ImageProxy : Image 
    {

        private String imageFilePath;
        private Image proxifiedImage;
        
        public ImageProxy(String imageFilePath) {
            this.imageFilePath= imageFilePath;	
        }
        
        public void showImage() {

            proxifiedImage = new HighResolutionImage(imageFilePath);
            
            proxifiedImage.showImage();
        }

    }
}
