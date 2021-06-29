using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RatingYourFeeling
{
    public class RatingFeeling : INotifyPropertyChanged
    {
        private int _rating;
        private string _time;
        public string Time
        {
            get { return _time; }
            set
            {
                this._time = value;
                NotifyPropertyChanged("time");
            }
        }
        public int Rating 
        {

            get { return _rating; }
            set
            {
                this._rating = value;
                NotifyPropertyChanged("rating");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }

    public sealed partial class MainPage : Page
    {
        int ratingValue ;
        ArrayList ratingArray = new ArrayList(); 
        int arrayCount = 1;
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// https://stackoverflow.com/questions/54629036/uwp-c-sharp-dynamically-change-chart-when-changing-data
        /// </summary>
        public ObservableCollection<RatingFeeling> LstSource
        {
            get { return lstSource; }
        }

        private ObservableCollection<RatingFeeling> lstSource = new ObservableCollection<RatingFeeling>
        {
            new RatingFeeling() { Time = "1-10", Rating = 10 },
            new RatingFeeling() { Time = "1-10", Rating = 1 },
        };

        #region buttom click
        private void Maximal_Click(object sender, RoutedEventArgs e)
        {
            ratingValue = 10;
            RatingValue.Text = "10";
            DateTime localDate = DateTime.Now;
            var now = localDate.ToString("HH:mm:ss");
            lstSource.Add(new RatingFeeling() { Time = now, Rating = 10 });
            arrayCount++;
        }

        private void Really_Really_hard_Button_Click(object sender, RoutedEventArgs e)
        {
            ratingValue = 9;
            RatingValue.Text = "9";
            DateTime localDate = DateTime.Now;
            var now = localDate.ToString("HH:mm:ss");
            lstSource.Add(new RatingFeeling() { Time = now, Rating = 9 });
            arrayCount++;
        }

        private void Really_hard_Button_Click(object sender, RoutedEventArgs e)
        {
            ratingValue = 8;
            RatingValue.Text = "8";
            DateTime localDate = DateTime.Now;
            var now = localDate.ToString("HH:mm:ss");
            lstSource.Add(new RatingFeeling() { Time = now, Rating = 8 });
            arrayCount++;
        }

        private void Challenging_hard_Button_Click(object sender, RoutedEventArgs e)
        {
            ratingValue = 7;
            RatingValue.Text = "7";
            DateTime localDate = DateTime.Now;
            var now = localDate.ToString("HH:mm:ss");
            lstSource.Add(new RatingFeeling() { Time = now, Rating = 7 });
            arrayCount++;
        }

        private void Hard_Button_Click(object sender, RoutedEventArgs e)
        {
            ratingValue = 6;
            RatingValue.Text = "6";
            DateTime localDate = DateTime.Now;
            var now = localDate.ToString("HH:mm:ss");
            lstSource.Add(new RatingFeeling() { Time = now, Rating = 6 });
            arrayCount++;
        }

        private void Challenging_Button_Click(object sender, RoutedEventArgs e)
        {
            ratingValue = 5;
            RatingValue.Text = "5";
            DateTime localDate = DateTime.Now;
            var now = localDate.ToString("HH:mm:ss");
            lstSource.Add(new RatingFeeling() { Time = now, Rating = 5 });
            arrayCount++;
        }

        private void Moderate_Button_Click(object sender, RoutedEventArgs e)
        {
            ratingValue = 4;
            RatingValue.Text = "4";
            DateTime localDate = DateTime.Now;
            var now = localDate.ToString("HH:mm:ss");
            //lstSource[0].Rating = 4;
            lstSource.Add(new RatingFeeling() { Time = now , Rating = 4 });
            //ratingArray.Add(ratingValue);
            arrayCount++;
        }

        private void Easy_Button_Click(object sender, RoutedEventArgs e)
        {
            ratingValue = 3;
            RatingValue.Text = "3";
            DateTime localDate = DateTime.Now;
            var now = localDate.ToString("HH:mm:ss");
            lstSource.Add(new RatingFeeling() { Time = now, Rating = 3 });
            arrayCount++;
        }

        private void Really_Easy_Button_Click_1(object sender, RoutedEventArgs e)
        {
            ratingValue = 2;
            RatingValue.Text = "2";
            DateTime localDate = DateTime.Now;
            var now = localDate.ToString("HH:mm:ss");
            lstSource.Add(new RatingFeeling() { Time = now, Rating = 2 });
            arrayCount++;
        }

        private void Rest_Button_Click(object sender, RoutedEventArgs e)
        {
            ratingValue = 1;
            RatingValue.Text = "1";
            DateTime localDate = DateTime.Now;
            var now = localDate.ToString("HH:mm:ss");
            lstSource.Add(new RatingFeeling() { Time = now, Rating = 1 });
            arrayCount++;
        }

        #endregion

        private void Page_loaded(object sender, RoutedEventArgs e)
        {
            //LoadChartContents();
            
        }


        private void LoadChartContents()
        {
            List<RatingFeeling> rateSource = new List<RatingFeeling>();

            if(ratingArray != null)
            {
                foreach( int obj in ratingArray)
                {
                    DateTime localDate = DateTime.Now;
                    var now = localDate.ToString();
                    rateSource.Add(new RatingFeeling() { Time = now, Rating = obj });
                }
            }

            rateSource.Add(new RatingFeeling() { Time = "10:00", Rating = 0 });
            //rateSource.Add(new RatingFeeling() { time = "10:10", Rating = 5 });
            //rateSource.Add(new RatingFeeling() { time = "10:15", Rating = 6 });
            //rateSource.Add(new RatingFeeling() { time = "10:20", Rating = 4 });
            //rateSource.Add(new RatingFeeling() { time = "10:25", Rating = 2 });
            //rateSource.Add(new RatingFeeling() { time = "10:20", Rating = 3 });
            (LineChart.Series[0] as LineSeries).ItemsSource = rateSource;
        }

        private void Clean_Button_Click(object sender, RoutedEventArgs e)
        {
            lstSource.Clear();
            lstSource.Add(new RatingFeeling() { Time = "1-10", Rating = 10 });
            lstSource.Add(new RatingFeeling() { Time = "1-10", Rating = 1 });
            arrayCount = 1;
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            if (arrayCount > 1)
            {
                lstSource.RemoveAt(arrayCount);
                arrayCount--;
            }
       
        }
    }
}
