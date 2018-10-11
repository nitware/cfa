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
    public abstract class EsnecilGeneratorBase
    {
        public string MachineCode { get; set; }

        //public abstract RawEsnecil GenerateLicense(string filePath, Dictionary<string, string> customerInfo);
        public abstract RawEsnecil GenerateLicense(Dictionary<string, string> customerInfo);
        protected abstract RawEsnecil GenerateLicenseHelper(Dictionary<string, string> customerInfo, CryptoLicenseGenerator generator);

        protected virtual void ValidateGenerator(string filePath)
        {
            if (File.Exists(filePath) == false)
            {
                throw new Exception("The selected .netlicproj file is invalid. Please select another file");
            }
        }

        protected virtual string SetCustomerInfo(Dictionary<string, string> customerInfo)
        {
            return string.Format("Email={0}#Phone={1}#Address={2}#CodeID={3}", customerInfo["Email"], customerInfo["Phone"], customerInfo["Address"], customerInfo["CodeID"]);
        }

        protected CryptoLicenseGenerator InitializeGenerator(string filePath)
        {
            CryptoLicenseGenerator generator = new CryptoLicenseGenerator(filePath);
            generator.SetLicenseCode("");
            return generator;
        }

        //protected virtual string[] GenerateLicenseHelper(CryptoLicenseGenerator generator)
        //{
        //    string licCode = generator.Generate();
        //    string serialCode = generator.SerialCodes[0];

        //    string[] codes = new string[2];
        //    codes[0] = serialCode;
        //    codes[1] = licCode;
        //    return codes;
        //}



    }
}
