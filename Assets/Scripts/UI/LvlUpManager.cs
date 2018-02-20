using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class LvlUpManager : MonoBehaviour
{
    public Text pointsValueText;
    public int pointsAvailable = 0;
    public ToggleGroup toggleGroup;
    public Button acceptButton;
    public Toggle fate1Toggle;
    public Toggle fate2Toggle;
    public Toggle skill1Toggle;
    public Toggle skill2Toggle;

    private void Start()
    {
        SetInteractive(false);
        pointsValueText.text = pointsAvailable.ToString();
       
    }

    private void Update()
    {
        if (pointsAvailable > 0)
            SetInteractive(true);
        else SetInteractive(false);
            
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

    void SetInteractive(bool mode)
    {
        fate1Toggle.interactable = mode;
        fate2Toggle.interactable = mode;
        skill1Toggle.interactable = mode;
        skill2Toggle.interactable = mode;
        acceptButton.interactable = mode;
    }

    void SetToggleInteractible(Toggle toggle, bool mode)
    {
        toggle.interactable = mode;
    }
}
