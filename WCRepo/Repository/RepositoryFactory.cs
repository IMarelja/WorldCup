﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCRepo.Repository
{
    public static class RepositoryFactory
    {
        public static IRepository GetRepository() => new JsonRepository();
    }
}
