using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

using Pbp.Properties;

namespace Pbp.Forms
{
	/// <summary>
	/// Interaction logic for UserControl1.xaml
	/// </summary>
	/// 

	public partial class UserControl1 : UserControl
	{
		DispatcherTimer tmr;
		static UserControl1 instance;
		private int fadeSteps;
		float opCounter;

		private UserControl1()
		{
			InitializeComponent();
			tmr = new DispatcherTimer();
			fadeSteps = 0;
		}

		static public UserControl1 getInstance()
		{
			if (instance == null)
				instance = new UserControl1();
			return instance;
		}

		public void setFadeSteps(int steps)
		{
			fadeSteps = steps >= 0 ? steps : 0;
		}

		public void setProjectionImage(System.Drawing.Bitmap img)
		{
			projectionImage.Opacity = 0f;
			projectionImage.Source = loadBitmap(img);
			opCounter = 0f;

			if (tmr.IsEnabled)
			{
				tmr.Stop();
			}
			tmr = new DispatcherTimer();
			tmr.Dispatcher.Thread.Priority = System.Threading.ThreadPriority.AboveNormal;
			tmr.Interval = TimeSpan.FromMilliseconds(fadeSteps);
			Console.WriteLine(fadeSteps.ToString());
			tmr.Tick += new EventHandler(tmr_Tick);
			tmr.Start();
		}

		void tmr_Tick(object sender, EventArgs e)
		{
			if (projectionImage.Opacity < 1.0f)
			{
				opCounter += 0.02f;
				projectionImage.Opacity = opCounter;
			}
			else
			{
				projectionImage.Opacity = 1f;
				projectionImageBack.Source = projectionImage.Source;
				tmr.Stop();
				Console.WriteLine(tmr.ToString());
			}
		}

		public static BitmapSource loadBitmap(System.Drawing.Bitmap source)
		{
			return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(source.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty,
				System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
		}

		private void projectionControl_Loaded(object sender, RoutedEventArgs e)
		{

		}

		public void blackOut(bool val)
		{
			if (val)
			{
				projectionImage.Visibility = Visibility.Hidden;
				projectionImageBack.Visibility = Visibility.Hidden;
			}
			else
			{
				projectionImage.Visibility = Visibility.Visible;
				projectionImageBack.Visibility = Visibility.Visible;
			}
		}






	}
}

