using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PreyScript : MonoBehaviour {
    public Vector3 position, orientation;
    public GameObject model;
    float visionLimit;
    public List<PredatorScript> predatorArray;
    // Use this for initialization
    void Start () {
        predatorArray = new List<PredatorScript>();
        visionLimit = 10f;
    }
	
	// Update is called once per frame
	void Update () {
        MoveForward();
        position = model.transform.position;

        CheckForPredator();
    }


    void TurnLeft() {
        GameObject left = GameObject.Find("LeftObj");

        Vector3 targetDir = left.transform.position - model.transform.position;
        float step = 3f * Time.fixedDeltaTime;
        Vector3 newDir = Vector3.RotateTowards(model.transform.forward, targetDir, step, 0.0F);
        model.transform.rotation = Quaternion.LookRotation(newDir);
    }

    void TurnRight() {
        GameObject right = GameObject.Find("RightObj");

        Vector3 targetDir = right.transform.position - model.transform.position;
        float step = 3f * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(model.transform.forward, targetDir, step, 0.0F);
        //Debug.DrawRay(transform.position, newDir, Color.red);
        model.transform.rotation = Quaternion.LookRotation(newDir);
    }

    void MoveForward() {
        model.transform.Translate(model.transform.forward * Time.deltaTime);
        Vector3 posCopy = model.transform.position;
        posCopy.y = 0.5f;
        model.transform.position = posCopy;
        position = model.transform.position;

    }

    void MoveBackward() {
        model.transform.Translate(-model.transform.forward * Time.deltaTime);
        Vector3 posCopy = model.transform.position;
        posCopy.y = 0.5f;
        model.transform.position = posCopy;
        position = model.transform.position;

    }

    void CheckForPredator() {
        for (int i =0; i<9; i++) {
            Vector3 objPosition = predatorArray[i].transform.position;
            Vector3 agentToVertex = objPosition - position;

            agentToVertex.Normalize();
            if (Vector3.Dot(agentToVertex, orientation) > visionLimit) {
                MoveBackward();
            }
        }
        
    }
}
