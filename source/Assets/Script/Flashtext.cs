using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashtext : MonoBehaviour
{
    public GameObject startText;
    // Start is called before the first frame update
    void Start()
    {
        startText = GetComponent<GameObject>();
    }
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(textstart());
    }
    IEnumerator textstart()
    {
        Instantiate(startText);
        yield return new WaitForSeconds(0.5f);
        Destroy(startText);
        yield return new WaitForSeconds(0.5f);
    }
}