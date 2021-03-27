using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] public float lookSensitivity = 100f;

    public Transform playerBody;
    float rawX, rawY;
    float xRotation=0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }



    // Update is called once per frame
    void Update()
    {
        float lookX = rawX * lookSensitivity * Time.deltaTime;
        float lookY = rawY * lookSensitivity * Time.deltaTime;

        xRotation -= lookY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * lookX);
        
    }

    public void ReceiveInput(Vector2 rawLookInput){
        rawX = rawLookInput.x;
        rawY = rawLookInput.y;

    }
}
