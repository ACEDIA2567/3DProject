using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition conditions;

    private Condition hp { get { return conditions.hp; } }
    private Condition sp { get { return conditions.sp; } }
    private Condition ep { get { return conditions.ep; } }
    private Condition wp { get { return conditions.wp; } }

    public float HealthDecay;

    private void Update()
    {
        ep.Down(ep.decayValue * Time.deltaTime);
        wp.Down(wp.decayValue * Time.deltaTime);

        if(ep.currentValue <= 0f)
        {
            hp.Down(HealthDecay * Time.deltaTime);
        }
        if(wp.currentValue <= 0f)
        {
            hp.Down(HealthDecay * Time.deltaTime);
        }
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

    public void Heal(float value)
    {
        hp.Up(value);
    }

    public void Restore(float value)
    {
        sp.Up(value);
    }

    public void Eat(float value)
    {
        ep.Up(value);
    }

    public void Drink(float value)
    {
        wp.Up(value);
    }
}
