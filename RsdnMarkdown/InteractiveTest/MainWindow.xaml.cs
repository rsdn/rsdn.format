using Nitra;

using RsdnMarkdown;

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Path = System.IO.Path;
using System.Reflection;

namespace InteractiveTest
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void _text_TextChanged(object sender, TextChangedEventArgs e)
    {
      var filePath = MakeHtmlFile();
      _htmlViewer.Navigate(filePath);
    }

    private string GetHtml()
    {
      var html = Properties.Resources.HtmlTemplate.Replace("{content}", Utils.GetHtml(_text.Text));
      return html;
    }

    private void _openInBrowser_Click(object sender, RoutedEventArgs e)
    {
      Process.Start(MakeHtmlFile());
    }

    private string MakeHtmlFile()
    {
      var html = GetHtml();
      var fileName = "preview.html";
      var path = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().Location).LocalPath);
      var htmlFilePath = Path.Combine(path, fileName);
      File.WriteAllText(htmlFilePath, html, Encoding.UTF8);
      return htmlFilePath;
    }
  }
}
