using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeOnClick : MonoBehaviour 
{
	private bool flag = false;
	private bool yesFlag = false;
	private bool maybeFlag = false;
	public static Color visColor = new Color (1.0f, 1.0f, 1.0f, 1.0f);
	public static Color invColor = new Color (1.0f, 1.0f, 1.0f, 0.0f);
	public static Color clickColor = new Color(1.0f, 1.0f, 1.0f, 0.1f);

	// Use this for initialization
	void Start () 
	{

	}
	
	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0) && !flag) 
		{
			Debug.Log("Object clicked!");
			renderer.material.color = clickColor;
			Destroy(GetComponent<Collider> ());
			Debug.Log("collider deleted");
			CubeContents script = GetComponent<CubeContents>();
			script.DisplayContents(); 
		}
		else if (Input.GetMouseButtonDown(1))
		{
			//if no flag, set yesflag
			if(!yesFlag && !maybeFlag)
			{
				yesFlag = true;
				renderer.materials[1].color = visColor;
			}
			//if yesFlag set maybeFlag
			else if (yesFlag)
			{
				yesFlag = false;
				renderer.materials[1].color = invColor;
				maybeFlag = true;
				renderer.materials[2].color = visColor;
			}
			else if (maybeFlag)
			{
				maybeFlag = false;
				renderer.materials[2].color = invColor;
			}
			
			//set flag to prevent left click
			if (yesFlag || maybeFlag)
			{
				flag = true;
			}
			else
			{
				flag = false;
			}
			Debug.Log("Right Click, flag set to " + flag);
		}
	}
}
