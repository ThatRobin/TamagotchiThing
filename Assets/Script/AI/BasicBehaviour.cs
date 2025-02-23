using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBehaviour : ScriptableObject {

    public Transform destinationParent;
    public virtual void OnStart(GameObject self, Transform destinationParent) {
        this.destinationParent = destinationParent;
    }

    public virtual void OnUpdate(GameObject self) {
    }
}
