using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

[HarmonyPatch(typeof(Gem_R_Adventure), "OnEquipGem")]
public class GemAdventurePro
{
    static void Postfix(Gem_R_Adventure __instance)
    {
        __instance.upgradeGemAmount = __instance.goldAmount;

    }
}
