using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InitScript : MonoBehaviour {
    public List<PreyScript> preyArray;
    public List<PredatorScript> predatorArray;

	// Use this for initialization
	void Start () {
        preyArray = new List<PreyScript>();
        predatorArray = new List<PredatorScript>();

        for (int i = 0; i < 9; i++) {
            GameObject preyModel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            PreyScript prey = preyModel.AddComponent<PreyScript>();
            preyModel.name = "Prey" + i.ToString();
            prey.model = preyModel;
            prey.model.transform.position = new Vector3(Random.Range(-4.5f,4.5f), 0.5f, Random.Range(-4.5f, -2.5f));
            prey.position = prey.model.transform.position;
            prey.model.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            prey.model.GetComponent<MeshRenderer>().material.color = Color.blue;
            prey.model.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            Rigidbody preyRb = preyModel.AddComponent<Rigidbody>();
            preyRb.isKinematic = false;
            preyRb.useGravity = false;
            preyRb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            preyRb.freezeRotation = true;
            preyArray.Add(prey);

        }

        for (int i = 0; i < 9; i++) {
            GameObject predatorModel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            PredatorScript predator = predatorModel.AddComponent<PredatorScript>();
            predatorModel.name = "Predator" + i.ToString();
            predator.model = predatorModel;
            predator.model.transform.position = new Vector3(Random.Range(-4.5f, -2.5f), 0, Random.Range(2.5f, 4.5f));
            predator.position = predator.model.transform.position;
            predator.model.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            predator.model.GetComponent<MeshRenderer>().material.color = Color.red;
            predator.model.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            Rigidbody predatorRb = predatorModel.AddComponent<Rigidbody>();
            predatorRb.isKinematic = false;
            predatorRb.useGravity = false;
            predatorRb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            predatorRb.freezeRotation = true;
            predatorArray.Add(predator);

        }

        for (int i = 0; i<0; i++) {
            GameObject boundingSphere = GameObject.CreatePrimitive(PrimitiveType.Cube);
            boundingSphere.name = "BoundingSphere" + i.ToString();
            boundingSphere.transform.position = new Vector3(Random.Range(-3.5f, 3.5f), 0.5f, Random.Range(-3.5f, 3.5f));
            boundingSphere.GetComponent<MeshRenderer>().material.color = Color.black;
            boundingSphere.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            Rigidbody bsRb = boundingSphere.AddComponent<Rigidbody>();
            bsRb.isKinematic = true;
            bsRb.useGravity = false;
            bsRb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            //bsRb.freezeRotation = true;
            //bsRb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        }
    }
	
	// Update is called once per frame
	void Update () {
	    for (int i = 0; i<9; i++) {
            if (preyArray[i] != null) {
                preyArray[i].predatorArray = predatorArray;
            }
            if (predatorArray[i] != null) {
                predatorArray[i].preyArray = preyArray;
            }
        }
	}
}
