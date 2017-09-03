using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

	public static PlayerManager m_Main = null;

	[SerializeField]
	private PlayerController m_PlayerController = null;
	[SerializeField]
	private Text m_HpValue = null;
	[SerializeField]
	private Slider m_HpBar = null;
	[SerializeField]
	private Image m_ActionEffectImage = null;
	[SerializeField]
	private Text m_SoulValue = null;
	[SerializeField]
	private Slider m_SoulBar = null;
	[SerializeField]
	private int m_Test = 0;


	private CharDataObject m_PlayerData = null;
	private Color m_EffectColorHurt;
	private Color m_EffectColorSoul = new Color(0.2f,1f,0.2f,0.01f);
	private float m_HpMax = 0;
	private float m_HpNow = 0;
	private ActionType m_ActionType = 0;

	private int m_SoulMax = 100;
	private int m_SoulNow = 0;

	public enum ActionType : int
	{
		NONE = 0,
		HURT = 1,
		ADD_SOUL = 2,
	}


	private void Awake()
	{
		m_Main = this;

		//GameGlobalValue的資料初始化 在awake 要用到 要在start確保資料存在
	}

	private void Start()
	{
		if (m_PlayerData == null)
		{
			m_PlayerData = GameGlobalValue.s_CharData[1];
			m_EffectColorHurt = m_ActionEffectImage.color;
			//Debug.Log(m_EffectColorHurt);
		}
		SetHpInit();
	}

	private void Update()
	{
		switch (m_ActionType)
		{
			case ActionType.NONE:
				break;
			case ActionType.HURT:
				UpdateHurt();
				break;
			case ActionType.ADD_SOUL:
				UpdateSoul();
				break;
			default:
				break;
		}
	}

	private void UpdateHurt()
	{
		m_ActionEffectImage.color = Color.Lerp(m_ActionEffectImage.color, m_EffectColorHurt, 0.1f);
		//Debug.Log(m_EffectColorHurt);
		if (m_ActionEffectImage.color.a < 0.01f)
		{
			m_ActionEffectImage.color = m_EffectColorHurt;
			m_ActionType = ActionType.NONE;
		}
	}

	private void UpdateSoul()
	{
		m_ActionEffectImage.color = Color.Lerp(m_ActionEffectImage.color, m_EffectColorSoul, 0.1f);
		if (m_ActionEffectImage.color.a < 0.01f)
		{
			m_ActionEffectImage.color = m_EffectColorSoul;
			m_ActionType = ActionType.NONE;
		}
	}

		public void OnHurt(float value)
	{
		m_ActionEffectImage.color = new Color(m_EffectColorHurt.r, m_EffectColorHurt.g, m_EffectColorHurt.b, 0.5f);
		m_ActionType = ActionType.HURT;
		m_HpNow -= value;
		if (m_HpNow<=0)
		{
			SceneManager.LoadScene(0);
			return;
		}
		m_HpValue.text = GameTools.GetBarValueText(m_HpNow, m_HpMax);
		m_HpBar.value = m_HpNow / m_HpMax;
		
	}

	public void OnEatSoul(float value)
	{
		m_ActionEffectImage.color = new Color(m_EffectColorSoul.r, m_EffectColorSoul.g, m_EffectColorSoul.b, 0.5f);
		m_ActionType = ActionType.ADD_SOUL;
		m_SoulNow += (int)value;
		if (m_SoulNow >= 1000)
		{
			SceneManager.LoadScene(0);
			return;
		}
		m_SoulValue.text = GameTools.GetBarValueText(m_SoulNow, m_SoulMax);
		m_SoulBar.value = m_SoulNow / (float)m_SoulMax; 

	}

	public Transform GetPlayerTransform()
	{
		return m_PlayerController.m_Player;
	}

	private void SetHpInit()
	{
		m_HpMax = m_PlayerData.m_Hp;
		m_HpNow = m_PlayerData.m_Hp;
		m_HpValue.text = GameTools.GetBarValueText(m_HpNow, m_HpMax);
		m_HpBar.value = m_HpNow / m_HpMax;
	}

	private void SetSoulInit()
	{
		m_SoulMax = 100;
		m_SoulNow = 0;
		m_SoulValue.text = GameTools.GetBarValueText(m_SoulNow, m_SoulMax);
		m_SoulBar.value = m_SoulNow / (float)m_SoulMax;
	}
}
