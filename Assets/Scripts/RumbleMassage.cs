using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using UnityEngine.InputSystem;

public class RumbleMassage : MonoBehaviour
{
	// **Data Fields**
	[SerializeField]
	private MassagePattern currentMassage;
	private bool isMassaging = false;


	// **Properties**
	public MassagePattern CurrentMassage { get => currentMassage; set => currentMassage = value; }
	public bool IsMassaging { get => isMassaging; set => isMassaging = value; }

	// **Private Methods**
	private void Awake()
	{
		CurrentMassage.Initialize(GetComponent<PlayerInput>());
	}
	private void OnDestroy()
	{
		CurrentMassage.StopMassage();
	}

	private void Update()
	{
		CurrentMassage.DoMassage();
	}
	// **Public Methods**

	// **Events**
	public void OnStart()
	{
		if (!isMassaging)
		{
			CurrentMassage.StartMassage();
			isMassaging = true;
		}
	}
	public void OnStop()
	{
		if (isMassaging)
		{
			CurrentMassage.StopMassage();
			isMassaging = false;
		}
	}

	//public void OnIncreaseHigh()
	//{
	//	HighSpeed += .1f;
	//}
	//public void OnDecreaseHigh()
	//{
	//	HighSpeed -= .1f;
	//}
	//public void OnIncreaseLow()
	//{
	//	LowSpeed += .1f;
	//}
	//public void OnDecreaseLow()
	//{
	//	LowSpeed -= .1f;
	//}
}
