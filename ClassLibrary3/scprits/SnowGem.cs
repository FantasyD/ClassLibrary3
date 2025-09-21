
using DewInternal;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Reflection;
using TriangleNet;


[HarmonyPatch(typeof(Gem_R_Snow), "OnEquipGem")]
public static class SnowGem
{
    static void Postfix(Gem_R_Snow __instance)
    {
        UnityEngine.Debug.Log($"AddItemsPlugin.Instance.ConfigData.SnowGemData.RechargeTime: {AddItemsPlugin.Instance.ConfigData.SnowGemData.RechargeTime} ");
        __instance.rechargeTime = AddItemsPlugin.Instance.ConfigData.SnowGemData.RechargeTime;
        __instance.range = AddItemsPlugin.Instance.ConfigData.SnowGemData.Range;
        __instance.shootIntervalMax = AddItemsPlugin.Instance.ConfigData.SnowGemData.ShootIntervalMax;
        __instance.shootIntervalMin = AddItemsPlugin.Instance.ConfigData.SnowGemData.ShootIntervalMin;
        
    }
    
}
