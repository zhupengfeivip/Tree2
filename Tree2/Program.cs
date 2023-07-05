using System.Diagnostics;
using System.Runtime;

namespace Tree2
{
    internal class Program
    {
        /// <summary>
        /// 
        /// </summary>
        private static int maxDepth = 3;

        /// <summary>
        /// 
        /// </summary>
        private static string path;

        /// <summary>
        /// 
        /// </summary>
        private static List<string> ignoreName = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            path = args[0];
            if (args.Length > 1)
                maxDepth = Convert.ToInt32(args[1]);

            int outType = 2;
            if (args.Length > 2)
                outType = Convert.ToInt32(args[2]);

            ReadTreeIgnore();

            DirInfo root = new DirInfo();
            root.Depth = 0;
            root.Name = Path.GetFileName(path);

            string[] dirs = System.IO.Directory.GetDirectories(path);
            List<DirInfo> list = new List<DirInfo>();
            GetDir(path, ref root);

            if (outType == 1)
            {
                PrintToTree(root);
            }
            else if (outType == 2)
            {
                Console.WriteLine("|Name              | Description       |");
                Console.WriteLine("|------------------|-------------------|");
                PrintToMdTalbe(root);
            }
            else
            {
                Console.WriteLine("未知输出类型：" + outType);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// 
        /// </summary>
        static void PrintToTree(DirInfo root)
        {
            var space = "|_______________________________"[..(root.Depth * 2 + 1)];

            Console.WriteLine(space + root.Name);
            foreach (var dir in root.ChildDirs)
            {
                PrintToTree(dir);
            }
        }

        static void PrintToMdTalbe(DirInfo root)
        {
            var space = "_______________________________"[..(root.Depth * 2)];
            
            Console.WriteLine($"|{space + root.Name}              |{root.Description}       |");
            foreach (var dir in root.ChildDirs)
            {
                PrintToMdTalbe(dir);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="root"></param>
        static void GetDir(string path, ref DirInfo root)
        {
            if (root.Depth >= maxDepth) return;

            var dirs = System.IO.Directory.GetDirectories(path);
            if (dirs.Length <= 0) return;

            foreach (var dir in dirs)
            {
                DirInfo dirInfo = new DirInfo();
                var subDirName = Path.GetFileName(dir);
                if (ignoreName.Contains(subDirName)) continue;

                dirInfo.Depth = root.Depth + 1;
                dirInfo.Name = subDirName;
                dirInfo.Description = ReadTreeAttr(dir);
                GetDir(dir, ref dirInfo);
                root.ChildDirs.Add(dirInfo);


            }
        }

        /// <summary>
        /// 
        /// </summary>
        static void ReadTreeIgnore()
        {
            try
            {
                // 指定要读取的文本文件路径
                string filePath = path + "//.treeignore";
                if (File.Exists(filePath) == false) return;

                // 创建StreamReader对象并打开文件
                using StreamReader sr = new StreamReader(filePath);
                // 逐行读取文件内容并打印到控制台
                while (sr.ReadLine() is { } line)
                {
                    // 不包含注释
                    if (line.StartsWith("#")) continue;
                    if (line.Trim().Length == 0) continue;

                    ignoreName.Add(line);

                    Trace.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("读取文件时出现错误：" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static string ReadTreeAttr(string path)
        {
            try
            {
                // 指定要读取的文本文件路径
                string filePath = path + "//.treeattributes";
                if (File.Exists(filePath) == false) return "";

                List<string> allLine = new List<string>();

                // 创建StreamReader对象并打开文件
                using StreamReader sr = new StreamReader(filePath);
                // 逐行读取文件内容并打印到控制台
                while (sr.ReadLine() is { } line)
                {
                    // 不包含注释
                    if (line.StartsWith("#")) continue;
                    if (line.Trim().Length == 0) continue;

                    allLine.Add(line);

                    Trace.WriteLine(line);
                }

                if(allLine.Count < 2) return "";

                return allLine[1];
            }
            catch (Exception ex)
            {
                Console.WriteLine("读取文件时出现错误：" + ex.Message);
                return "";
            }
        }


    }
}