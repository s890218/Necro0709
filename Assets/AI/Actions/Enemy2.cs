using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class EnemyDataInit : RAINAction
{

	public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
		int key = ai.WorkingMemory.GetItem<int>("type");
		MonsterDataObject data;
		if (GameGlobalValue.s_MonsterData.TryGetValue(key , out data))
		{
			ai.WorkingMemory.SetItem("NowHp" , data.m_Hp);
			ai.WorkingMemory.SetItem("MaxHp", data.m_Hp);
			ai.WorkingMemory.SetItem("Atk", data.m_Atk);
		}
		Debug.Log("init");
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