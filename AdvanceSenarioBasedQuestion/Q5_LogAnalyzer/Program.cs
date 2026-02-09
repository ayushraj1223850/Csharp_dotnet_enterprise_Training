using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace LargeFileLogAnalyzer
{
    internal static class Program
    {
        private static void Main()
        {
            string logFilePath = "large-log.txt"; // Replace with real log path
            int topN = 5;

            IEnumerable<ErrorSummary> topErrors =
                GetTopErrors(logFilePath, topN);

            Console.WriteLine("\n🔥 Top Errors:");
            foreach (ErrorSummary error in topErrors)
            {
                Console.WriteLine($"{error.Code} → {error.Count}");
            }
        }

        // ===================== CORE LOGIC =====================

        public static IEnumerable<ErrorSummary> GetTopErrors(
            string filePath,
            int topN)
        {
            // Dictionary to count occurrences of each error code
            Dictionary<string, int> errorCounts = new Dictionary<string, int>();

            // Regex to extract error patterns like ERR123
            Regex errorPattern = new Regex(@"ERR\d+",
                RegexOptions.Compiled);

            // File.ReadLines streams the file line by line (memory safe)
            foreach (string line in File.ReadLines(filePath))
            {
                MatchCollection matches = errorPattern.Matches(line);

                foreach (Match match in matches)
                {
                    string errorCode = match.Value;

                    if (errorCounts.ContainsKey(errorCode))
                    {
                        errorCounts[errorCode]++;
                    }
                    else
                    {
                        errorCounts[errorCode] = 1;
                    }
                }
            }

            // Return top N errors by frequency
            return errorCounts
                .OrderByDescending(e => e.Value)
                .Take(topN)
                .Select(e => new ErrorSummary(e.Key, e.Value))
                .ToList();
        }
    }

    // ===================== MODEL =====================

    internal sealed class ErrorSummary
    {
        public string Code { get; }
        public int Count { get; }

        public ErrorSummary(string code, int count)
        {
            Code = code;
            Count = count;
        }
    }
}
