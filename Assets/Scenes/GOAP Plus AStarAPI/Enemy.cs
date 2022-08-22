using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathingAPI;

public class Enemy : MonoBehaviour
{
    //AStar aStar;
    
    public PathingAPI.GridGenerator grid;
    PathingAPI.AStarManager pathManager;

    //bool following;
    //int index = 0;


    public float speed;

    public Vector3Int startPoint;
    public Vector3Int endPoint;
    public Vector3Int patrolPoint1;
    public Vector3Int patrolPoint2;
    public Vector3Int patrolPoint3;
    //public Vector3Int patrolPoint4;

    Vector3Int[] patrolPnts;

    //Node startNode;
    //Node endNode;

    //GameObject player;
    //Node playerPosOnGrid;


    // Start is called before the first frame update
    void Start()
    {
        pathManager = GetComponent<PathingAPI.AStarManager>();
        pathManager.aStar.grid = grid;

        patrolPnts = new Vector3Int[3];
        patrolPnts[0] = patrolPoint1;
        patrolPnts[1] = patrolPoint2;
        patrolPnts[2] = patrolPoint3;

        //aStar = new AStar();//GetComponent<AStar>();
        //aStar.grid = grid;
        /*playerPosOnGrid = aStar.grid.GetNode(new Vector3Int(
                                            (int)player.transform.position.x, 
                                            (int)player.transform.position.y, 
                                            (int)player.transform.position.z));*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            pathManager.FollowPathSingle(startPoint, endPoint, speed);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            pathManager.FollowPatrolPath(patrolPnts, speed);
        }


        /*
        if (Input.GetKeyDown(KeyCode.K) && !following)
        {
            startNode = aStar.grid.GetNode(startPoint);
            endNode = aStar.grid.GetNode(endPoint);

            if (aStar.FindPath(startNode, endNode))
            {
                following = true;
                index = 0;
                Debug.Log("Noice");
            }
            else
                Debug.Log("No valid path found!");
        }

        if (Input.GetKeyDown(KeyCode.R) && !following)
        {
            if (aStar.FindPath(aStar.grid.GetNode(patrolPoint1), aStar.grid.GetNode(patrolPoint2)))
            {
                following = true;
                index = 0;
                Debug.Log("Noice");
            }
            else
                Debug.Log("No valid path found!");
        }

        if (Input.GetKeyDown(KeyCode.Y) && !following)
        {
            if (aStar.FindPath(aStar.grid.GetNode(patrolPoint3), aStar.grid.GetNode(patrolPoint4)))
            {
                following = true;
                index = 0;
                Debug.Log("Noice");
            }
            else
                Debug.Log("No valid path found!");
        }

        // go through each node in the found path one by one
        if (following)
        {
            if (index >= aStar.finalNodePath.Count) // stop following once we've reached the end of our node list (end of the path)
            {
                following = false;
                return;
            }

            transform.position = Vector3.MoveTowards(transform.position, 
                                                     aStar.finalNodePath[index].worldPosition, 
                                                     speed); // move to next node

            if (Vector3.Distance(transform.position, aStar.finalNodePath[index].worldPosition) < 0.2f)
            {
                index++;
            }

        }
        */

    }
}
