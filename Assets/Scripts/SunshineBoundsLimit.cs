using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunshineBoundsLimit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LimitPosition(transform);
    }

    public void LimitPosition(Transform trNeedLimit)
    {
        trNeedLimit.position = new Vector3(Mathf.Clamp(trNeedLimit.position.x, -1, 1.5f),
                                           Mathf.Clamp(trNeedLimit.position.y, 0, 1.2f),
                                           Mathf.Clamp(trNeedLimit.position.z,-0.6f,1));
    }
}
