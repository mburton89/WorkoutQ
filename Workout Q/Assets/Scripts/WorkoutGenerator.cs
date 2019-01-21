using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkoutGenerator : MonoBehaviour {

	public static WorkoutGenerator Instance;

	public WorkoutData ExampleChestTricep;
	public WorkoutData ExampleBackBicep;
	public WorkoutData ExampleLegs;
	public WorkoutData ExampleShoulders;
	public WorkoutData ExampleCore;	

	void Awake()
	{
		Instance = this;
	}
}
