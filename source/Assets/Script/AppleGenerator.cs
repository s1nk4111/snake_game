using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleGenerator : MonoBehaviour
{
    public GameObject fruit_ringo;
    //public bool appleDetect = false;
    float span = 2.0f;
    float delta = 0;

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            AppleCreate();
        }
    }
    public void AppleCreate()
    {
        //if (appleDetect == false)
        //{
        this.delta = 0;
        GameObject spawn = Instantiate(fruit_ringo);
        int px = Random.Range(-10, 11);
        int py = Random.Range(-4, 5);
        spawn.transform.position = new Vector3(px, py, 0);
        //  appleDetect = true;
        //}
    }
}
