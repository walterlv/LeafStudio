using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunshineHitChloroplast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameLevelManager = GameObject.Find("GameLevelManager");
        LevelManager = GameLevelManager.GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Hitted)
        {
            StayTime += Time.deltaTime;

            const float originScale = 0.1f;
            var scale = (MaxStayTime - StayTime) / MaxStayTime * originScale;
            transform.localScale = new Vector3(scale, scale, scale);
        }

        if (StayTime > MaxStayTime)
        {
            LevelManager.GotoNextLevel();
            Destroy(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Chloroplast")
        {
            Hitted = true;
        }
    }

    private bool Hitted;

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Chloroplast")
        {
            StayTime += Time.deltaTime;

            const float originScale = 0.1f;
            var scale = (MaxStayTime - StayTime) / MaxStayTime * originScale;
            transform.localScale = new Vector3(scale, scale, scale);
        }
        else
        {
            StayTime = 0;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        //StayTime = 0;
    }

    public float MaxStayTime = 1f;

    public float StayTime;
    public GameObject GameLevelManager { set; get; }
    public LevelManager LevelManager { set; get; }
}
