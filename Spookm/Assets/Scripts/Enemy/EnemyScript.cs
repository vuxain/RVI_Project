using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    private NavMeshAgent Enemy;
    public GameObject Player;

    //private bool message = false;

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
        if (col.tag == "Player")
        {
            SceneManager.LoadScene("DeathMenuScene");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
        }
    }

    // void OnGUI () {
    //     if (message) {
    //         Time.timeScale = 0.0f; 
    //         GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), "Loš kraj žurke");
    //     }
    // }
}


