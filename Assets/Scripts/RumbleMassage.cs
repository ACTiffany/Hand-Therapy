using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using UnityEngine.InputSystem;

public class RumbleMassage : MonoBehaviour
{
	// **Data Fields**
	PlayerInput inputSystem;

	private Gamepad massager;
	private bool isMassaging = false;

	// **Properties**
	public PlayerInput InputSystem { get => inputSystem; set => inputSystem = value; }

	public Gamepad Massager { get => massager; set => massager = value; }
	public bool IsMassaging { get => isMassaging; set => isMassaging = value; }

	// **Constructors**

	// **Private Methods**
	private Gamepad GetGamepad()
	{
		return Gamepad.all.FirstOrDefault(g => InputSystem.devices.Any(d => d.deviceId == g.deviceId));
	}
	
	private void StartMassage()
	{
		Massager.SetMotorSpeeds(1, 1);
	}
	private void StopMassage()
	{
		Massager.SetMotorSpeeds(0, 0);
	}

	// **Public Methods**
	private void Awake()
	{
		InputSystem = GetComponent<PlayerInput>();
	}
	private void Update()
	{
		Massager = GetGamepad();
	}

	private void OnDestroy()
	{
		Massager.SetMotorSpeeds(0, 0);
	}
	// **Events**
	public void OnStart()
	{
		StartMassage();
	}
	public void OnStop()
	{
		StopMassage();
	}
}
