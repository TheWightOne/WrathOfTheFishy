using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AIHealth : MonoBehaviour
{
    [SerializeField]private Animator animator = null;
    [SerializeField]private float maxHealth = 10f;
    
    
    private float currentHealth;
    public float CurrentHealth{
        get{
            return currentHealth;
        }
    }

    void Start(){
        currentHealth = maxHealth;
    }

    //deals damage to the AI, and returns true if it killed
    public bool TakeDamage(float amount, Vector3 direction){
        currentHealth -= amount;
        if(currentHealth <= 0.0f){
            Die();
            return true;
        }else{
            //take damage
        }
        return false;
    }

    public bool TakeDamage(float amount){
        return TakeDamage(amount, new Vector3(0,0,0));
    }


    private void Die(){
        Destroy(gameObject);
    }

}
