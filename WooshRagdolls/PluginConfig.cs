using Synapse.Config;
using System.ComponentModel;

namespace WooshRagdolls
{
    public class PluginConfig : AbstractConfigSection
    {
        [Description("Shall the Command display the execution speed?")]
        public bool MeasureExecutionSpeed { get; set; } = false;
        [Description("Toggle ragdoll spawning")]
        public bool NoRagdollSpawning { get; set; } = false;
    }
}