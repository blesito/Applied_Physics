using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageUI : MonoBehaviour
{
    
    public GameObject car;
    Text textUI;
    private bool blinking;
    public bool isTrue;
   


    void Start(){
        textUI = GetComponent<Text>();
        car = GameObject.Find("Jeep2");
    }

    void Update(){
        if (isTrue == false){
            BlinkingText();
            isTrue = true;
        }
    }

    void BlinkingText(){
        blinking = car.GetComponent<PhysicsEngine>().netForceCheck;
        if (blinking){
            StartCoroutine(BlinkBalanced());
        }
        else{
            StartCoroutine(BlinkUnbalanced());
        }
    }


    IEnumerator BlinkBalanced(){  
        while (true){
            textUI.text = " ";
            yield return new WaitForSeconds(1f);
            textUI.color = Color.yellow;
            textUI.text = "Success!";
            yield return new WaitForSeconds(1f);
        }
    }
    IEnumerator BlinkUnbalanced(){
        while (true){
            textUI.text = " ";
            yield return new WaitForSeconds(0.5f);
            textUI.color = Color.red;
            textUI.text = "Unbalanced Force Detected";
            yield return new WaitForSeconds(0.5f);
        }
    }
}