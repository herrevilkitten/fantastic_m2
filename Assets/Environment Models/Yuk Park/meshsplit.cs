using UnityEngine;
using System.Collections;
using System;
using UnityEditor;

public class MeshSplit : MonoBehaviour
{
	Mesh mesh;

	void Awake ()
	{
		MeshFilter mf = GetComponent<MeshFilter>();
		mesh = mf.sharedMesh;
		
		for(int i = 0; i < mesh.subMeshCount; i++){
			int[] subMeshTris = mesh.GetTriangles(i);
			CreateMesh(subMeshTris,i);
		}
	}

	Mesh CreateMesh(int[] triangles,int index){
		Mesh newMesh = new Mesh();
		newMesh.Clear();
		newMesh.vertices = mesh.vertices;
		newMesh.triangles = triangles;
		newMesh.uv = mesh.uv;
		newMesh.uv2 = mesh.uv2;
		newMesh.uv2 = mesh.uv2;
		newMesh.colors = mesh.colors;
		newMesh.subMeshCount = mesh.subMeshCount;
		newMesh.normals = mesh.normals;
		AssetDatabase.CreateAsset(newMesh, "Assets/"+mesh.name+"_submesh["+index+"].asset");
		return newMesh;
	}
}
