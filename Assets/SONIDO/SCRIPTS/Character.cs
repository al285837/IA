using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public float speed;
    Animator anim;
    bool sprinting = false;
    bool crouchI = false;
    bool crouchW = false;
    bool idle = true;

    // Use this for initialization
    void Start()
    {

        speed = 3.5f;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (/*(Input.GetKeyDown("v") && (*/Input.GetAxis("Horizontal") == 0f && Input.GetAxis("Vertical") == 0f/*)) || ((Input.GetAxis("Horizontal") == 0f || Input.GetAxis("Vertical") == 0f) &&crouchW ==true)*/)
        {
            

            if (Input.GetKeyDown("v")){
                if (crouchI == false)
                {
                    idle = false;
                    anim.SetBool("Idle", idle);
                    crouchI = true;
                    anim.SetBool("CrouchingI", crouchI);
                }
                else
                {
                    crouchI = false;
                    anim.SetBool("CrouchingI", crouchI);
                    idle = true;
                    anim.SetBool("Idle", idle);
                }
                
            }
           


            if (crouchW == true && crouchI == false)
            {
               
               /*if (Input.GetKeyDown("v"))
                {
                    crouchI = false;
                    anim.SetBool("CrouchingI", crouchI);
                    idle = true;
                    anim.SetBool("Idle", idle);
                }*/
                crouchW = false;
                anim.SetBool("CWalking", crouchW);
                crouchI = true;
                anim.SetBool("CrouchingI", crouchI);
                
            }


           

           


        }

        if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
        {
           //print("" + idle + ", " + walking + ", " + sprinting);

            //print(crouchI);

            if (crouchI || sprinting)
            {
           

                if ((Input.GetAxis("Horizontal") <= 0.5f || Input.GetAxis("Vertical") <= 0.5f) && crouchI)
                {
                    speed = 2f;
                    crouchI = false;
                    anim.SetBool("CrouchingI", crouchI);
                    crouchW = true;
                    anim.SetBool("CWalking", crouchW);

               }

                if ((Input.GetAxis("Horizontal") <= 0.5f || Input.GetAxis("Vertical") <= 0.5f) && sprinting)
                {
                    speed = 2f;
                    sprinting = false;
                    anim.SetBool("Sprinting", sprinting);
                    crouchW = true;
                    anim.SetBool("CWalking", crouchW);

                }
                /*if (Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("Vertical") > 0.5f)
                {
                    speed = 5f;
                    sprinting = true;
                    anim.SetBool("Sprinting", sprinting);

                }*/
            }
            

            else if((idle || crouchW ) && crouchI ==false)
            { 
               
                    speed = 5f;
                    sprinting = true;
                    anim.SetBool("Sprinting", sprinting);
                      
            }
        }

    }
}
