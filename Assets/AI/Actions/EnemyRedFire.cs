using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class EnemyRedFire : RAINAction
{
	private bool m_IsInit = false;
	private GameObject m_Shoter = null;
	private FireData m_FireData = null;

	public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
		if (m_IsInit == false)
		{
			m_IsInit = true;
			m_Shoter = Resources.Load<GameObject>("Prefabs/Shot3");
			m_FireData = new FireData();
			m_FireData.m_ChangeTime = 0.6f;
			m_FireData.m_LifeTime = 10f;
			m_FireData.m_Speed = 7f;
			m_FireData.m_Damage = 50;
		}
		if (m_Shoter != null)
		{
			GameObject obj = GameObject.Instantiate(m_Shoter, ai.Body.transform.position, m_Shoter.transform.rotation);
			obj.GetComponent<Shoter>().InitData(m_FireData);
			ai.WorkingMemory.SetItem("DelayTime", 2.5f);
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