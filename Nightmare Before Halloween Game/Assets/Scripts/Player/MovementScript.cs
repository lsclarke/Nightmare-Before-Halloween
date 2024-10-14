using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementScript : MonoBehaviour
{
    //Variable that controls our speed
    public float speed;
    private float originalspeed;

    //Variable that controls our run speed
    public float RunSpeed;

    public Slider StaminaBar;

    public bool isRunning;

    private void Start()
    {
        originalspeed = speed;
    }
    // Update is called once per frame
    void Update()
    {
        //If I press the W key
        if (Input.GetKey(KeyCode.W))
        {
            //Move my player forward at a speed of 10f by the second
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        //If I press the S key
        if (Input.GetKey(KeyCode.S))
        {
            //Move my player backward at a speed of 10f by the second
            transform.Translate(Vector3.back *  speed * Time.deltaTime);
        }

        //If I press the D key
        if (Input.GetKey(KeyCode.D))
        {
            //Move my player right at a speed of 10f by the second
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        //If I press the A key
        if (Input.GetKey(KeyCode.A))
        {
            //Move my player left at a speed of 10f by the second
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }


        /// Challenge # 1
        /// Create a run mechanic! 
        /// 

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }

        Run();
    }


    public void Run()
    {
        StaminaBar.gameObject.SetActive(isRunning);

        if (isRunning)
        {
            if (StaminaBar.value > 0f)
            {
                speed = RunSpeed;
                StaminaBar.value -= 0.01f;
            }
            else
            {
                isRunning = false;
            }
        }
        else
        {
            speed = 2f;
            StaminaBar.value += 0.01f;
            if(StaminaBar.value > 1f)
            {
                StaminaBar.value = 1f;
            }
        }
    }
}
