using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using UnityEngine.InputSystem;

public abstract class MassagePattern : ScriptableObject
{
	// **Data Fields**
	PlayerInput inputSystem;
	private Gamepad massager;

	// **Properties**
	public PlayerInput InputSystem { get => inputSystem; set => inputSystem = value; }
	public Gamepad Massager { get => massager; set => massager = value; }

	// **Private Methods**


	private void GetGamepad()
	{
		Massager = Gamepad.all.FirstOrDefault(g => InputSystem.devices.Any(d => d.deviceId == g.deviceId));
	}

	// **Public Methods**
	internal void Initialize(PlayerInput playerInput)
	{
		InputSystem = playerInput;
		GetGamepad();
	}

	public abstract void StartMassage();
	public abstract void StopMassage();

	public virtual void DoMassage()
	{
		GetGamepad();
	}
}
