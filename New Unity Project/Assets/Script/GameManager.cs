using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerControl playerControlScpt;
    [SerializeField] SphereCollider playerSphere;
    [SerializeField] Rigidbody playerRigid;
    [SerializeField] PlayerControl gameRestart;

    public AudioSource song;

    public void BGsoundtrack()
    {
        song.Play();
    }
    void GameRestart()
    {
        if (playerControlScpt.count == 8)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }  
        }
        
    }
}
