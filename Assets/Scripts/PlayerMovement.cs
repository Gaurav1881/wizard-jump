using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterController2D controller;
    public Animator animator;

    public float horizontalMultiplier = 0.1f;
    bool jump = false;
    Vector3 dragStartPos;
    Vector3 endPosition;
    float horizontalForce = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isCrouching", true);
            dragStartPos = Input.mousePosition;
        }
        else if (Input.GetButtonUp("Jump") || Input.GetMouseButtonUp(0))
        {
            endPosition = Input.mousePosition;
            horizontalForce = dragStartPos.x - endPosition.x;
            animator.SetBool("isCrouching", false);
            jump = true;
            animator.SetBool("isJumping", true);
        }
    }

    void FixedUpdate ()
    {
        controller.Move(horizontalForce * horizontalMultiplier, false, jump);
        jump = false;
        horizontalForce = 0;
    }

    public void onLanding()
    {
        animator.SetBool("isJumping", false);
    }
}
