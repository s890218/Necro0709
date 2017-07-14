using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour {

	private void Awake()
	{
		var data = Resources.Load<MonsterDataTotal>("ScriptObject/MonsterData");
		SetMonsterData(data);
	}

	private void SetMonsterData(MonsterDataTotal data)
	{
		for(int i = 0; i<data.m_TotalData.Count; i++)
		{
			MonsterDataObject o = data.m_TotalData[i];
			GameGlobalValue.s_MonsterData[o.m_index] = o;
			//Debug.Log(o.name);
		}
	}

}
