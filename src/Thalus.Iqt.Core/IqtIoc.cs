using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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

        protected override Dictionary<Type, Func<IPoorMansIoC, object>> Initialize()
        {
            return new Dictionary<Type, Func<IPoorMansIoC, object>>()
            {
                { typeof(HashAlgorithm),CreateHashAlgorithm },
                { typeof(IIqtIdentityCompare),CreateIqtIdentityCompare },
                { typeof(IIqtHashCreator),CreateHashCreator },
                { typeof(IIoAccess),CreateIoAccess },
                { typeof(IIqtIdentityFactory),CreateIqtIdentityFactory },
                { typeof(IIqtIdentityCreator),CreateIqtIdentityCreator }
            };
        }
        protected virtual HashAlgorithm CreateHashAlgorithm(IPoorMansIoC i)
        {
            return SHA1.Create();
        }


        protected virtual IIqtHashCreator CreateHashCreator(IPoorMansIoC i)
        {
            var hResult = i.Get<HashAlgorithm>();
            hResult.ThrowIfException();

            return new IqtHashCreator(hResult.ResultSet);
        }

        protected virtual IIoAccess CreateIoAccess(IPoorMansIoC i)
        {
            return new FileAccess();
        }

        protected virtual IIqtIdentityCompare CreateIqtIdentityCompare(IPoorMansIoC i)
        {
            return new IqtIdentityCompare();
        }

        protected virtual IIqtIdentityFactory CreateIqtIdentityFactory(IPoorMansIoC i)
        {
            var r = i.Get<IIqtHashCreator>();
            r.ThrowIfException();

            return new IqtIdentityFactory(r.ResultSet);
        }

        protected virtual IIqtIdentityCreator CreateIqtIdentityCreator(IPoorMansIoC i)
        {
            var rAccess = i.Get<IIoAccess>();
            rAccess.ThrowIfException();

            var rFactory = i.Get<IIqtIdentityFactory>();
            rFactory.ThrowIfException();

            return new IqtIdentityCreator(rAccess.ResultSet, rFactory.ResultSet);
        }
    }
}
