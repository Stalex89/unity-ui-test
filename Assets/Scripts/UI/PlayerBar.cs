using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerBar : MonoBehaviour {
	public float barMaxValue;
	public float barMaxValueIncrease;
	public float barValueRegenPerSecond;
	public float barValueRegenIncrease;
	public float barCurrentValue;
	public float barReduceValue;
	float barFillWidth;
	float barBackgroundWidth;
	public float barWidthIncrease;
	public Image barBackground;
	public Image barFill;
	public Text	barTextValue;

	public KeyCode ReduceCurrentValueKey;
	public KeyCode IncreaseMaxValueKey;
	public KeyCode IncreaseRegenValueKey;


	RectTransform barBackgroundRect;
	RectTransform barFillRect;


	// Use this for initialization
	void Start () 
	{
		barCurrentValue = barMaxValue;
		barBackgroundRect = barBackground.rectTransform;
		barFillRect = barFill.rectTransform;

		//playerHPBackgroundWidth = playerHPBackground.rectTransform.rect.width;
		//playerHPFillWidth = playerHPFill.rectTransform.rect.width;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (barCurrentValue < barMaxValue)
			RegenerateBarCurrentValue();

		if (Input.GetKeyDown(ReduceCurrentValueKey) && barCurrentValue > 0)
			ReduceBarCurrentValue();

		if (Input.GetKeyDown(IncreaseMaxValueKey))
			IncreaseBarMaxValue();

		if (Input.GetKeyDown(IncreaseRegenValueKey))
			IncreaseBarValueRegen();

		UpdateBarValueText();

	}

	void ReduceBarCurrentValue()
	{
		if(barCurrentValue >= barReduceValue)
		{
			barCurrentValue -= barReduceValue;
			barFill.transform.localScale = new Vector3((barCurrentValue / barMaxValue),1,1);
		}
		else
		{
			barCurrentValue = 0;
			barFill.transform.localScale = new Vector3((barCurrentValue),1,1);
		}
	}

	void RegenerateBarCurrentValue()
	{
		barCurrentValue += barValueRegenPerSecond * Time.deltaTime;
		barFill.transform.localScale = new Vector3((barCurrentValue / barMaxValue),1,1);
	}

	void IncreaseBarMaxValue()
	{
		barMaxValue += barMaxValueIncrease;
		barBackground.rectTransform.sizeDelta = new Vector2(barBackgroundRect.rect.width + 
		barWidthIncrease, barBackgroundRect.rect.height);
		barFill.rectTransform.sizeDelta = new Vector2(barFillRect.rect.width + 
		barWidthIncrease, barFillRect.rect.height);

		//playerHPBackgroundWidth += HPBarWidthIncrease;
		//playerHPFillWidth += HPBarWidthIncrease;
		//playerHPBackground.rectTransform.sizeDelta = new Vector2(playerHPBackgroundWidth,20);
		//playerHPFill.rectTransform.sizeDelta = new Vector2(playerHPFillWidth,16);
	
	}

	void IncreaseBarValueRegen()
	{
		barValueRegenPerSecond += barValueRegenIncrease;
	}

	void UpdateBarValueText()
	{
		barTextValue.text = ((int)(barCurrentValue)).ToString() + " / " + ((int)(barMaxValue)).ToString();
	}

}


