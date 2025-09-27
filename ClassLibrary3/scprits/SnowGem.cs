
using DewInternal;
using HarmonyLib;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;
using TriangleNet;


[HarmonyPatch(typeof(Gem_R_Snow), "OnEquipGem")]
public static class SnowGem
{
    static void Postfix(Gem_R_Snow __instance)
    {
        SnowGemData SnowGemData = AddItemsPlugin.Instance.ConfigData.SnowGemData;

        __instance.rechargeTime = SnowGemData.RechargeTime;
        __instance.range = SnowGemData.Range;
        __instance.shootIntervalMax = SnowGemData.ShootIntervalMax;
        __instance.shootIntervalMin = SnowGemData.ShootIntervalMin;

    }
    
}
