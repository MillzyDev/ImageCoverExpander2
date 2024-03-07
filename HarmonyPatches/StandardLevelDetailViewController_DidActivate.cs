using HarmonyLib;
using HMUI;
using UnityEngine;

namespace ImageCoverExpander2.HarmonyPatches;

[HarmonyPatch(typeof(StandardLevelDetailViewController))]
[HarmonyPatch(nameof(StandardLevelDetailViewController.DidActivate))]
internal static class StandardLevelDetailViewController_DidActivate
{
    [HarmonyPostfix]
    // ReSharper disable once InconsistentNaming
    private static void Postfix(StandardLevelDetailViewController __instance, bool firstActivation)
    {
        if (!firstActivation)
            return;

        LevelBar levelBar = __instance._standardLevelDetailView._levelBar;
        
        Plugin.s_log.LogInfo("Expanding artwork for " + levelBar.name);

        ImageView imageView = levelBar._songArtworkImageView;
        imageView.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
        imageView.preserveAspect = false;
        imageView._skew = 0f;

        RectTransform imageRt = imageView.rectTransform;
        imageRt.sizeDelta = new Vector2(70, 58.0f);
        imageRt.localPosition = new Vector3(-34.5f, -56.0f, 0.0f);
        imageRt.SetAsFirstSibling();
    }
}