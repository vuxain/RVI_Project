using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeTriggerScript : MonoBehaviour
{

    public Transform enemy;

    void OnTriggerEnter(Collider col)
    {

        //Debug.Log(enemy.GetComponent<EnemyScript>().enabled);
        if (col.tag == "Player" && enemy.GetComponent<EnemyScript>().enabled == true)
        {
            SceneManager.LoadScene("MainMenuScene");
            Cursor.lockState = CursorLockMode.None;
            
        }
    }
}
