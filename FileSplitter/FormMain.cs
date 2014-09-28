using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace FileSplitter
{
  public partial class FormMain : Form
  {
    public FormMain()
    {
      InitializeComponent();
    }

    private int numberOfLineToCut = 1;
    private string fileName = string.Empty;
    private string fullFileName = string.Empty;
    private int nombreTotalDeLignesDuFichier = 0;


    private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void buttonGetfilePath_Click(object sender, EventArgs e)
    {
      OpenFileDialog ofd = new OpenFileDialog
      {
        InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
        Filter = "Fichiers textes (*.txt)|*.txt",
        Multiselect = false
      };

      if (ofd.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      textBoxfilePath.Text = ofd.FileName;
      fullFileName = ofd.FileName;
      fileName = ofd.SafeFileName;
    }

    private void buttonFileSplit_Click(object sender, EventArgs e)
    {
      // valider chemin fichier
      if (textBoxfilePath.Text == string.Empty)
      {
        MessageBox.Show("Le chemin du fichier ne peut pas être vide");
        return;
      }

      //valider nombre de ligne
      if (!int.TryParse(textBoxNumberOfLines.Text, out numberOfLineToCut))
      {
        MessageBox.Show("Le nombre de ligne doit être un entier");
        return;
      }

      try
      {
        StreamReader streamReader = new StreamReader(fullFileName);
        nombreTotalDeLignesDuFichier = 0;
        string ligneCourante = string.Empty;
        while (streamReader.Peek() >= 0)
        {
          ligneCourante = streamReader.ReadLine();
          nombreTotalDeLignesDuFichier++;
        }
        
        textBoxNombreDeLigneFichier.Text = nombreTotalDeLignesDuFichier.ToString(CultureInfo.InvariantCulture);
        textBoxValeurDerniereLigne.Text = ligneCourante;
        streamReader.Close();
      }
      catch (Exception exception)
      {
        MessageBox.Show("Une erreur est apparue\n{0}", exception.Message);
      }

      
    }

    private void FormMain_Load(object sender, EventArgs e)
    {
      fullFileName = textBoxfilePath.Text;
      numberOfLineToCut = int.Parse(textBoxNumberOfLines.Text);
      progressBar1.Visible = false;
    }

    private void copierToolStripMenuItem_Click(object sender, EventArgs e)
    {
      // quel controle a le focus
      Clipboard.SetText(ActiveControl.Text);
    }

  }
}