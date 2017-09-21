using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assignment3 : MonoBehaviour {

	public GameObject spherePrefab;
	List<GameObject> sphereList = new List<GameObject>();

	public GameObject cubePrefab;
	List<GameObject> cubeList = new List<GameObject>();
	List<GameObject> cubeKillList = new List<GameObject>();

	int cubeNum = 0;

	// Use this for initialization
	void Start () {

		int sphereNum = 0;

		for (int i = 0; i < 9; i++ ) {
			for (int j = 0; j < 9; j++ ) {
				GameObject sphere = Instantiate(spherePrefab);
				sphere.name = "Sphere"+sphereNum;
				sphereNum++;
				sphere.transform.position = new Vector3(i,j,0);

				sphereList.Add(sphere);
			}
		}

		sphereList[40].GetComponent <Renderer>().material.color = new Color ( Random.value, Random.value, Random.value );
		Destroy(sphereList[41]);
	}

	// Update is called once per frame
	void Update () {

		// 1.Instantiate one cube prefab every frame into the scene.
		GameObject cube = Instantiate(cubePrefab);
		cubeList.Add(cube);

		// 2.The cubes need to be named as “Cube1”, “Cube2”... based on the order they are generated.
		cube.name = "Cube"+cubeNum;
		cubeNum++;

		// 3.The cubes need to be generated at a random locations within 1 unit from the origin [0,0,0].
		cube.transform.position = new Vector3( (100 * Random.value), (100 * Random.value), (100 * Random.value));

		// 4.Each cube should have a random color.
		cube.GetComponent <Renderer>().material.color = new Color ( Random.value, Random.value, Random.value );

		// 5.The cube size (localScale) shrink 10% in each frame.
		sphereList.Add(cube);

		foreach( GameObject cubePrefab in cubeList )
		{
			cubePrefab.transform.localScale = new Vector3 ( cubePrefab.transform.localScale.x * .9f, cubePrefab.transform.localScale.y * .9f, cubePrefab.transform.localScale.z * .9f );

			// 6.When the cube’s scale is less than 10% of its original scale, the cube is destroyed.
			if( cubePrefab.transform.localScale.x < .1f )
			{
				cubeKillList.Add(cubePrefab);
			}
		}
		foreach( GameObject cubePrefab in cubeKillList ) {
			Destroy(cubePrefab);
			cubeList.Remove(cubePrefab);
		}
		cubeKillList.Clear();
	}
}
