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
    
    public void EnableMouse(){
        //Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void DisableMouse(){
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
