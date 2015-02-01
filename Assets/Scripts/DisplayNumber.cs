using UnityEngine;
using System.Collections;

public class DisplayNumber : MonoBehaviour 
{
	[Range (-1,1)]
	public int facing;
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 cameraPos = Camera.main.transform.position;
		transform.LookAt(cameraPos);
		transform.Rotate(new Vector3(180, 0, 180));
	}
}
