using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Domain;

namespace BusinessLogic
{
    public class OperationPluginReader:IPluginReader
    {
        public List<IOperation> ReadPluginsFrom(string directory)
        {
            var operations = new List<IOperation>();

            var plugins = GetPluginFiles(directory);
            foreach (var fileInfo in plugins)
            {
                var assembly = Assembly.LoadFrom(fileInfo.FullName);
                GetOperationsFromAssembly(assembly, operations);
            }
            return operations;
        }

        private void GetOperationsFromAssembly(Assembly assembly, List<IOperation> operations)
        {
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                if (typeof (IOperation).IsAssignableFrom(type))
                {
                    var operation = (IOperation) Activator.CreateInstance(type);
                    operations.Add(operation);
                }
            }
        }

        private IEnumerable<FileInfo> GetPluginFiles(string path)
        {
            var directory = new DirectoryInfo(path);
            if (!directory.Exists)
            {
                throw new DirectoryNotFoundException();
            }
            return directory.GetFiles("*.dll");
        }
    }
}