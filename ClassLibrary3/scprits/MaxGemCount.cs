
using DewInternal;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Reflection;
using TriangleNet;
using UnityEngine;


[HarmonyPatch(typeof(HeroSkill), "GetMaxGemCount")]
public static class MaxGemCount
{
    static bool Prefix(HeroSkill __instance, ref int __result, HeroSkillLocation type)
    {
        __result = 4;
        return false;

    }

}
