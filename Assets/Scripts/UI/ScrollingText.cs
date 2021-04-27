using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrollingText : MonoBehaviour
{
    [SerializeField]private float delayTime;
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
        controls.General.Attack.performed += _ =>{
            SkipButton.SetActive(true);
        }; 
        
    }
    
    #region - Enable/Disable -
    void OnEnable(){
        controls.Enable();
    }

    void OnDisable(){
        controls.Disable();
    }

    #endregion

    IEnumerator Start(){
        parentTransformToMove.position = startTransform.position;
        yield return new WaitForSeconds(delayTime);
        scrollCoroutine = StartCoroutine(ScrollCor());
    }

    private IEnumerator ScrollCor(){
        //Debug.Log("Starting MoveCor!");
        while(Mathf.Abs((parentTransformToMove.position - endTransform.position).sqrMagnitude) > 0.03f){
            //Debug.Log("Distance between transforms: " + Mathf.Abs((parentTransform.position - endTransform.position).sqrMagnitude) );

            yield return new WaitForEndOfFrame();
            Vector3 oldTransform = parentTransformToMove.position;
            Vector3 newTransform = oldTransform;
            newTransform.y += Time.deltaTime * speed;
            parentTransformToMove.position = newTransform;
        }
        Debug.Log("Ending MoveCor! Distance between transforms: " + Mathf.Abs((parentTransformToMove.position - endTransform.position).sqrMagnitude) );
        SkipToEnd();
    }

    public void SkipToEnd(){
        if(scrollCoroutine != null){
            Debug.Log("Skipping!");
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

    public void ToMainMenu(){
        SceneManager.LoadScene(0);
    }
}
