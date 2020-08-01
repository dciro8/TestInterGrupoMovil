using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.Entry;

namespace TestInterGrupoMovil.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChartPage : ContentPage
    {
        List<Entry> entryList;
        public ChartPage()
        {
            InitializeComponent();
            entryList = new List<Entry>();
            LoadEntries();
            //Asignar los datos dentro de los entrys a los gráficos dentro de la vista XAML
            barChart. Chart = new RadialGaugeChart()
            {
                Entries = entryList,LabelTextSize=50,Margin=25,StartAngle=100//,PointMode= PointMode.Circle
            };
            //pieChart.Chart = new RadialGaugeChart()
            //{
            //    Entries = entryList
            //};
            //linesChart.Chart = new Microcharts.LineChart()
            //{
            //    Entries = entryList
            //};


            

            //donutChart.Chart= new Microcharts.DonutChart()
            //{
            //    Entries = entryList,HoleRadius=10,LabelTextSize=40,MaxValue=20,MinValue=70,BackgroundColor=SKColor.Parse("#F44336")

            //};
        }

        private void LoadEntries()
        {
            Entry e1 = new Entry(70)
            {
                Label = "A",
                ValueLabel = "70",
                Color = SKColor.Parse("#00bcd4"),
                TextColor = SKColor.Parse("#F44336")

            };
            Entry e2 = new Entry(300)
            {
                Label = "B",
                ValueLabel = "300",
                Color = SKColor.Parse("#F44336"),
                TextColor = SKColor.Parse("#00bcd4")
            };
            Entry e3 = new Entry(50)
            {
                Label = "C",
                ValueLabel = "50",
                Color = SKColor.Parse("#43A047")
                ,
                TextColor = SKColor.Parse("#F9A825")
            };
            //Entry e4 = new Entry(500)
            //{
            //    Label = "D",
            //    ValueLabel = "500",
            //    Color = SKColor.Parse("#F9A825"),
            //    TextColor = SKColor.Parse("#43A047")
            //};
            entryList.Add(e1);
            //entryList.Add(e2);
            //entryList.Add(e3);
            //entryList.Add(e4);
        }
    }
}