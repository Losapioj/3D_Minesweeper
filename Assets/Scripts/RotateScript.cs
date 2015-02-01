using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {

public float xrot;
public float yrot;
public float zrot;

	// Use this for initialization
	void Start () 
	{
		Quaternion quat = Quaternion.FromToRotation(renderer.transform.rotation.eulerAngles,
								  new Vector3(xrot, yrot, zrot));
		renderer.transform.rotation = quat;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
