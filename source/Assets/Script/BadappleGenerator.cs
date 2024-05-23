using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadappleGenerator : MonoBehaviour
{
    public GameObject apple_doku_ringo;
    float span = 5.0f;
    float delta = 0;

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject spawn = Instantiate(apple_doku_ringo);
            int px = Random.Range(-10, 11);
            int py = Random.Range(-4, 5);
            spawn.transform.position = new Vector3(px, py, 0);
        }
    }
}
