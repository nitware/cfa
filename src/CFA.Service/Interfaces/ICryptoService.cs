﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFA.Service.Interfaces
{
    public interface ICryptoService
    {
        string GenerateSalt();
        string EncryptPassword(string password, string salt);
    }


}
