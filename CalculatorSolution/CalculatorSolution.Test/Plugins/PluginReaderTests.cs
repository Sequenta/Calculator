using BusinessLogic;
using Domain;
using Xunit;

namespace CalculatorSolution.Test.Plugins
{
    public class PluginReaderTests
    {
        [Fact]
        public void PluginReader_FindsAllDLLFiles()
        {
            IPluginReader pluginReader = new OperationPluginReader();
            var pluginPath = System.Environment.CurrentDirectory;

            var result = pluginReader.ReadPluginsFrom(pluginPath);

            Assert.Equal(1,result.Count);
        }
    }
}