using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLookPlayer : MonoBehaviour {

    public Transform m_Player = null;
    public Transform m_Cam = null;
    private float m_PosY = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float math_f = Mathf.Lerp(m_Cam.localPosition.y, m_PosY, 0.1f);
        m_Cam.localPosition = new Vector3(m_Player.localPosition.x, math_f, -10);
        m_PosY = m_Player.localPosition.y;

    }
}
