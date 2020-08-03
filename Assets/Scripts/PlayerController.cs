using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float gravityMod = 1;
    public float jumpForce = 10;
    public ParticleSystem explosionEffect;
    public ParticleSystem dirtEffect;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioSource playerSound;
    public bool touchGround = true;
    public bool gameOver;
    private Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMod;
        playerAnim = GetComponent<Animator>();
        playerSound = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && touchGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            touchGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtEffect.Stop();
            playerSound.PlayOneShot(jumpSound, 1.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            touchGround = true;
            dirtEffect.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionEffect.Play();
            dirtEffect.Stop();
            playerSound.PlayOneShot(crashSound, 1.0f);
        }
    }
}
