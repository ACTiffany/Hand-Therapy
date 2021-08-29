using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "NewSimpleMassage", menuName ="Massage Pattern/Simple")]
public class SimpleMassage : MassagePattern
{
	// **Data Fields**
	[SerializeField]
	private float highSpeed;
	[SerializeField]
	private float lowSpeed;
	// **Properties**
	public float HighSpeed { get => highSpeed; set => highSpeed = value; }
	public float LowSpeed { get => lowSpeed; set => lowSpeed = value; }

	// **Public Methods**
	public override void StartMassage()
	{
		Massager.SetMotorSpeeds(LowSpeed, HighSpeed);
	}
	public override void StopMassage()
	{
		Massager.SetMotorSpeeds(0, 0);
	}
	// **Events**
}
