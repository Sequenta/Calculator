﻿using System.IO;
using BusinessLogic;
using Domain;
using Xunit;

namespace CalculatorSolution.Test.Plugins
{
    public class PluginReaderTests
    {
        [Fact]
        public void PluginReader_FindsAllOperationsInDLLFiles()
        {
            IPluginReader pluginReader = new OperationPluginReader();
            var pluginPath = System.Environment.CurrentDirectory + "\\" + "Plugins";

            var result = pluginReader.ReadPluginsFrom(pluginPath);

            Assert.Equal(4,result.Count);
        }

        [Fact]
        public void PluginReader_ThrowsDirectoryNotFoundException()
        {
            IPluginReader pluginReader = new OperationPluginReader();
            var pluginPath = System.Environment.CurrentDirectory + "\\" + "Pluguns";
            Assert.Throws<DirectoryNotFoundException>(() => pluginReader.ReadPluginsFrom(pluginPath));
        }
    }
}