using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class UI_Input : MonoBehaviour
{
    private TMP_InputField inputField;

    private void Awake(){
        inputField = transform.Find("inputField").GetComponent<TMP_InputField>();
    }

    public void Show(string inputString){

        inputField.text = inputString;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
