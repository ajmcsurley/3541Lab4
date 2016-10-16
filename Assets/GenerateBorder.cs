using UnityEngine;
using System.Collections;

public class GenerateBorder : MonoBehaviour {
    Vector3 temp = new Vector3(-5.5f, 0.5f, -5.5f);
	// Use this for initialization
	void Start () {
        GameObject plane = GameObject.Find("Plane");
	    for (int i = 0; i < 11; i++) {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.name += i.ToString();
            cube.transform.position = temp;
            temp.z += 1;

            //Properties
            MeshRenderer meshR = cube.GetComponent<MeshRenderer>();
            meshR.material.color = Color.black;
            meshR.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            Rigidbody cubeRigidBody = cube.AddComponent<Rigidbody>();
            cubeRigidBody.isKinematic = true;
            cubeRigidBody.useGravity = false;
            cubeRigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

            cube.transform.parent = plane.transform;


        }

        for (int i = 11; i < 22; i++) {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.name += i.ToString();
            cube.transform.position = temp;
            temp.x += 1;

            //Properties
            MeshRenderer meshR = cube.GetComponent<MeshRenderer>();
            meshR.material.color = Color.black;
            meshR.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

            Rigidbody cubeRigidBody = cube.AddComponent<Rigidbody>();
            cubeRigidBody.isKinematic = true;
            cubeRigidBody.useGravity = false;
            cubeRigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

            cube.transform.parent = plane.transform;


        }

        for (int i = 22; i < 33; i++) {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.name += i.ToString();
            cube.transform.position = temp;
            temp.z -= 1;

            //Properties
            MeshRenderer meshR = cube.GetComponent<MeshRenderer>();
            meshR.material.color = Color.black;
            meshR.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

            Rigidbody cubeRigidBody = cube.AddComponent<Rigidbody>();
            cubeRigidBody.isKinematic = true;
            cubeRigidBody.useGravity = false;
            cubeRigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

            cube.transform.parent = plane.transform;


        }

        for (int i = 33; i < 44; i++) {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.name += i.ToString();
            cube.transform.position = temp;
            temp.x -= 1;

            //Properties
            MeshRenderer meshR = cube.GetComponent<MeshRenderer>();
            meshR.material.color = Color.black;
            meshR.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

            Rigidbody cubeRigidBody = cube.AddComponent<Rigidbody>();
            cubeRigidBody.isKinematic = true;
            cubeRigidBody.useGravity = false;
            cubeRigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            cube.transform.parent = plane.transform;


        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
