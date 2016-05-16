// Decompiled with JetBrains decompiler
// Type: ZebraLabelPrint.Program
// Assembly: ZebraLabelPrint, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ED888763-08FF-4F95-B0CC-2EF83552D2E6
// Assembly location: X:\Apartment Apps, Inc\Label Printer\Label Printer\Label Printer\Label Printer Prog\ZebraLabelPrint.exe

using System;
using System.Windows.Forms;

namespace ZebraLabelPrint
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new Form1());
    }
  }
}
