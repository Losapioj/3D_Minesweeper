using UnityEngine;
using System.Collections;

public class EventMngr : MonoBehaviour 
{

	//public delegate void CubeClickedAction(int x, int y);
	//public static event CubeClickedAction CubeClickEvent;
	
	public delegate void ResetLevel();
	public static event ResetLevel ResetLevelEvent;
	
	//private GUI.Button ResLvlButton;
	
	// Use this for initialization
	void Start () 
	{
		//ResLvlButton = 
	}
	
	void OnGUI()
	{
		if(GUI.Button(new Rect(Screen.width/2 - 50, 5, 100, 30), "Reset Level"))
		{
			if (ResetLevelEvent != null)
			{
				ResetLevelEvent();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
