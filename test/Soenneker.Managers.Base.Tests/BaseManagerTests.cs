using Soenneker.Tests.HostedUnit;

namespace Soenneker.Managers.Base.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class BaseManagerTests : HostedUnitTest
{
    public BaseManagerTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
