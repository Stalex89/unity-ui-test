using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Script for UI skill cooldown
public class SkillCoolDown : MonoBehaviour 
{
	public string skillButtonAxisName;
	public Image skillIcon;
    public Image charPanelSkillIcon;
	public Image darkMask;
    public Image charPanelDarkMask;
	public Text cooldownText;
    public Text charPanelCooldownText;

	[HideInInspector]
	public float cooldownTimeLeft;
	[HideInInspector]
	public float nextReadyTime;
	public float cooldownDuration;
	


	void Start()
	{
        SkillReady();
	}


	void Update()
	{
		bool cooldownComplete = (Time.time > nextReadyTime);
		if(cooldownComplete)
		{
			SkillReady();
			if(Input.GetButtonDown(skillButtonAxisName) && !EventSystem.current.IsPointerOverGameObject())
				ButtonTriggered();
		}
		else SkillCooldown();
	}

    public void Initialize( /*Assume we have Skill class object passedd*/)
    {
        // Here we initialize all fields with object fields
    }

    // Disable cooldown text and mask when skill is ready
    private void SkillReady()
	{
		cooldownText.enabled = false;
		darkMask.enabled = false;
        charPanelCooldownText.enabled = false;
        charPanelDarkMask.enabled = false;
    }

	private void SkillCooldown()
	{
		cooldownTimeLeft -= Time.deltaTime;
		float roundedCooldown = Mathf.Round(cooldownTimeLeft);
		cooldownText.text = roundedCooldown.ToString();
        charPanelCooldownText.text = roundedCooldown.ToString();
        darkMask.fillAmount = (cooldownTimeLeft/cooldownDuration);
        charPanelDarkMask.fillAmount = (cooldownTimeLeft / cooldownDuration);
    }

	public void ButtonTriggered()
	{
		nextReadyTime = cooldownDuration + Time.time;
		cooldownTimeLeft = cooldownDuration;
		darkMask.enabled = true;
		cooldownText.enabled = true;
        charPanelCooldownText.enabled = true;
        charPanelDarkMask.enabled = true;

        // Call skill initialization
    }

}



