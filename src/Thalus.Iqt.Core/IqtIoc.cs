using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Thalus.Contracts;
using Thalus.Iqt.Core.Contracts;

namespace Thalus.Iqt.Core
{
    public class IqtIoc : PoorMansIoC
    {
        public IqtIoc(bool favorExceptionsOverResult) : base(favorExceptionsOverResult)
        {
        }

        public IqtIoc() : this(false)
        {
        }

        protected override Dictionary<Type, Func<object>> Initialize()
        {
            return new Dictionary<Type, Func<object>>()
            {
                { typeof(HashAlgorithm),CreateHashAlgorithm },
                { typeof(IIqtIdentityCompare),CreateIqtIdentityCompare },
                { typeof(IIqtHashCreator),CreateHashCreator },
                { typeof(IIoAccess),CreateIoAccess },
                { typeof(IIqtIdentityFactory),CreateIqtIdentityFactory },
                { typeof(IIqtIdentityCreator),CreateIqtIdentityCreator }
            };
        }
        public HashAlgorithm CreateHashAlgorithm()
        {
            return SHA1.Create();
        }


        public IIqtHashCreator CreateHashCreator()
        {
            var hResult = Get<HashAlgorithm>();
            hResult.ThrowIfException();

            return new IqtHashCreator(hResult.ResultSet);
        }

        public IIoAccess CreateIoAccess()
        {
            return new FileAccess();
        }

        public IIqtIdentityCompare CreateIqtIdentityCompare()
        {
            return new IqtIdentityCompare();
        }

        public IIqtIdentityFactory CreateIqtIdentityFactory()
        {
            var r = Get<IIqtHashCreator>();
            ThrowIfException<IIqtHashCreator>(r);

            return new IqtIdentityFactory(r.ResultSet);
        }

        public IIqtIdentityCreator CreateIqtIdentityCreator()
        {
            var rAccess = Get<IIoAccess>();
            rAccess.ThrowIfException();

            var rFactory = Get<IIqtIdentityFactory>();
            rFactory.ThrowIfException();

            return new IqtIdentityCreator(rAccess.ResultSet, rFactory.ResultSet);
        }       
    }
}
