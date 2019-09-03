using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using Harmony;
using Console = Colorful.Console;

namespace WebClientMemoryDumper {
    [HarmonyPatch(typeof(WebClient))]
    [HarmonyPatch("GetUri")]
    [HarmonyPatch(new [] { typeof(Uri) })]
    static class UriPatch {
        static readonly HashSet<Uri> _urls = new HashSet<Uri>();

        internal static void Postfix(Uri address) {
            if (_urls.Contains(address))
                return;

            Console.Write("[", Color.White);
            Console.Write("+", Color.Lime);
            Console.Write("] ", Color.White);
            Console.WriteLine($"{address}", Color.DarkGray);
            _urls.Add(address);
        }
    }
}