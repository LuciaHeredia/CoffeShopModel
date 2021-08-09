using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    private float speed, angularSpeed;
    private CharacterController controller;
    private float rotationAboutX=0, rotationAboutY=90;
    public GameObject PlayerCamera;
    
    void Start() // Start is called before the first frame update
    {
        speed = 5;
        angularSpeed = 100;
        controller = GetComponent<CharacterController>();
    }
    
    void Update() // Update is called once per frame
    {
        float dx, dy, dz;
        dy = -1; // is a gravity

        // Player rotation
        rotationAboutY += Input.GetAxis("Mouse X")*angularSpeed*Time.deltaTime;
        transform.localEulerAngles = new Vector3(0, rotationAboutY, 0);

        // Camera rotation
        rotationAboutX -= Input.GetAxis("Mouse Y")*angularSpeed*Time.deltaTime;
        PlayerCamera.transform.localEulerAngles = new Vector3(rotationAboutX,0,0);

        // motion after rotation
        dx = Input.GetAxis("Horizontal"); // -1 or 0 or +1
        dx*=speed*Time.deltaTime;
        dz = Input.GetAxis("Vertical"); // -1 or 0 or +1
        dz*=speed*Time.deltaTime;

        // EXAMPLE of simple motion:
        // Time.deltaTime is time that has passed from frame to frame
        //transform.Translate(new Vector3(dx,dy,dz)); // forward/backward
        //transform.Translate(new Vector3(dx,dy,dz)); // left/right

        // Motion using CharacterController
        Vector3 motion = new Vector3(dx,dy,dz); // motion is defined in Local coordinates
        motion = transform.TransformDirection(motion); // now motion is in Global coordinates
        controller.Move(motion); // must recieve Vector3 in Globl coordinates

    }
}
