namespace ProjectWhatsApp;

using BepInEx;
using HarmonyLib;
using System.IO;
using UnityEngine;

/// <summary> Base plugin class, does all the set up and fancy. </summary>
[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
public class Plugin : BaseUnityPlugin
{
    /// <summary> Plugin instance for whatever needs it. </summary>
    public static Plugin Instance { get; private set; }

    /// <summary> Whether to buff enemies. </summary>
    public static bool EnemyBuffs { get { if (Instance.Config.TryGetEntry<bool>("Settings", "EnemyBuffs", out var entry)) return entry.Value;
            return false; 
        }
    }

    /// <summary> Load the mod and such. </summary>
    public void Awake()
    {
        Logger.LogInfo("Rawr :3");

        Instance = this;
        BundleLoader.LoadAssets(Path.Combine(Path.GetDirectoryName(Info.Location), "assets.bundle"));

        new Harmony("uwuwuwuwu :3 rawr >:3 meow1!! :3 haiii hii").PatchAll();
        _ = Config.Bind("Settings", "EnemyBuffs", false, "Whether to buff enemies such as the WhatsAppBMW. (MAY CAUSE DESYNC)").Value;
    }

    /// <summary> Changes the Zombie entity to be WhatsApp. </summary>
    public static void ChangeZombieV1(Loadmap.Entity ent)
    {
        GameObject obj = ent.prefab;
        ZombieAI zomb = obj.GetComponent<ZombieAI>();

        Destroy(obj.GetComponent<LODGroup>());
        Destroy(obj.GetComponent<MeshFilter>());
        Destroy(zomb.GetComponent<MeshRenderer>());
        zomb.Groan1.GetComponent<AudioSource>().clip = BundleLoader.WhatsAppNot;

        GameObject mesh = Instantiate(BundleLoader.WhatsAppPrefab);
        MeshRenderer meshRenderer = mesh.GetComponent<MeshRenderer>();
        mesh.transform.eulerAngles = obj.transform.eulerAngles;
        mesh.transform.position = obj.transform.position;
        mesh.transform.parent = obj.transform;

        obj.name = "WhatsApp";
        ent.nickname = "WhatsApp";

        Transform transform = obj.transform;
        transform.Find("LowPoly")?.gameObject.SetActive(false);
        transform.Find("LowPolyInside")?.gameObject.SetActive(false);
    }

    /// <summary> Changes the normal ZombieV2 entity to be WhatsApp. </summary>
    public static void ChangeZombieV2(Loadmap.Entity ent)
    {
        GameObject obj = ent.prefab;
        ZombieAI zomb = obj.GetComponent<ZombieAI>();

        Destroy(obj.GetComponent<LODGroup>());
        zomb.Groan1.GetComponent<AudioSource>().clip = BundleLoader.WhatsAppPhonk;

        obj.name = "WhatsAppV2";
        ent.nickname = "WhatsAppV2";

        Transform transgender = obj.transform;
        transgender.Find("LowPoly")?.gameObject.SetActive(false);
        transgender.Find("LowPolyInside")?.gameObject.SetActive(false);
    }
}

/// <summary> Class containing all the information about the WhatsApp plugin. 
/// <para>(this isnt in ProjectWhatsApp.Plugin to reduce clutter)</para></summary> 
public static class PluginInfo
{
    /// <summary> The unique identifier of the plugin. Should not change between plugin versions. </summary>
    public const string GUID = "Bryan_-000-.ProjectWhatsApp";
    /// <summary> The user friendly name of the plugin. Is able to be changed between versions. </summary>
    public const string Name = "ProjectWhatsApp";
    /// <summary> The specfic version of the plugin. </summary>
    public const string Version = "1.0.0";
}