using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSimpleMassage", menuName = "Massage Pattern/Pulse")]
public class PulseMassage : MassagePattern
{
	// **Data Fields**	
	#region Data Fields
	[SerializeField]
	private float minHighSpeed;
	[SerializeField]
	private float maxHighSpeed;
	[SerializeField]
	private float minLowSpeed;
	[SerializeField]
	private float maxLowSpeed;

	[SerializeField]
	private float waveDuration;
	[SerializeField]
	private float restPeriod;

	private float nextStopTime = 0;
	private float currentHigh = 0;
	private float currentLow = 0;
	private bool isRunning = false;
	private bool isPaused = false;
	#endregion

	// **Properties**
	#region Properties
	public float MinHighSpeed { get => minHighSpeed; set => minHighSpeed = value; }
	public float MaxHighSpeed { get => maxHighSpeed; set => maxHighSpeed = value; }
	public float MinLowSpeed { get => minLowSpeed; set => minLowSpeed = value; }
	public float MaxLowSpeed { get => maxLowSpeed; set => maxLowSpeed = value; }
	public float WaveDuration { get => waveDuration; set => waveDuration = value; }
	public float RestPeriod { get => restPeriod; set => restPeriod = value; }

	public float HighStep { get => (MaxHighSpeed - MinLowSpeed) / WaveDuration; }
	public float LowStep { get => (MaxLowSpeed - MinLowSpeed) / WaveDuration; }
	#endregion

	// **Private Methods**
	public override void DoMassage()
	{
		base.DoMassage();

		if (isRunning)
		{
			if (Time.time < nextStopTime
				&& !isPaused)
			{
				currentHigh += HighStep;
				currentLow += LowStep;
				Massager.SetMotorSpeeds(currentLow, currentHigh);
			}
			else if (Time.time >= nextStopTime
					&& !isPaused)
			{
				currentHigh = MinHighSpeed;
				currentLow = MinLowSpeed;
				nextStopTime = Time.time + RestPeriod;
				isPaused = true;
			}
			else if (Time.time >= nextStopTime
					&& isPaused)
			{
				nextStopTime = Time.time + WaveDuration;
				Massager.SetMotorSpeeds(currentLow, currentHigh);
				isPaused = false;
			}
		}
	}

	// **Public Methods**
	public override void StartMassage()
	{
		if (!isRunning)
		{
			nextStopTime = Time.time + WaveDuration;
			currentHigh = MinHighSpeed;
			currentLow = MinLowSpeed;
			Massager.SetMotorSpeeds(currentLow, currentHigh);
			isRunning = true;
		}
	}
	public override void StopMassage()
	{
		if (isRunning)
		{
			Massager.SetMotorSpeeds(0, 0);
			isRunning = false;
		}
	}

	// **Events**
}
