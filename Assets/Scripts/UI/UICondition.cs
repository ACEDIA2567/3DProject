using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICondition : MonoBehaviour
{
    public Condition hp;
    public Condition sp;

    private void Start()
    {
        GameManager.Instance.Player.condition.conditions = this;
    }
}
