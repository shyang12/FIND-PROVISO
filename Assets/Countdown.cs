using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    GameObject Orange;
    GameObject Red;
    GameObject hint1;
    GameObject hint2;
    bool activehint = false;

    public string m_Timer = @"00:00:00.000";
    private bool m_IsPlaying = true;
    public float m_TotalSeconds = 5 * 60; // 카운트 다운 전체 초(5분 X 60초), 인스펙트 창에서 수정해야 함. 
    public Text m_Text;
    // Start is called before the first frame update
    void Start()
    {
        this.Orange = GameObject.Find("Orange");
        this.Red = GameObject.Find("Red");
        this.hint1 = GameObject.Find("hint1");
        this.hint2 = GameObject.Find("hint2");
        Orange.GetComponent<Image>().enabled = activehint;
        Red.GetComponent<Image>().enabled = activehint;
        hint1.GetComponent<Text>().enabled = activehint;
        hint2.GetComponent<Text>().enabled = activehint;
        m_Timer = CountdownTimer(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsPlaying)
        {
            m_Timer = CountdownTimer();
        }

        // m_TotalSeconds이 줄어들때, 완전히 0에 맞출수 없기 때문에  
        if (m_TotalSeconds <= 0)
        {
            SetZero();
            //... 여기에 카운트 다운이 종료 될때 [이벤트]를 넣으면 됩니다. 
            SceneManager.LoadScene("BadEnding");
        }

        if(m_TotalSeconds <= 10*60)
        {
            Orange.GetComponent<Image>().enabled = true;
            hint1.GetComponent<Text>().enabled = true; 
        }
        if (m_TotalSeconds <= 7*60)
        {
            Orange.GetComponent<Image>().enabled = false;
            hint1.GetComponent<Text>().enabled = false;
        }

        if(m_TotalSeconds <=5*60)
        {
            m_Timer = "<color=red>"+ m_Timer + "</color>";
            Red.GetComponent<Image>().enabled = true;
            hint2.GetComponent<Text>().enabled = true;
        }
        if (m_Text)
            m_Text.text = m_Timer;
    }

    private string CountdownTimer(bool IsUpdate = true)
    {
        if (IsUpdate)
            m_TotalSeconds -= Time.deltaTime;

        TimeSpan timespan = TimeSpan.FromSeconds(m_TotalSeconds);
        string timer = string.Format("{0:00}:{1:00}:{2:00}.{3:000}",
            timespan.Hours, timespan.Minutes, timespan.Seconds, timespan.Milliseconds);

        return timer;
    }

    private void SetZero()
    {
        m_Timer = @"00:00:00.000";
        m_TotalSeconds = 0;
        m_IsPlaying = false;
    }
}
