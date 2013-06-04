using System.IO;
using BusinessLogic;
using Domain;
using Moq;
using Xunit;

namespace CalculatorSolution.Test.Plugins
{
    public class PluginReaderTests
    {
        [Fact]
        public void PluginReader_FindsAllDLLFiles()
        {
            IPluginReader pluginReader = new OperationPluginReader();
            var pluginPath = System.Environment.CurrentDirectory + "\\" + "Plugins";

            var result = pluginReader.ReadPluginsFrom(pluginPath);

            Assert.Equal(1,result.Count);
        }

        [Fact]
        public void PluginReader_ThrowsDirectoryNotFoundException()
        {
            IPluginReader pluginReader = new OperationPluginReader();
            var pluginPath = System.Environment.CurrentDirectory + "\\" + "Pluguns";
            Assert.Throws<DirectoryNotFoundException>(() => pluginReader.ReadPluginsFrom(pluginPath));
        }

        [Fact]
        public void PluginReader_ReturnsValidOperation()
        {
            var moqOperation = new Mock<IOperation>();
            moqOperation.Setup(operation => operation.StringPresentation).Returns("+");
            IPluginReader pluginReader = new OperationPluginReader();
            var pluginPath = System.Environment.CurrentDirectory + "\\" + "Plugins";

            var operations = pluginReader.ReadPluginsFrom(pluginPath);

            Assert.Equal(moqOperation.Object.StringPresentation, operations[0].StringPresentation);
        }
       
    }
}