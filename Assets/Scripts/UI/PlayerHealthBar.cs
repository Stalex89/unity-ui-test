using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerHealthBar : MonoBehaviour {

	public float playerMaxHP;
	public float playerMaxHPIncrease;
	public float playerHPRegenPerSecond;
	public float playerHPRegenIncrease;
	public float playerCurrentHP;
	public float damageTaken;
	float playerHPFillWidth;
	float playerHPBackgroundWidth;
	public float playerHPBarWidthIncrease;
	public Image playerHPBackground;
	public Image playerHPFill;
	public Text	playerHPValue;

	RectTransform playerHPBackgroundRect;
	RectTransform playerHPFillRect;


	// Use this for initialization
	void Start () 
	{
		playerCurrentHP = playerMaxHP;
		playerHPBackgroundRect = playerHPBackground.rectTransform;
		playerHPFillRect = playerHPFill.rectTransform;

		//playerHPBackgroundWidth = playerHPBackground.rectTransform.rect.width;
		//playerHPFillWidth = playerHPFill.rectTransform.rect.width;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (playerCurrentHP < playerMaxHP && playerCurrentHP > 0)
		{
			RegeneratePlayerHP();
		}


		if (Input.GetKeyDown(KeyCode.Z) && playerCurrentHP > 0)
		{
			PlayerTakeDamage();
		}

		if (Input.GetKeyDown(KeyCode.Q) && playerMaxHP < 150)
		{
			IncreasePlayerMaxHP();
		}

		if (Input.GetKeyDown(KeyCode.A) && playerHPRegenPerSecond < 30)
		{
			IncreasePlayerHPRegen();
		}

		UpdatePlayerHPValueText();

	}

	void PlayerTakeDamage()
	{
		if(playerCurrentHP >= damageTaken)
		{
			playerCurrentHP -= damageTaken;
			playerHPFill.transform.localScale = new Vector3((playerCurrentHP / playerMaxHP),1,1);
		}
		else
		{
			playerCurrentHP = 0;
			playerHPFill.transform.localScale = new Vector3((playerCurrentHP),1,1);
		}
	}

	void RegeneratePlayerHP()
	{
		playerCurrentHP += playerHPRegenPerSecond * Time.deltaTime;
		playerHPFill.transform.localScale = new Vector3((playerCurrentHP / playerMaxHP),1,1);
	}

	void IncreasePlayerMaxHP()
	{
		playerMaxHP += playerMaxHPIncrease;
		playerHPBackground.rectTransform.sizeDelta = new Vector2(playerHPBackgroundRect.rect.width + 
		playerHPBarWidthIncrease, playerHPBackgroundRect.rect.height);
		playerHPFill.rectTransform.sizeDelta = new Vector2(playerHPFillRect.rect.width + 
		playerHPBarWidthIncrease, playerHPFillRect.rect.height);

		//playerHPBackgroundWidth += HPBarWidthIncrease;
		//playerHPFillWidth += HPBarWidthIncrease;
		//playerHPBackground.rectTransform.sizeDelta = new Vector2(playerHPBackgroundWidth,20);
		//playerHPFill.rectTransform.sizeDelta = new Vector2(playerHPFillWidth,16);
	
	}

	void IncreasePlayerHPRegen()
	{
		playerHPRegenPerSecond += playerHPRegenIncrease;
	}

	void UpdatePlayerHPValueText()
	{
		playerHPValue.text = ((int)(playerCurrentHP)).ToString() + " / " + ((int)(playerMaxHP)).ToString();
	}

}
