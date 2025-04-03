using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Managers.Base.Tests;

[Collection("Collection")]
public class BaseManagerTests : FixturedUnitTest
{
    public BaseManagerTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }
}
