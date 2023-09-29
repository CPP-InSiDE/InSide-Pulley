using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputValidation : MonoBehaviour
{
    private TMP_InputField userInput;

    private void Start()
    {
        userInput = gameObject.GetComponent<TMP_InputField>();    
    }

    public void CheckInput() {
        float setValue = 0;

        float.TryParse(userInput.text, out setValue);

        userInput.text = "" + Mathf.Abs(setValue);
    }
}
