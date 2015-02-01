using UnityEngine;
using System.Collections;

public class SpawnLevel : MonoBehaviour 
{

	const int BOMB_INT = -1;
	
	const int LEVEL_SIZE = 10;
	const int BOMB_TOTAL = 15;
	
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
	private int[,] levelIntArray = new int[LEVEL_SIZE,LEVEL_SIZE];
	private Object[,] levelObjArray = new Object[LEVEL_SIZE,LEVEL_SIZE];
	
	
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
				levelIntArray[i,j] = 0;
				Debug.Log("I: " + i + " J: " + j);
			}
		}
		
		//set bombs in array
		int bombAddIndex = 0;
		while (bombAddIndex < BOMB_TOTAL)
		{
			int x = Random.Range(0, LEVEL_SIZE);
			int y = Random.Range(0, LEVEL_SIZE);
			
			if(levelIntArray[x,y] == -1)
			{
				continue;
			}
			
			levelIntArray[x,y] = -1;
			Debug.Log("BOMB AT x: " + x + " y: " + y);
			bombAddIndex++;
		}
		
		//set other numbers based on bombs next door
		for (int i = 0; i < levelIntArray.GetLength(0); i++)
		{
			
			for (int j = 0; j < levelIntArray.GetLength(1); j++)
			{
				//Debug.Log("I: " + i + " J: " + j);
				bool aboveSafe, belowSafe, leftSafe, rightSafe;
				leftSafe = i > 0;
				aboveSafe = j > 0;
				rightSafe = i < (levelIntArray.GetLength(0) - 1);
				belowSafe = j < (levelIntArray.GetLength(1) - 1);
				
				//do not adjust bomb values
				if(levelIntArray[i,j] == BOMB_INT)
				{
					Debug.Log("I: " + i + " J: " + j + " = " + levelIntArray[i,j]);
					continue;
				}
				//check left, left/above, left/below
				if(leftSafe) //left is safe to access
				{
					if(levelIntArray[i-1,j] == BOMB_INT)
						levelIntArray[i,j] ++;
					
					if(aboveSafe) //left/above is safe
					{
						if(levelIntArray[i-1,j-1] == BOMB_INT)
							levelIntArray[i,j] ++;
					}
					if(belowSafe) //left/below is safe
					{
						if(levelIntArray[i-1,j+1] == BOMB_INT)
							levelIntArray[i,j] ++;
					}
				}
				//check right, right/above, right/below
				if(rightSafe) //right is safe to access
				{
					if(levelIntArray[i+1,j] == BOMB_INT)
						levelIntArray[i,j] ++;
					
					if(aboveSafe) //right/above is safe
					{
						if(levelIntArray[i+1,j-1] == BOMB_INT)
							levelIntArray[i,j] ++;
					}
					if(belowSafe) //right/below is safe
					{
						if(levelIntArray[i+1,j+1] == BOMB_INT)
							levelIntArray[i,j] ++;
					}
				}
				//check JUST above
				if(aboveSafe)
				{
					if(levelIntArray[i,j-1] == BOMB_INT)
						levelIntArray[i,j] ++;
				}
				//check JUST below
				if(belowSafe)
				{
					if(levelIntArray[i,j+1] == BOMB_INT)
						levelIntArray[i,j] ++;
				}
				
				Debug.Log("I: " + i + " J: " + j + " = " + levelIntArray[i,j]);
			}
			
		}
		
		
		//create cubes to represent level array
		for (int i = 0; i < levelIntArray.GetLength(0); i++)
		{
			for (int j = 0; j < levelIntArray.GetLength(1); j++)
			{
				//spawn bomb cube if bomb
				switch (levelIntArray[i,j])
				{
				case 0:
					levelObjArray[i,j] = Instantiate(blankCube, 
					                                  new Vector3((-LEVEL_SIZE/2 + i), 
					            (-LEVEL_SIZE/2 + j), 
					            0.0f),
					                                  Quaternion.LookRotation(new Vector3(0.0f, 
					                                    0.0f, 
					                                    -1.0f))
					                                  );
					break;
				case 1:
					levelObjArray[i,j] = Instantiate(oneCube, 
					                                  new Vector3((-LEVEL_SIZE/2 + i), 
					            (-LEVEL_SIZE/2 + j), 
					            0.0f),
					                                  Quaternion.LookRotation(new Vector3(0.0f, 
					                                    0.0f, 
					                                    -1.0f))
					                                  );
					break;
				case 2:
					levelObjArray[i,j] = Instantiate(twoCube, 
					                                  new Vector3((-LEVEL_SIZE/2 + i), 
					            (-LEVEL_SIZE/2 + j), 
					            0.0f),
					                                  Quaternion.LookRotation(new Vector3(0.0f, 
					                                    0.0f, 
					                                    -1.0f))
					                                  );
					break;
				case 3:
					levelObjArray[i,j] = Instantiate(thrCube, 
					                                  new Vector3((-LEVEL_SIZE/2 + i), 
					            (-LEVEL_SIZE/2 + j), 
					            0.0f),
					                                  Quaternion.LookRotation(new Vector3(0.0f, 
					                                    0.0f, 
					                                    -1.0f))
					                                  );
					break;
				case 4:
					levelObjArray[i,j] = Instantiate(fouCube, 
					                                  new Vector3((-LEVEL_SIZE/2 + i), 
					            (-LEVEL_SIZE/2 + j), 
					            0.0f),
					                                  Quaternion.LookRotation(new Vector3(0.0f, 
					                                    0.0f, 
					                                    -1.0f))
					                                  );
					break;
				case 5:
					levelObjArray[i,j] = Instantiate(fivCube, 
					                                  new Vector3((-LEVEL_SIZE/2 + i), 
					            (-LEVEL_SIZE/2 + j), 
					            0.0f),
					                                  Quaternion.LookRotation(new Vector3(0.0f, 
					                                    0.0f, 
					                                    -1.0f))
					                                  );
					break;
				case 6:
					levelObjArray[i,j] = Instantiate(sixCube, 
					                                  new Vector3((-LEVEL_SIZE/2 + i), 
					            (-LEVEL_SIZE/2 + j), 
					            0.0f),
					                                  Quaternion.LookRotation(new Vector3(0.0f, 
					                                    0.0f, 
					                                    -1.0f))
					                                  );
					break;
				case 7:
					levelObjArray[i,j] = Instantiate(sevCube, 
					                                  new Vector3((-LEVEL_SIZE/2 + i), 
					            (-LEVEL_SIZE/2 + j), 
					            0.0f),
					                                  Quaternion.LookRotation(new Vector3(0.0f, 
					                                    0.0f, 
					                                    -1.0f))
					                                  );
					break;
				case 8:
					levelObjArray[i,j] = Instantiate(eigCube, 
					                                  new Vector3((-LEVEL_SIZE/2 + i), 
					            (-LEVEL_SIZE/2 + j), 
					            0.0f),
					                                  Quaternion.LookRotation(new Vector3(0.0f, 
					                                    0.0f, 
					                                    -1.0f))
					                                  );
					break;
					
				default:
					levelObjArray[i,j] = Instantiate(bombCube, 
					                                  new Vector3((-LEVEL_SIZE/2 + i), 
					            (-LEVEL_SIZE/2 + j), 
					            0.0f),
					                                  Quaternion.LookRotation(new Vector3(0.0f, 
					                                    0.0f, 
					                                    -1.0f))
					                                  );
					break;
				}
			}
		}
	}
	
	void ResetLevel()
	{
		for(int i = 0; i < levelObjArray.GetLength(0); i++)
		{
			for(int j = 0; j < levelObjArray.GetLength(1); j++)
			{
				Debug.Log ("destroying object");
				Destroy(levelObjArray[i,j]);
				levelIntArray[i,j] = 0;
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
