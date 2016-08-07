using System;

public class WeaponEQ : Equipment
{
    private int deadlyStrike = 0;//致命一击加成
    private int brokenDefence;//破甲属性

    private string info = "";

    public WeaponEQ ()
    {
        info = "NoInstantiation";
    }

    public WeaponEQ(int id, string name, int duration, int maxDuration, int minVOA, int maxVOA, int lucky, int attackSpeed, int deadlyStrike, int brokenDefence)
    {
        this.id = id;
        this.name = name;
        this.duration = duration;
        this.maxDuration = maxDuration;
        this.minVOA = minVOA;
        this.maxVOA = maxVOA;
        this.lucky = lucky;
        this.attackSpeed = attackSpeed;
        this.deadlyStrike = deadlyStrike;
        this.brokenDefence = brokenDefence;

        info = "ReadyInstantiation";
    }
        
}

