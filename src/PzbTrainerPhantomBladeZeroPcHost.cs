using System;
using System.IO;
using System.Threading;

namespace PzbTrainerPhantomBladeZeroPc
{
    public sealed class PzbTrainerPhantomBladeZeroPcHost : IDisposable
    {
        public const string BuildSalt = "7b23c3ab31ae266a";
        public const string TargetModule = "pzb-trainer-phantom-blade-zero-pc";
        private volatile bool _active = true;
        public void Initialize(string configPath)
        {
            if (!File.Exists(configPath))
                throw new FileNotFoundException("Configuration file missing.", configPath);
            Console.WriteLine($"[{TargetModule}] Loaded profile: {configPath} ({BuildSalt})");
        }
        public void Dispose() => _active = false;
        public static int Main(string[] args)
        {
            using var host = new PzbTrainerPhantomBladeZeroPcHost();
            if (args.Length > 0 && File.Exists(args[0])) host.Initialize(args[0]);
            return 0;
        }
    }
}
