using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using Logic_Tier;

namespace Presentation_Tier
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public bool LoginOK { get; set; }
      private LoginWindow loginW;
      private Logic logicObj;
      private ECG_Window ecgw;
      private string socsecNB;
      public MainWindow()
      {
         logicObj = new Logic();
         loginW = new LoginWindow(this, logicObj);
         InitializeComponent();
         this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

      private void Window_Loaded(object sender, RoutedEventArgs e)
      {
         this.Hide();
         
         loginW.ShowDialog();

         cpr_CB.Text = "Find CPR";


         if (LoginOK == true)
         {
            MainW.Show();

         }
         if (LoginOK == false)
         {
            MainW.Close();
         }

      }
        
        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                MainW.Close();
            }
        }
        public void Blinkingbutton(Button newECG_Button, int length, double repetition)
      {
         DoubleAnimation opacityAnimation = new DoubleAnimation
         {
            From = 1.0,
            To = 0.0,
            Duration = new Duration(TimeSpan.FromMilliseconds(length)),
            AutoReverse = true,
            RepeatBehavior = new RepeatBehavior(repetition)
         };
         Storyboard storyboard = new Storyboard();
         storyboard.Children.Add(opacityAnimation);
         Storyboard.SetTarget(opacityAnimation, newECG_Button);
         Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath("Opacity"));
         storyboard.Begin(newECG_Button);
      }

      private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
         //hvis programmet lukkes ved kommando kaldt i koden lukkes vinduet som normalt
         if (LoginOK == false)
         {
            e.Cancel = false;
         }

         // hvis programmet lukkes på lukknappen, sørger metoden  for at der kommer en advarelsesbok op hvor brugeren kan nå at fortryde
         else
         {
            e.Cancel = true;

            var result = MessageBox.Show("Ønsker du at lukke programmet?", "Advarelse", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);

            if (result == MessageBoxResult.Yes)
            {
               e.Cancel = false;
            }
         }
      }

      private void newECG_Button_Click(object sender, RoutedEventArgs e)
      {
        
         Blinkingbutton(newECG_Button, 500, 3.0);

         ecgw = new ECG_Window(logicObj, socsecNB);
         this.Hide();
         ecgw.ShowDialog();
         this.Show();



      }
   }
}
