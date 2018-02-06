using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerEnergyBar : MonoBehaviour {

	public float playerMaxEnergy;
	public float playerMaxEnergyIncrease;
	public float playerEnergyRegenPerSecond;
	public float playerEnergyRegenIncrease;
	public float playerCurrentEnergy;
	public float energyConsumed;
	float playerEnergyFillWidth;
	float playerEnergyBackgroundWidth;
	public float playerEnergyBarWidthIncrease;
	public Image playerEnergyBackground;
	public Image playerEnergyFill;
	public Text	playerEnergyValue;

	RectTransform playerEnergyBackgroundRect;
	RectTransform playerEnergyFillRect;


	// Use this for initialization
	void Start () 
	{
		playerCurrentEnergy = playerMaxEnergy;
		playerEnergyBackgroundRect = playerEnergyBackground.rectTransform;
		playerEnergyFillRect = playerEnergyFill.rectTransform;

		//playerHPBackgroundWidth = playerHPBackground.rectTransform.rect.width;
		//playerHPFillWidth = playerHPFill.rectTransform.rect.width;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (playerCurrentEnergy < playerMaxEnergy)
		{
			RegeneratePlayerEnergy();
		}


		if (Input.GetKeyDown(KeyCode.X) && playerCurrentEnergy > 0)
		{
			PlayerConsumeEnergy();
		}

		if (Input.GetKeyDown(KeyCode.W) && playerMaxEnergy < 350)
		{
			IncreasePlayerMaxEnergy();
		}

		if (Input.GetKeyDown(KeyCode.S) && playerEnergyRegenPerSecond < 30)
		{
			IncreasePlayerEnergyRegen();
		}

		UpdatePlayerEnergyValueText();

	}

	void PlayerConsumeEnergy()
	{
		if(playerCurrentEnergy >= energyConsumed)
		{
			playerCurrentEnergy -= energyConsumed;
			playerEnergyFill.transform.localScale = new Vector3((playerCurrentEnergy / playerMaxEnergy),1,1);
		}
		else
		{
			playerCurrentEnergy = 0;
			playerEnergyFill.transform.localScale = new Vector3((playerCurrentEnergy),1,1);
		}
	}

	void RegeneratePlayerEnergy()
	{
		playerCurrentEnergy += playerEnergyRegenPerSecond * Time.deltaTime;
		playerEnergyFill.transform.localScale = new Vector3((playerCurrentEnergy / playerMaxEnergy),1,1);
	}

	void IncreasePlayerMaxEnergy()
	{
		playerMaxEnergy += playerMaxEnergyIncrease;
		playerEnergyBackground.rectTransform.sizeDelta = new Vector2(playerEnergyBackgroundRect.rect.width + 
		playerEnergyBarWidthIncrease, playerEnergyBackgroundRect.rect.height);
		playerEnergyFill.rectTransform.sizeDelta = new Vector2(playerEnergyFillRect.rect.width + 
		playerEnergyBarWidthIncrease, playerEnergyFillRect.rect.height);

		//playerHPBackgroundWidth += HPBarWidthIncrease;
		//playerHPFillWidth += HPBarWidthIncrease;
		//playerHPBackground.rectTransform.sizeDelta = new Vector2(playerHPBackgroundWidth,20);
		//playerHPFill.rectTransform.sizeDelta = new Vector2(playerHPFillWidth,16);
	
	}

	void IncreasePlayerEnergyRegen()
	{
		playerEnergyRegenPerSecond += playerEnergyRegenIncrease;
	}

	void UpdatePlayerEnergyValueText()
	{
		playerEnergyValue.text = ((int)(playerCurrentEnergy)).ToString() + " / " + ((int)(playerMaxEnergy)).ToString();
	}

}
