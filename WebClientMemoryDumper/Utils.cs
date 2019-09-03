using System;
using System.Linq;

namespace WebClientMemoryDumper {
    static class Utils {
        static readonly Random _random = new Random();
        const string _abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789<>#&@{}$()[]!+~/%";
        
        internal static string RandomString() =>
            new string(Enumerable.Repeat(_abc, 64).Select(s => s[_random.Next(_abc.Length)]).ToArray());
    }
}