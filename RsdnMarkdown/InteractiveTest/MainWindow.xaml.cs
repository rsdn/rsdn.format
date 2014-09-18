﻿using Nitra;

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
      var html = GetHtml();
      _htmlViewer.NavigateToString(html);
    }

    private string GetHtml()
    {
      var reader = new StringReader(_text.Text);
      var blocks = Utils.SplitQuotations(reader);
      var sb = new StringBuilder();
      sb.AppendLine("<table border=\"1\" width=\"100%\">");
      foreach (var block in blocks)
      {
        var blockContent = string.Join("<br>\r\n", Utils.ProcessQuotationBlock(block.Value));
        sb.AppendLine("<tr><td><b>" + block.Key + "</b></td><td>" + blockContent + "</td></tr>");
      }
      sb.AppendLine("</table>");

      var html = Properties.Resources.HtmlTemplate.Replace("{content}", sb.ToString()); ;
      return html;
    }

    private void _openInBrowser_Click(object sender, RoutedEventArgs e)
    {
      var html = GetHtml();
      var fileName = Path.GetTempFileName();
      fileName = Path.ChangeExtension(fileName, "html");
      File.WriteAllText(fileName, html, Encoding.UTF8);
      Process.Start(fileName);
    }
  }
}
