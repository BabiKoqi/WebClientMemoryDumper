using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using GetEntryAssemblySpoofer;
using Harmony;
using Console = Colorful.Console;

namespace WebClientMemoryDumper {
    static class Program {
        static Assembly _asm;
        
        static void Main(string[] args) {
            Console.Title = Utils.RandomString();
            Console.WriteAscii("WebClientDumper", Color.SandyBrown);
            Console.WriteLine("Version: v1.0.0\nMade by: xsilent007\n", Color.Chocolate);

            if (args.Length < 1) {
                Logger.Warning("Usage: WebClientMemoryDumper.exe <path to assembly> [args to assembly]");
                Console.ReadLine();
                return;
            }

            _asm = TryLoadAssembly(args[0]);
            if (_asm == null) {
                Logger.Warning($"'{Path.GetFileName(args[0])}' doesn't exist or it isn't a .NET binary");
                Console.ReadLine();
                return;
            }
            
            Logger.Info($"Loaded '{_asm.ManifestModule.Name}'");

            Logger.Debug("Initializing Harmony...");
            var har = HarmonyInstance.Create("com.xsilent007.webclientdumper");

            Logger.Debug("Patching method...");
            har.PatchAll(typeof(Program).Assembly);

            Logger.Info("Spoofing Assembly.GetEntryAssembly()");
            Spoofer.Spoof(_asm);
            
            Logger.Info("Starting target...\n\n" + new string('=', 32) + "\n");
            RuntimeHelpers.RunModuleConstructor(_asm.ManifestModule.ModuleHandle); //Sometimes module.cctors won't run
            _asm.EntryPoint.Invoke(null, args.Skip(1).ToArray());

            Logger.Success("Done.");
            Console.ReadLine();
        }

        static Assembly TryLoadAssembly(string path) {
            try {
                return Assembly.LoadFile(Path.GetFullPath(path));
            }
            catch {
                return null;
            }
        }
    }
}