using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition conditions;

    private Condition hp { get { return conditions.hp; } }
    private Condition sp { get { return conditions.sp; } }
    private Condition ep { get { return conditions.ep; } }
    private Condition wp { get { return conditions.wp; } }

    private void Update()
    {

    }

    public bool UseSp(float value)
    {
        if (sp.currentValue > value)
        {
            sp.Down(value);
            return true;
        }
        return false;
    }

    public bool UseEp(float value)
    {
        if (ep.currentValue > value)
        {
            //ep.Down(value);
            return true;
        }
        return false;
    }

    public bool UseWp(float value)
    {
        if (wp.currentValue > value)
        {
            //wp.Down(value);
            return true;
        }
        return false;
    }

    public void Heal(float value)
    {
        hp.Up(value);
    }

    public void Restore(float value)
    {
        sp.Up(value);
    }
}
