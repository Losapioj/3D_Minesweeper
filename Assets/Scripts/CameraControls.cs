using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour 
{

	public GameObject target = null;
	private float speedMod = 50.0f;
	private Vector3 point;
	private Vector3 defaultCameraPos;
	// Use this for initialization
	void Start () 
	{
		if(target != null)
		{
			point = target.GetComponent<Renderer>().transform.position;
		}
		else
		{
			point = new Vector3(0, 0, 0);
		}
		transform.LookAt(point);
		
	}
	
/*	void Activate()
	{
		defaultCameraPos = transform.position;
	}*/
	
	// Update is called once per frame
	void Update () 
	{
		//rotate up
		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			transform.RotateAround(point, transform.right, Time.deltaTime * speedMod);
		}
		//rotate left
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			transform.RotateAround(point, transform.up, Time.deltaTime * speedMod);
		}
		//rotate right
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			transform.RotateAround(point, transform.up, Time.deltaTime * -speedMod);
		}
		//rotate down
		if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			transform.RotateAround(point, transform.right, Time.deltaTime * -speedMod);
		}
		//spin left
		if(Input.GetKey(KeyCode.Q))
		{
			transform.RotateAround(point, transform.forward, Time.deltaTime * speedMod);
		}
		//spin right
		if(Input.GetKey(KeyCode.E))
		{
			transform.RotateAround(point, transform.forward, Time.deltaTime * -speedMod);
		}
		//mouse wheel down
		if(Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			transform.position -= transform.forward * Time.deltaTime * speedMod/2;
		}
		//mouse wheel down
		if(Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			transform.position += transform.forward * Time.deltaTime * speedMod/2;
		}
	}
	
/*	void ResetCamPos()
	{
		transform.position = defaultCameraPos;
	}
	void OnEnable()
	{
		EventMngr.ResetLevelEvent += ResetCamPos;
	}
	void OnDisable()
	{
		EventMngr.ResetLevelEvent -= ResetCamPos;
	}*/
}





