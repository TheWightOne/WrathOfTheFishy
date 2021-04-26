using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hitbox : MonoBehaviour
{
    private List<CharacterStats> targetStats = new List<CharacterStats>();
    public List<CharacterStats> TargetStats{
        get{
            return targetStats;
        }
    }

    //a list containin gthe stats of characters who have already been hit
    private List<CharacterStats> hitStats = new List<CharacterStats>();

    public UnityEvent hitDetectedEvent;
    void OnTriggerEnter(Collider other){
        CharacterStats newStats;

        //processes will not execute if hit enemy is not an enemy, is in the list already, or has already been hit
        if(other.CompareTag("Enemy") && !targetStats.Contains(newStats = other.GetComponent<CharacterStats>()) && !hitStats.Contains(newStats)){
            targetStats.Add(newStats);
            hitDetectedEvent.Invoke();
        }
    }

    void OnTriggerExit(Collider other){
        CharacterStats newStats;
        if(other.CompareTag("Enemy") && targetStats.Contains(newStats = other.GetComponent<CharacterStats>())){
            targetStats.Remove(newStats);
        }
    }

    void OnDisable(){
        targetStats.Clear();
        hitStats.Clear();
    }

    public void SetStatsAsHit(){
        foreach(CharacterStats cs in targetStats){
            if(!cs.enabled){
                continue;
            }
            hitStats.Add(cs);
        }
        targetStats.Clear();
    }

    public void ResetHitbox(){
        targetStats.AddRange(hitStats);
        hitStats.Clear();
    }

}
