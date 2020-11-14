using Synapse.Api.Plugin;

namespace WooshRagdolls
{
    [PluginInformation(
        Author = "AlmightyLks",
        Description = "Some simple utilities to manage ragdolls",
        Name = "WooshRagdolls",
        SynapseMajor = 2,
        SynapseMinor = 0,
        SynapsePatch = 0,
        Version = "1.0.0"
        )]
    public class WooshRagdolls : AbstractPlugin
    {
        [Config(section = "WooshRagdolls")]
        public static PluginConfig Config;
        public override void Load()
        {
            SynapseController.Server.Logger.Info("<WooshRagdolls> Loaded");

            _ = new PluginEventHandler();
        }
    }
}
