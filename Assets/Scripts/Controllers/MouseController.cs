using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public static MouseController instance;

    void Awake(){
        if(!instance){
            instance = this;
        }else{
            Destroy(this);
        }
    }
    void Start(){
        DisableMouse();
    }
    
    //allows the player to use their mouse again
    public void EnableMouse(){
        //Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    //prevents the player from using their mouse
    public void DisableMouse(){
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void OnEnable(){
        DisableMouse();
    }

    void OnDisable(){
        EnableMouse();
    }
}
