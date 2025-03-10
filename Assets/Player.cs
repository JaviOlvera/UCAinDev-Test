using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public float Speed = 7f;
    public float JumpForce = 16f;
    public float Gravity = 5f;
    
    public bool OnGround;
    public Transform BottomRight;
    public Transform BottomLeft;
    public float JumpRaycastSize = 0.6f;
    public float WallRaycastSize = 0.25f;

    public Rigidbody2D Rb;
    public Animator Anim;
    public SpriteRenderer Renderer;
    public TMP_Text Cojones;
    public int Coins;

    void Update()
    {
        Cojones.text = "Cojones: " + Coins;
        Rb.gravityScale = Gravity;

        float xMovement = Input.GetAxis("Horizontal");

        if(Physics2D.Raycast(BottomRight.position, new Vector3(1, 0, 0), WallRaycastSize) && xMovement > 0)
        {
            xMovement = 0;
        }

        if (Physics2D.Raycast(BottomLeft.position, new Vector3(-1, 0, 0), WallRaycastSize) && xMovement < 0)
        {
            xMovement = 0;
        }

        Rb.linearVelocity = new Vector2(xMovement * Speed, Rb.linearVelocity.y);

        if(Physics2D.Raycast(BottomRight.position, new Vector3(0,-1,0), JumpRaycastSize)
           || Physics2D.Raycast(BottomLeft.position, new Vector3(0, -1, 0), JumpRaycastSize))
        {
            OnGround = true;
        }
        else
        {
            OnGround = false;
        }


        if (Input.GetKeyDown(KeyCode.Space) && OnGround == true)
        {
            Rb.linearVelocity = new Vector2(Rb.linearVelocity.x, JumpForce);

            GetComponent<AudioSource>().Play();
        }

        if(Input.GetKeyUp(KeyCode.Space) && Rb.linearVelocity.y > 0)
        {
            Rb.linearVelocity = new Vector2(Rb.linearVelocity.x, 0);
        }

        Anim.SetBool("Walk", xMovement != 0);
        Anim.SetBool("Jump", OnGround == false);
        Renderer.flipX = xMovement < 0;
    }
}
