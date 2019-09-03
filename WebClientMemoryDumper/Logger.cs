using System.Drawing;
using Colorful;

namespace WebClientMemoryDumper {
    static class Logger {
        static Logger() {
            _sheet = new StyleSheet(Color.White);
            _sheet.AddStyle("(?<=\\[)\\-(?=\\])", Color.DarkGray);
            _sheet.AddStyle("(?<=\\[)\\*(?=\\])", Color.Cyan);
            _sheet.AddStyle("(?<=\\[)\\!(?=\\])", Color.Orange);
            _sheet.AddStyle("(?<=\\[)\\#(?=\\])", Color.Red);
            _sheet.AddStyle("(?<=\\[)\\+(?=\\])", Color.Lime);
            _sheet.AddStyle("(?<=^....)(.*)", Color.LightGray);
        }

        static readonly StyleSheet _sheet;

        static void Log(string message) => Console.WriteLineStyled(message, _sheet);

        internal static void Debug(string message) =>
            Log($"[-] {message}");

        internal static void Info(string message) =>
            Log($"[*] {message}");

        internal static void Warning(string message) =>
            Log($"[!] {message}");

        internal static void Error(string message) =>
            Log($"[#] {message}");

        internal static void Success(string message) =>
            Log($"[+] {message}");
    }
}