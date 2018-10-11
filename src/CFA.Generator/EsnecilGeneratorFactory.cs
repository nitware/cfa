using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Generator.Interfaces;

namespace CFA.Generator
{
    public class EsnecilGeneratorFactory : IEsnecilGeneratorFactory
    {

        private IEsnecilGeneratorResource _esnecilGeneratorResource;

        public EsnecilGeneratorFactory(IEsnecilGeneratorResource esnecilGeneratorFile)
        {
            if (esnecilGeneratorFile == null)
            {
                throw new ArgumentNullException("esnecilGeneratorFile");
            }

            _esnecilGeneratorResource = esnecilGeneratorFile;
        }

        public EsnecilGeneratorBase Create(EsnecilType type)
        {
            EsnecilGeneratorBase generator;

            switch (type)
            {
                case EsnecilType.Trial:
                    {
                        generator = new TrialEsnecilGenerator(_esnecilGeneratorResource);
                        break;
                    }
                case EsnecilType.Sales:
                    {
                        generator = new SalesEsnecilGenerator(_esnecilGeneratorResource);
                        break;
                    }
                default:
                    {
                        throw new NotImplementedException("Esnecil type specified has not been implemented!");
                    }
            }

            return generator;

        }



    }
}
