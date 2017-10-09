using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace StringReplacer
{
    static class Replacer
    {
        private static readonly ConcurrentBag<string> Log = new ConcurrentBag<string>();

        public static void Replace(DirectoryInfo directorySelected, string replaceStr, string newStr)
        {
            Task[] tasks = new Task[directorySelected.GetDirectories().Length];
            int i = 0;

            foreach (var dir in directorySelected.GetDirectories())
            {
                tasks[i++] = Task.Factory.StartNew(() => Replace(dir, replaceStr, newStr));
            }

            var filesToChange = directorySelected.GetFiles("*.*")
                .Where(s => s.Extension.Equals(".txt")
                         || s.Extension.Equals(".csv")
                         || s.Extension.Equals(".json")
                         || s.Extension.Equals(".cs"));

            foreach (FileInfo fileToChange in filesToChange)
            {
                var lines = File.ReadAllLines(fileToChange.FullName);
                fileToChange.Delete();

                using (StreamWriter sw = new StreamWriter(fileToChange.FullName, false, Encoding.Default))
                {
                    foreach (var line in lines)
                    {
                        if (line.Contains(replaceStr))
                        {
                            var newline = line.Replace(replaceStr, newStr);
                            Log.Add($"File:{fileToChange.FullName}, string:{line}, newString:{newline}");
                            sw.WriteLine(newline);
                        }
                        else
                        {
                            sw.WriteLine(line);
                        }
                    }
                }
            }
            Task.WaitAll(tasks);
        }

        public static void WriteLogToFile()
        {
            using (StreamWriter sw = new StreamWriter("log.txt", false, Encoding.Default))
            {
                foreach (var note in Log)
                {
                    sw.WriteLine(note);
                }
            }
        }
    }
}
