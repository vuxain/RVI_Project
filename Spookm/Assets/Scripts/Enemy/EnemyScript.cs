using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    private NavMeshAgent Enemy;
    public GameObject Player;

    private bool message = false;

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

        Enemy.SetDestination( Player.transform.position);
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.tag);

         if(col.tag == "Player")
            message = true;
    }

    void OnGUI () {
        if (message) {
            Time.timeScale = 0.0f; 
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), "Loš kraj žurke");
        }
    }
}


