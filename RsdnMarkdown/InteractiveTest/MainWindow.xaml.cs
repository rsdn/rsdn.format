using Nitra;

using RsdnMarkdown;

using System;
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
      var reader = new StringReader(_text.Text);
      var blocks = Utils.SplitQuotations(reader);
      var sb = new StringBuilder();
      sb.AppendLine("<table border=\"1\">");
      foreach (var block in blocks)
      {
        sb.AppendLine("<tr><td><b>" + block.Key + "</b></td><td>" + block.Value.Replace("\n", "<br>\n") + "</td></tr>");
      }
      sb.AppendLine("</table>");

      //var parserHost  = new ParserHost();
      //var source      = new SingleLineSourceSnapshot(_text.Text);
      //var parseResult = Paragraph.Start(source, parserHost);
      //var ast         = ParagraphAst.Start.Create(parseResult);
      var html = Properties.Resources.HtmlTemplate.Replace("{content}", sb.ToString()); ;
      _htmlViewer.NavigateToString(html);
    }
  }
}
