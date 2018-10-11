using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using CFA.Generator.Model;
using LogicNP.CryptoLicensing;
using CFA.Generator.Interfaces;

namespace CFA.Generator
{
    public class SalesEsnecilGenerator : EsnecilGeneratorBase
    {
        protected IEsnecilGeneratorResource _esnecilGeneratorFile;

        public SalesEsnecilGenerator(IEsnecilGeneratorResource esnecilGeneratorFile)
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
                ValidateMachineCode();

                CryptoLicenseGenerator generator = InitializeGenerator(filePath); // Load license project file  
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
            string userData = SetCustomerInfo(customerInfo);
            
            //generator.UserData = customerInfo;
            generator.NumberOfUsers = 1;
            generator.SetCustomInfo(id, userData); // not working yet
            generator.MachineCodeAsString = MachineCode;
            generator.DetectDateRollback = true;
            generator.EnableTamperChecking = true;

            string licCode = generator.Generate();
            string serialCode = generator.SerialCodes[0];
            
            RawEsnecil esnecil = new RawEsnecil();
            esnecil.NoOfUsers = generator.NumberOfUsers;
            esnecil.DetectDateRollback = generator.DetectDateRollback;
            esnecil.EnableTamperChecking = generator.EnableTamperChecking;
            esnecil.RawUserData = userData;
            esnecil.SerialCode = serialCode;
            esnecil.MachineKey = MachineCode;
            esnecil.EsnecilCode = licCode;
            esnecil.GeneratedOn = DateTime.UtcNow;

            return esnecil;
        }

        private void ValidateMachineCode()
        {
            if (string.IsNullOrWhiteSpace(MachineCode))
            {
                throw new Exception("Machine Code not set! Please enter your machine code.");
            }
        }









    }
}
