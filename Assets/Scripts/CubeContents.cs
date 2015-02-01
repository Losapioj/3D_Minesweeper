using UnityEngine;
using System.Collections;

public class CubeContents : MonoBehaviour 
{
	//in case contents needs a special texture applied to it
	public Texture tex = null;
	
	//decides if looks at or away from target
	//-1 away, 1 towards, 0 ignores target
	[Range (-1,1)]
	public int facing;
	
	public Object contents = null;
	public Transform target = null;
	void Start()
	{
		if(contents != null)
		{
			contents = Instantiate(contents, renderer.transform.position, Quaternion.identity);
			if(tex != null)
			{
				Renderer rend;
				rend = ((GameObject)contents).GetComponent<Renderer>();
				rend.material.SetTexture("Transparent Diffuse",tex);
			}
			Debug.Log ("Contents created!");
			HideContents();
		}
	}
	
	public void HideContents()
	{
		if (contents != null)
		{
			Color col = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			((GameObject)contents).GetComponent<Renderer>().materials[0].color = col;
		}
	}
	public void DisplayContents()
	{
		if (contents != null)
		{
			Color col = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			((GameObject)contents).GetComponent<Renderer>().materials[0].color = col;
		}
	}
	
	void OnDestroy()
	{
		Destroy(contents);
	}
	
	void Update()
	{
	}
}




