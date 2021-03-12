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
    public int CurrentHealth{
        get{
            return currentHealth;
        }
        set{
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

    [SerializeField]private int attack = 0;
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
