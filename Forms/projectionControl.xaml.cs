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
		public UserControl1()
		{
			InitializeComponent();
		}

		public void setProjectionImage(System.Drawing.Bitmap img)
		{
			Settings setting = new Settings();

			projectionImage.Opacity = 0f;
			projectionImage.Source = loadBitmap(img);

			if (setting.projectionFadeTime >= 100)
			{
				int interval = (int)(setting.projectionFadeTime / 100f);

				Console.WriteLine(interval.ToString());
				DispatcherTimer tmr = new DispatcherTimer();
				tmr.Interval = TimeSpan.FromMilliseconds(interval);
				tmr.Tick += new EventHandler(tmr_Tick);
				tmr.Tag = 0f;
				tmr.Start();
			}
			else
			{
				projectionImageBack.Source = projectionImage.Source;
				projectionImage.Opacity = 1f;
			}
		}

		void tmr_Tick(object sender, EventArgs e)
		{
			float val = (float)((DispatcherTimer)sender).Tag;
			if ( val <= 1.0f)
			{
				projectionImage.Opacity = val;
				((DispatcherTimer)sender).Tag = val + 0.01f;
			}
			else
			{
				projectionImageBack.Source = projectionImage.Source;
				((DispatcherTimer)sender).Stop();
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






	}
}

