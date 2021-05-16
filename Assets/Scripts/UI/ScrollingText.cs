using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrollingText : MonoBehaviour
{
    [SerializeField]private float delayTime = 0f;
    [SerializeField]private RectTransform parentTransformToMove = null;
    [SerializeField]private RectTransform startTransform;
    [SerializeField]private RectTransform endTransform;
    [SerializeField]private float speed = 300f;

    private Coroutine scrollCoroutine;

    private Controls controls;

    [SerializeField]private GameObject SkipButton = null;
    [SerializeField]private GameObject BackButton = null;

    void Awake()
    {
        controls = new Controls();
        controls.General.Interact.performed += _ =>{
            SkipButton.SetActive(true);
        }; 
        
    }
    
    #region - Enable/Disable -
    void OnEnable(){
        controls.Enable();

        parentTransformToMove.position = startTransform.position;
        scrollCoroutine = StartCoroutine(ScrollCor());
    }

    void OnDisable(){
        controls.Disable();

        if(scrollCoroutine != null){
            StopCoroutine(scrollCoroutine);
            scrollCoroutine = null;
        }
    }

    #endregion


    private IEnumerator ScrollCor(){
        Debug.Log("scroll Cor started!");
        yield return new WaitForSecondsRealtime(delayTime);
        Debug.Log("We're past the seconds delay");
        //Debug.Log("Starting MoveCor!");
        while(Mathf.Abs((parentTransformToMove.position - endTransform.position).sqrMagnitude) > .01f){
            //Debug.Log("Distance between transforms: " + Mathf.Abs((parentTransform.position - endTransform.position).sqrMagnitude) );

            yield return new WaitForEndOfFrame();
            Vector3 oldTransform = parentTransformToMove.position;
            Vector3 newTransform = Vector3.MoveTowards(oldTransform, endTransform.position, Time.unscaledDeltaTime * speed);
            parentTransformToMove.position = newTransform;
        }
        Debug.Log("Ending MoveCor! Distance between transforms: " + Mathf.Abs((parentTransformToMove.position - endTransform.position).sqrMagnitude) );
        SkipToEnd();
    }

    public void SkipToEnd(){
        if(scrollCoroutine != null){
            //Debug.Log("Ending ScrollCor");
            StopCoroutine(scrollCoroutine);
        }
        parentTransformToMove.position = endTransform.position;
        if(SkipButton){
            SkipButton.SetActive(false);

        }
        if(BackButton){
            BackButton.SetActive(true);

        }
    }
}
