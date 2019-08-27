using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Xunit;

namespace dotnet_cert
{
    public class UnitTestA
    {
        [Fact]
        public async Task Test_Multiple_Certificates()
        {
            Collection<Task> tasks = new Collection<Task>();

            for (int j = 0; j < 100; j++)
            {
                for (int i = 1; i <= 1000; i++)
                {
                    tasks.Add(UnitTest.Test(i, count: 1, accessCount: 50));
                }

                await Task.WhenAll(tasks);
            }
        }
    }

    internal static class UnitTest
    {
        public static async Task Test(int certificateId, int count = 1, int accessCount = 100)
        {
            await Task.Yield();

            for (int i = 0; i < count; i++)
            {
                byte[] data = File.ReadAllBytes($"certificate_{certificateId}.pfx");

                using (X509Certificate2 certificate = new X509Certificate2(data, "secure", X509KeyStorageFlags.Exportable | X509KeyStorageFlags.Exportable))
                using (var privateKey = certificate.GetRSAPrivateKey())
                {
                    certificate.Dispose();
                    GC.Collect();

                    for (int j = 0; j < accessCount; j++)
                    {
                        var parameters = privateKey.ExportParameters(includePrivateParameters: true);
                        var parameters2 = privateKey.ExportParameters(includePrivateParameters: true);

                        GC.Collect();

                        privateKey.Dispose();
                        var parameters3 = privateKey.ExportParameters(includePrivateParameters: true);

                        Assert.Equal(parameters.D, parameters2.D);
                        // Assert.Equal(parameters.D, parameters3.D);
                    }
                }
            }
        }
    }

    public class UnitTest1
    {
        [Fact]
        public Task Test_Same_Certificate()
        {
            return UnitTest.Test(1, 1000);
        }
    }

    public class UnitTest2
    {
        [Fact]
        public Task Test_Same_Certificate()
        {
            return UnitTest.Test(2, 1000);
        }
    }

    public class UnitTest3
    {
        [Fact]
        public Task Test_Same_Certificate()
        {
            return UnitTest.Test(3, 1000);
        }
    }

    public class UnitTest4
    {
        [Fact]
        public Task Test_Same_Certificate()
        {
            return UnitTest.Test(4, 1000);
        }
    }

    public class UnitTest5
    {
        [Fact]
        public Task Test_Same_Certificate()
        {
            return UnitTest.Test(5, 1000);
        }
    }

    public class UnitTest6
    {
        [Fact]
        public Task Test_Same_Certificate()
        {
            return UnitTest.Test(6, 1000);
        }
    }

    public class UnitTest7
    {
        [Fact]
        public Task Test_Same_Certificate()
        {
            return UnitTest.Test(7, 1000);
        }
    }

    public class UnitTest8
    {
        [Fact]
        public Task Test_Same_Certificate()
        {
            return UnitTest.Test(8, 1000);
        }
    }

    public class UnitTest9
    {
        [Fact]
        public Task Test_Same_Certificate()
        {
            return UnitTest.Test(9, 1000);
        }
    }
}
