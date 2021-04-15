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

    private int currentHealth;

    public bool perfectTiming = false;
    public bool blocking = false;
    public int CurrentHealth{
        get{
            return currentHealth;
        }
        set{
            int targetValue = value;
            if(perfectTiming){
                return;
            }else if(blocking){
                targetValue = currentHealth - ((currentHealth - targetValue)/2);
            }
            if(currentHealth < 0){
                return;
            }
            if(value < 0){
                currentHealth = 0;
                DeathEvent.Invoke();
            }else{
                currentHealth = value;
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
