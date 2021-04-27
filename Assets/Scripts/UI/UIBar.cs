using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBar : MonoBehaviour
{
    enum BarType{
        NONE,
        HEALTH,
        POWER
    }

    [SerializeField] private CharacterStats statsToLookAt;
    [Header("Setup Variables")]
    [SerializeField] private BarType type;
    [SerializeField] private Image animatedFill;
    [SerializeField] private Image realFill;

    private int maxValue;
    private int minValue = 0;
    private float currentValue;


    void Start(){
        switch(type){
            case BarType.NONE:
            return;

            case BarType.HEALTH:
            maxValue = statsToLookAt.MaxHealth;
            currentValue = statsToLookAt.CurrentHealth;

            return;

        }
        
        
    }

    void Update(){
        switch(type){
            case BarType.NONE:
            break;

            case BarType.HEALTH:
            currentValue = statsToLookAt.CurrentHealth;

            break;
            case BarType.POWER:
            
            break;

        }

        float newValue = currentValue.Map(minValue, maxValue, 0f, 1f);

        animatedFill.fillAmount = newValue;
        realFill.fillAmount = newValue;
    }
}

public static class ExtensionMethods {
 
    public static float Map (this float value, float inputFrom, float inputTo, float outputFrom, float outputTo) {
        return (value - inputFrom) / (inputTo - inputFrom) * (outputTo - outputFrom) + outputFrom;
    }
   
}
