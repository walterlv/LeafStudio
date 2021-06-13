using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

using Valve.VR.Extras;
using Valve.VR.InteractionSystem;

using static UnityEngine.UI.GridLayoutGroup;

public class MainMenuNewGameScript : Interactable
{
    public SteamVR_LaserPointer laserPointer;

    private void Awake()
    {
        laserPointer.PointerIn += LaserPointer_PointerIn;
        laserPointer.PointerOut += LaserPointer_PointerOut;
        laserPointer.PointerClick += LaserPointer_PointerClick;
    }

    private void LaserPointer_PointerIn(object sender, PointerEventArgs e)
    {
    }

    private void LaserPointer_PointerOut(object sender, PointerEventArgs e)
    {
    }

    private void LaserPointer_PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.gameObject == gameObject)
        {
            GotoLevel();
        }
    }

    protected override void OnHandHoverBegin(Hand hand)
    {
        GotoLevel();
        base.OnHandHoverBegin(hand);
    }

    private static void GotoLevel()
    {
        var player = GameObject.Find("Player");
        GameObject.Destroy(player);

        Valve.VR.SteamVR_LoadLevel.Begin("Challenge1-1",
            showGrid: true,
            fadeOutTime: 1);
    }
}
