namespace Tree2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = args[0];
            int depth = 3;
            if (args.Length > 1)
                depth = Convert.ToInt32(args[1]);
            string[] dirs = System.IO.Directory.GetDirectories(path);
            foreach (string dir in dirs)
            {

                string subdirectoryName = Path.GetFileName(dir);
                Console.WriteLine(subdirectoryName);
            }

        }
    }
}