using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveleft : MonoBehaviour
{
    private float speed = 30;
    private playercontrol playercontrolerscript;
    private float leftbound = -15;

    // Start is called before the first frame update
    void Start()
    {
        playercontrolerscript = GameObject.Find("player").GetComponent<playercontrol>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playercontrolerscript.GameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftbound && gameObject.CompareTag("obstackle"))
        {
            Destroy(gameObject);
        }

    }
}