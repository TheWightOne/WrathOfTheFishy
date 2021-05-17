using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{

    [SerializeField]private CharacterStats playerStats;
    [SerializeField]private GameObject deathPanel;
    // Start is called before the first frame update
    void Start()
    {
        if(!playerStats){
            Debug.LogWarning("Warning: player has not been assigned. please assign them in the inspector before playing.");
        }else{
            playerStats.DeathEvent.AddListener(OnDeath);
        }
    }

    void OnDeath(){
        StartCoroutine(DeathCor());
    }

    IEnumerator DeathCor(){
        yield return new WaitForSeconds(3f);
        MouseController.instance.EnableMouse();
        deathPanel.SetActive(true);
    }

    
}
