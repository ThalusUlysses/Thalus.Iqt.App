using System;
using System.Collections.Generic;
using System.Linq;
using Thalus.Contracts;

namespace Thalus.Iqt.Core
{
    public class IqtIdentityCompare
    {
        public IResult CompareIdentities(IqtIdentityDTO[] expected, IqtIdentityDTO[] current)
        {
            IqtIdentityResultSetDTO set = new IqtIdentityResultSetDTO();

            CompareIdentities(expected, current, set);

            return GetResult(set);

        }

        public IResult CompareIdentity(IqtIdentityDTO expected, IqtIdentityDTO current)
        {
            IqtIdentityResultSetDTO set = new IqtIdentityResultSetDTO();           

            CompareIdentity(expected, current, set);

            return GetResult(set);

        }

        public IResult CompareIdentitySet(IqtIdentitySetDTO expected, IqtIdentitySetDTO current)
        {

            IqtIdentityResultSetDTO set = new IqtIdentityResultSetDTO();            

            CompareIdentities(expected.Identities, current.Identities, set);

            return GetResult(set);
        }

        private void CompareIdentities(IqtIdentityDTO[] expected, IqtIdentityDTO[] current, IqtIdentityResultSetDTO set)
        {
            List<IqtIdentityDTO> idents = new List<IqtIdentityDTO>(current);
            foreach (var item in expected)
            {
                var k = current.FirstOrDefault(i => i.FullName == item.FullName);

                if (k == null)
                {
                    set.ExpectedButNotThere.Add(new IqtIdentityResultDTO { Current = null, Expected = item, Text = "Identity was expected but was not found" });
                    continue;
                }

                idents.Remove(k);
                CompareIdentity(item, k, set);
            }

            foreach (var item in idents)
            {
                set.ThereButNotExpected.Add(new IqtIdentityResultDTO { Current = item, Expected = null, Text = "Identity was found but was not expected" });
            }
        }

        IResult GetResult(IqtIdentityResultSetDTO set)
        {
            int code = 0;
            if (CheckNotEqual(set))
            {
                code = 402;
            }

            return Result.Ok(code: code, data: set);
        }

        private bool CheckNotEqual(IqtIdentityResultSetDTO set)
        {
            return set.ExcludedButNotThere.Any() || set.ExpectedButNotThere.Any() || set.ThereButExcluded.Any() || set.ThereButNotExpected.Any() || set.ThereButWrongHash.Any();
        }

        private void CompareIdentity(IqtIdentityDTO expected, IqtIdentityDTO current, IqtIdentityResultSetDTO set)
        {
            if (expected.Excluded && !current.Excluded)
            {
                set.ThereButExcluded.Add(new IqtIdentityResultDTO { Current = current, Expected = expected, Text = "Identity was expected as excluded but was not marked excluded" });
            }

            if (!expected.Excluded && current.Excluded)
            {
                set.ExpectedButNotThere.Add(new IqtIdentityResultDTO { Current = current, Expected = expected, Text = "Identity was expected not excluded but was marked excluded" });
            }

            if (!expected.Hash.Equals(current.Hash, StringComparison.InvariantCulture))
            {
                set.ThereButWrongHash.Add(new IqtIdentityResultDTO { Current = current, Expected = expected, Text = "Identity found in both but hash is different." });
            }
        }
    }
}
