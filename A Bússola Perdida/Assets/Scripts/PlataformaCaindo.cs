using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaCaindo : MonoBehaviour
{
    public float fallingTime;

    private TargetJoint2D target;
    private BoxCollider2D boxColl;

    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        boxColl = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            Invoke("Falling", fallingTime);
        }
    }

    void OnCollisionEnter2D(Collider2D collider){
        if(collider.gameObject.layer == 9){
            Destroy(gameObject);
        }
    }

    void Falling(){
        target.enabled = false;
        boxColl.isTrigger = true;
    }
    
}
