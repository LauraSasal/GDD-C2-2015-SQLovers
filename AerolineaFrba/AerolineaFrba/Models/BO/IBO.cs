﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace AerolineaFrba.Models.BO{
    public interface IBO<T> where T: new() {

        T setData(DataRow dr);

    }
}