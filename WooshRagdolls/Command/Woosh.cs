using Mirror;
using Synapse.Api;
using Synapse.Command;
using System.Collections.Generic;
using System.Diagnostics;

namespace WooshRagdolls.Command
{
    [CommandInformation(
        Name = "Woosh",
        Aliases = new string[] { "woosh" },
        Description = "Woosh all ragdolls off the map",
        Platforms = new Platform[] { Platform.RemoteAdmin },
        Usage = "Woosh"
        )]
    public class Woosh : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            var result = new CommandResult();
            Stopwatch watch = new Stopwatch();
            var num = Map.Get.Ragdolls.Count;

            watch.Start();

            foreach (var ragdoll in Map.Get.Ragdolls.ToArray())
                ragdoll.Destroy();

            watch.Stop();

            result.Message += $"Removed {num} ragdolls";

            if (WooshRagdolls.Config.MeasureExecutionSpeed)
                result.Message += $"\n{watch.Elapsed.TotalMilliseconds} ms";

            result.State = CommandResultState.Ok;

            return result;
        }
    }
}
