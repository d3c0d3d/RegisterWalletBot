using System.Diagnostics;

//var _cliPath = @"D:\wallets\Dero\dero-wallet-cli-windows-amd64.exe";
var _cliPath = @"dero-wallet-cli-windows-amd64.exe";

bool _quit = false;
int _countLoop = 0;

string _walletPass = "pass";
string _walletName = "wt";
int _walletCount = 0;

while (!_quit)
{
    _countLoop++;
    
    if(_countLoop == 3) // controle
        _quit = true;

    StartCli(_cliPath);
}

void StartCli(string path)
{
    try
    {
        Process proc = new();
        proc.StartInfo.FileName = "cmd.exe";
        proc.StartInfo.Arguments = $"/c {path} --remote";
        proc.StartInfo.CreateNoWindow = false;
        proc.StartInfo.UseShellExecute = false;
        proc.Start();

        Thread.Sleep(3000);

        _walletCount++;
        SendCommand("2"); // Create Wallet

        SendCommand($"{_walletName}{_walletCount}"); // Wallet Name

        SendCommand(_walletPass); // Password

        SendCommand(_walletPass); // Password Confirm

        SendCommand("0"); // Language

        SendCommand("4"); // Register
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
}

void SendCommand(string msg)
{
    SendKeys.SendWait(msg);
    SendKeys.SendWait("{Enter}");
    Thread.Sleep(1000);
}