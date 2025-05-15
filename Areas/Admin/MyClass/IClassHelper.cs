using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kazanola.Areas.Admin.MyClass
{
    
    public interface IClassHelper
    {
        String SaveImage(IFormFile File, string folder);
        bool acc(bool g);
    }
}
