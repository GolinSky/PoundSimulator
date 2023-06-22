using CodeFramework.Runtime.BaseServices;
using PoundSimulator.Services;

namespace PoundSimulator.Context
{
    public class PoundGameContext : GameContext
    {
        public override IEntryPoint GameService => new PoundGameService();
    }
}
