using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoter : MonoBehaviour {

	private Transform m_Player = null;
	private float m_LifeTime = 0;
	private float m_ChangeTime = 0;
	private float m_Speed = 0;
	private float m_Damage = 0;

	private float m_Time = 0;
	private float m_OverTime = 0;

	private int m_Type = 0;
	public void InitData(FireData data)
	{
		m_Player = PlayerManager.m_Main.GetPlayerTransform();
		m_LifeTime = data.m_LifeTime;
		m_ChangeTime = data.m_ChangeTime;
		m_Speed = data.m_Speed;
		m_Damage = data.m_Damage;
		m_OverTime = Time.time + data.m_LifeTime;
		m_Type = data.m_Type;
		transform.LookAt(m_Player);
	}

	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * m_Speed * Time.deltaTime);
		if (m_OverTime < Time.time)
		{
			if (m_OverTime + 3 < Time.time)
			{
				Destroy(this.gameObject);
			}
			return;
		}

		if (m_Time< Time.time)
		{
			
			m_Time = Time.time + m_ChangeTime;
			transform.LookAt(m_Player);
		}
		
	}
	

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			if (m_Type == 0)
			{
				PlayerManager.m_Main.OnHurt(m_Damage);
				Destroy(this.gameObject);
			}
			else
			{
				PlayerManager.m_Main.OnEatSoul(15);
				Destroy(this.gameObject);
			}
		}
		
	}

	
}
