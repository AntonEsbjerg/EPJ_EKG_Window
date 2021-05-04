using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Logic_Tier;
using LiveCharts;

namespace Presentation_Tier
{
   /// <summary>
   /// Interaction logic for ECG_Window.xaml
   /// </summary>
   public partial class ECG_Window : Window
   {
      Logic logicRef;
      String SocSecNb;

      public ChartValues<Double> Yvalues { get; set; }
      public ChartValues<Double> Xvalues { get; set; }


      public ECG_Window(Logic logicRef, String SocSecNb)
      {
         InitializeComponent();

         this.logicRef = logicRef;
         this.SocSecNb = SocSecNb;

         Yvalues = new ChartValues<Double>();
         Xvalues = new ChartValues<Double>();

      }


      private void Window_Loaded(object sender, RoutedEventArgs e)
      {
         socsec_TB.Text = SocSecNb;

         // listerne til x og y værdieren fyldes med data:

         //foreach (var dTO_BSugar in logicRef.getBSugarData(SocSecNb))
         //{
         //   Yvalues.Add();
         //   Xvalues.Add();
            

         //DataContext = this;
      }

      private void home_button_Click1(object sender, RoutedEventArgs e)
      {
         this.Close();
      }

      private void STEMI_Button_Click(object sender, RoutedEventArgs e)
      {

      }

      private void NOSTEMI_Button_Click(object sender, RoutedEventArgs e)
      {

      }
   }
}
