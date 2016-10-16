using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PredatorScript : MonoBehaviour {
    public Vector3 position, orientation, objPosition;
    public GameObject model;
    public List<PreyScript> preyArray;
    float visionLimit;
    public PreyScript prey;
    bool preyCheck;
    // Use this for initialization
    void Start() {
        preyArray = new List<PreyScript>();
        visionLimit = 50f;
        preyCheck = false;
        prey = null;
    }

    // Update is called once per frame
    void Update() {
        MoveForward();
        position = model.transform.position;

        if (!preyCheck) {
            //Debug.Log("Checking Prey");
            CheckForPrey();
        }

        if (prey != null) {
            Debug.Log("Prey is not null.");
            FoundPrey(model.GetComponent<Renderer>(), prey.GetComponent<Renderer>());
        }

        position = model.transform.position;
    }

    void TurnLeft() {

    }

    void TurnRight() {

    }

    void MoveForward() {
        model.transform.Translate(-model.transform.forward * Time.deltaTime);
        Vector3 posCopy = model.transform.position;
        posCopy.y = 0.5f;
        model.transform.position = posCopy;
        position = model.transform.position;

    }

    void MoveBackward() {
        model.transform.Translate(model.transform.forward * Time.deltaTime);
        Vector3 posCopy = model.transform.position;
        posCopy.y = 0.5f;
        model.transform.position = posCopy;
        position = model.transform.position;
    }

    void CheckForPrey() {
        for (int i = 0; i < 9; i++) {
            if (preyArray[i] != null) {
                Vector3 objPosition = preyArray[i].transform.position;
                Vector3 agentToVertex = objPosition - position;
                float angle = Vector3.Angle(agentToVertex, model.transform.forward);
                if (angle < 5.0f) {
                    //Debug.Log("Close");
                    //preyCheck = true;
                    float step = 3f * Time.deltaTime;
                    Vector3 newDir = Vector3.RotateTowards(model.transform.forward, agentToVertex, step, 0.0F);
                    model.transform.rotation = Quaternion.LookRotation(newDir);
                    prey = preyArray[i];
                    i = 9;
                    break;
                }
            }
        }
    }

    void FoundPrey(Renderer rend1, Renderer rend2) {
        //Debug.Log("FoundPrey");
        if (rend1.bounds.Intersects(rend2.bounds)) {
            Debug.Log("Intersection");
            model.GetComponent<MeshRenderer>().material.color = Color.yellow;
            int index = preyArray.IndexOf(prey);
            GameObject.Destroy(preyArray[index].model);
            preyArray[index] = null;
            prey = null;
            //preyCheck = false;
        }
    }
}
