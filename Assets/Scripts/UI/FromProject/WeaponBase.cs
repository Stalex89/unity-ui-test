using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
	[System.NonSerialized]
	public bool isUnlocked = false;

#region Requirements
	public ProgressionManager.Fate[] requiredFates;
	public WeaponBase[] requiredSkills;

	public bool MeetsRequirements()
	{
		var manager = GetComponentInParent<ProgressionManager>();
		foreach (var itRequired in requiredFates)
		{
			bool found = false;
			foreach (var itOwned in manager.chosenFates)
				if (itOwned.name == itRequired.name && itOwned.lvl >= itRequired.lvl)
				{
					found = true;
					break;
				}

			if (!found)
				return false;
		}

		foreach (var itRequired in requiredSkills)
			if (!itRequired.isUnlocked)
				return false;
		
		return true;
	}
#endregion Requirements

	EnergyController resource;
	public float cost;

	[System.NonSerialized]
	public string buttonCode;
	public Timer cd = new Timer(0.5f);
	[System.NonSerialized]
	public new AudioSource audio;

	public PlayerMovement movement;
	public string displayName;
	public string description;

	protected void Start()
	{
		resource = GetComponentInParent<EnergyController>();
		audio = GetComponent<AudioSource>();
	}

	protected void PlaySound()
	{
		if (audio)
			audio.Play();
	}
	protected bool CastSkill()
	{
		if (cd.isReady() && resource.Spend(cost) )
		{
			cd.restart();
			return true;
		}
		return false;
	}
}
