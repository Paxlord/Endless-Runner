using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour {

    public GameObject groundPrefab;
    public GameObject obstaclePrefab;
    
    float scrollingSpeed = 2f;

    Vector3 scrollMovement = new Vector3();

    float endPoint;
    float startPoint;

    List<GameObject> grounds = new List<GameObject>();
    List<GameObject> obstacles = new List<GameObject>();

    GameObject currentGround;

    // Use this for initialization
    void Start () {
        

        endPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -10)).x;
        startPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, -10)).x;

        currentGround = Instantiate(groundPrefab, new Vector3(endPoint + 30, -5, 0), Quaternion.identity);
        currentGround.transform.position = new Vector3(startPoint + (currentGround.GetComponent<Collider2D>().bounds.size.x/2), -5, 0);
        grounds.Add(currentGround);

        currentGround = Instantiate(groundPrefab, new Vector3(startPoint + currentGround.GetComponent<Collider2D>().bounds.size.x + (currentGround.GetComponent<Collider2D>().bounds.size.x / 2), -5, 0), Quaternion.identity);
        grounds.Add(currentGround);

    }

    // Update is called once per frame
    void Update () {


        if (currentGround.transform.position.x + currentGround.GetComponent<Collider2D>().bounds.size.x/2 -1 <= endPoint)
        {
            currentGround = Instantiate(groundPrefab, new Vector3(endPoint + (currentGround.GetComponent<Collider2D>().bounds.size.x / 2), -5, 0), Quaternion.identity);

            

            grounds.Add(currentGround);

            spawnObstacle(currentGround);
        }

        for(int i = 0; i < grounds.Count; i++)
        {

            if (grounds[i].transform.position.x + grounds[i].GetComponent<Collider2D>().bounds.size.x / 2 < startPoint)
            {
                Destroy(grounds[i]);
                grounds.RemoveAt(i);
                
            }

        }

        for(int j = 0; j < obstacles.Count; j++)
        {

            if (obstacles[j].transform.position.x + obstacles[j].GetComponent<Collider2D>().bounds.size.x / 2 < startPoint)
            {
                Destroy(obstacles[j]);
                obstacles.RemoveAt(j);

            }

        }
    }

    void spawnObstacle(GameObject g)
    {
        float positionX = g.transform.position.x;
        int rightOrLeft = Random.Range(0, 2) * 2 -1 ;
        float randomPos = Random.Range(0,g.GetComponent<Collider2D>().bounds.size.x/2);


        int upOrDown = Random.Range(0, 2) * 2 - 1;
        
        if(upOrDown == -1)
        {
            GameObject currentObstacle = Instantiate(obstaclePrefab, new Vector3(positionX + (randomPos * rightOrLeft), g.transform.position.y + 1, 0), Quaternion.identity);
            obstacles.Add(currentObstacle);
        }
        else
        {
            GameObject currentObstacle = Instantiate(obstaclePrefab, new Vector3(positionX + (randomPos * rightOrLeft), g.transform.position.y + 3, 0), Quaternion.identity);
            obstacles.Add(currentObstacle);
        }
        


    }
}
