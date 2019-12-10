using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    private Rigidbody playerRB;
    private Animator playeranim;
    private AudioSource playeraudio;
    public ParticleSystem exsplosionpar;
    public ParticleSystem dirtpar;
    public AudioClip jumpaudio;
    public AudioClip crashaudio; 
    public float jumpForce;
    public float graffitymodefier;
    public bool isOnGround = true;
    public bool GameOver;

// Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playeranim = GetComponent<Animator>();
        playeraudio = GetComponent<AudioSource>();
        Physics.gravity *= graffitymodefier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !GameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playeranim.SetTrigger("Jump_trig");
            dirtpar.Stop();
            playeraudio.PlayOneShot(jumpaudio, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("grond"))
        {
            isOnGround = true;
            dirtpar.Play();
        }
        else if (collision.gameObject.CompareTag("obstackle"))
        {
            Debug.Log("game over");
            GameOver = true;
            playeranim.SetBool("Death_b", true);
            playeranim.SetInteger("DeathType_int", 1);
            exsplosionpar.Play();
            dirtpar.Stop();
            playeraudio.PlayOneShot(crashaudio, 1.0f);
        }
    }
}