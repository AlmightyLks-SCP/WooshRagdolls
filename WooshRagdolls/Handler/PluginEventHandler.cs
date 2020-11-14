using MEC;
using Synapse.Api;
using Synapse.Api.Events.SynapseEventArguments;

namespace WooshRagdolls
{
    internal class PluginEventHandler
    {
        public PluginEventHandler()
        {
            Synapse.Api.Events.EventHandler.Get.Player.PlayerDeathEvent += Player_PlayerDeathEvent;
        }

        private void Player_PlayerDeathEvent(PlayerDeathEventArgs ev)
        {
            if (!WooshRagdolls.Config.NoRagdollSpawning)
                return;
            Timing.CallDelayed(0.01f, () =>
            {
                var ragdoll = Map.Get.Ragdolls[Map.Get.Ragdolls.Count - 1];
                ragdoll.Destroy();
            });
        }
    }
}