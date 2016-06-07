namespace DefineClassesAndStructs
{
    using System.IO;

    public static class PathStorage
    {
        public static bool SavePath(Path pointsPath, string fileName)
        {
            var fileContent = pointsPath.ToString();
            var filePath = string.Format(@"./Paths/{0}.txt", fileName);
            FileInfo file = new FileInfo(filePath);
            file.Directory.Create();
            var writer = new StreamWriter(filePath, false);

            try
            {
                using (writer)
                {
                    writer.WriteLine(fileContent);
                    return true;
                }
            }

            catch (IOException)
            {
                return false;
            }

            finally
            {
                writer.Close();
            }
        }

        public static Path LoadPath(string fileName)
        {
            string filePath;
            if (fileName.Contains(".txt"))
            {
                filePath = string.Format(@"./Paths/{0}", fileName);
            }

            else
            {
                filePath = string.Format(@"./Paths/{0}.txt", fileName);
            }

            try
            {
                var reader = new StreamReader(filePath);
                using (reader)
                {
                    var readedPath = Path.Parse(reader.ReadLine());
                    return readedPath;
                }
            }
            catch (IOException)
            {
                return new Path();
            }
        }
    }
}
