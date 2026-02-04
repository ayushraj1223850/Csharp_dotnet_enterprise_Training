using System;
using System.IO;

class FileReader
{
    static void Main()
    {
        string filePath = "data.txt";

        try
        {
            // 1 & 4. Read file content safely (resource auto-closed)
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                Console.WriteLine("File Content:");
                Console.WriteLine(content);
            }
        }
        catch (FileNotFoundException)
        {
            // 2. File not found
            Console.WriteLine("Error: File not found.");
        }
        catch (UnauthorizedAccessException)
        {
            // 3. Access denied
            Console.WriteLine("Error: Access to the file is denied.");
        }
        catch (Exception ex)
        {
            // Other unexpected errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
