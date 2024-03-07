using System;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace ImageCoverExpander2
{
    [BepInPlugin(BuildInfo.Id, BuildInfo.Name, BuildInfo.Version)]
    internal sealed class Plugin : BaseUnityPlugin
    {
        public static ManualLogSource s_log = null!;

        private Harmony _harmony = null!;

        private void Awake()
        {
            s_log = Logger;
            _harmony = new Harmony(BuildInfo.Id);
        }

        private void Start()
        {
            _harmony.PatchAll();
        }
    }
}