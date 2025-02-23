using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourManager : MonoBehaviour {

    public Transform destinationParent;
    public List<BasicBehaviour> behaviours = new List<BasicBehaviour>();

    void Start() {
        foreach (BasicBehaviour behaviour in behaviours) {
            behaviour.OnStart(this.gameObject, destinationParent);
        }
    }

    void Update() {
        foreach (BasicBehaviour behaviour in behaviours) {
            behaviour.OnUpdate(this.gameObject);

        }
    }
}
