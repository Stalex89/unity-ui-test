using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButton : MonoBehaviour
{


    public bool boolToogleButton;

    public GUISkin MyGUISkin;

    void OnGUI()

    {

        if (boolToogleButton == false)
        {
            if (GUI.Button(new Rect(Screen.width * 0.7f, Screen.height * 0.3f, Screen.width * 0.02f, Screen.width * 0.02f), "", MyGUISkin.customStyles[1])) // MyGUISkin.customStyles[1] is unselected button image
            {
                boolToogleButton = true;
                Debug.Log("Tick On");
            }
        }
        else
        {
            if (GUI.Button(new Rect(Screen.width * 0.7f, Screen.height * 0.3f, Screen.width * 0.02f, Screen.width * 0.02f), "", MyGUISkin.customStyles[2]))  // MyGUISkin.customStyles[2] is selected button image
            {
                boolToogleButton = false;
                Debug.Log("Tick Off");
            }
        }
    }
}
