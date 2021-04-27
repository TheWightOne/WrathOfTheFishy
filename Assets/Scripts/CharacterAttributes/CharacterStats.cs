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
            if(!enabled){
                return;
            }
            int targetValue = value;
            if(perfectTiming){
                return;
            }else if(blocking){
                targetValue = currentHealth - ((currentHealth - targetValue)/2);
            }
            if(currentHealth < 0){
                return;
            }
            if(targetValue <= 0){
                currentHealth = 0;
                DeathEvent.Invoke();
                enabled = false;
                return;
            }else{
                currentHealth = value;
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

    [HideInInspector]public UnityEvent DeathEvent;

    void Start(){
        CurrentHealth = MaxHealth;
    }
}
