using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour
{
    public PlayerControl playerControlScpt;
    void Update()
    {
        if (playerControlScpt.count == 12)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }  
        }
        
    }

}