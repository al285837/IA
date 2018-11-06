using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [HideInInspector]
    public float speed;

    public float standing_speed;
    public float crouching_speed;
    Animator anim;
    bool sprinting = false;
    bool crouchI = false;
    bool crouchW = false;
    bool idle = true;

    bool moving = false;
    bool crouchPressed = false;
    bool crouching = false;

    float c_height= 1f;
    float st_height = 1.446755f;

    CapsuleCollider capsula;

    public Vector3 direccion;

    Vector3 center = new Vector3(0, 0.6187291f, 0);
    Vector3 low_center= new Vector3(0, 0.42f, 0);

    public float numero;


    // Use this for initialization
    void Start()
    {

        standing_speed = 10f;    //VELOCIDADES DE PIE Y AGACHADO
        crouching_speed = 4f;

        capsula = GetComponent<CapsuleCollider>();

        anim = GetComponent<Animator>();
        direccion = new Vector3(0, 0, 0);


    }

    // Update is called once per frame
    void Update()
    {
        crouchPressed = Input.GetKeyDown("c");
        if (crouchPressed) toggleCrouch();
        moving = Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f;

        if (idle)
        {
            if (moving)
            {
                idle = false;
                sprinting = true;
            }
            else if (crouching)
            {
                idle = false;
                crouchI = true;           
            }

        }
        else if (crouchI)
        {

            if(!crouching)
            {
                crouchI = false;
                idle = true;
            }
            else if(moving)
            {
                crouchI = false;
                crouchW = true;
            }
        }
        else if (crouchW)
        {
            if (!crouching)
            {
                crouchW = false;
                sprinting = true;
            }
            else if (!moving)
            {
                crouchW = false;
                crouchI = true;
            }
        }
        else if(sprinting)
        {
            if(crouching)
            {
                sprinting = false;
                crouchW = true;
            }
            else if(!moving)
            {
                sprinting = false;
                idle = true;
                    
            }
        }

        actualizarBools();

        if (!crouching)
        {
            speed = standing_speed;
            capsula.height = st_height;
            capsula.center = center;
        }
        if (crouching)
        {
            speed = crouching_speed;
            capsula.height = c_height;
            capsula.center =  low_center;


        }
        numero = capsula.height;




        direccion = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        if (direccion != Vector3.zero) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direccion), 0.15F);

        

        transform.Translate((direccion.normalized) * speed * Time.deltaTime, Space.World);
      


    }


    void toggleCrouch()
    {
        if (crouching) crouching = false;
        else crouching = true;

    }

    void actualizarBools()
    {
        anim.SetBool("CrouchingI", crouchI);
        anim.SetBool("CWalking", crouchW);
        anim.SetBool("Sprinting", sprinting);
        anim.SetBool("Idle", idle);
    }


    void CodigoAparte()
    {
        if (/*(Input.GetKeyDown("v") && (*/Input.GetAxis("Horizontal") == 0f && Input.GetAxis("Vertical") == 0f/*)) || ((Input.GetAxis("Horizontal") == 0f || Input.GetAxis("Vertical") == 0f) &&crouchW ==true)*/)
        {


            if (Input.GetKeyDown("v"))
            {
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


            else if ((idle || crouchW) && crouchI == false)
            {

                speed = 5f;
                sprinting = true;
                anim.SetBool("Sprinting", sprinting);

            }
        }
    }
}
