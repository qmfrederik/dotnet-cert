using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Xunit;

namespace dotnet_cert
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test_Multiple_Certificates()
        {
            Collection<Task> tasks = new Collection<Task>();

            for (int i = 1; i <= 100; i++)
            {
                tasks.Add(Test(i));
            }

            await Task.WhenAll(tasks);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public async Task Test_Same_Certificate(int certificateId)
        {
            Collection<Task> tasks = new Collection<Task>();

            for (int i = 1; i <= 100; i++)
            {
                tasks.Add(Test(certificateId));
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
