// Decompiled with JetBrains decompiler
// Type: ZebraLabelPrint.Form1
// Assembly: ZebraLabelPrint, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ED888763-08FF-4F95-B0CC-2EF83552D2E6
// Assembly location: X:\Apartment Apps, Inc\Label Printer\Label Printer\Label Printer\Label Printer Prog\ZebraLabelPrint.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace ZebraLabelPrint
{
  public class Form1 : Form
  {
    private IContainer components = (IContainer) null;
    private TextBox txtBuildingNumber;
    private TextBox txtUnitNumber;
    private Button btnCreateLabel;
    private Label label1;
    private Label label2;
    private Button btnFileImport;

    public Form1()
    {
      this.InitializeComponent();
    }

    private void btnCreateLabel_Click(object sender, EventArgs e)
    {
      System.IO.File.WriteAllBytes("C:\\Temp\\Chart.png", new WebClient().DownloadData("https://chart.googleapis.com/chart?chs=200x200&cht=qr&chl=http://www.apartmentapps.com?apt=" + this.txtBuildingNumber.Text + "," + this.txtUnitNumber.Text));
      HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create("http://api.labelary.com/v1/graphics");
      string str1 = "----WebKitBoundaryString";
      string path = "C:\\Temp\\Chart.png";
      httpWebRequest.Method = "POST";
      httpWebRequest.ContentType = "multipart/form-data; boundary=" + str1;
      httpWebRequest.KeepAlive = true;
      httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
      MemoryStream memoryStream = new MemoryStream();
      StreamWriter streamWriter = new StreamWriter((Stream) memoryStream);
      streamWriter.Write("\r\n--" + str1 + "\r\n");
      streamWriter.Write("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: image/png\r\n\r\n", (object) "file", (object) Path.GetFileName(path), (object) Path.GetExtension(path));
      streamWriter.Flush();
      FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
      byte[] buffer = new byte[1024];
      int count;
      while ((count = fileStream.Read(buffer, 0, buffer.Length)) != 0)
        memoryStream.Write(buffer, 0, count);
      fileStream.Close();
      streamWriter.Write("\r\n--" + str1 + "--\r\n");
      streamWriter.Flush();
      httpWebRequest.ContentLength = memoryStream.Length;
      using (Stream requestStream = httpWebRequest.GetRequestStream())
        memoryStream.WriteTo(requestStream);
      memoryStream.Close();
      string str2 = "";
      try
      {
        str2 = new StreamReader(httpWebRequest.GetResponse().GetResponseStream()).ReadToEnd();
      }
      catch
      {
      }
      string szString = "^XA\n" + "^CFA,14,7\n" + "^FO25,10^GFA,1800,1800,15,,T01,T038,T078,T034,T0F8,S01FC,T0FC,S03FE,S07FE,S07FF,S0IF8,R01IF8,R03IF8,R03IFC,R07IFE,R07JF,R0KF8,Q01KFC,::Q07KFE,::Q0MF,:Q0MF8,:Q0MFC,Q07LFC,Q07LFE,R037JFE,S03KF,O03EI07JF,O07FF800JF8,O0JF003IF,O07JF006FF,N01KFC00FF,N01LF803E,N03MF008,N03MFC028,N03NF8,N0OFE,N0PF8,M01PFE,M01QFC,M01RF,M07RFC,M03SF,M0TF,M07SF8,L01TF,L01TFC,L03TFE,L07TFE,L07UF,:L0VF8,K01VF8,K01VFC,K03VFC,K03VFE,K07WF,:K0XF,K0XF8,J01XF8,J01XFC,J03XFC,J03XFE,J07XFE,J07YF,J0gF8,:I01gFC,I01IFEK03PFC,I03FFEM03OFE,I03FF8N03NFE,I03FEP07NF,I03F8P01NF,I01FR03MF8,J04S0MF8,X01LFC,Y03KFE,g07KF,gG07JF,gH0JF,gI0IF,gJ07F,gJ03E,,:::::::::::::::::::::::::::::^FS\n" + "^FO30,110^FDApartmentApps.com^FS\n" + "^FO30,135^FDBuilding:     " + this.txtBuildingNumber.Text + "^FS\n" + "^FO30,160^FDApartment: " + this.txtUnitNumber.Text + "^FS\n" + "^FO200,10" + str2.Replace("^XA^FO0,0", "").Replace("^XZ", "") + "\n" + "^XZ";
      PrintDialog printDialog = new PrintDialog();
      printDialog.PrinterSettings = new PrinterSettings();
      if (DialogResult.OK != printDialog.ShowDialog((IWin32Window) this))
        return;
      RawPrinterHelper.SendStringToPrinter(printDialog.PrinterSettings.PrinterName, szString);
    }

    private void btnFileImport_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.InitialDirectory = "C:\\";
      openFileDialog.Filter = "csv files (*.csv)|*.csv|All Files (*.*)|*.*";
      openFileDialog.FilterIndex = 2;
      openFileDialog.RestoreDirectory = true;
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      using (StreamReader streamReader = new StreamReader(openFileDialog.FileName))
      {
        PrintDialog printDialog = new PrintDialog();
        printDialog.PrinterSettings = new PrinterSettings();
        if (DialogResult.OK == printDialog.ShowDialog((IWin32Window) this))
        {
          string str1;
          while ((str1 = streamReader.ReadLine()) != null)
          {
            string[] strArray = str1.Split(',');
            System.IO.File.WriteAllBytes("C:\\Temp\\Chart.png", new WebClient().DownloadData("https://chart.googleapis.com/chart?chs=200x200&cht=qr&chl=http://www.apartmentapps.com?apt=" + str1));
            HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create("http://api.labelary.com/v1/graphics");
            string str2 = "----WebKitBoundaryString";
            string path = "C:\\Temp\\Chart.png";
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "multipart/form-data; boundary=" + str2;
            httpWebRequest.KeepAlive = true;
            httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
            MemoryStream memoryStream = new MemoryStream();
            StreamWriter streamWriter = new StreamWriter((Stream) memoryStream);
            streamWriter.Write("\r\n--" + str2 + "\r\n");
            streamWriter.Write("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: image/png\r\n\r\n", (object) "file", (object) Path.GetFileName(path), (object) Path.GetExtension(path));
            streamWriter.Flush();
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[1024];
            int count;
            while ((count = fileStream.Read(buffer, 0, buffer.Length)) != 0)
              memoryStream.Write(buffer, 0, count);
            fileStream.Close();
            streamWriter.Write("\r\n--" + str2 + "--\r\n");
            streamWriter.Flush();
            httpWebRequest.ContentLength = memoryStream.Length;
            using (Stream requestStream = httpWebRequest.GetRequestStream())
              memoryStream.WriteTo(requestStream);
            memoryStream.Close();
            string str3 = "";
            try
            {
              str3 = new StreamReader(httpWebRequest.GetResponse().GetResponseStream()).ReadToEnd();
            }
            catch
            {
            }
            string str4 = str3.Replace("^XA^FO0,0", "").Replace("^XZ", "");
            string szString = "^XA\n" + "^CFA,14,7\n" + "^FO25,10^GFA,1800,1800,15,,T01,T038,T078,T034,T0F8,S01FC,T0FC,S03FE,S07FE,S07FF,S0IF8,R01IF8,R03IF8,R03IFC,R07IFE,R07JF,R0KF8,Q01KFC,::Q07KFE,::Q0MF,:Q0MF8,:Q0MFC,Q07LFC,Q07LFE,R037JFE,S03KF,O03EI07JF,O07FF800JF8,O0JF003IF,O07JF006FF,N01KFC00FF,N01LF803E,N03MF008,N03MFC028,N03NF8,N0OFE,N0PF8,M01PFE,M01QFC,M01RF,M07RFC,M03SF,M0TF,M07SF8,L01TF,L01TFC,L03TFE,L07TFE,L07UF,:L0VF8,K01VF8,K01VFC,K03VFC,K03VFE,K07WF,:K0XF,K0XF8,J01XF8,J01XFC,J03XFC,J03XFE,J07XFE,J07YF,J0gF8,:I01gFC,I01IFEK03PFC,I03FFEM03OFE,I03FF8N03NFE,I03FEP07NF,I03F8P01NF,I01FR03MF8,J04S0MF8,X01LFC,Y03KFE,g07KF,gG07JF,gH0JF,gI0IF,gJ07F,gJ03E,,:::::::::::::::::::::::::::::^FS\n" + "^FO30,110^FDApartmentApps.com^FS\n" + "^FO30,135^FDBuilding:     " + strArray[0] + "^FS\n" + "^FO30,160^FDApartment: " + strArray[1] + "^FS\n" + "^FO200,10" + str4 + "\n" + "^XZ";
            RawPrinterHelper.SendStringToPrinter(printDialog.PrinterSettings.PrinterName, szString);
          }
        }
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.txtBuildingNumber = new TextBox();
      this.txtUnitNumber = new TextBox();
      this.btnCreateLabel = new Button();
      this.label1 = new Label();
      this.label2 = new Label();
      this.btnFileImport = new Button();
      this.SuspendLayout();
      this.txtBuildingNumber.Location = new Point(144, 35);
      this.txtBuildingNumber.Name = "txtBuildingNumber";
      this.txtBuildingNumber.Size = new Size(100, 20);
      this.txtBuildingNumber.TabIndex = 0;
      this.txtUnitNumber.Location = new Point(144, 73);
      this.txtUnitNumber.Name = "txtUnitNumber";
      this.txtUnitNumber.Size = new Size(100, 20);
      this.txtUnitNumber.TabIndex = 1;
      this.btnCreateLabel.Location = new Point(144, 153);
      this.btnCreateLabel.Name = "btnCreateLabel";
      this.btnCreateLabel.Size = new Size(75, 23);
      this.btnCreateLabel.TabIndex = 2;
      this.btnCreateLabel.Text = "Print";
      this.btnCreateLabel.UseVisualStyleBackColor = true;
      this.btnCreateLabel.Click += new EventHandler(this.btnCreateLabel_Click);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(24, 38);
      this.label1.Name = "label1";
      this.label1.Size = new Size(87, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "Building Number:";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(24, 76);
      this.label2.Name = "label2";
      this.label2.Size = new Size(69, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "Unit Number:";
      this.btnFileImport.Location = new Point(27, 153);
      this.btnFileImport.Name = "btnFileImport";
      this.btnFileImport.Size = new Size(75, 23);
      this.btnFileImport.TabIndex = 5;
      this.btnFileImport.Text = "File Import";
      this.btnFileImport.UseVisualStyleBackColor = true;
      this.btnFileImport.Click += new EventHandler(this.btnFileImport_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(284, 201);
      this.Controls.Add((Control) this.btnFileImport);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.btnCreateLabel);
      this.Controls.Add((Control) this.txtUnitNumber);
      this.Controls.Add((Control) this.txtBuildingNumber);
      this.Name = "Form1";
      this.Text = "Label Printer";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
