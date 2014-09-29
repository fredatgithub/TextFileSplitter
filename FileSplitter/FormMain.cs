using System;
<<<<<<< HEAD
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
=======
using System.Globalization;
using System.IO;
>>>>>>> 3f613d36b85b91c2525a0c20f0567a0fbada3cc7
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
<<<<<<< HEAD
    private int nombreTotalDeLignesDuFichier;
    private bool fileHasBeenReadOnce;
    
=======
    private int nombreTotalDeLignesDuFichier = 0;


>>>>>>> 3f613d36b85b91c2525a0c20f0567a0fbada3cc7
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
<<<<<<< HEAD
      // validation of file path
=======
      // valider chemin fichier
>>>>>>> 3f613d36b85b91c2525a0c20f0567a0fbada3cc7
      if (textBoxfilePath.Text == string.Empty)
      {
        MessageBox.Show("Le chemin du fichier ne peut pas être vide");
        return;
      }

<<<<<<< HEAD
      // validation of number of lines
=======
      //valider nombre de ligne
>>>>>>> 3f613d36b85b91c2525a0c20f0567a0fbada3cc7
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
<<<<<<< HEAD

        fileHasBeenReadOnce = true;
=======
        
>>>>>>> 3f613d36b85b91c2525a0c20f0567a0fbada3cc7
        textBoxNombreDeLigneFichier.Text = nombreTotalDeLignesDuFichier.ToString(CultureInfo.InvariantCulture);
        textBoxValeurDerniereLigne.Text = ligneCourante;
        streamReader.Close();
      }
      catch (Exception exception)
      {
        MessageBox.Show("Une erreur est apparue\n{0}", exception.Message);
      }
<<<<<<< HEAD
=======

      
>>>>>>> 3f613d36b85b91c2525a0c20f0567a0fbada3cc7
    }

    private void FormMain_Load(object sender, EventArgs e)
    {
<<<<<<< HEAD
      DisplayTitle();
=======
>>>>>>> 3f613d36b85b91c2525a0c20f0567a0fbada3cc7
      fullFileName = textBoxfilePath.Text;
      numberOfLineToCut = int.Parse(textBoxNumberOfLines.Text);
      progressBar1.Visible = false;
    }

<<<<<<< HEAD
    private void DisplayTitle()
    {
      Assembly assembly = Assembly.GetExecutingAssembly();
      FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
      Text += string.Format(" V{0}.{1}.{2}.{3}", fvi.FileMajorPart, fvi.FileMinorPart, fvi.FileBuildPart, fvi.FilePrivatePart);
    }

    private void copierToolStripMenuItem_Click(object sender, EventArgs e)
    {
      // What control has focus ?
      Clipboard.SetText(ActiveControl.Text);
    }

    private void buttonLireFichier_Click(object sender, EventArgs e)
    {
      // Validation of file path
      if (textBoxfilePath.Text == string.Empty)
      {
        MessageBox.Show("Le chemin du fichier ne peut pas être vide");
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

        fileHasBeenReadOnce = true;
        textBoxNombreDeLigneFichier.Text = nombreTotalDeLignesDuFichier.ToString(CultureInfo.InvariantCulture);
        textBoxValeurDerniereLigne.Text = ligneCourante;
        streamReader.Close();
      }
      catch (Exception exception)
      {
        MessageBox.Show("Une erreur est apparue\n{0}", exception.Message);
      }
    }
=======
    private void copierToolStripMenuItem_Click(object sender, EventArgs e)
    {
      // quel controle a le focus
      Clipboard.SetText(ActiveControl.Text);
    }

>>>>>>> 3f613d36b85b91c2525a0c20f0567a0fbada3cc7
  }
}