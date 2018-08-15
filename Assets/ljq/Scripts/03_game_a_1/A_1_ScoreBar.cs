using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_1_ScoreBar : MonoBehaviour
{

    public GameObject StarBar;
    Animator StarBar_animator;

    void Start()
    {
        StarBar_animator = StarBar.GetComponent<Animator>();

    }

    void Update()
    {

    }

    //ScoreBar的状态更新
    public void ScoreBar_update()
    {
        StarBar_animator.SetTrigger("goal");
    }


}
