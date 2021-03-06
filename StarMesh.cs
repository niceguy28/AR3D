﻿using UnityEngine;
using System.Collections;

public class StarMesh : MonoBehaviour {
	MeshFilter mf;
	Mesh mesh;
	Vector3[] starPattern;
	Vector3[] vertices;	
	int[] triangles;
	int count = 0;
	float addz = 0.0f;
	float addx = 0.0f;
	float addy = 0.0f;
	bool Durchlauf = false;

	void Start () {

		mf = GetComponent<MeshFilter>();
		mesh = mf.mesh;

		//Vertices
		starPattern = new Vector3[] {

			//Grundmuster
			new Vector3(0,1,1), 
			new Vector3(0.5f,0,1),   
			new Vector3(1.5f,0,1),
			new Vector3(0.5f,-1,1),  
			new Vector3(1,-2.2f,1),   
			new Vector3(0,-1.5f,1),
			new Vector3(-1,-2.2f,1),  
			new Vector3(-0.5f,-1,1),   
			new Vector3(-1.5f,0,1), 
			new Vector3(-0.5f,0,1)   
		};

		//zu extrudierendes Pattern nach vertices kopieren
		vertices = new Vector3[starPattern.Length];
		System.Array.Copy (starPattern, vertices, starPattern.Length);

		//Triangles
		triangles = new int[]
		{
			//front 
			0,9,1,
			1,3,2,
			3,5,4,
			5,7,6,
			7,9,8, // äußerer stern
			3,7,5,  // innerer stern
			3,1,7,
			9,7,1

		};



		mesh.Clear();
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.Optimize();
		mesh.RecalculateNormals();


	}

	void AddNewVertices() {

		Vector3[] NewVertices = new Vector3[vertices.Length + 10];
		System.Array.Resize (ref vertices, NewVertices.Length);
		System.Array.Copy (vertices, NewVertices, NewVertices.Length);

		if (Durchlauf == false) {
			addy += 0.1f;
		} else {
			addy -= 0.1f;
		}

		NewVertices [vertices.Length-10] = new Vector3 (0+addx,1+addy,1 + addz);
		NewVertices [vertices.Length-9] = new Vector3 (0.5f+addx,0+addy,1 + addz);
		NewVertices [vertices.Length-8] = new Vector3 (1.5f+addx,0+addy,1 + addz);
		NewVertices [vertices.Length-7] = new Vector3 (0.5f+addx,-1+addy,1 + addz);
		NewVertices [vertices.Length-6] = new Vector3 (1+addx,-2.2f+addy,1 + addz);
		NewVertices [vertices.Length-5] = new Vector3 (0+addx,-1.5f+addy,1 + addz);
		NewVertices [vertices.Length-4] = new Vector3 (-1+addx,-2.2f+addy,1 + addz);
		NewVertices [vertices.Length-3] = new Vector3 (-0.5f+addx,-1+addy,1 + addz);
		NewVertices [vertices.Length-2] = new Vector3 (-1.5f+addx,0+addy,1 + addz);
		NewVertices [vertices.Length-1] = new Vector3 (-0.5f+addx,0+addy,1 + addz);

		System.Array.Copy (NewVertices, vertices, vertices.Length);
		mesh.vertices = vertices;
		addz += 0.1f;
	}

	void DefineTriangles (){

		int[] newTriangles = new int[triangles.Length + 60];
		System.Array.Resize (ref triangles, newTriangles.Length);
		System.Array.Copy (triangles, newTriangles, newTriangles.Length);
		int m = vertices.Length ; //number of all vertices
		int n = 10; //number of added vertices

		newTriangles[triangles.Length-60] = m-2*n;          
		newTriangles[triangles.Length-59] = m - n;		
		newTriangles[triangles.Length-58] = m - n + 1;		
		newTriangles[triangles.Length-57] = m - n + 1;		
		newTriangles[triangles.Length-56] = m-2*n +1;		
		newTriangles[triangles.Length-55] = m-2*n;			
		newTriangles[triangles.Length-54] = m-2*n +1; 		
		newTriangles[triangles.Length-53] = m-n+1; 			
		newTriangles[triangles.Length-52] = m-n+2;			
		newTriangles[triangles.Length-51] = m-n+2; 			
		newTriangles[triangles.Length-50] = m-2*n+2; 			
		newTriangles[triangles.Length-49] = m-2*n+1;			
		newTriangles[triangles.Length-48] = m-2*n+2;			
		newTriangles[triangles.Length-47] = m-n+2; 			
		newTriangles[triangles.Length-46] = m-n+3;		
		newTriangles[triangles.Length-45] = m-n+3; 		
		newTriangles[triangles.Length-44] = m - 2 * n + 3;	
		newTriangles[triangles.Length-43] = m-2*n+2;			
		newTriangles[triangles.Length-42] = m-2*n+3;		
		newTriangles[triangles.Length-41] = m-n+3; 	
		newTriangles[triangles.Length-40] = m - n +4;		
		newTriangles[triangles.Length-39] = m - n+4; 		
		newTriangles[triangles.Length-38] = m - 2*n+4; 	
		newTriangles[triangles.Length-37]   = m -2*n + 3;  	
		newTriangles[triangles.Length-36] = m-2*n+4;          
		newTriangles[triangles.Length-35] = m - n+4;		
		newTriangles[triangles.Length-34] = m - n + 5;		
		newTriangles[triangles.Length-33] = m-n+5;		
		newTriangles[triangles.Length-32] = m - 2*n+5;		
		newTriangles[triangles.Length-31] = m - 2*n+4;			
		newTriangles[triangles.Length-30] = m-2*n+5; 		
		newTriangles[triangles.Length-29] = m-n+5; 			
		newTriangles[triangles.Length-28] = m-n+6;			
		newTriangles[triangles.Length-27] = m-n+6; 			
		newTriangles[triangles.Length-26] = m-2*n+6; 			
		newTriangles[triangles.Length-25] = m-2*n+5;			
		newTriangles[triangles.Length-24] = m-2*n+6;			
		newTriangles[triangles.Length-23] = m-n+6; 			
		newTriangles[triangles.Length-22] = m-n+7;		
		newTriangles[triangles.Length-21] = m - n + 7; 		
		newTriangles[triangles.Length-20] = m - 2 * n + 7;	
		newTriangles[triangles.Length-19] = m-2*n+6;			
		newTriangles[triangles.Length-18] = m - 2*n + 7;		
		newTriangles[triangles.Length-17] = m - n + 7; 	
		newTriangles[triangles.Length-16] = m - n +8;		
		newTriangles[triangles.Length-15] = m - n+8; 		
		newTriangles[triangles.Length-14] = m - 2*n +8; 	
		newTriangles[triangles.Length-13]   = m -2*n + 7; 
		newTriangles[triangles.Length-12] = m-2*n+8;			
		newTriangles[triangles.Length-11] = m-n+8; 			
		newTriangles[triangles.Length-10] = m-n+9;		
		newTriangles[triangles.Length- 9] = m - n + 9; 		
		newTriangles[triangles.Length- 8] = m - 2 * n + 9;	
		newTriangles[triangles.Length- 7] = m-2*n+8;			
		newTriangles[triangles.Length- 6] = m - 2*n + 9;		
		newTriangles[triangles.Length- 5] = m - n + 9; 	
		newTriangles[triangles.Length- 4] = m - n;		
		newTriangles[triangles.Length- 3] = m - n; 		
		newTriangles[triangles.Length- 2] = m - 2*n; 	
		newTriangles[triangles.Length- 1]   = m -2*n + 9; 


		System.Array.Copy (newTriangles, triangles, triangles.Length);

		mesh.triangles = triangles;

		mesh.RecalculateNormals();
		mesh.Optimize();

	}

	// Update is called once per frame
	void Update () {
		AddNewVertices ();
		DefineTriangles ();
		if (count == 40) {
			count = 0;
			if (Durchlauf == false) {
				Durchlauf = true;
			} else
				Durchlauf = false;
		}
		count++;
	}
}
