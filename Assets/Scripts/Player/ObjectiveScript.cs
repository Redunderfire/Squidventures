using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveScript : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    ObjectiveManager objManager;


    // Start is called before the first frame update
    void Start() {
        objManager = playerObject.GetComponent(typeof(ObjectiveManager)) as ObjectiveManager;
        }

    private void OnTriggerEnter(Collider other){
        objManager.incrementObjValue();
        Destroy(gameObject);
    }
}
