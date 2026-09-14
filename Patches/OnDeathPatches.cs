using HarmonyLib;
using static Skills;
using System.Collections.Generic;
using Logging;

namespace FortifySkillsReborn.Patches;

/// <summary>
///     Applies the fortified skill levels when the player dies.
/// </summary>
[HarmonyPatch(typeof(Player))]
internal static class OnDeathPatches
{
    /// <summary>
    ///     Clears the DeathSkillsReset global key so the game takes its normal
    ///     percentage penalty instead of wiping every skill. Without this, a
    ///     HardCore preset would empty m_skillData and there would be nothing
    ///     left for the fortified levels to restore. The ordinary death penalty
    ///     is left alone and handled in the finalizer below.
    /// </summary>
    /// <param name="__instance"></param>
    [HarmonyPrefix]
    [HarmonyPriority(Priority.Last)]
    [HarmonyPatch(nameof(Player.OnDeath))]
    private static void OnDeath()
    {
        if (ZoneSystem.instance.GetGlobalKey(GlobalKeys.DeathSkillsReset))
        {
            ZoneSystem.instance.m_globalKeysEnums.Remove(GlobalKeys.DeathSkillsReset);
        }
    }

    [HarmonyFinalizer]
    [HarmonyPriority(Priority.VeryLow)]
    [HarmonyPatch(nameof(Player.OnDeath))]
    private static void OnDeathFinalizer(Player __instance)
    {
        Log.LogInfo("Finalizing skills on death", Log.InfoLevel.Medium);
        if (!__instance || !__instance.m_skills)
        {
            return;
        }

        // This runs as a finalizer, so the game has already applied its own
        // skill penalty by now: Player.OnDeath calls Skills.OnDeath, which
        // lowers every skill by m_DeathLowerFactor * Game.m_skillReductionRate
        // (5% by default), and only on a hard death.
        bool resetToFortify = FortifySkillsReborn.Instance.SkillLossOnDeath.Value == SkillLossMode.ResetToFortify;

        Skills skills = __instance.m_skills;
        foreach (KeyValuePair<SkillType, Skill> pair in skills.m_skillData)
        {
            if (!FortifySkillData.s_FortifySkills.TryGetValue(pair.Key, out FortifySkillData fortify))
            {
                continue;
            }

            if (resetToFortify)
            {
                // Discard whatever the game worked out and drop straight to the
                // fortified level, even when that costs more than the penalty.
                Log.LogInfo($"Setting {fortify.SkillName} to fortify level: {fortify.FortifyLevel}", Log.InfoLevel.Medium);

                pair.Value.m_level = fortify.FortifyLevel;
                pair.Value.m_accumulator = 0f;
            }
            else if (pair.Value.m_level < fortify.FortifyLevel)
            {
                // Keep the game's penalty and use the fortified level purely as
                // a floor. A soft death costs nothing, matching the base game.
                Log.LogInfo($"Raising {fortify.SkillName} to fortify floor: {fortify.FortifyLevel}", Log.InfoLevel.Medium);

                pair.Value.m_level = fortify.FortifyLevel;
                pair.Value.m_accumulator = 0f;
            }
        }
    }
}
