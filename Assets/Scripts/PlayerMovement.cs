using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterController2D controller;
    public float jumpVelocity = 40f;

    public Animator animator;

    bool jump = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }
    }

    void FixedUpdate ()
    {
        controller.Move(0, false, jump);
        jump = false;
    }

    public void onLanding()
    {
        animator.SetBool("isJumping", false);
    }
}
