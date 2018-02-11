using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PanelManager : MonoBehaviour 
{

	// public GameObject panel;

	// public void TogglePanelFunction()
	// {
	// 	if(panel.gameObject.activeSelf == true)
	// 		panel.gameObject.SetActive(false);
	// 	else panel.gameObject.SetActive(true);

	// }

	GameObject openedPanel;

	public void TogglePanel(GameObject currentPanel)
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
