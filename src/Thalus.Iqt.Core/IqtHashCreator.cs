using System;
using System.Security.Cryptography;
using System.Text;
using Thalus.Iqt.Core.Contracts;

namespace Thalus.Iqt.Core
{
    public class IqtHashCreator : IIqtHashCreator
    {
        HashAlgorithm _alg;
        public IqtHashCreator(HashAlgorithm alg)
        {
            _alg = alg;
        }

        public string CreateHash(string qualifiedName)
        {
            var hash = _alg.ComputeHash(Encoding.UTF8.GetBytes(qualifiedName));
            return BitConverter.ToString(hash);
        }
    }
}
