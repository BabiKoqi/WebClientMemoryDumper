using System;
using System.Collections.Generic;
using System.Drawing;
using Harmony;
using Console = Colorful.Console;

namespace WebClientMemoryDumper {
    [HarmonyPatch(typeof(Uri))]
    [HarmonyPatch("CreateThis")]
    [HarmonyPatch(new [] { typeof(string), typeof(bool), typeof(UriKind) })]
    class Patch {
        static readonly HashSet<string> _urls = new HashSet<string>();
        
        static void Postfix(string uri, bool dontEscape, UriKind uriKind) {
            if (_urls.Contains(uri))
                return;

            _urls.Add(uri);
            
            Console.Write("[", Color.White);
            Console.Write("+", Color.Lime);
            Console.Write("] ", Color.White);
            Console.WriteLine(uri, Color.DarkGray);
        }
    }
}