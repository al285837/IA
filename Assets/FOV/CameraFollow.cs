using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


    public Transform player;
    public float smoothTime;

    private Vector3 velocity;
    Camera camera;

    public float numero;

    float min_camera;
    float max_camera;
    public float camera_zoom_speed;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        smoothTime = 0.2f;

        velocity = Vector3.zero;
        camera = GetComponent<Camera>();

        min_camera = 2f;
        max_camera = 10f;
        camera_zoom_speed = 150f;


    }


    void Update()
    {

        Vector3 goalPos = player.position;
        goalPos.y = transform.position.y;
        transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, smoothTime);

        
        if(Input.GetAxis("Mouse ScrollWheel") > 0f && camera.orthographicSize > min_camera)
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, camera.orthographicSize - 1, camera_zoom_speed * Time.deltaTime);
            if (camera.orthographicSize < min_camera) camera.orthographicSize = min_camera;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f && camera.orthographicSize < max_camera)
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, camera.orthographicSize + 1, camera_zoom_speed * Time.deltaTime);
            if (camera.orthographicSize > max_camera) camera.orthographicSize = max_camera;
            
        }

        numero = camera.orthographicSize;
        
        
    }

}
