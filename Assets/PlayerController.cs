using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public Transform m_Player = null;
    public Rigidbody2D m_RigidbodyPlayer = null;
    public Transform m_Left = null;
    public Transform m_Right = null;
    public bool _canTwoJump = false;

    Quaternion Leftt;
    Quaternion Rightt;
    Animator _objAnimator;

    private void Awake()
    {
        m_Player.gameObject.SetActive(true);
        Leftt = Quaternion.Euler(0, 0, 0);
        Rightt = Quaternion.Euler(0, 180, 0);
        _objAnimator = m_Player.gameObject.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start ()
    {
        //_objAnimator.SetFloat("Speed", Input.GetAxis("Horizontal"));

        
	}
	
	// Update is called once per frame
	void Update () {

        _objAnimator.SetFloat("Speed", Input.GetAxis("Horizontal"));
        

        if (Input.GetAxis("Horizontal") == 0 && !Input.GetButton("Horizontal"))
        {
            _objAnimator.SetBool("isIdle", true);
            _objAnimator.speed = 1;
            
            
            //Debug.Log(Input.GetAxis("Horizontal"));
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            m_Player.rotation = Rightt;
            _objAnimator.SetBool("isIdle", false);
            //_objAnimator.speed = Input.GetAxis("Horizontal") * 1.2f;
            

            //Debug.Log(Input.GetAxis("Horizontal"));
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            m_Player.rotation = Leftt;
            _objAnimator.SetBool("isIdle", false);
            //_objAnimator.speed = Input.GetAxis("Horizontal") * 1.2f* -1;
            

            //Debug.Log(Input.GetAxis("Horizontal"));
        }
        /* 
         if (Input.GetAxis("Horizontal") != 0)
         {
             _objAnimator.SetBool("isIdle", false);
             return;
         }
         */
        /*
		if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //m_Player.rotation = m_Left.rotation;
            m_Player.rotation = Leftt;
            

        }
        
        if (Input.GetKey(KeyCode.A))
        {
            m_RigidbodyPlayer.AddForce(new Vector2(-500, 0));
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //m_Player.rotation = m_Right.rotation;
            m_Player.rotation = Rightt;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            m_RigidbodyPlayer.AddForce(new Vector2(500, 0));
        }
        */
        RaycastHit2D ray = Physics2D.Raycast(m_Player.transform.localPosition, Vector2.down, 1.8f, 1 << 12);
        if (ray.collider)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                m_RigidbodyPlayer.AddForce(new Vector2(0, 2300));
                Debug.Log("777777");
            }
            else { _canTwoJump = true;return; }
        }
        else if (  _canTwoJump == true && !ray.collider && Input.GetButtonDown("Fire1"))
        {
            
            m_RigidbodyPlayer.velocity = new Vector2(m_RigidbodyPlayer.velocity.x, 0f);
            m_RigidbodyPlayer.AddForce(new Vector2(0, 2300));
            _canTwoJump = false;

        }


        if (m_Player.transform.localPosition.y<-10)
        {
            SceneManager.LoadScene(0);
        }
    }

}
