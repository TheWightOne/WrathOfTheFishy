using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterStats : MonoBehaviour
{
    [SerializeField]private int maxHealth = 10;
    public int MaxHealth{
        get{
            return maxHealth;
        }
    }


    public bool perfectTiming = false;
    public bool blocking = false;
    private int currentHealth;
    public int CurrentHealth{
        get{
            return currentHealth;
        }
        set{
            bool lostHealth = value < currentHealth;
            if(!enabled){
                return;
            }
            int targetValue = value;
            if(perfectTiming){
                //perfect block, no damage
                return;
            }else if(blocking){
                //block, half damage
                targetValue = currentHealth - ((currentHealth - targetValue)/2);
            }
            if(currentHealth < 0){
                //already dead, no damage
                return;
            }
            if(targetValue <= 0){
                //damage would kill, deal only lethal damage
                currentHealth = 0;
                DeathEvent.Invoke();
                enabled = false;
                return;
            }else{
                //take full damage
                currentHealth = targetValue;
                if(lostHealth){
                    TakeDamageEvent.Invoke();
                }
                return;
            }
        }
    }

    [SerializeField]private int attack = 1;
    public int Attack{
        get{
            return attack;
        }
    }

    public UnityEvent DeathEvent;
    public UnityEvent TakeDamageEvent;

    void Start(){
        CurrentHealth = MaxHealth;
    }
}
