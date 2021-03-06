using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Serialize_Mesh {

	[SerializeField]
	public float[] vertices;

	[SerializeField]
	public int[] triangles;

	[SerializeField]
	public float[] uv;

	[SerializeField]
	public float[] uv2;

	[SerializeField]
	public float[] normals;


	public Serialize_Mesh(Mesh m){
		//Vertex
		int total_vertices=m.vertexCount*3;
		vertices = new float[total_vertices];
		for (int i = 0; i < m.vertexCount; i++) {
			vertices [3*i] = m.vertices [i].x;
			vertices [3*i + 1] = m.vertices [i].y;
			vertices [3*i + 2] = m.vertices [i].z;
		}

		//Triangles
		int total_triangles=m.triangles.Length;
		triangles = new int[total_triangles];
		for (int i = 0; i < m.triangles.Length; i++) {
			triangles [i] = m.triangles [i];
		}

		//UV
		int total_uv=m.uv.Length*2;
		uv = new float[total_uv];
		for (int i = 0; i < m.uv.Length; i++) {
			uv [2*i] = m.uv [i].x;
			uv [2*i+1] = m.uv [i].y;
		}

		//UV2
		int total_uv2=m.uv2.Length*2;
		uv2 = new float[total_uv2];
		for (int i = 0; i < m.uv2.Length; i++) {
			uv2 [2*i] = m.uv2 [i].x;
			uv2 [2*i+1] = m.uv2 [i].y;
		}
		//Normals
		int total_normals=m.normals.Length;
		normals = new float[total_normals*3];
		for(int i=0;i<m.normals.Length;i++){
			normals[3*i]=m.normals [i].x;
			normals[3*i+1]=m.normals [i].y;
			normals[3*i+2]=m.normals [i].z;
		}

	
	}
	public Mesh Construct(){
		Mesh m = new Mesh ();

		//Vertex
		List<Vector3> vertices_list = new List<Vector3> ();
		for (int i = 0; i < vertices.Length/3; i++) {
			vertices_list.Add (new Vector3 (vertices[3*i],vertices[3*i+1],vertices[3*i+2]));
		}
		m.SetVertices (vertices_list);

		//Triangles
		m.triangles = triangles;

		//UV
		List<Vector2> uvlist = new List<Vector2> ();
		for (int i = 0; i < uv.Length / 2; i++) {
			uvlist.Add(new Vector2 (uv [2 * i], uv [2 * i + 1]));
		}
		m.SetUVs (0, uvlist);

		//UV2
		List<Vector2> uvlist2 = new List<Vector2> ();
		for (int i = 0; i < uv2.Length / 2; i++) {
			uvlist2.Add (new Vector2 (uv2 [2 * i], uv2 [2 * i + 1]));
		}
		m.SetUVs (1, uvlist2);

		//Normals
		List<Vector3> normals_list = new List<Vector3> ();
		for (int i = 0; i < normals.Length/3; i++) {
			normals_list.Add (new Vector3 (normals[3*i],normals[3*i+1],normals[3*i+2]));
		}
		return m;
	
	}


}
