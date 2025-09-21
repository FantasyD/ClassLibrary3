
using DewInternal;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Reflection;
using TriangleNet;


[HarmonyPatch(typeof(Se_Star_I_DreamDustOnKillChance), "ClientHeroEventOnKillOrAssist")]
public static class DatabasePatch
{
    static void Prefix(Se_Star_I_DreamDustOnKillChance __instance)
    {
        __instance.gainedAmount = AddItemsPlugin.Instance.ConfigData.DreamDustOnKillChanceData.GainedAmount;
    }
    static void Postfix(Se_Star_I_DreamDustOnKillChance __instance)
    {
        UnityEngine.Debug.Log($"(double)__instance.GetValue(__instance.gainChance): {(double)__instance.GetValue(__instance.gainChance)} ");
        if ((double)UnityEngine.Random.value > AddItemsPlugin.Instance.ConfigData.DreamDustOnKillChanceData.Chance)
            return;
        ++__instance.victim.owner.platinumCoin;
        UnityEngine.Debug.Log($"__instance.victim.owner.platinumCoin: {__instance.victim.owner.platinumCoin} ");
        //foreach (var prop in __instance.owner.GetType().GetProperties(
        //             BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
        //{
        //    try
        //    {
        //        var value = prop.GetValue(__instance);
        //        UnityEngine.Debug.Log($"[Property] {prop.Name} : {prop.PropertyType.Name} = {FormatValue(value)}");
        //    }
        //    catch
        //    {
        //        UnityEngine.Debug.Log($"Could not read property {prop.Name}");
        //    }
        //}

        //// 如果你还想打印字段：
        //foreach (var field in __instance.owner.GetType().GetFields(
        //             BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
        //{
        //    try
        //    {
        //        var value = field.GetValue(__instance);
        //        UnityEngine.Debug.Log($"[Field] {field.Name} : {field.FieldType.Name} = {FormatValue(value)}");
        //    }
        //    catch
        //    {
        //        UnityEngine.Debug.Log($"Could not read field {field.Name}");
        //    }
        //}
        //++__instance.tempOwner.platinumCoin;


        //// 假设游戏原本有个道具叫 "Gem"
        //// 你写了一个继承类 MyBetterGem : Gem
        //var typeName = "Gem_R_Wealth"; // 原类的名字
        //var newTypeName = "Gem_R_Wealth_Mine"; // 原类的名字
        //var guid = __instance.typeNameToGuid[typeName];
        //System.Type type = System.Type.GetType(newTypeName);
        //// 替换为你的新类
        //__instance.typeToGuid[type] = guid;
        //__instance.guidToType[guid] = type;
        //__instance.typeNameToType[typeName] = type;

        //UnityEngine.Debug.Log($"[Mod] 替换道具 {typeName} 为 {nameof(Gem_R_Wealth_Mine)} 成功！");

        //UnityEngine.Debug.Log("=== DumpItems 插件已加载 ===");

        //// 尝试获取数据库

        //UnityEngine.Debug.Log($"数据库已加载，道具数量: {__instance.typeNameToGuid.Count}");

        //foreach (var kvp in __instance.typeNameToGuid)
        //{
        //    string key = kvp.Key;   // 类名，例如 "Gem"
        //    string value = kvp.Value;     // 唯一标识符
        //    if (key.Equals(typeName))
        //    {
        //        UnityEngine.Debug.Log("==============================");
        //    }

        //    UnityEngine.Debug.Log($"道具: {key}  →  GUID: {value}");
        //}

        //UnityEngine.Debug.Log("=== DumpItems 完成 ===");
    }
    private static string FormatValue(object value)
    {
        if (value == null) return "null";

        // 特殊处理 Unity 对象，避免 ToString() 引发 Unity 内部调用
        if (value is UnityEngine.Object unityObj)
            return $"{unityObj.GetType().Name}(name={unityObj.name})";

        return value.ToString();
    }
}
