using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class BeginningText : MonoBehaviour
{
    private string text1 = "Everyone makes mistakes..";
    private string text2 = "I know I have..";
    private string text3 = "Each morning, I feel the retribution for my wrongdoings..";
    private string text4 = "But my memory fails me these days..";
    private string text5 = "I must remember..";
    private string text6 = "If I can't, will I ever be forgiven??";

    public TMP_Text beginning;

    public string currentText = "";

    private float delay = .05f;
    //private float delay1 = .1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowText1());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShowText1(){
        for(int i = 0; i<text1.Length; i++){
            currentText = text1.Substring(0,i);
            beginning.text = currentText;
            yield return new WaitForSeconds(delay);
            if(currentText.Length == text1.Length){
                break;
            }
        }
        for(int i = 1; i>0; i++){
            if(Input.GetKey(KeyCode.Mouse0)){
                break;
            }
            else{
                yield return new WaitForSeconds(delay);
            }
        }
        yield return StartCoroutine(ShowText2());
    }

    IEnumerator ShowText2(){
        currentText = "";
        for(int i = 0; i<text2.Length; i++){
            currentText = text2.Substring(0,i);
            beginning.text = currentText;
            yield return new WaitForSeconds(delay);
            if(currentText.Length == text2.Length){
                break;
            }
        }
        for(int i = 1; i>0; i++){
            if(Input.GetKey(KeyCode.Mouse0)){
                break;
            }
            else{
                yield return new WaitForSeconds(delay);
            }
        }
        yield return StartCoroutine(ShowText3());
    }

    IEnumerator ShowText3(){
        currentText = "";
        for(int i = 0; i<text3.Length; i++){
            currentText = text3.Substring(0,i);
            beginning.text = currentText;
            yield return new WaitForSeconds(delay);
            if(currentText.Length == text3.Length){
                break;
            }
        }
        for(int i = 1; i>0; i++){
            if(Input.GetKey(KeyCode.Mouse0)){
                break;
            }
            else{
                yield return new WaitForSeconds(delay);
            }
        }
        yield return StartCoroutine(ShowText4());
    }

    IEnumerator ShowText4(){
        currentText = "";
        for(int i = 0; i<text4.Length; i++){
            currentText = text4.Substring(0,i);
            beginning.text = currentText;
            yield return new WaitForSeconds(delay);
            if(currentText.Length == text4.Length){
                break;
            }
        }
        for(int i = 1; i>0; i++){
            if(Input.GetKey(KeyCode.Mouse0)){
                break;
            }
            else{
                yield return new WaitForSeconds(delay);
            }
        }
        yield return StartCoroutine(ShowText5());
    }

    IEnumerator ShowText5(){
        currentText = "";
        for(int i = 0; i<text5.Length; i++){
            currentText = text5.Substring(0,i);
            beginning.text = currentText;
            yield return new WaitForSeconds(delay);
            if(currentText.Length == text5.Length){
                break;
            }
        }
        for(int i = 1; i>0; i++){
            if(Input.GetKey(KeyCode.Mouse0)){
                break;
            }
            else{
                yield return new WaitForSeconds(delay);
            }
        }
        yield return StartCoroutine(ShowText6());
    }

    IEnumerator ShowText6(){
        currentText = "";
        for(int i = 0; i<text6.Length; i++){
            currentText = text6.Substring(0,i);
            beginning.text = currentText;
            yield return new WaitForSeconds(delay);
            if(currentText.Length == text6.Length){
                break;
            }
        }
        for(int i = 1; i>0; i++){
            if(Input.GetKey(KeyCode.Mouse0)){
                break;
            }
            else{
                yield return new WaitForSeconds(delay);
            }
        }
        beginning.text = "";
        yield return new WaitForSeconds(delay);
    }
}
