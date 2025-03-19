using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackAnimation : MonoBehaviour
{
    public AnimationCurve curve;

    public Transform PlayerA;
    public Transform PlayerB;

    public Coroutine PlayerAAttack;
    public Coroutine PlayerBAttack;

    public Button PlayerAButton;
    public Button PlayerBButton;

    public float t = 0;
    public float maxTime = 1;

    public void StartAttackA()
    {
        StartCoroutine(AttackA());
    }

    public void StartAttackB()
    {
        StartCoroutine(AttackB());
    }

    IEnumerator AttackA()
    {
        t = 0;
        PlayerAButton.interactable = false;
        PlayerBButton.interactable = false;
        while (t < maxTime)
        {
            t += Time.deltaTime;
            PlayerA.Rotate(0, 0, curve.Evaluate(t));
            yield return null;
        }
        PlayerAButton.interactable = true;
        PlayerBButton.interactable = true;
    }

    IEnumerator AttackB()
    {
        t = 0;
        PlayerAButton.interactable = false;
        PlayerBButton.interactable = false;
        while (t < maxTime)
        {
            t += Time.deltaTime;
            PlayerB.Rotate(0, 0, curve.Evaluate(t));
            yield return null;
        }
        PlayerAButton.interactable = true;
        PlayerBButton.interactable = true;
    }
}
