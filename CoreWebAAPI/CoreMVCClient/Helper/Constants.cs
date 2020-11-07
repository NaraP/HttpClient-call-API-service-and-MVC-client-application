using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCClient.Helper
{
    public class Constants
    {
        public static readonly string GetProjectsService = @"{0}/api/Project/GetProjectsData";

        public static readonly string PostProjectsService = @"{0}/api/Project/CreateProject";
    }
}
