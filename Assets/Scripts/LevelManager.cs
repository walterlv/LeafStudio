using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        _currentLevelAction = GetLevelList().GetEnumerator();
        PrefabsManager = gameObject.GetComponent<PrefabsManager>();
    }

    internal void GotoNextLevel()
    {
        _currentLevelAction.Current();
        if (!_currentLevelAction.MoveNext())
        {
            _currentLevelAction = GetLevelList().GetEnumerator();
        }
    }

    private IEnumerator<Action> _currentLevelAction;
    private PrefabsManager PrefabsManager { set; get; }

    IEnumerable<Action> GetLevelList()
    {
        return new Action[]
        {
            FallDownSunshine
        };
    }

    private void FallDownSunshine()
    {
        gameObject.AddComponent<SunshineFallDown>();
        var sunshineFallDown = gameObject.GetComponent<SunshineFallDown>();

        sunshineFallDown.SunshinePrefabs = PrefabsManager.SunshinePrefabs;
    }
}
