using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternateSphereMovement : MonoBehaviour
{

    public KeyCode pressUp;
    public KeyCode pressRight;
    public KeyCode pressDown;
    public KeyCode pressLeft;
    public KeyCode clockwise;
    public KeyCode counterClockwise;
    public GameObject sphere;
    public float movementSpeed;
    private float[] snapAngles;

    public bool Up;
    public bool Right;
    public bool Down;
    public bool Left;
    public bool Cw;
    public bool Countercw;

    // Use this for initialization
    void Start()
    {
        sphere = GameObject.Find("Sphere");
        snapAngles = new float[] { 0.000001f, 90.0f, 180.0f, 270.0f, 360.0f };
        movementSpeed = 40.0f;
        Up = false;
        Right = false;
        Down = false;
        Left = false;
        Cw = false;
        Countercw = false;
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log (Input.GetKey("joystick button 0"));

        float yAxis = Input.GetAxis ("Vertical");
        float zAxis = Input.GetAxis ("Horizontal");

        Vector3 rotation = sphere.transform.rotation.eulerAngles;

        //set flags as true when pressed
        if (Input.GetKeyDown(pressUp) || yAxis == -1)
        {
            Up = true;
        }
        if (Input.GetKeyDown(pressRight) || Input.GetKeyDown("joystick button 0"))
        {
            Right = true;
        }
        if (Input.GetKeyDown(pressDown) || yAxis == 1)
        {
            Down = true;
        }
        if (Input.GetKeyDown(pressLeft) || Input.GetKeyDown("joystick button 1"))
        {
            Left = true;
        }
        if (Input.GetKeyDown(clockwise) || zAxis == 1)
        {
            Countercw = true;
        }
        if (Input.GetKeyDown(counterClockwise) || zAxis == -1)
        {
            Cw = true;
        }

        //set flags as false when released
        if (Input.GetKeyUp(pressUp) || yAxis == -1)
        {
            Up = false;
        }
        if (Input.GetKeyUp(pressRight) || Input.GetKeyUp("joystick button 0"))
        {
            Right = false;
        }
        if (Input.GetKeyUp(pressDown) || yAxis == 1)
        {
            Down = false;
        }
        if (Input.GetKeyUp(pressLeft) || Input.GetKeyUp("joystick button 1"))
        {
            Left = false;
        }
        if (Input.GetKeyUp(clockwise) || zAxis == 1)
        {
            Countercw = false;
        }
        if (Input.GetKeyUp(counterClockwise) || zAxis == -1)
        {
            Cw = false;
        }
        moveSphere();
    }
    public void moveSphere()
    {
        //movementSpeed = 40.0f * Time.deltaTime;
        if (Up)
            sphere.transform.Rotate(movementSpeed, 0.0f, 0.0f, Space.World);
        if (Right)
            sphere.transform.Rotate(0.0f, movementSpeed, 0.0f, Space.World);
        if(Down)
            sphere.transform.Rotate(-movementSpeed, 0.0f, 0.0f, Space.World);
        if (Left)
            sphere.transform.Rotate(0.0f, -movementSpeed, 0.0f, Space.World);
        if (Cw)
            sphere.transform.Rotate(0.0f, 0.0f, -movementSpeed, Space.World);
        if (Countercw)
            sphere.transform.Rotate(0.0f, 0.0f, movementSpeed, Space.World);
    }       
}