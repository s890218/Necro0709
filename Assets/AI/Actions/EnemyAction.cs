using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class EnemyAction : RAINAction
{
	private bool m_IsInit = false;
	private GameObject m_Shoter = null;
	private GameObject m_Shoter2 = null;
	private FireData m_FireData = null;

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
		if(m_IsInit == false)
		{
			m_IsInit = true;
			m_Shoter = Resources.Load<GameObject>("Prefabs/Shot1");
			m_Shoter2 = Resources.Load<GameObject>("Prefabs/Shot2");
			m_FireData = new FireData();
			m_FireData.m_ChangeTime = 0.9f;
			m_FireData.m_LifeTime = 8f;
			m_FireData.m_Speed = 5f;
			m_FireData.m_Damage = 20f;
		}

		if(m_Shoter!=null)
		{
			if (Random.Range(0, 2) == 0)
			{
				GameObject obj = GameObject.Instantiate(m_Shoter, ai.Body.transform.position, m_Shoter.transform.rotation);
				obj.GetComponent<Shoter>().InitData(m_FireData);
			}
			else
			{
				GameObject obj = GameObject.Instantiate(m_Shoter2, ai.Body.transform.position, m_Shoter.transform.rotation);
				obj.GetComponent<Shoter>().InitData(m_FireData);
			}
		}
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}