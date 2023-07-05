using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree2
{
    public class DirInfo
    {
        public string Name;

        public int Depth;

        public string Description;

        public List<DirInfo> ChildDirs = new List<DirInfo>();
    }
}
