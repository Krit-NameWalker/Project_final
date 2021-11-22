using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour {

    
    public float forceAccepted;
    public float speed;
    private Rigidbody rigid;
    public Text CountText;
    public GameObject GameWinPanel;


    private Rigidbody rb;
    public int count;
    private int nextSceneToLoad;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rigid = gameObject.GetComponent<Rigidbody> ();
        count = 0;
        SetCountText();
        GameWinPanel.SetActive(false);
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    void FixedUpdate()
    {
        if(Input.GetAxis("Horizontal") > 0)
        {
            rigid.AddForce(Vector3.right * speed);
        }

        else if (Input.GetAxis("Horizontal") < 0)
        {
            rigid.AddForce(-Vector3.right * speed);
        }

        if(Input.GetAxis("Vertical") > 0)
        {
            rigid.AddForce(Vector3.forward * speed);
        }

        else if (Input.GetAxis("Vertical") < 0)
        {
            rigid.AddForce(-Vector3.forward * speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        CountText.text = "Count: " + count.ToString();
        if (count >= 2)
        {
            GameWinPanel.SetActive(true);
            SceneManager.LoadScene(nextSceneToLoad);
        }
    }

    void OnCollisionEnter(Collision c)
    {
        
        if (c.gameObject.CompareTag("Pusher"))
        {
            
            Vector3 dir = c.transform.position - transform.position;
            
            dir = -dir.normalized;
            
            rb.AddForce(dir * forceAccepted);
        }
    }

}


