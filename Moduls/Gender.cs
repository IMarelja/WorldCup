﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public enum Gender
    {
        //Remove descriptions

        [Description("Male")]
        men,

        [Description("Female")]
        women
    }
}
