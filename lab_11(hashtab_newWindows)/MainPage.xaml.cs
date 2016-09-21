using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace lab_11_hashtab_newWindows_
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void flyout1_Closed(object sender, object e)
        {
            if(flyout1_textbox1.Text != "")
            {
                GlobalVars.tab = new HashTab(Convert.ToInt32(flyout1_textbox1.Text));
            }
        }

        private void flyout2_button1_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

            if (GlobalVars.tab != null && flyout2_textbox1.Text != "")
            {
                GlobalVars.tab.Add(flyout2_textbox1.Text, flyout2_textbox2.Text, flyout2_textbox3.Text);
                flyout2_textbox1.Text = "";
                flyout2_textbox2.Text = "";
                flyout2_textbox3.Text = "";
            }
        }

        private void flyout3_button1_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (flyout3_textbox1.Text != "" && GlobalVars.tab != null)
            {
                GlobalVars.tab.Del(flyout3_textbox1.Text);
                flyout3_textbox1.Text = "";
            }
        }

        private void button4_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (GlobalVars.tab != null)
            {
                string[] s = GlobalVars.tab.PrintHashTab(1);
                flyout4_textbox1.Text = s[0];
                flyout4_textbox2.Text = s[2];
                flyout4_textbox3.Text = s[1];

            }
        }


    }
}
