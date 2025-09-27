
//using DewInternal;
//using HarmonyLib;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using TriangleNet;
//using UnityEngine;
//using UnityEngine.UI;


//[HarmonyPatch(typeof(UI_InGame_SkillButton_GemGroup), "Awake")]
//public static class AddGemGroup
//{
//    static void Postfix(UI_InGame_SkillButton_GemGroup __instance)
//    {
//        if (__instance.groups == null || __instance.groups.Length == 0)
//        {
//            return;
//        }

//        // 原始数组
//        var originalGroups = __instance.groups;
//        var newGroups = originalGroups.ToList();

//        // 克隆最后一个作为模板

//        int extraSlots = 5; // 例如扩展2个
//        for (int i = 1; i < extraSlots; i++)
//        {
//            var template = newGroups.Last();
//            //EnsureLayoutGroup(template);
//            UnityEngine.Debug.Log($"groups.count: {template.GetComponentsInChildren<UI_InGame_GemSlot>().Length} ============");

//            var clone = GameObject.Instantiate(template, template.transform.parent);
//            clone.name = template.name + "_Extra" + (i + 1);
//            UI_InGame_GemSlot templateSolt = clone.GetComponentInChildren<UI_InGame_GemSlot>();
          
//            // 克隆一个新的槽位到父物体下
//            GameObject newSlot = UnityEngine.Object.Instantiate(templateSolt.gameObject, clone.transform);
//            newSlot.name = $"ExtraGemSlot_{i}";
//            // 可选：如果需要的话，这里可以初始化一些参数
//            UI_InGame_GemSlot slotComp = newSlot.GetComponent<UI_InGame_GemSlot>();
//            if (slotComp != null)
//            {
//                // 例如：slotComp.SetEmpty(); // 伪代码，视实际API而定
//            }
//            newGroups.Add(clone);
//        }
//        UnityEngine.Debug.Log($"groups.count: {newGroups.Count} ============");

//        //// 替换回数组
//        __instance.groups = newGroups.ToArray();

//        //UnityEngine.Debug.Log($"groups.count: {__instance.groups.Length} ============");
//        //// 举例：给第 0 个技能增加 2 个槽位
//        //int addCount = 2;

//        //for (int targetIndex = 0; targetIndex < __instance.groups.Length; ++targetIndex)
//        //{
//        //    GameObject parent = __instance.groups[targetIndex];
//        //    UnityEngine.Debug.Log($"groups.children.count: {__instance.groups[targetIndex].GetComponentsInChildren<UI_InGame_GemSlot>().Length} ============");
//        //    UnityEngine.Debug.Log($"groups.children: {__instance.groups[targetIndex].GetComponentsInChildren<UI_InGame_GemSlot>()} ============");

//        //    // 找一个现有槽位作为克隆模板
//        //    UI_InGame_GemSlot template = parent.GetComponentInChildren<UI_InGame_GemSlot>();
//        //    if (template != null)
//        //    {
//        //        for (int i = 0; i < addCount; i++)
//        //        {
//        //            // 克隆一个新的槽位到父物体下
//        //            GameObject newSlot = UnityEngine.Object.Instantiate(template.gameObject, parent.transform);
//        //            newSlot.name = $"ExtraGemSlot_{i}";

//        //            // 可选：如果需要的话，这里可以初始化一些参数
//        //            UI_InGame_GemSlot slotComp = newSlot.GetComponent<UI_InGame_GemSlot>();
//        //            if (slotComp != null)
//        //            {
//        //                // 例如：slotComp.SetEmpty(); // 伪代码，视实际API而定
//        //            }
//        //        }
//        //    }
//        //}
//    }
//    /// <summary>
//    /// 确保父物体上有 GridLayoutGroup，否则自动添加
//    /// </summary>
//    //private static void EnsureLayoutGroup(GameObject parent)
//    //{
//    //    // 在这个 GameObject 上加 GridLayoutGroup

//    //    GridLayoutGroup layout = parent.GetComponent<GridLayoutGroup>();
//    //    UnityEngine.Debug.Log($"groups.count: {layout} ============");
//    //    if (layout == null)
//    //    {
//    //        UnityEngine.Debug.Log($"groups.count: {layout} ============");
//    //        layout = parent.AddComponent<GridLayoutGroup>();
//    //        layout.cellSize = new Vector2(60, 60);   // 每个槽位的大小
//    //        layout.spacing = new Vector2(10, 0);     // 横向间距
//    //        layout.startAxis = GridLayoutGroup.Axis.Horizontal;
//    //        layout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
//    //        layout.constraintCount = 3; // 每行最多 3 个
//    //    }
//    //}


//}
