using System.Runtime.InteropServices;

namespace CentralImpressao.Data.Services
{
  public static class RawPrinterHelper
  {
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class DOCINFOA
    {
      [MarshalAs(UnmanagedType.LPStr)] public string pDocName;
      [MarshalAs(UnmanagedType.LPStr)] public string pOutputFile;
      [MarshalAs(UnmanagedType.LPStr)] public string pDataType;
    }
    [DllImport("winspool.drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    public static extern bool OpenPrinter(string szPrinter, out IntPtr hPrinter, IntPtr pd);

    [DllImport("winspool.drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    public static extern bool ClosePrinter(IntPtr hPrinter);

    [DllImport("winspool.drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    public static extern bool StartDocPrinter(IntPtr hPrinter, int level, [In] DOCINFOA di);

    [DllImport("winspool.drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    public static extern bool EndDocPrinter(IntPtr hPrinter);

    [DllImport("winspool.drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    public static extern bool StartPagePrinter(IntPtr hPrinter);

    [DllImport("winspool.drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    public static extern bool EndPagePrinter(IntPtr hPrinter);

    [DllImport("winspool.drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);

    public static bool SendStringToPrinter(string szPrinterName, string szString)
    {
      IntPtr pBytes;
      int dwCount = szString.Length;
      pBytes = Marshal.StringToCoTaskMemAnsi(szString);

      bool sucesso = SendBytesToPrinter(szPrinterName, pBytes, dwCount);

      Marshal.FreeCoTaskMem(pBytes);
      return sucesso;
    }
    private static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, int dwCount)
    {
      IntPtr hPrinter;
      var di = new DOCINFOA
      {
        pDocName = "Etiqueta CentralImpressao",
        pDataType = "RAW"
      };
      bool sucesso = OpenPrinter(szPrinterName, out hPrinter, IntPtr.Zero);
      if (!sucesso)
        return false;
      sucesso = StartDocPrinter(hPrinter, 1, di);
      if (sucesso)
      {
        sucesso = StartPagePrinter(hPrinter);
        if (sucesso)
        {
          sucesso = WritePrinter(hPrinter, pBytes, dwCount, out _);
          EndPagePrinter(hPrinter);
        }
        EndDocPrinter(hPrinter);
      }
      ClosePrinter(hPrinter);
      return sucesso;
    }
  }
}