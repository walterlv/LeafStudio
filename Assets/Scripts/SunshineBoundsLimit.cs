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
        LimitPosition();
    }

    void OnCollisionEnter(Collision collision)
    {

    }

    void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.name == "Chloroplast")
        {

        }
    }

    public float MinX = -1;
    public float MinY = 0;
    public float MinZ = -0.7f;
    public float MaxX = 1.2f;
    public float MaxY = 1.6f;
    public float MaxZ = 0.5f;

    public void LimitPosition()
    {
        Transform trNeedLimit = transform;
        var rigidbody = GetComponent<Rigidbody>();

        if (trNeedLimit.position.x < MinX || trNeedLimit.position.x > MaxX)
        {
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, rigidbody.velocity.z);
        }
        if (trNeedLimit.position.y < MinY || trNeedLimit.position.y > MaxY)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
        }
        if (trNeedLimit.position.z < MinZ || trNeedLimit.position.z > MaxZ)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, 0);
        }

        rigidbody.rotation = new Quaternion();

        trNeedLimit.position = new Vector3(Mathf.Clamp(trNeedLimit.position.x, MinX, MaxX),
                                           Mathf.Clamp(trNeedLimit.position.y, MinY, MaxY),
                                           Mathf.Clamp(trNeedLimit.position.z, MinZ, MaxZ));
    }
}
