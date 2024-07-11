using System.Drawing;
using Dar.CodeAnalysis.Binding;

namespace Dar.CodeAnalysis
{
    internal static class Program
    {
        // 1 + 2 * 3
        //   +
        //  / \
        // 1   *
        //    / \
        //   2   3
        private static void Main()
        {
            var repl = new DarRepl();
            repl.Run();  
        }
    }



}
