using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoawnManager : MonoBehaviour
{

    public GameObject spawnPoint;
    public GameObject agentprefab1;
    public GameObject agentprefab2;
    public GameObject agentprefab3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            spawn(agentprefab1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            spawn(agentprefab2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            spawn(agentprefab3);
        }
    }

    void spawn(GameObject objectPrefab)
    {
        Instantiate(objectPrefab, spawnPoint.transform.position, Quaternion.identity);
    }
}
