using System.Collections.Generic;
using CodeFramework;


namespace PoundSimulator.Context
{
    public class PoundProjectContext:ProjectContext
    {
        public override List<IService> Data { get; }
        public override List<IService> LoadContext()
        {
            return new List<IService>();
        }
    }
}