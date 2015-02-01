using UnityEngine;
using System.Collections;

public class SpawnLevel3D : MonoBehaviour 
{
	
	const int BOMB_INT = -1;
	
	static int LEVEL_SIZE = 5;
	static int BOMB_TOTAL = 30;
	
	public Object bombCube;
	public Object blankCube;
	public Object oneCube;
	public Object twoCube;
	public Object thrCube;
	public Object fouCube;
	public Object fivCube;
	public Object sixCube;
	public Object sevCube;
	public Object eigCube;
	//public CubeContents contents;
	private int[,,] levelIntArray = new int[LEVEL_SIZE,LEVEL_SIZE,LEVEL_SIZE];
	private Object[,,] levelObjArray = new Object[LEVEL_SIZE,LEVEL_SIZE,LEVEL_SIZE];
	
	
	// Use this for initialization
	void Start () 
	{
		SetupLevel();
	}
	
	void SetupLevel()
	{
		//initialize bombs into array 
		//Init all arrays
		//for (int i = 0; i < levelIntArray.GetLength; i++)
		//{
		//	levelIntArray[i] = new int[LEVEL_SIZE];
		//	levelObjArray[i] = new Object[LEVEL_SIZE];
		//}
		
		//init all to 0 at start
		for (int i = 0; i < levelIntArray.GetLength(0); i++)
		{
			for (int j = 0; j < levelIntArray.GetLength(1); j++)
			{
				for (int k = 0; k < levelIntArray.GetLength(2); k++)
				{
					levelIntArray[i,j,k] = 0;
					Debug.Log("I: " + i + " J: " + j + " K: " + k);
				}
			}
		}
		
		//set bombs in array
		int bombAddIndex = 0;
		while (bombAddIndex < BOMB_TOTAL)
		{
			int x = Random.Range(0, levelIntArray.GetLength(0) - 1);
			int y = Random.Range(0, levelIntArray.GetLength(1) - 1);
			int z = Random.Range(0, levelIntArray.GetLength(2) - 1);
			
			if(levelIntArray[x,y,z] == -1)
			{
				continue;
			}
			
			levelIntArray[x,y,z] = -1;
			Debug.Log("BOMB AT x: " + x + " y: " + y);
			bombAddIndex++;
		}
		
		//set other numbers based on bombs next door
		for (int i = 0; i < levelIntArray.GetLength(0); i++)
		{
			for (int j = 0; j < levelIntArray.GetLength(1); j++)
			{
				for(int k = 0; k < levelIntArray.GetLength(2); k++)
				{
					//Debug.Log("I: " + i + " J: " + j);
					bool aboveSafe, belowSafe, leftSafe, rightSafe, behindSafe, infrontSafe;
					leftSafe = i > 0;
					aboveSafe = j > 0;
					behindSafe = k > 0;
					rightSafe = i < (levelIntArray.GetLength(0) - 1);
					belowSafe = j < (levelIntArray.GetLength(1) - 1);
					infrontSafe = k < (levelIntArray.GetLength(2) - 1);
					
					//do not adjust bomb values
					if(levelIntArray[i,j,k] == BOMB_INT)
					{
						levelObjArray[i,j,k] = Instantiate(bombCube, 
						                                   new Vector3((-LEVEL_SIZE/2 + i), (-LEVEL_SIZE/2 + j), (-LEVEL_SIZE/2 + k)),
						                                   Quaternion.LookRotation(new Vector3(0.0f, 0.0f, -1.0f))
						                                   );
						Debug.Log("I: " + i + " J: " + j + " = " + levelIntArray[i,j,k]);
						continue;
					}
					
					//check left, left/above, left/below
					if(leftSafe) //left is safe to access
					{
						if(levelIntArray[i-1,j,k] == BOMB_INT)
							levelIntArray[i,j,k] ++;
					}
					//check right, right/above, right/below
					if(rightSafe) //right is safe to access
					{
						if(levelIntArray[i+1,j,k] == BOMB_INT)
							levelIntArray[i,j,k] ++;
					}
					//check JUST above
					if(aboveSafe)
					{
						if(levelIntArray[i,j-1,k] == BOMB_INT)
							levelIntArray[i,j,k] ++;
					}
					//check JUST below
					if(belowSafe)
					{
						if(levelIntArray[i,j+1,k] == BOMB_INT)
							levelIntArray[i,j,k] ++;
					}
					if(behindSafe)
					{
						if(levelIntArray[i,j,k-1] == BOMB_INT)
							levelIntArray[i,j,k] ++;
					}
					if(infrontSafe)
					{
						if(levelIntArray[i,j,k+1] == BOMB_INT)
							levelIntArray[i,j,k] ++;
					}
					
					Debug.Log("I: " + i + " J: " + j + " = " + levelIntArray[i,j,k]);
					
					//spawn cube with appropriate number
					switch (levelIntArray[i,j,k])
					{
					case 0:
						levelObjArray[i,j,k] = Instantiate(blankCube, 
						                                   new Vector3((-LEVEL_SIZE/2 + i), (-LEVEL_SIZE/2 + j), (-LEVEL_SIZE/2 + k)),
						                                   Quaternion.LookRotation(new Vector3(0.0f, 0.0f, -1.0f))
						                                   );
						break;
					case 1:
						levelObjArray[i,j,k] = Instantiate(oneCube, 
						                                   new Vector3((-LEVEL_SIZE/2 + i), (-LEVEL_SIZE/2 + j), (-LEVEL_SIZE/2 + k)),
						                                   Quaternion.LookRotation(new Vector3(0.0f, 0.0f, -1.0f))
						                                   );
						break;
					case 2:
						levelObjArray[i,j,k] = Instantiate(twoCube, 
						                                   new Vector3((-LEVEL_SIZE/2 + i), (-LEVEL_SIZE/2 + j), (-LEVEL_SIZE/2 + k)),
						                                   Quaternion.LookRotation(new Vector3(0.0f, 0.0f, -1.0f))
						                                   );
						break;
					case 3:
						levelObjArray[i,j,k] = Instantiate(thrCube, 
						                                   new Vector3((-LEVEL_SIZE/2 + i), (-LEVEL_SIZE/2 + j), (-LEVEL_SIZE/2 + k)),
						                                   Quaternion.LookRotation(new Vector3(0.0f, 0.0f, -1.0f))
						                                   );
						break;
					case 4:
						levelObjArray[i,j,k] = Instantiate(fouCube, 
						                                   new Vector3((-LEVEL_SIZE/2 + i), (-LEVEL_SIZE/2 + j), (-LEVEL_SIZE/2 + k)),
						                                   Quaternion.LookRotation(new Vector3(0.0f, 0.0f, -1.0f))
						                                   );
						break;
					case 5:
						levelObjArray[i,j,k] = Instantiate(fivCube, 
						                                   new Vector3((-LEVEL_SIZE/2 + i), (-LEVEL_SIZE/2 + j), (-LEVEL_SIZE/2 + k)),
						                                   Quaternion.LookRotation(new Vector3(0.0f, 0.0f, -1.0f))
						                                   );
						break;
					case 6:
						levelObjArray[i,j,k] = Instantiate(sixCube, 
						                                   new Vector3((-LEVEL_SIZE/2 + i), (-LEVEL_SIZE/2 + j), (-LEVEL_SIZE/2 + k)),
						                                   Quaternion.LookRotation(new Vector3(0.0f, 0.0f, -1.0f))
						                                   );
						break;
					case 7:
						levelObjArray[i,j,k] = Instantiate(sevCube, 
						                                   new Vector3((-LEVEL_SIZE/2 + i), (-LEVEL_SIZE/2 + j), (-LEVEL_SIZE/2 + k)),
						                                   Quaternion.LookRotation(new Vector3(0.0f, 0.0f, -1.0f))
						                                   );
						break;
					case 8:
						levelObjArray[i,j,k] = Instantiate(eigCube, 
						                                   new Vector3((-LEVEL_SIZE/2 + i), (-LEVEL_SIZE/2 + j), (-LEVEL_SIZE/2 + k)),
						                                   Quaternion.LookRotation(new Vector3(0.0f, 0.0f, -1.0f))
						                                   );
						break;
						
					default:
						
						break;
					}
				}
			}
			
		}
		
		
		//create cubes to represent level array
		for (int i = 0; i < levelIntArray.GetLength(0); i++)
		{
			for (int j = 0; j < levelIntArray.GetLength(1); j++)
			{
				
			}
		}
	}
	
	void ResetLevel()
	{
		for(int i = 0; i < levelObjArray.GetLength(0); i++)
		{
			for(int j = 0; j < levelObjArray.GetLength(1); j++)
			{
				for(int k = 0; k < levelObjArray.GetLength(2); k++)
				{
					Debug.Log ("destroying object");
					Destroy(levelObjArray[i,j,k]);
					levelIntArray[i,j,k] = 0;
				}
			}
		}
		SetupLevel();
	}
	
	// Event methods for when a cube is clicked, to display contents
	void OnEnable()
	{
		EventMngr.ResetLevelEvent += ResetLevel;
	}
	
	void OnDisable()
	{
		EventMngr.ResetLevelEvent -= ResetLevel;
	}
}
