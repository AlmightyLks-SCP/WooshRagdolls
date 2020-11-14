using Synapse.Api;
using Synapse.Command;
using System.Diagnostics;

namespace WooshRagdolls.Command
{
    [CommandInformation(
        Name = "Woosh",
        Description = "Woosh either all or the last X amount of ragdolls off the map",
        Permission = "WooshRagdolls.woosh",
        Platforms = new Platform[] { Platform.RemoteAdmin },
        Usage = "\"Woosh\" or \"Woosh [Amount]\""
        )]
    public class Woosh : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            var result = new CommandResult();
            Stopwatch watch = new Stopwatch();
            var amountRagdolls = Map.Get.Ragdolls.Count;

            if (amountRagdolls == 0)
            {
                result.Message = "No Ragdolls.";
                result.State = CommandResultState.Error;
                return result;
            }

            if (context.Arguments.Array.Length == 1)
            {
                watch.Start();

                foreach (var ragdoll in Map.Get.Ragdolls.ToArray())
                    ragdoll.Destroy();

                watch.Stop();

                result.Message += $"Removed {amountRagdolls} ragdolls";

                if (WooshRagdolls.Config.MeasureExecutionSpeed)
                    result.Message += $"\n{watch.Elapsed.TotalMilliseconds} ms";

                result.State = CommandResultState.Ok;
            }
            else if (context.Arguments.Array.Length == 2 && int.TryParse(context.Arguments.Array[1], out int delAmount))
            {
                watch.Start();

                if (delAmount > amountRagdolls)
                    delAmount = amountRagdolls;

                var ragdolls = Map.Get.Ragdolls.ToArray();


                for (int i = ragdolls.Length - 1; i > (ragdolls.Length - delAmount) - 1; i--)
                    ragdolls[i].Destroy();

                watch.Stop();

                result.Message += $"Removed {delAmount} ragdolls";

                if (WooshRagdolls.Config.MeasureExecutionSpeed)
                    result.Message += $"\n{watch.Elapsed.TotalMilliseconds} ms";

                result.State = CommandResultState.Ok;
            }
            else
            {
                result.Message = "Wrong usage.";
                result.State = CommandResultState.Error;
            }

            return result;
        }
    }
}
