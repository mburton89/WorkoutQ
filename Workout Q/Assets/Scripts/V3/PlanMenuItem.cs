using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlanMenuItem : UIPanel {

	private AddPlanPanel _addPlanPanel;

	public PlanData planData;
	public TextMeshProUGUI planName;
	public TextMeshProUGUI statsText;
	public FitBoyDifficulty fitBoyDifficulty;

	private const string WORKOUTS_PER_WEEK_LABEL = " workouts per week";

	public void Init(AddPlanPanel addPlanPanel, PlanData planData)
	{
		_addPlanPanel = addPlanPanel;
		this.planData = planData;
		planName.text = planData.name;
		statsText.text = planData.workoutsPerWeek() + WORKOUTS_PER_WEEK_LABEL; 
		UpdateColor ();
		fitBoyDifficulty.Init(WorkoutGenerator.Instance.GetSpriteForDifficulty(planData.planDifficulty));
	}
		
	public void HandleSelfClicked(){
		Unhighlight ();
		_addPlanPanel.ShowWorkoutsForPlan (planData);
		SoundManager.Instance.PlayButtonPressSound ();
	}
}
