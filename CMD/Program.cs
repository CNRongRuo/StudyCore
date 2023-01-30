// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

using (Process pro = new Process())
{
    pro.StartInfo.FileName = @"C:\WINDOWS\system32\cmd.exe"; //设定程序名
    //pro.StartInfo.FileName = "cmd.exe"; //设定程序名
    pro.StartInfo.UseShellExecute = false; //关闭Shell的使用
    pro.StartInfo.RedirectStandardInput = true; //重定向标准输入
    pro.StartInfo.RedirectStandardOutput = true; //重定向标准输出
    pro.StartInfo.RedirectStandardError = true; //重定向错误输出
    pro.StartInfo.CreateNoWindow = false; // 设置不显示窗口
    pro.StartInfo.ErrorDialog = false;
    pro.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
    pro.Start();
    pro.StandardInput.WriteLine("adb shell am broadcast -a NotifyServiceStop");
    Thread.Sleep(3000);
    pro.StandardInput.WriteLine("adb forward tcp:12580 tcp:10086");
    Thread.Sleep(3000);
    pro.StandardInput.WriteLine("adb shell am broadcast -a NotifyServiceStart");
    Thread.Sleep(3000);


}