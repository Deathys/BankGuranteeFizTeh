using Renci.SshNet;
using System;
using System.Diagnostics;

namespace BcIntegration
{
    public class BcAccess
    {
        string userName = "deathys";
        string pass = "12345";
        //string hostUrl = "138.201.93.171";
        string hostUrl = "localhost";

        string acc1 = "0x325ceb662289517a27208cbd6ab26c85653d586d";
        string acc2 = "0x43237303da3e105f8182718df9b80fb71195cdee";

        string guaranteeAbiDef = "";
        string guaranteeByteCode = "";

        public string SendTransaction(string script)
        {
            try
            {
                using (var client = new SshClient(hostUrl, 22, userName, pass))
                {
                    client.Connect();

                    string filename = Guid.NewGuid().ToString().Substring(0, 5);

                    Func<string, string> toFile = (str) =>
                    {
                        return "echo '" + str.Replace("'", @"'\''") + "' >> ~/eth_data/" + filename;
                    };

                    Func<string, string> toFile2 = (str) =>
                    {
                        return "echo '" + str.Replace("'", @"'\''") + "' >> ~/eth_data/ex" + filename;
                    };

                    SshCommand comm = null;

                    var lines = script.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var line in lines)
                    {
                        comm = client.RunCommand(toFile(line));
                    }

                    comm = client.RunCommand($"geth --exec 'loadScript(\"/home/{userName}/eth_data/{filename}\")' attach ipc:chains/devtest/geth.ipc");

                    client.Disconnect();

                    return comm.Result;
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string SendEth()
        {
            string cmd = $@"personal.unlockAccount(""{acc1}"", '1', 0)";
            cmd = "eth.sendTransaction({from: \"" + acc1 +"\", to: \""+ acc2 + "\", gasPrice: '0x0000000000001', gasLimit: '0x00001', value: 1 })";
            return SendTransaction(cmd);
        }
    }
}
