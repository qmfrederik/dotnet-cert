using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Xunit;

namespace dotnet_cert
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            Collection<Task> tasks = new Collection<Task>();

            for (int i = 1; i <= 100; i++)
            {
                tasks.Add(Test(i));
            }

            await Task.WhenAll(tasks);
        }

        private async Task Test(int i)
        {
            await Task.Yield();

            X509Certificate2 certificate = new X509Certificate2($"certificate_{i}.pfx", "secure");
            Assert.NotNull(certificate);

            var privateKey = certificate.GetRSAPrivateKey();
            Assert.NotNull(privateKey);
        }
    }
}
