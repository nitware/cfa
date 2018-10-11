using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Generator.Model;
using CFA.Domain.Entities;

namespace CFA.Service.Extentions
{
    public static class EsnecilExtensions
    {
        public static Esnecil ToEsnecil(this RawEsnecil rawEsnecil)
        {
            if (rawEsnecil == null)
                throw new ArgumentNullException("rawEsnecil cannot be null!");

            Esnecil esnecil = new Esnecil()
            {
                EsnecilCode = rawEsnecil.EsnecilCode,
                MachineKey = rawEsnecil.MachineKey,
                EnableTamperChecking = rawEsnecil.EnableTamperChecking,
                DetectDateRollback = rawEsnecil.DetectDateRollback,
                SerialCode = rawEsnecil.SerialCode,
                RawUserData = rawEsnecil.RawUserData,
                NoOfUsers = rawEsnecil.NoOfUsers,
                GeneratedOn = rawEsnecil.GeneratedOn,
            };

            return esnecil;
        }





    }
}
