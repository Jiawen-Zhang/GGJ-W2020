using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public GameObject replaceWithThis;

    public float distance = 10f;

    public Transform ladderDetection; 

    public AudioSource audioData;
    public AudioClip jumpClip;
    public AudioClip runClip;
    public AudioClip fireClip;

    public int health = 100;
    public int score = 0;

	public bool dead = false;
    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove = 0f;
    float verticalMove = 0f;

    public float runSpeed = 40f;

    public float climbSpeed = 2f;
    bool jump = false;
    bool crouch = false;

    bool climbing = false;

    public LayerMask whatIsLadder;

    Rigidbody2D rb;
   
    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        Debug.Log(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name);

        RaycastHit2D hitInfo = Physics2D.Raycast(ladderDetection.position, Vector2.up, distance, whatIsLadder);

        if (hitInfo.collider != null) {
            if (Input.GetButtonDown("Climb")) {
                climbing = true;
                animator.SetBool("IsClimbing", true);
            }
        } else {
            if (Input.GetButtonDown("Horizontal")) {
                climbing = false;
                animator.SetBool("IsClimbing", false);
            }
        }

        if (climbing == true && hitInfo.collider != null) {
            verticalMove = Input.GetAxisRaw("Vertical") * climbSpeed;
            rb.velocity = new Vector2(rb.velocity.x, verticalMove);
            rb.gravityScale = 0;
        } else {
            rb.gravityScale = 1;
        }

        if (audioData.isPlaying == false && animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "player run") {
            audioData.clip = runClip;
            audioData.Play();
        }
        else if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "player fire") {
            audioData.clip = fireClip;
            audioData.Play();
        }
        
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump")){
            jump = true;
            animator.SetBool("IsJumping", true);

        }
        if (Input.GetButtonDown("Crouch")){
            crouch = true;

        } else if (Input.GetButtonUp("Crouch")){
            crouch = false;
        } else if (Input.GetButtonDown("Fire1") && crouch == false){
            animator.SetBool("IsFiring", true);

        } else if (Input.GetButtonUp("Fire1") && crouch == false){
            animator.SetBool("IsFiring", false);
        }
    }
    void FixedUpdate() 
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }

    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);

    }

    public void OnCrouching (bool IsCrouching)
    {
        animator.SetBool("IsCrouching", IsCrouching);

    }

    public void TakeDamage (int damage, int type)
    //type 0 = from virus   type 1 = from trap/fall
	{
		health -= damage;

		if (health <= 0 && dead == false)
		{
			Die(type);
		}
	}

	void Die (int type)
	{
		dead = true;
        if (type == 0) {
            GameObject deadman = Instantiate(replaceWithThis,  gameObject.transform.position,  gameObject.transform.rotation);
            deadman.layer = replaceWithThis.layer;
        }

		Destroy(gameObject);

	}

    public void leap() {
        jump = true;
        animator.SetBool("IsJumping", true);
    }


}