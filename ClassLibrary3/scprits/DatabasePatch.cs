using HarmonyLib;

[HarmonyPatch(typeof(Se_Star_I_DreamDustOnKillChance), "ClientHeroEventOnKillOrAssist")]
public static class DatabasePatch
{
    static void Prefix(Se_Star_I_DreamDustOnKillChance __instance)
    {
        UnityEngine.Debug.Log($"======AdventureGemData: {AddItemsPlugin.Instance.ConfigData} ");
        UnityEngine.Debug.Log($"=======AdventureGemData: {AddItemsPlugin.Instance.ConfigData.ToString()} ");
        DreamDustOnKillChanceData DreamDustData = AddItemsPlugin.Instance.ConfigData.DreamDustOnKillChanceData;
        __instance.gainedAmount = DreamDustData.GainedAmount;
    }
    static void Postfix(Se_Star_I_DreamDustOnKillChance __instance)
    {
        UnityEngine.Debug.Log($"(double)__instance.GetValue(__instance.gainChance): {(double)__instance.GetValue(__instance.gainChance)} ");
        DreamDustOnKillChanceData DreamDustData = AddItemsPlugin.Instance.ConfigData.DreamDustOnKillChanceData;
        double chance = DreamDustData.Chance;
        if ((double)UnityEngine.Random.value > chance)
            return;
        ++__instance.victim.owner.platinumCoin;
        UnityEngine.Debug.Log($"__instance.victim.owner.platinumCoin: {__instance.victim.owner.platinumCoin} ");
        
    }
}
