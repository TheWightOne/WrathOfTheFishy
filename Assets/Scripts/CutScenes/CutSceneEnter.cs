using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneEnter : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject cutsceneCam;
    public GameObject TimelineObject;
    

    void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player"))
        {
            return;
        }
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        cutsceneCam.SetActive(true);
        thePlayer.SetActive(false);
        StartCoroutine(FinishCut());
        TimelineObject.SetActive(true);
    }

    IEnumerator FinishCut()
    {
        yield return new WaitForSeconds(12);
        thePlayer.SetActive(true);
        cutsceneCam.SetActive(false);
    }


}
