using Synapse.Config;
using System.ComponentModel;

namespace WooshRagdolls
{
    public class PluginConfig : IConfigSection
    {
        [Description("Shall the Command display the execution speed?")]
        public bool MeasureExecutionSpeed = true;
    }
}