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
	private Image m_HurtEffect = null;

	private CharDataObject m_PlayerData = null;
	private Color m_EffectColor;
	private float m_HpMax = 0;
	private float m_HpNow = 0;
	private bool m_IsHurt = false;

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
			m_EffectColor = m_HurtEffect.color;
		}
		m_HpMax = m_PlayerData.m_Hp;
		m_HpNow = m_PlayerData.m_Hp;
		m_HpValue.text = GameTools.GetBarValueText(m_HpNow, m_HpMax);
		m_HpBar.value = m_HpNow / m_HpMax;
	}

	private void Update()
	{
		if(m_IsHurt)
		{
			m_HurtEffect.color = Color.Lerp(m_HurtEffect.color, m_EffectColor, 0.1f);
			if(m_HurtEffect.color.a<0.01f)
			{
				m_HurtEffect.color = m_EffectColor;
				m_IsHurt = false;
			}
		}
	}

	public void OnHurt(float value)
	{
		m_HurtEffect.color = new Color(m_EffectColor.r, m_EffectColor.g, m_EffectColor.b, 0.5f);
		m_IsHurt = true;
		m_HpNow -= value;
		if (m_HpNow<=0)
		{
			SceneManager.LoadScene(0);
			return;
		}
		m_HpValue.text = GameTools.GetBarValueText(m_HpNow, m_HpMax);
		m_HpBar.value = m_HpNow / m_HpMax;
		
	}

	public Transform GetPlayerTransform()
	{
		return m_PlayerController.m_Player;
	}
}
