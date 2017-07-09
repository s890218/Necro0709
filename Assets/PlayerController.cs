using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public Transform m_Player = null;
    public Rigidbody2D m_RigidbodyPlayer = null;
    public Transform m_Left = null;
    public Transform m_Right = null;

    private void Awake()
    {
        m_Player.gameObject.SetActive(true);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A))
        {
            m_Player.rotation = m_Left.rotation;
        }
        if (Input.GetKey(KeyCode.A))
        {
            m_RigidbodyPlayer.AddForce(new Vector2(-500, 0));
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            m_Player.rotation = m_Right.rotation;
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_RigidbodyPlayer.AddForce(new Vector2(500, 0));
        }
        RaycastHit2D ray = Physics2D.Raycast(m_Player.transform.localPosition, Vector2.down,1.8f,1<<12);
        if(ray.collider)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_RigidbodyPlayer.AddForce(new Vector2(0, 2300));
            }
        }
        if(m_Player.transform.localPosition.y<-10)
        {
            SceneManager.LoadScene(0);
        }
    }
}
