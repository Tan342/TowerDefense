using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    List<Node> path = new List<Node>();
    [SerializeField] float speed = 2f;

    GridManager gridManager;
    bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        gridManager = FindObjectOfType<GridManager>();
        Move();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StopMove()
    {
        StopCoroutine("FollowPath");
        isMoving = false;
        Node currentNode = gridManager.GetNodeFromPosition(transform.position);
        currentNode.isPlaceable = false;
    }

    public void Move()
    {
        if(isMoving)
        {
            return;
        }
        Node start = gridManager.GetNodeFromPosition(transform.position);
        path = gridManager.BFS(start);
        isMoving = true;
        StartCoroutine("FollowPath");
        Node currentNode = gridManager.GetNodeFromPosition(transform.position);
        currentNode.isPlaceable = true;
    }

    IEnumerator FollowPath()
    {
        for (int i = 0; i < path.Count - 1; i++)
        {
            Vector3 start = transform.position;
            Vector3 end = path[i+1].GetPosition();

            float timer = 0;

            while(timer <=1 && isMoving)
            {
                timer += Time.deltaTime;
                transform.position = Vector3.Lerp(start,end, timer * speed); 
                yield return new WaitForEndOfFrame();
            }
        }
    }

    
}
