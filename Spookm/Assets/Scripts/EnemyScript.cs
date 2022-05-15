using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    private NavMeshAgent Enemy;
    public GameObject Player;

    //public float EnemyDistanceRun = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 dirToPlayer = transform.position - Player.transform.position;
        Vector3 newPos = transform.position - dirToPlayer;

        Enemy.SetDestination(newPos);
        
    }
}
