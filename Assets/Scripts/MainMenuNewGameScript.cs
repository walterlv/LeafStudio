using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

using Valve.VR.InteractionSystem;

public class MainMenuNewGameScript : Interactable
{
    protected override void OnHandHoverBegin(Hand hand)
    {
        var player = GameObject.Find("Player");
        GameObject.Destroy(player);

        Valve.VR.SteamVR_LoadLevel.Begin("Challenge1-1");
     
        //SceneManager.LoadScene("Challenge1");
        base.OnHandHoverBegin(hand);
    }
}
