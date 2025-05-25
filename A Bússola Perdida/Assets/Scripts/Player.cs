using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    public bool isJumping;
    public bool doubleJump;

    private Rigidbody2D rig;
    //private Animator anim;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        //Anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move(){
        Vector3 moviment = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += moviment * Time.deltaTime * Speed;

        if(Input.GetAxis("Horizontal") > 0f){
            //anim.SetBool("Walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if(Input.GetAxis("Horizontal") < 0f){
           //anim.Setbool("Walk", true);
           transform.eulerAngles = new Vector3(0f, 180f, 0f); 
        }

        if(Input.GetAxis("Horizontal") == 0f){
            //anim.SetBool("Walk", false);
        }
    }

    void Jump(){
        if(Input.GetButtonDown("Jump")){
            if(!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                //anim.SetBool("Jump", true);
            }
            else
            {
                if(doubleJump){
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }
     
    void OnCollissionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == 8){
            isJumping = false;
        }

        /*if(collision.gameObject.tag == "EndOfLevel"){
            GameController.instance.PassLvl();
        }

        if(collision.gameObject.tag == "Spike"){
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }*/
    }

    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.layer == 8){
            isJumping = true;
        }
    }

}
