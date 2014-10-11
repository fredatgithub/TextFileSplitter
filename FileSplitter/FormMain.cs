using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
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
    private int nombreTotalDeLignesDuFichier;
    private bool fileHasBeenReadOnce;
    
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
      // validation of file path
      if (textBoxfilePath.Text == string.Empty)
      {
        MessageBox.Show("Le chemin du fichier ne peut pas être vide");
        return;
      }

      // validation of number of lines
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

        fileHasBeenReadOnce = true;
        
        textBoxNombreDeLigneFichier.Text = nombreTotalDeLignesDuFichier.ToString(CultureInfo.InvariantCulture);
        textBoxValeurDerniereLigne.Text = ligneCourante;
        streamReader.Close();
        // on coupe le fichier
        streamReader = new StreamReader(fullFileName);
        int compteurDeLigneCoupee = 0;
        List<string> paquetDeLigneList = new List<string>();

        while (streamReader.Peek() >= 0)
        {
          ligneCourante = streamReader.ReadLine();
          compteurDeLigneCoupee++;
          paquetDeLigneList.Add(ligneCourante);
          if (compteurDeLigneCoupee == numberOfLineToCut)
          {
            // écriture dans un fichier séparé
            StreamWriter sw = new StreamWriter(fullFileName.Substring(0, fullFileName.Length - 4) + "-" + ligneCourante + fullFileName.Substring(fullFileName.Length - 4, 4));
            foreach (string ligne in paquetDeLigneList)
            {
              sw.WriteLine(ligne);
            }

            sw.Close();
            paquetDeLigneList = new List<string>();
            compteurDeLigneCoupee = 0;
          }
        }

        // écriture du dernier fichier
        if (paquetDeLigneList.Count > 0)
        {
          StreamWriter sw = new StreamWriter(fullFileName.Substring(0, fullFileName.Length - 4) + "-" + ligneCourante + fullFileName.Substring(fullFileName.Length - 4, 4));
          foreach (string ligne in paquetDeLigneList)
          {
            sw.WriteLine(ligne);
          }

          sw.Close();
          paquetDeLigneList = new List<string>();
          //compteurDeLigneCoupee = 0;
        }
      }
      catch (Exception exception)
      {
        MessageBox.Show("Une erreur est apparue\n{0}", exception.Message);
      }
    }

    private void FormMain_Load(object sender, EventArgs e)
    {
      DisplayTitle();
      fullFileName = textBoxfilePath.Text;
      numberOfLineToCut = int.Parse(textBoxNumberOfLines.Text);
      progressBar1.Visible = false;
    }

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
  }
}