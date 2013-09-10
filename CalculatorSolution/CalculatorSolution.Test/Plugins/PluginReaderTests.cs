using System.IO;
using BusinessLogic;
using Domain;
using Xunit;

namespace CalculatorSolution.Test.Plugins
{
    public class PluginReaderTests
    {
        private readonly IPluginReader pluginReader;
        private readonly string pluginPath;
        public PluginReaderTests()
        {
            pluginReader = new OperationPluginReader();
            pluginPath = System.Environment.CurrentDirectory + "\\" + "Plugins";
        }

        [Fact]
        public void PluginReader_FindsAllOperationsInDLLFiles()
        {
            var result = pluginReader.ReadPluginsFrom(pluginPath);
            Assert.Equal(4,result.Count);
        }

        [Fact]
        public void PluginReader_ThrowsDirectoryNotFoundException()
        {
            Assert.Throws<DirectoryNotFoundException>(() => pluginReader.ReadPluginsFrom(pluginPath));
        }
    }
}