using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dudeMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public Animator  animator;
    public float speed;

    public Joystick joystick;
    


    public void Start(){
    }
    public void Update()
    {

        animator.SetFloat("Speed",(Mathf.Abs(joystick.Horizontal)+2)*(Mathf.Abs(joystick.Vertical)+2)*speed);

        if(joystick.Horizontal>=.1f || joystick.Horizontal<=-.1f ){
            Vector3 dir = transform.right * joystick.Horizontal;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
            if(dir.x < 0.0f){
                transform.localScale = new Vector3(-1,1,0);
            }
            else{
                transform.localScale = new Vector3(1,1,0);
            }
        }
        if(joystick.Vertical>=.1f||joystick.Vertical<=-.1f){
            Vector3 dir = transform.up * joystick.Vertical;
            transform.position = Vector3.MoveTowards(transform.position, transform.position+dir, speed * Time.deltaTime);
        }
    }

    public void changeSpeed(float speedd){
        speed=speedd;
    }
}
