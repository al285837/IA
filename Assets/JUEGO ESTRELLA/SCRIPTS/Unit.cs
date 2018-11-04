﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Unit : MonoBehaviour {

    const float minPathUpdateTime = .2f;
    const float pathUpdateMoveThreshold = .5f;

    Transform target;
    public float speed = 20;
    public float turnSpeed = 3;
    public float turnDst = 5;
    public float stoppingDst = 10;

    Path path;
    //Transform transform;



    

    void Start()
    {

        Transform targetHeard = GameObject.FindGameObjectWithTag("TargetHeard").transform;
        //transform = GetComponent<Transform>();
        targetHeard.position = transform.position;
        target = targetHeard;
        StartCoroutine(UpdatePath());
        
        
    }

    public void OnPathFound(Vector3 [] waypoints, bool pathSuccessful)
    {
        for (int i =0;i<waypoints.Length; i++){
            waypoints[i] += new Vector3(0,1,0);
        }

        if (pathSuccessful)
        {
            path = new Path(waypoints,transform.position,turnDst,stoppingDst);

            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }
    
    IEnumerator UpdatePath()
    {
        if(Time.timeSinceLevelLoad < .3f)
        {
            yield return new WaitForSeconds(.3f);
        }
        PathRequestManager.RequestPath(new PathRequest(transform.position, target.position, OnPathFound));

        float sqrMoveThreshold = pathUpdateMoveThreshold * pathUpdateMoveThreshold;
        Vector3 targetPosOld = target.position;


        while (true)
        {
            yield return new WaitForSeconds(minPathUpdateTime);
            if((target.position -targetPosOld).sqrMagnitude> sqrMoveThreshold)
            {
                PathRequestManager.RequestPath(new PathRequest(transform.position, target.position, OnPathFound));
                targetPosOld = target.position;
            }
            
        }
    }


    IEnumerator FollowPath()
    {

        bool followingPath = true;
        int pathIndex = 0;
        transform.LookAt(path.lookPoints[0]);

        float speedPercent = 1;

        while (followingPath)
        {
            Vector2 pos2D = new Vector2(transform.position.x, transform.position.z);
            while (path.turnBoundaries[pathIndex].HasCrossedLine(pos2D))
            {
                if (pathIndex == path.finishLineIndex)
                {
                    followingPath = false;
                    break;
                }
                else { pathIndex++; }
            }

            if (followingPath)
            {
                if(pathIndex>= path.slowDownIndex && stoppingDst> 0)
                {
                    speedPercent = Mathf.Clamp01(path.turnBoundaries[path.finishLineIndex].DistanceFromPoint(pos2D) / stoppingDst);
                    if (speedPercent < 0.01f)
                    {
                        followingPath = false;
                    }
                }
               


                Quaternion targetRotation = Quaternion.LookRotation(path.lookPoints[pathIndex] - transform.position);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
                transform.Translate(Vector3.forward * Time.deltaTime * speed* speedPercent, Space.Self);
            }

           yield return null;
        }
    }
	
    public void OnDrawGizmos() {
        if(path != null)
        {
            path.DrawWithGizmos();
        }

    }
       
}
