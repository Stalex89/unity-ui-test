using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script for UI skill cooldown
public class SkillCoolDown : MonoBehaviour 
{
	public string skillButtonAxisName;
	public Image skillIcon;
	public Image darkMask;
	public Text cooldownText;

	[HideInInspector]
	public float cooldownTimeLeft;
	[HideInInspector]
	public float nextReadyTime;
	public float cooldownDuration;
	
	public void Initialize()
	{
		SkillReady();
	}

	void Start()
	{	
		Initialize();
	}


	void Update()
	{
		bool cooldownComplete = (Time.time > nextReadyTime);
		if(cooldownComplete)
		{
			SkillReady();
			if(Input.GetButtonDown(skillButtonAxisName))
			{
				ButtonTriggered();
			}
		}
		else SkillCooldown();
	}

	// Disable cooldown text and mask when skill is ready
	private void SkillReady()
	{
		cooldownText.enabled = false;
		darkMask.enabled = false;
	}

	private void SkillCooldown()
	{
		cooldownTimeLeft -= Time.deltaTime;
		float roundedCooldown = Mathf.Round(cooldownTimeLeft);
		cooldownText.text = roundedCooldown.ToString();
		darkMask.fillAmount = (cooldownTimeLeft/cooldownDuration);
	}

	private void ButtonTriggered()
	{
		nextReadyTime = cooldownDuration + Time.time;
		cooldownTimeLeft = cooldownDuration;
		darkMask.enabled = true;
		cooldownText.enabled = true;

		// Call skill initialization
	}

}



