using System;
using PatchZone.Hatch;
using PatchZone.Hatch.Utils;
using FarmRotation.Services;

using ECS;
using Service.Achievement;
using Service.Building;
using Service.Localization;
using Service.Street;
using Service.UserWorldTasks;
using HarmonyLib;

namespace FarmRotation
{
    public class FarmRotation : Singleton<FarmRotation>, IPatchZoneMod
    {
        public static IPatchZoneContext Context { get; private set; }
        public static Harmony Harmony;

        public void Init(IPatchZoneContext context)
        {
            Context = context;
            Context.Log.Log("Farm Rotation Initializing");
            Harmony = new Harmony("Farm Rotation");
            
            var method = typeof(Zenject.ProjectContext).GetMethod("EnsureIsInitialized"); // Patches need to go in ASAP in case they override initialize
            Harmony.Patch(method, null, new HarmonyMethod(typeof(FarmRotation).GetMethod(nameof(FarmRotation.InstallModPatches))));
        }

        public FarmRotation() : base()
        {
            int test = 0;
            test++;
        }

        public void OnBeforeGameStart()
        {
            Context.RegisterProxyService<ILocalizationService, LocalizationService>();
        }

        public static void InstallModPatches()
        {
            Context.Log.Log("Adding Farm Rotation");
            Harmony.PatchAll();
            Context.Log.Log("Farm Rotation added");
        }
    }
}
