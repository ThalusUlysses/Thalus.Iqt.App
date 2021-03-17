
using System.Collections.Generic;

namespace Thalus.Iqt.Core.Contracts
{
    public interface IIqtIdentityResultSet
    {
        IEnumerable<IIqtIdentityResult> ExcludedButNotThere { get;  }
        IEnumerable<IIqtIdentityResult> ExpectedButNotThere { get;  }
        IEnumerable<IIqtIdentityResult> ThereButExcluded { get;  }
        IEnumerable<IIqtIdentityResult> ThereButNotExpected { get;  }
        IEnumerable<IIqtIdentityResult> ThereButWrongHash { get;  }

        void AddExcludedButNotThere(IIqtIdentityResult dto);
        void AddExpectedButNotThere(IIqtIdentityResult dto);
        void AddThereButExcluded(IIqtIdentityResult dto);
        void AddThereButNotExpected(IIqtIdentityResult dto);
        void AddThereButWrongHash(IIqtIdentityResult dto);
    }
}