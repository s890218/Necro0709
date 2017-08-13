using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private Transform m_BottomPoint1 = null;
	[SerializeField]
	private Transform m_BottomPoint2 = null;

	public Transform m_Player = null;
    public Rigidbody2D m_RigidbodyPlayer = null;
    public Transform m_Left = null;
    public Transform m_Right = null;
    public bool _canTwoJump = false;

    Quaternion Leftt;
    Quaternion Rightt;
    Animator _objAnimator;

	private Vector2 m_check1;
	private Vector2 m_check2;
	private float m_Dis1;
	private float m_Dis2;
	private bool m_IsLeft = true;

	private void Awake()
    {
        m_Player.gameObject.SetActive(true);
        Leftt = Quaternion.Euler(0, 0, 0);
        Rightt = Quaternion.Euler(0, 180, 0);
        _objAnimator = m_Player.gameObject.GetComponent<Animator>();
		m_check1 = new Vector2(m_BottomPoint1.position.x - m_Player.position.x, m_BottomPoint1.position.y - m_Player.position.y );
		m_check2 = new Vector2(m_BottomPoint2.position.x - m_Player.position.x, m_BottomPoint2.position.y - m_Player.position.y);
		m_Dis1 = Vector3.Distance(m_Player.transform.localPosition, m_BottomPoint1.position);
		m_Dis2 = Vector3.Distance(m_Player.transform.localPosition, m_BottomPoint2.position);
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
			RotatePlayerDis(false);

			//Debug.Log(Input.GetAxis("Horizontal"));
		}
        else if (Input.GetAxis("Horizontal") < 0)
        {
            m_Player.rotation = Leftt;
            _objAnimator.SetBool("isIdle", false);
			//_objAnimator.speed = Input.GetAxis("Horizontal") * 1.2f* -1;
			RotatePlayerDis(true);

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
#if UNITY_EDITOR
		Debug.DrawRay(m_Player.position, m_check1, Color.red, m_Dis1);
		Debug.DrawRay(m_Player.position, m_check2, Color.red, m_Dis2);
#endif
		RaycastHit2D ray = Physics2D.Raycast(m_Player.position, m_check1,m_Dis1, 1 << 12);
		RaycastHit2D ray2 = Physics2D.Raycast(m_Player.position, m_check2, m_Dis2, 1 << 12);

		if (ray.collider|| ray2.collider)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                m_RigidbodyPlayer.AddForce(new Vector2(0, 2300));
            }
            else { _canTwoJump = true;return; }
        }
        else if (  _canTwoJump == true && !(ray.collider|| ray2.collider) && Input.GetButtonDown("Fire1"))
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

	private void RotatePlayerDis(bool isLeft)
	{
		if(m_IsLeft == isLeft)
		{
			return;
		}
		m_IsLeft = isLeft;
		Vector2 v = m_check1;
		m_check1 = new Vector2(-1* m_check1.x, m_check1.y);
		m_check2 = new Vector2(-1 * m_check2.x, m_check2.y);
	}
}
