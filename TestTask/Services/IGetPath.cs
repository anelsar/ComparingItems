﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Services
{
    public interface IGetPath
    {
        string GetPath(string rootDirectory, string fileName);
    }
}
