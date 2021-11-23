using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour 
{
    public float forceAccepted;
    public float speed;
    private Rigidbody rigid;
    public Text CountText;
    public GameObject GameWinPanel;
    public GameObject button_next;
    public float gravityValue = 2;


    // emission part
    public ParticleSystem walkPar;
    public int walkParRate = 12;
    private ParticleSystem.EmissionModule walkParEmission;


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
        button_next.SetActive(false);
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;

        walkParEmission = walkPar.emission;
    }

    void FixedUpdate()
    {
        if(Input.GetAxis("Horizontal") > 0)
        {
            rigid.AddForce(Vector3.right * speed);
            walkParEmission.rateOverTime = walkParRate;
        }

        else if (Input.GetAxis("Horizontal") < 0)
        {
            rigid.AddForce(-Vector3.right * speed);
            walkParEmission.rateOverTime = walkParRate;
        }

        if(Input.GetAxis("Vertical") > 0)
        {
            rigid.AddForce(Vector3.forward * speed);
            walkParEmission.rateOverTime = walkParRate;
        }

        else if (Input.GetAxis("Vertical") < 0)
        {
            rigid.AddForce(-Vector3.forward * speed);
            walkParEmission.rateOverTime = walkParRate;
        }

        rigid.AddForce(Physics.gravity * rigid.mass * gravityValue);
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
        CountText.text = "Score: " + count.ToString();
        if (count >= 1)
        {
            GameWinPanel.SetActive(true);
            button_next.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void gotoNextLevel()
    {
        SceneManager.LoadScene(nextSceneToLoad);
        Time.timeScale = 1;
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


