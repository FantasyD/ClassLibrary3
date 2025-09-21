using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using CI.QuickSave.Core.Serialisers;
using Epic.OnlineServices;
using HarmonyLib;
using Mirror;
using Newtonsoft.Json;
using TriangleNet;

[BepInPlugin("com.mygame.additems", "Add Custom Items", "1.0.0")]
public class AddItemsPlugin : BaseUnityPlugin
{
    public static AddItemsPlugin Instance;
    public ConfigData ConfigData;
    private string configPath;
    private FileSystemWatcher watcher;

    void Awake()
    {
        var harmony = new Harmony("com.yourname.customitems");
        harmony.PatchAll();
        
        configPath = Path.Combine(Paths.PluginPath, "MyPluginConfig.json"); 
        Instance = this;
        UnityEngine.Debug.Log($"Config Path: {configPath}");
        LoadConfig();

        // 监听配置文件变化
        watcher = new FileSystemWatcher(Paths.PluginPath, "MyPluginConfig.json");
        watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size;
        watcher.Changed += OnConfigChanged;
        watcher.EnableRaisingEvents = true;
    }

    private void OnConfigChanged(object sender, FileSystemEventArgs e)
    {
        try
        {
            // 等待文件写入完成（避免占用冲突）
            System.Threading.Thread.Sleep(100);
            UnityEngine.Debug.Log($"Config Path: {configPath}");
            LoadConfig();
        }
        catch (Exception ex)
        {
        }
    }

    private void LoadConfig()
    {
        if (!File.Exists(configPath))
        {
            
        }
        else
        {
            var json = File.ReadAllText(configPath);
            ConfigData = JsonConvert.DeserializeObject<ConfigData>(File.ReadAllText(configPath));
        }
    }

    public ConfigData GetConfig() => ConfigData;
}

public class ConfigData
{
    public DreamDustOnKillChanceData DreamDustOnKillChanceData { get; set; }
    public SnowGemData SnowGemData { get; set; }
    public RigidityGemData RigidityGemData { get; set; }
}

public class DreamDustOnKillChanceData
{
    public double Chance { get; set; }
    public int GainedAmount { get; set; }
}

public class SnowGemData
{
    public float RechargeTime = 5f;
    public float Range = 5f;
    public float ShootIntervalMax = 1.5f;
    public float ShootIntervalMin = 0.2f;
}
public class RigidityGemData
{
    public float RechargeTime = 5f;
    public float Range = 5f;
    public float ShootIntervalMax = 1.5f;
    public float ShootIntervalMin = 0.2f;
}
