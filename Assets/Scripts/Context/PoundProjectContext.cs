using System.Collections.Generic;
using CodeFramework;
using ExportPackage.Runtime.Scripts.Core;

namespace PoundSimulator.Context
{
    public class PoundProjectContext:ProjectContext
    {
        public override List<IService> Data { get; }
        public override List<IService> LoadContext()
        {
            throw new System.NotImplementedException();
        }
    }
}