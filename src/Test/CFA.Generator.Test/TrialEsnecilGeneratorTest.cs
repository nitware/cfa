
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using CFA.Generator.Interfaces;
using CFA.Generator.Model;

namespace CFA.Generator.Test
{
    public class TrialEsnecilGeneratorTest
    {
        [Fact]
        public void GenerateLicense_Should_GenerateEsnecilSerialNoAndCode_WhenValidGeneratorFileAndCustomerInfoIsSet()
        {
           
            //Dictionary<string, string> customerInfo = new Dictionary<string, string>();
            //customerInfo.Add("Email", "akuabata.egenti@nitware.com.ng");
            //customerInfo.Add("Name", "Akuabata Egenti");
            //customerInfo.Add("Phone", "09087651122");
            //customerInfo.Add("Address", "99 Opebi road, Ikeja Lagos");
            //customerInfo.Add("CodeID", "109930");

            Dictionary<string, string> customerInfo = new Dictionary<string, string>
            {
                { "Email", "akuabata.egenti@nitware.com.ng" },
                { "Name", "Akuabata Egenti" },
                { "Phone", "09087651122" },
                { "Address", "99 Opebi road, Ikeja Lagos" },
                { "CodeID", "109930" }
            };

            //var discountsDictionary = new Dictionary<AccountStatus, IAccountDiscountCalculator>
            //  {
            //    {AccountStatus.NotRegistered, new NotRegisteredDiscountCalculator()},
            //    {AccountStatus.SimpleCustomer, new SimpleCustomerDiscountCalculator()},
            //    {AccountStatus.ValuableCustomer, new ValuableCustomerDiscountCalculator()},
            //    {AccountStatus.MostValuableCustomer, new MostValuableCustomerDiscountCalculator()}
            //};

            IEsnecilGeneratorResource esnecilGeneratorFile = new EsnecilGeneratorFile();
            IEsnecilGeneratorFactory generatorFactory = new EsnecilGeneratorFactory(esnecilGeneratorFile);
            EsnecilGeneratorBase generator = generatorFactory.Create(EsnecilType.Trial);
            RawEsnecil esnecil = generator.GenerateLicense(customerInfo);
            //RawEsnecil esnecil = generator.GenerateLicense(filePath, customerInfo);

            Assert.NotNull(esnecil);
            Assert.NotNull(esnecil.SerialCode);
            Assert.NotNull(esnecil.EsnecilCode);
            Assert.True(esnecil.GeneratedOn.Date == DateTime.Today.Date);
            Assert.True(esnecil.SerialCode.Length > 5);
            Assert.True(esnecil.EsnecilCode.Length > 5);
            Assert.True(esnecil.DetectDateRollback);
            Assert.True(esnecil.EnableTamperChecking);
            Assert.Equal(1, esnecil.NoOfUsers);
        }




    }
}
