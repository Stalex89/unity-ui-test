using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class LvlUpManager : MonoBehaviour
{
    public ToggleGroup toggleGroup;
    public Text pointsValueText;
    public int pointsAvailable = 0;

    private void Awake()
    {
        pointsValueText.text = pointsAvailable.ToString();
    }

    public void OnSubmit()
    {
        if (pointsAvailable > 0)
        {
            var selectedToggle = toggleGroup.ActiveToggles().First();
            Debug.Log("Submit button clicked. " + selectedToggle.name + " is selected");
            toggleGroup.SetAllTogglesOff();
            pointsAvailable -= 1;
            pointsValueText.text = pointsAvailable.ToString();

            // call skill/fate random function

            
        }
    }
}
