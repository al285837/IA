using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


    public Transform player;
    public float smoothTime;

    private Vector3 velocity;
    Camera camera;

    public float numero;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        smoothTime = 0.2f;

        velocity = Vector3.zero;
        camera = GetComponent<Camera>();
        numero = 0;
  
    }


    void Update()
    {

        Vector3 goalPos = player.position;
        goalPos.y = transform.position.y;
        transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, smoothTime);

        
        if(Input.GetAxis("Mouse ScrollWheel") > 0f && camera.orthographicSize>0)
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, camera.orthographicSize - 1, 10f*Time.deltaTime);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f && camera.orthographicSize < 10)
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, camera.orthographicSize + 1, 10f*Time.deltaTime);
            
        }

        numero = camera.orthographicSize;
        
        
    }

}
