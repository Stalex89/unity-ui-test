using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TogglePanel: MonoBehaviour 
{

	GameObject openedPanel;

    private void Start()
    {
        openedPanel = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && openedPanel != null)
        {
            openedPanel.gameObject.SetActive(false);
            openedPanel = null;
        }
    }

    public void Paneltoggle(GameObject currentPanel)
	{
		if (openedPanel != null)
			openedPanel.gameObject.SetActive(false);

		if(openedPanel == currentPanel)
			openedPanel = null;
		else
		{
			openedPanel = currentPanel;
			openedPanel.gameObject.SetActive(true);
		}
	}
}
