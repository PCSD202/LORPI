using LORPI;
using Microsoft.Extensions.Configuration;

namespace LORPIClientTests;

public class Tests
{
    private LORPIClient Client;
    
    [SetUp]
    public void Setup()
    {
        IConfiguration configuration = new ConfigurationBuilder().AddUserSecrets<Tests>().AddEnvironmentVariables().Build();



        var authKey = configuration["UnitTestSettings:ApiKey"];
        if (authKey is null)
        {
            throw new InvalidOperationException("Mandatory environment variable or secret is not set: UnitTestSettings:ApiKey");
        }

        Client = new LORPIClient(authKey);

    }

    [TestCase("5LM5GW2", "LATITUDE 5300 2-IN-1", TestName = "Check that service tag 5LM5GW2 belongs to a LATITUDE 5300 2-IN-1")]
    [TestCase("7709ZY2", "LATITUDE 3190 2-IN-1", TestName = "Check that service tag 7709ZY2 belongs to a LATITUDE 3190 2-IN-1")]
    [TestCase("AAAAAA", null, TestName = "Check that service tag AAAAAA is invalid")]
    public void CheckWarrantyData(string serviceTag, string expectedModelName)
    {
        var data = Client.GetWarrantyInfo(serviceTag);
        Assert.That(data.ProductLineDescription, Is.EqualTo(expectedModelName));
    }
    
    [Test]
    public void CheckOverview()
    {
        var data = Client.GetSystemOverview();
        Assert.That(data, Is.Not.Empty);
    }
}