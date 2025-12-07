namespace ProjectWhatsApp;

using UnityEngine;

/// <summary> Loader for the mods assets. </summary>
public static class BundleLoader
{
    /// <summary> The loaded AssetBundle. </summary>
    public static AssetBundle bundle;

    /// <summary> It's just a plane. </summary>
    public static GameObject WhatsAppPrefab;

    /// <summary> Literally just a png of the whatsapp logo. </summary>
    public static Material WhatsAppMaterial;

    /// <summary> WHATSAPP INVINCIBLE!!! </summary>
    public static Material WhatsAppInvincibleMaterial;

    /// <summary> dayum why this song so good </summary>
    public static Material WhatsAppRemixMaterial;

    /// <summary> WhatsApp notification for all enemies. </summary>
    public static AudioClip WhatsAppNot;

    /// <summary> WhatsApp Phonk music for random 1 in 10 chance enemies. </summary>
    public static AudioClip WhatsAppPhonk;

    /// <summary> this is the green car one(1 in 50 chance)(and this will only be for bosses when duviz decides to add them) </summary>
    public static AudioClip WhatsAppRemix;

    /// <summary> Actually loads the fucking assets. </summary>
    public static void LoadAssets(string bundlePath)
    {
        bundle = AssetBundle.LoadFromFile(bundlePath);

        WhatsAppPrefab = bundle.LoadAsset<GameObject>("WhatsAppPrefab");
        WhatsAppRemixMaterial = bundle.LoadAsset<Material>("WhatsAppRemixMaterial");
        WhatsAppMaterial = bundle.LoadAsset<Material>("WhatsAppMaterial");
        WhatsAppInvincibleMaterial = bundle.LoadAsset<Material>("WhatsAppInvincibleMaterial");

        WhatsAppRemix = bundle.LoadAsset<AudioClip>("WhatsAppRemix");
        WhatsAppNot = bundle.LoadAsset<AudioClip>("WhatsAppNot");
        WhatsAppPhonk = bundle.LoadAsset<AudioClip>("WhatsAppPhonk");
    }
}
