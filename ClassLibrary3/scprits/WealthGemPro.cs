using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[HarmonyPatch(typeof(Gem_R_Wealth), "Callback")]
public static class WealthGemPro
{
    static bool Prefix(Gem_R_Wealth __instance, EventInfoKill obj)
    {
        UnityEngine.Debug.Log($"AddItemsPlugin.Instance.ConfigData.SnowGemData.RechargeTime: {AddItemsPlugin.Instance.ConfigData.SnowGemData.RechargeTime} ");

        if (!(obj.victim is Monster victim))
            return false;
        ++__instance.tempOwner.platinumCoin;
        Vector3 pos = victim.position;
        __instance.StartCoroutine(DropGoldRoutine());

        IEnumerator DropGoldRoutine()
        {
            int amount = DewMath.RandomRoundToInt(__instance.GetValue(__instance.killGold));
            int adjustedAmountPerDrop = __instance.amountPerDrop;
            if ((double)adjustedAmountPerDrop < (double)amount / 3.0)
                adjustedAmountPerDrop = Mathf.RoundToInt((float)amount / 3f);
            yield return (object)new UnityEngine.WaitForSeconds(__instance.initDelay);
            while (amount > 0 && !((UnityEngine.Object)__instance.owner == (UnityEngine.Object)null))
            {
                if (amount > adjustedAmountPerDrop)
                {
                    NetworkedManagerBase<PickupManager>.instance.DropGold(false, false, adjustedAmountPerDrop, pos);
                    NetworkedManagerBase<PickupManager>.instance.DropDreamDust(false, adjustedAmountPerDrop, pos);
                }
                else
                {
                    NetworkedManagerBase<PickupManager>.instance.DropGold(false, false, amount, pos);
                    NetworkedManagerBase<PickupManager>.instance.DropDreamDust(false, amount, pos);
                }
                amount -= adjustedAmountPerDrop;
                __instance.FxPlayNewNetworked(__instance.goldSpawnEffect, pos, new Quaternion?(Quaternion.identity));
                __instance.NotifyUse();
                yield return (object)new UnityEngine.WaitForSeconds(__instance.interval);
            }
        }
        return false;
    }
}
