using System;

public class Equipment
{
    protected int id = 0;//标识id

    protected string name = "";//名称
    protected int duration = 0;//耐久度
    protected int maxDuration = 0;//最大耐久度

    protected int minVOA = 0;//攻击力下限
    protected int maxVOA = 0; //攻击力上限
    protected int minPOD = 0;//物防下限
    protected int maxPOD = 0;//物防上限
    protected int minMOD = 0;//魔抗下限
    protected int maxMOD = 0;//魔抗上限
    protected int lucky = 0;//幸运值
    protected int attackSpeed = 0;//攻击速度


    public Equipment()
    {
        
    }
}

