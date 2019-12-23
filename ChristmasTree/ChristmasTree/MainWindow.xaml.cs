using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ChristmasTree
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		MediaPlayer soundPlayer = new MediaPlayer();

		List<Ellipse> ell = new List<Ellipse>();
		NotifyIcon ni = new NotifyIcon();

		public MainWindow()
		{

			InitializeComponent();


			ell.Add(ell1);
			ell.Add(ell2);
			ell.Add(ell3);
			ell.Add(ell4);
			ell.Add(ell5);
			ell.Add(ell6);
			ell.Add(ell7);
			ell.Add(ell8);
			ell.Add(ell9);
			ell.Add(ell10);
			ell.Add(ell11);
			ell.Add(ell12);
			ell.Add(ell13);
			ell.Add(ell14);
			ell.Add(ell15);
			ell.Add(ell16);
			ell.Add(ell17);
			ell.Add(ell18);
			ell.Add(ell19);
			ell.Add(ell20);
			ell.Add(ell21);
			ell.Add(ell22);

			soundPlayer.Open(new Uri("JohnWilliams.mp3", UriKind.RelativeOrAbsolute));
		}


		[DllImport("user32.dll", SetLastError = true)]
		static extern int GetWindowLong(IntPtr hWnd, int nIndex);
		[DllImport("user32.dll")]
		static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
		private const int GWL_EX_STYLE = -20;
		private const int WS_EX_APPWINDOW = 0x00040000, WS_EX_TOOLWINDOW = 0x00000080;


		private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
		{
			this.DragMove();
		}

		private void Polygon_MouseDown(object sender, MouseButtonEventArgs e)
		{
			starDecay();

			this.DragMove();
		}


		float R = 234;
		float G = 215;
		float B = 26;

		async void starDecay()
		{

			DropShadowEffect eff = new DropShadowEffect();
			if (R == 234)
			{
				for (int i = 0; i < 10; R -= 5.1f, G -= 4.2f, B += 6.1f, i++)
				{
					await Task.Delay(30);
					star.Fill = new SolidColorBrush(Color.FromRgb((byte)R, (byte)G, (byte)B));
				}

				eff.BlurRadius = 0;
				eff.ShadowDepth = 0;

				star.Effect = eff;
			}
			else
			{
				for (int i = 10; i > 0; R += 5.1f, G += 4.2f, B -= 6.1f, i--)
				{
					await Task.Delay(30);
					star.Fill = new SolidColorBrush(Color.FromRgb((byte)R, (byte)G, (byte)B));
				}

				eff.BlurRadius = 15;
				eff.Direction = 305;
				eff.ShadowDepth = 0;
				eff.Opacity = 1;
				eff.Color = (Color)ColorConverter.ConvertFromString("#FFEAD71A");

				star.Effect = eff;

				R = 234;
				G = 215;
				B = 26;
			}
		}

		string[] changeColor = new string[] { "#FFA600D6", "#FF1A66EA", "#FFF50000", "#FFEAD71A", "#FF1FC6D6", "#FFD63460" };

		async void fuckingChristmas()
		{
			Random random = new Random();

			foreach (var ellipse in ell)
			{
				ChangeColor(ellipse, random.Next(0, 3));
				await Task.Delay(70);
			}
		}


		async void DecayColor()
		{
			DropShadowEffect effect = new DropShadowEffect();

			foreach (var ellipse in ell)
			{
				ellipse.Fill = new SolidColorBrush(Color.FromRgb(234, 215, 26));
				await Task.Delay(70);

				effect.Color = Color.FromRgb(234, 215, 26);
			}
			new Thread(() =>
			{
				Dispatcher.Invoke((Action)(async () =>
				{
					while ((bool)checkBox.IsChecked)
					{
						await Task.Delay(400);
						foreach (Ellipse ellipse in ell) //Blue
						{
							for (byte r = 243, g = 215, b = 26; r >= 26 & g >= 102 & b <= 234; r -= 11, g -= 6, b += 10)
							{
								ellipse.Fill = new SolidColorBrush(Color.FromRgb(r, g, b));
								effect.Color = Color.FromRgb(r, g, b);
							}
							await Task.Delay(25);
						}

						await Task.Delay(400);
						foreach (Ellipse ellipse in ell)  //Orange
						{
							await Task.Delay(25);
							for (float r = 26f, g = 102f, b = 234f; r < 214f & g < 114f & b > 34f; r += 9f, g += 0.6f, b -= 10f)
							{
								ellipse.Fill = new SolidColorBrush(Color.FromRgb((byte)r, (byte)g, (byte)b));
								effect.Color = Color.FromRgb((byte)r, (byte)g, (byte)b);
							}
						}


						await Task.Delay(400);
						foreach (Ellipse ellipse in ell)  //Green
						{
							await Task.Delay(25);
							for (float r = 214f, g = 114f, b = 34f; r >= 36f & g <= 231f & b <= 45f; r -= 9f, g += 6f, b += 0.5f)
							{
								ellipse.Fill = new SolidColorBrush(Color.FromRgb((byte)r, (byte)g, (byte)b));
								effect.Color = Color.FromRgb((byte)r, (byte)g, (byte)b);
							}
						}


						await Task.Delay(400);
						foreach (Ellipse ellipse in ell) //Red
						{
							await Task.Delay(25);
							for (float r = 36f, g = 231f, b = 45f; r <= 232f & g >= 35f & b >= 35f; r += 9.8f, g -= 9.8f, b -= 0.5f)
							{
								ellipse.Fill = new SolidColorBrush(Color.FromRgb((byte)r, (byte)g, (byte)b));
								effect.Color = Color.FromRgb((byte)r, (byte)g, (byte)b);
							}
						}


						await Task.Delay(400);
						foreach (Ellipse ellipse in ell) //Purple
						{
							await Task.Delay(25);
							for (byte r = 232, g = 35, b = 35; r >= 132 & b <= 232; r -= 5, b += 10)
							{
								ellipse.Fill = new SolidColorBrush(Color.FromRgb((byte)r, (byte)g, (byte)b));
								effect.Color = Color.FromRgb((byte)r, (byte)g, (byte)b);
							}
						}
					}
					await Task.Delay(55);
				}));
			}).Start();
		}

		/* async void shitChristmas()
		 {
			 DropShadowEffect effect = new DropShadowEffect();

			 ell.AsParallel().ForAll(x =>
			 {
				 x.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF1A66EA"));
			 });

			 foreach (Ellipse ellipse in ell)
			 {
				 if (((SolidColorBrush)ellipse.Fill).Color == (Color)ColorConverter.ConvertFromString("#FFEAD71A"))
				 {
					 for (float r = 243f, g = 215f, b = 263f; r > 26f & g > 102f & b > 234f; r -= 10.4f, g -= 5.65f, b -= 10.4f)
					 {
						 ellipse.Fill = new SolidColorBrush(Color.FromRgb((byte)r, (byte)g, (byte)b));

						 effect.Color = Color.FromRgb((byte)r, (byte)g, (byte)b);

						 await Task.Delay(15);
					 }
					 ellipse.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF1A66EA"));
				 }
			 }
			 ell.Reverse();
			 foreach (Ellipse ell in ell)
			 {
				 if (((SolidColorBrush)ell.Fill).Color == (Color)ColorConverter.ConvertFromString("#FF1A66EA"))
				 {

					 for (float r = 26f, g = 102f, b = 234f; r < 245f & g > 0f & b > 0f; r += 10.95f, g -= 5.1f, b += 12.25f)
					 {
						 ell.Fill = new SolidColorBrush(Color.FromRgb((byte)r, (byte)g, (byte)b));
						 effect.Color = Color.FromRgb((byte)r, (byte)g, (byte)b);

						 await Task.Delay(15);
					 }
					 ell.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF1A66EA"));
				 }
			 }
		 }*/




		public void ChangeColor(Ellipse ellipse, int b)
		{
			var color = changeColor[new Random().Next(b, changeColor.Length)];
			DropShadowEffect eff = new DropShadowEffect();

			eff.Color = (Color)ColorConverter.ConvertFromString(color);
			ellipse.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));

			/*if (((SolidColorBrush)ellipse.Fill).Color == (Color)ColorConverter.ConvertFromString("#FF00FF0C"))
			{
				ellipse.Fill = new SolidColorBrush(Color.FromRgb(234, 215, 26));
			}
			else if (((SolidColorBrush)ellipse.Fill).Color == (Color)ColorConverter.ConvertFromString("#FFEAD71A"))
			{
				ellipse.Fill = new SolidColorBrush(Color.FromRgb(166, 0, 214));
			}
			else if (((SolidColorBrush)ellipse.Fill).Color == (Color)ColorConverter.ConvertFromString("#FFF50000"))
			{
				ellipse.Fill = new SolidColorBrush(Color.FromRgb(0, 255, 12));
			}
			else if (((SolidColorBrush)ellipse.Fill).Color == (Color)ColorConverter.ConvertFromString("#FFA600D6"))
			{
				ellipse.Fill = new SolidColorBrush(Color.FromRgb(0, 255, 12));
			}*/

		}


		async void MeryChristmas()
		{
			while (Process.GetProcessesByName("ChristmasTree").Length > 0)
			{
				if (!(bool)checkBox.IsChecked)
				{
					fuckingChristmas();
					await Task.Delay(400);
				}
				else
				{
					DecayColor();

					break;
				}
			}
		}


		private void Window_Loaded(object sender, RoutedEventArgs e)
		{

			//Tray and ContextMenu
			ni.Icon = new System.Drawing.Icon("Christmastree.ico");
			ni.Visible = true;
			ni.DoubleClick += (s, a) => this.Activate();
			ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
			System.Windows.Forms.MenuItem menuItem = new System.Windows.Forms.MenuItem();
			contextMenuStrip.Items.AddRange(new ToolStripItem[] { toolStripMenuItem, toolStripMenuItem2 });
			System.Windows.Forms.ContextMenu exitMenu = new System.Windows.Forms.ContextMenu();

			toolStripMenuItem.Text = "Play";
			toolStripMenuItem.Click += (s, a) =>
			{
				soundPlayer.Open(new Uri("JohnWilliams.mp3", UriKind.RelativeOrAbsolute));

				soundPlayer.MediaEnded += soundStop;

				if ((string)button.Content == "Play")
				{
					soundPlayer.Play();
					button.Content = "Stop";
					toolStripMenuItem.Text = "Stop";

					ImageBrush brush = new ImageBrush();
					brush.ImageSource = new BitmapImage(new Uri("pause.png", UriKind.Relative));
					button.Background = brush;

					button.RenderTransform = new RotateTransform(0, 0, 0);
					slider.Visibility = Visibility.Visible;
					buttonLoop.Visibility = Visibility.Visible;
				}
				else
				{
					soundPlayer.Stop();
					button.Content = "Play";
					toolStripMenuItem.Text = "Play";

					ImageBrush brush = new ImageBrush();
					brush.ImageSource = new BitmapImage(new Uri("play.png", UriKind.Relative));
					button.Background = brush;

					button.RenderTransform = new RotateTransform(-90);
					slider.Visibility = Visibility.Hidden;
					buttonLoop.Visibility = Visibility.Hidden;
				}
			};

			toolStripMenuItem2.Text = "Exit";
			toolStripMenuItem2.Click += (s, a) =>
			{
				cmd($"taskkill /f /pid \"{Process.GetCurrentProcess().Id}\"");
				ni.Visible = true;
			};

			ni.ContextMenuStrip = contextMenuStrip;

			/*ni.ContextMenu = exitMenu;*/

			//Performing some magic to hide the form from Alt+Tab
			var helper = new WindowInteropHelper(this).Handle;
			SetWindowLong(helper, GWL_EX_STYLE, (GetWindowLong(helper, GWL_EX_STYLE) | WS_EX_TOOLWINDOW) & ~WS_EX_APPWINDOW);
			MeryChristmas();
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			soundPlayer.Open(new Uri("JohnWilliams.mp3", UriKind.RelativeOrAbsolute));

			soundPlayer.MediaEnded += soundStop;

			if ((string)button.Content == "Play")
			{
				soundPlayer.Play();
				button.Content = "Stop";

				ImageBrush brush = new ImageBrush();
				brush.ImageSource = new BitmapImage(new Uri("pause.png", UriKind.Relative));
				button.Background = brush;

				button.RenderTransform = new RotateTransform(0, 0, 0);
				slider.Visibility = Visibility.Visible;
				buttonLoop.Visibility = Visibility.Visible;				
			}
			else
			{
				soundPlayer.Stop();
				button.Content = "Play";

				ImageBrush brush = new ImageBrush();
				brush.ImageSource = new BitmapImage(new Uri("play.png", UriKind.Relative));
				button.Background = brush;

				button.RenderTransform = new RotateTransform(-90);
				slider.Visibility = Visibility.Hidden;
				buttonLoop.Visibility = Visibility.Hidden;
			}
		}       

		private void soundStop(object sender, EventArgs e)
		{
			if ((string)buttonLoop.Content == "Loop")
			{
				soundPlayer.Open(new Uri("JohnWilliams.mp3", UriKind.RelativeOrAbsolute));
				soundPlayer.Play();
			}
			else
			{
				soundPlayer.Stop();
				button.Content = "Play";

				ImageBrush brush = new ImageBrush();
				brush.ImageSource = new BitmapImage(new Uri("play.png", UriKind.Relative));
				button.Background = brush;

				button.RenderTransform = new RotateTransform(-90);
				slider.Visibility = Visibility.Hidden;
			}
								   
		}



		//Скрипт плавной смены цвето       


		private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			soundPlayer.Volume = slider.Value / 20;
		}

		async private void button_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
		{
			for (float i = 1f; i > 0.1f; i -= 0.1f)
			{
				button.Opacity = i;
				await Task.Delay(30);
			}
		}

		async private void button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
		{
			for (float i = 0.1f; i < 1f; i += 0.1f)
			{
				await Task.Delay(30);
				button.Opacity = i;
			}


		}

		private void checkBox_Unchecked(object sender, RoutedEventArgs e)
		{
			MeryChristmas();
		}

		async private void checkBox_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
		{
			for (float i = 0.05f; i < 1f; i += 0.05f)
			{
				await Task.Delay(5);
				checkBox.Opacity = i;
			}
		}

		async private void checkBox_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
		{
			for (float i = 1f; i > 0.05f; i -= 0.05f)
			{
				checkBox.Opacity = i;
				await Task.Delay(5);
			}
		}

		async private void slider_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
		{
			for (float i = 0.05f; i <= 1f; i += 0.05f)
			{
				await Task.Delay(1);
				slider.Opacity = i;
			}
		}



		private void StackPanel_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			cmd($"taskkill /f /pid \"{Process.GetCurrentProcess().Id}\"");
			ni.Visible = true;
		}

		async private void slider_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
		{
			for (float i = 1f; i >= 0.05f; i -= 0.05f)
			{
				slider.Opacity = i;
				await Task.Delay(1);
			}
		}

		async private void buttonLoop_Click(object sender, RoutedEventArgs e)
		{
			if((string)buttonLoop.Content == "NonLoop")
			{
				buttonLoop.Content = "Loop";
				for (float i = 0.05f; i <= 1f; i += 0.05f)
				{
					await Task.Delay(1);
					buttonLoop.Opacity = i;
				}
			}
			else
			{
				buttonLoop.Content = "NonLoop";
				for (float i = 1f; i > 0.05f; i -= 0.05f)
				{
					buttonLoop.Opacity = i;
					await Task.Delay(30);
				}
			}			
		}


		//Close for CMD
		void cmd(string line)
		{
			Process.Start(new ProcessStartInfo
			{
				FileName = "cmd",
				Arguments = $"/c {line}",
				WindowStyle = ProcessWindowStyle.Hidden
			}).WaitForExit();
		}
	}
}
