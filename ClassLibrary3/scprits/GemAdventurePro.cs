using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

[HarmonyPatch(typeof(Gem_R_Adventure), "OnEquipGem")]
public class GemAdventurePro
{
    static void Postfix(Gem_R_Adventure __instance)
    {

        UnityEngine.Debug.Log($"======AdventureGemData: {__instance.goldAmount.ToString()}");
        UnityEngine.Debug.Log($"======AdventureGemData: {__instance.GetValue(__instance.goldAmount)}");

        AdventureGemData AdventureGemData = AddItemsPlugin.Instance.ConfigData.AdventureGemData;
        UnityEngine.Debug.Log($"AdventureGemData: {AdventureGemData.ToString()} ");

        float goldBaseValue = AdventureGemData.GoldBaseValue;
        float GoldAdFactor = AdventureGemData.GoldAdFactor;
        float GoldApFactor = AdventureGemData.GoldApFactor;
        float GoldLvlFactor = AdventureGemData.GoldLvlFactor;
        ScalingValue goldAmount = new ScalingValue(goldBaseValue, GoldAdFactor, GoldApFactor, GoldLvlFactor, LevelScaling.GemDefault);
        goldAmount.scalingMultiplier = AdventureGemData.GoldScalingMultiplier;
        __instance.goldAmount = goldAmount;

        UnityEngine.Debug.Log($"======AdventureGemData: {__instance.upgradeGemAmount.ToString()}");
        UnityEngine.Debug.Log($"======AdventureGemData: {__instance.GetValue(__instance.upgradeGemAmount)}");
        float upgradeGemBaseValue = AdventureGemData.UpgradeBaseValue;
        float UpgradeGemAdFactor = AdventureGemData.UpgradeAdFactor;
        float UpgradeGemApFactor = AdventureGemData.UpgradeApFactor;
        float UpgradeGemLvlFactor = AdventureGemData.UpgradeLvlFactor;
        ScalingValue upgradeGemAmount = new ScalingValue(upgradeGemBaseValue, UpgradeGemAdFactor, UpgradeGemApFactor, UpgradeGemLvlFactor, LevelScaling.GemDefault);
        upgradeGemAmount.scalingMultiplier = AdventureGemData.UpgradeScalingMultiplier;
        __instance.upgradeGemAmount = upgradeGemAmount;

    }
}
