using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour
{
	//public GameObject _cube;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void CreateCube (bool front2, bool top2, bool right2, bool left2, bool back2, bool bottom2, int id, int x, int y, int z) {
		GameObject _cube = new GameObject();
		        //1) Create an empty GameObject with the required Components
        _cube.AddComponent<MeshRenderer>();
        MeshFilter meshFilter = _cube.AddComponent<MeshFilter>();
        Mesh mesh = meshFilter.mesh;

        //Create a 'Cube' mesh...
      
        //2) Define the cube's dimensions
        float length = 1f;
        float width = 1f;
        float height = 1f;


        //3) Define the co-ordinates of each Corner of the cube 
        Vector3[] c = new Vector3[8];

        c[0] = new Vector3(-length * .5f, -width * .5f, height * .5f);
        c[1] = new Vector3(length * .5f, -width * .5f, height * .5f);
        c[2] = new Vector3(length * .5f, -width * .5f, -height * .5f);
        c[3] = new Vector3(-length * .5f, -width * .5f, -height * .5f);

        c[4] = new Vector3(-length * .5f, width * .5f, height * .5f);
        c[5] = new Vector3(length * .5f, width * .5f, height * .5f);
        c[6] = new Vector3(length * .5f, width * .5f, -height * .5f);
        c[7] = new Vector3(-length * .5f, width * .5f, -height * .5f);

        Vector3 up = Vector3.up;
        Vector3 down = Vector3.down;
        Vector3 forward = Vector3.forward;
        Vector3 back = Vector3.back;
        Vector3 left = Vector3.left;
        Vector3 right = Vector3.right;
		
		Vector2 uv00 = new Vector2(0f, 0f);
        Vector2 uv10 = new Vector2(1f, 0f);
        Vector2 uv01 = new Vector2(0f, 1f);
        Vector2 uv11 = new Vector2(1f, 1f);
		
        //4) Define the vertices that the cube is composed of:
        //I have used 16 vertices (4 vertices per side). 
        //This is because I want the vertices of each side to have separate normals.
        //(so the object renders light/shade correctly) 
		/*void AddToArray(List<int> list, int v1, int v2, int v3, int v4, int v5, int v6){
            list.Add(v1);
            list.Add(v2);
            list.Add(v3);
            list.Add(v4);
            list.Add(v5);
            list.Add(v6);
        }*/
		
		List<Vector3> vertices = new List<Vector3>();
		List<Vector3> normals = new List<Vector3>();
		List<Vector2> uvs = new List<Vector2>();
		List<int> triangles = new List<int>();
		
		vertices.Add(c[0]); //bottom
		vertices.Add(c[1]);
		vertices.Add(c[2]);
		vertices.Add(c[3]);
		
		normals.Add(down);
		normals.Add(down);
		normals.Add(down);
		normals.Add(down);
		
		uvs.Add(uv11);
		uvs.Add(uv01);
		uvs.Add(uv00);
		uvs.Add(uv10);
		
		if (bottom2) {
	    triangles.Add(3);
        triangles.Add(1);
		triangles.Add(0);
	    triangles.Add(3);
        triangles.Add(2);
		triangles.Add(1);
		}
		
		vertices.Add(c[7]); //left
		vertices.Add(c[4]);
		vertices.Add(c[0]);
		vertices.Add(c[3]);
		
	    normals.Add(left);
		normals.Add(left);
		normals.Add(left);
		normals.Add(left);
		
		uvs.Add(uv11);
		uvs.Add(uv01);
		uvs.Add(uv00);
		uvs.Add(uv10);
		
		if (left2) {
	    triangles.Add(7);
        triangles.Add(5);
		triangles.Add(4);
	    triangles.Add(7);
        triangles.Add(6);
		triangles.Add(5);
		}
		
		vertices.Add(c[4]); //front
		vertices.Add(c[5]);
		vertices.Add(c[1]);
		vertices.Add(c[0]);
		
		normals.Add(forward);
		normals.Add(forward);
		normals.Add(forward);
		normals.Add(forward);
		
		uvs.Add(uv11);
		uvs.Add(uv01);
		uvs.Add(uv00);
		uvs.Add(uv10);
		
        if (front2){
	    triangles.Add(11);
        triangles.Add(9);
		triangles.Add(8);
	    triangles.Add(11);
        triangles.Add(10);
		triangles.Add(9);
		}

		vertices.Add(c[6]); //back
		vertices.Add(c[7]);
		vertices.Add(c[3]);
		vertices.Add(c[2]);
		
		normals.Add(back);
		normals.Add(back);
		normals.Add(back);
		normals.Add(back);
		
		uvs.Add(uv11);
		uvs.Add(uv01);
		uvs.Add(uv00);
		uvs.Add(uv10);
		
		if (back2) {
	    triangles.Add(15);
        triangles.Add(13);
		triangles.Add(12);
	    triangles.Add(15);
        triangles.Add(14);
		triangles.Add(13);
		}
		
		vertices.Add(c[5]); //right
		vertices.Add(c[6]);
		vertices.Add(c[2]);
		vertices.Add(c[1]);
		
		normals.Add(right);
		normals.Add(right);
		normals.Add(right);
		normals.Add(right);
		
		uvs.Add(uv11);
		uvs.Add(uv01);
		uvs.Add(uv00);
		uvs.Add(uv10);
		
		if (right2) {
		triangles.Add(19);
        triangles.Add(17);
		triangles.Add(16);
	    triangles.Add(19);
        triangles.Add(18);
		triangles.Add(17);
		}

		vertices.Add(c[7]); //top
		vertices.Add(c[6]);
		vertices.Add(c[5]);
		vertices.Add(c[4]);
		
		normals.Add(up);
		normals.Add(up);
		normals.Add(up);
		normals.Add(up);
		
		uvs.Add(uv11);
		uvs.Add(uv01);
		uvs.Add(uv00);
		uvs.Add(uv10);
		
		if (top2) {
	    triangles.Add(23);
        triangles.Add(21);
		triangles.Add(20);
	    triangles.Add(23);
        triangles.Add(22);
		triangles.Add(21);
		}
		
        /*Vector3[] vertices = new Vector3[]
        {
	        c[0], c[1], c[2], c[3], // Bottom
	        c[7], c[4], c[0], c[3], // Left
	        c[4], c[5], c[1], c[0], // Front
	        c[6], c[7], c[3], c[2], // Back
	        c[5], c[6], c[2], c[1], // Right
	        c[7], c[6], c[5], c[4]  // Top
        };*/


        //5) Define each vertex's Normal
        /*Vector3 up = Vector3.up;
        Vector3 down = Vector3.down;
        Vector3 forward = Vector3.forward;
        Vector3 back = Vector3.back;
        Vector3 left = Vector3.left;
        Vector3 right = Vector3.right;


        Vector3[] normals = new Vector3[]
        {
	        down, down, down, down,             // Bottom
	        left, left, left, left,             // Left
	        forward, forward, forward, forward,	// Front
	        back, back, back, back,             // Back
	        right, right, right, right,         // Right
	        up, up, up, up	                    // Top
        };*/


        //6) Define each vertex's UV co-ordinates
        /*Vector2 uv00 = new Vector2(0f, 0f);
        Vector2 uv10 = new Vector2(1f, 0f);
        Vector2 uv01 = new Vector2(0f, 1f);
        Vector2 uv11 = new Vector2(1f, 1f);

        Vector2[] uvs = new Vector2[]
        {
	        uv11, uv01, uv00, uv10, // Bottom
	        uv11, uv01, uv00, uv10, // Left
	        uv11, uv01, uv00, uv10, // Front
	        uv11, uv01, uv00, uv10, // Back	        
	        uv11, uv01, uv00, uv10, // Right 
	        uv11, uv01, uv00, uv10  // Top
        };*/


        //7) Define the Polygons (triangles) that make up the our Mesh (cube)
        //IMPORTANT: Unity uses a 'Clockwise Winding Order' for determining front-facing polygons.
        //This means that a polygon's vertices must be defined in 
        //a clockwise order (relative to the camera) in order to be rendered/visible.
        /*int[] triangles = new int[]
        {
	        3, 1, 0,        3, 2, 1,        // Bottom	
	        7, 5, 4,        7, 6, 5,        // Left
	        11, 9, 8,       11, 10, 9,      // Front
	        15, 13, 12,     15, 14, 13,     // Back
	        19, 17, 16,     19, 18, 17,	    // Right
	        23, 21, 20,     23, 22, 21,	    // Top
        };*/


        //8) Build the Mesh
        mesh.Clear();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.normals = normals.ToArray();
        mesh.uv = uvs.ToArray();
        mesh.Optimize();
        //mesh.RecalculateNormals();

        _cube.transform.Translate(0f, 1f, -8f);
		_cube.name = "Block" + id;

        //9) Give it a Material
        Material cubeMaterial = new Material(Shader.Find("Standard"));
        cubeMaterial.SetColor("_Color", new Color(0f, 0.7f, 0f)); //green main color
        _cube.GetComponent<Renderer>().material = cubeMaterial;
		
		if (_cube == null) {
			Debug.Log("wth");
		}
		
		_cube.transform.position = new Vector3(x, y, z);
	}
}
