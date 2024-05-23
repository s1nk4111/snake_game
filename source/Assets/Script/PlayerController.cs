using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float speed = 2.0f; //移動速度
    Animator animator;
    int nowApple;
    public TextMeshProUGUI text_apple;
    public AudioClip se;
    AudioSource audi;
    int dirX = 0;
    int dirY = -1;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audi = GetComponent<AudioSource>();
        nowApple = 0;
        text_apple.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            dirY = -1;
            dirX = 0;
            animator.SetTrigger("Walk_D");
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            dirY = 1;
            dirX = 0;
            animator.SetTrigger("Walk_U");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            dirX = -1;
            dirY = 0;
            animator.SetTrigger("Walk_L");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            dirX = 1;
            dirY = 0;
            animator.SetTrigger("Walk_R");
        }

        this.transform.position += new Vector3
            (dirX * speed * Time.deltaTime, dirY * speed * Time.deltaTime, 0);

        //アップル個数を表示
        text_apple.text = "Apple: " + nowApple;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "apple")
        {
            nowApple++;
            if (speed <= 8.0f)
            {
                speed++;
            }
            audi.PlayOneShot(se);
            Destroy(col.gameObject);
            //->appleDetect = false;
        }
        else if (col.gameObject.tag == "bad apple")
        {
            SceneManager.LoadScene("End");
        }
        else if (col.gameObject.tag == "boundary")
        {
            SceneManager.LoadScene("End");
        }
    }
}
