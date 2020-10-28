using System;
using System.Drawing;
using System.Windows;


namespace NewSkills.View
{
    /// <summary>
    /// Interaction logic for CongratulationWindow.xaml
    /// </summary>
    public partial class CongratulationWindow : Window
    {
        MainWindow mainWindow;
    

        public CongratulationWindow(MainWindow mainWindow)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
        }

        public void loadVideo()
        {
            try
            {
                Bitmap bitmap = new System.Drawing.Bitmap(Properties.Resources.Einstein);//it is in the memory now
                //var bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
               // imageEinstein.Source = bitmapSource;
            }
            catch (Exception e)
            {
                string s = e.ToString();
            }

        }
    }
}
