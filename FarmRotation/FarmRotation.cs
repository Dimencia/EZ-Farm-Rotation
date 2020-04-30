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
            Harmony = new Harmony("Farm Rotation");
        }


        public void OnBeforeGameStart()
        {
            Context.Log.Log("Adding Farm Rotation");
            Harmony.PatchAll();
            Context.Log.Log("Farm Rotation added");
        }
    }
}
