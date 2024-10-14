using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class SampleMovementScript : MonoBehaviour
{
    //This variable stores the data for the Rigidbody component, allowing game physics
    private Rigidbody physics;

    /// <summary>
    /// [SerializeField] is a attribute! This attribute allows a private variable 
    /// to be seen in the Unity Inspector.
    /// </summary>

    //This variable stores information for the exact Axis the player will move on, exp: "Horizontal" or "Vertical Axises"
    private Vector3 MovementInput; 

    //This variable stores information for the exact direction the player will move in
    private Vector3 MoveDirection;

    public float speed;

    //The awake is used to set variables before the game starts
    private void Awake()
    {
        physics = GetComponent<Rigidbody>();
    }

    //This is a custom method created to hold the body of coded needed for player movement
    public void MovementMethod()
    {

        //Assign Movement Input variable too access both HORIZONTAL and VERTICAL axis in a new Vector3
        MovementInput = new Vector3(Input.GetAxis("Horizontal"), physics.velocity.y, Input.GetAxis("Vertical"));

        //Use Move Direction variable to assign the transform direction based on the input, and multiply it by the speed
        MoveDirection = transform.TransformDirection(MovementInput) * speed;

        //Create a brand new velocity that uses the MoveDirection variable to acces the x and x movement
        physics.velocity = new Vector3(MoveDirection.x, physics.velocity.y, MoveDirection.z);
    }
    
    //Fixed Update is mainly used for physics based procedures
    private void FixedUpdate()
    {
        //Place movement method in here
        MovementMethod();
    }


}
