using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextOnInput : MonoBehaviour {

    Text myText;

    // Use this for initialization
    void Start () {
        myText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        string textToPrint = "Pressed Buttons:\n";

        if (SimonXInterface.GetButton(SimonXInterface.SimonButtonType.Button_UL))
        {
            textToPrint += "UL ";
        }

        if (SimonXInterface.GetButton(SimonXInterface.SimonButtonType.Button_UR))
        {
            textToPrint += "UR ";
        }

        if (SimonXInterface.GetButton(SimonXInterface.SimonButtonType.Button_LL))
        {
            textToPrint += "LL ";
        }

        if (SimonXInterface.GetButton(SimonXInterface.SimonButtonType.Button_LR))
        {
            textToPrint += "LR";
        }

        myText.text = textToPrint;
    }
}
