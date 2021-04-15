using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParticleHandler : MonoBehaviour
{
    public List<GameObject> particlesToShow;
    public void ShowParticles(){
        foreach(GameObject go in particlesToShow){
            go.SetActive(true);
        }
    }

    public void HideParticles(){
        foreach(GameObject go in particlesToShow){
            go.SetActive(false);
        }
    }
}
