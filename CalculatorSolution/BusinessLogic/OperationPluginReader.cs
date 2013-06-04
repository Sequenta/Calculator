using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            operations.AddRange(from type 
                                in types 
                                where typeof (IOperation).IsAssignableFrom(type) 
                                select (IOperation) Activator.CreateInstance(type));
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