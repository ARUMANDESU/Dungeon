using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public Animator animator;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage){
        health-=damage;
        if(health<=0){
            animator.Play("die");
        }
        else{
            animator.Play("hurt");
        }
    }

    public void die(){
        Destroy(gameObject);
    }


}
