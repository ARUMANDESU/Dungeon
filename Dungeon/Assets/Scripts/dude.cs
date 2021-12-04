using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dude : MonoBehaviour
{
    private Rigidbody2D rb;

    public Transform attackPos;
    public LayerMask Enemy;
    public float attackRange;
    public int damage;
    public Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Attack(){
        animator.Play("attack1");
        
    }

    public void DamageEnemy(){
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Enemy);
        for(int i =0; i<enemies.Length;i++){
            enemies[i].GetComponent<enemy>().TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
