using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LogicNP.CryptoLicensing;
using System.IO;
using CFA.Generator.Model;
using CFA.Generator.Interfaces;

namespace CFA.Generator
{
    public class TrialEsnecilGenerator : EsnecilGeneratorBase
    {
        protected IEsnecilGeneratorResource _esnecilGeneratorFile;

        public TrialEsnecilGenerator(IEsnecilGeneratorResource esnecilGeneratorFile)
        {
            if (esnecilGeneratorFile == null)
            {
                throw new ArgumentNullException("esnecilGeneratorFile");
            }

            _esnecilGeneratorFile = esnecilGeneratorFile;
        }

        public override RawEsnecil GenerateLicense(Dictionary<string, string> customerInfo)
        {
            try
            {
                string filePath = _esnecilGeneratorFile.GetResource();
                ValidateGenerator(filePath);

                CryptoLicenseGenerator generator = base.InitializeGenerator(filePath); // Load license project file  
                RawEsnecil esnecil = GenerateLicenseHelper(customerInfo, generator);

                return esnecil;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override RawEsnecil GenerateLicenseHelper(Dictionary<string, string> customerInfo, CryptoLicenseGenerator generator)
        {
            string id = customerInfo["CodeID"];
            string userData = base.SetCustomerInfo(customerInfo);

            generator.SetCustomInfo(id, userData); // not working yet
            generator.NumberOfUsers = 1;
            generator.DetectDateRollback = true;
            generator.EnableTamperChecking = true;
            generator.MaxUsageDays = 30;

            string esnecilCode = generator.Generate();
            string serialCode = generator.SerialCodes[0];

            RawEsnecil esnecil = new RawEsnecil();
            esnecil.NoOfUsers = generator.NumberOfUsers;
            esnecil.DetectDateRollback = generator.DetectDateRollback;
            esnecil.EnableTamperChecking = generator.EnableTamperChecking;
            esnecil.RawUserData = userData;
            esnecil.SerialCode = serialCode;
            esnecil.MachineKey = MachineCode;
            esnecil.EsnecilCode = esnecilCode;
            esnecil.GeneratedOn = DateTime.UtcNow;

            return esnecil;
        }

        






    }
}
