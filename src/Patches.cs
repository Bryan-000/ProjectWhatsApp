using HarmonyLib;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.AI;

namespace ProjectWhatsApp;

/// <summary> All harmony patches fore the mod. </summary>
[HarmonyPatch]
public static class Patches
{
    [HarmonyPrefix]
    [HarmonyPatch(typeof(ZombieAI), "Start")]
    public static void ZombiePostStart(ZombieAI __instance)
    {
        if (__instance.name == "WhatsAppV2")
        {
            bool setPlane = false;
            MeshRenderer meshmesh = null;

            if (Random.Range(1, 3) == 1)
            {
                setPlane = true;
                Object.Destroy(__instance.GetComponent<MeshFilter>());
                Object.Destroy(__instance.GetComponent<MeshRenderer>());

                GameObject mesh = Object.Instantiate(BundleLoader.WhatsAppPrefab);
                MeshRenderer meshRenderer = mesh.GetComponent<MeshRenderer>();
                mesh.transform.eulerAngles = __instance.transform.eulerAngles;
                mesh.transform.position = __instance.transform.position;
                mesh.transform.parent = __instance.transform;

                meshmesh = meshRenderer;
                meshRenderer.material = BundleLoader.WhatsAppInvincibleMaterial;
            }
            else
            {
                __instance.GetComponent<MeshRenderer>().material = BundleLoader.WhatsAppInvincibleMaterial;
            }

            if (Random.Range(1, 7) == 1)
            {
                __instance.Groan1.GetComponent<AudioSource>().clip = BundleLoader.WhatsAppRemix;

                MeshRenderer meshRenderer = null;
                GameObject mesh = null;
                if (!setPlane)
                {
                    Object.Destroy(__instance.GetComponent<MeshFilter>());
                    Object.Destroy(__instance.GetComponent<MeshRenderer>());

                    mesh = Object.Instantiate(BundleLoader.WhatsAppPrefab);
                    meshRenderer = mesh.GetComponent<MeshRenderer>();
                }
                else meshRenderer = meshmesh;
                meshRenderer.material = BundleLoader.WhatsAppRemixMaterial;
                mesh.transform.eulerAngles = __instance.transform.eulerAngles;
                mesh.transform.position = __instance.transform.position;
                mesh.transform.parent = __instance.transform;

                __instance.name = "WhatsAppBMW";

                if (Plugin.EnemyBuffs)
                {
                    NavMeshAgent agent = __instance.GetComponent<NavMeshAgent>();
                    agent.speed = 140f;

                    DummyHealth hp = __instance.GetComponent<DummyHealth>();
                    hp.health = hp.maxHealth = 250;
                }
            }
        }
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(ZombieAI), "Update")]
    public static void Groan1PlayForcer(ZombieAI __instance)
    {
        var field = AccessTools.Field(typeof(SmoothPlayState), "state");
        field.SetValue(__instance.Groan1, System.Enum.Parse(field.FieldType, "Playing"));
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(Loadmap), "Start")]
    public static void ModifyPrefabs(Loadmap __instance)
    {
        Plugin.ChangeZombieV1(__instance.entities[0]);
        Plugin.ChangeZombieV2(__instance.entities[2]);
    }
}