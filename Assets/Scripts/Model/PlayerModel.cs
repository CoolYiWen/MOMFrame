using UnityEngine;
using System.Collections;


public class PlayerModel : Singleton<PlayerModel>{

    private int hp;//生命值
    private int maxHp;//最大生命值
    private int mp;//魔法值
    private int maxMp;//最大魔法值
    private int exp;//经验值
    private int maxExp;//升级经验值
    private int minVOA;//最小攻击力
    private int maxVOA;//最大攻击力
    private int minPOD;//最小物理防御力
    private int maxPOD;//最大物理防御力
    private int minMOD;//最小魔法防御力
    private int maxMOD;//最大魔法防御力
    private int attackSpeed;//攻击速度
    private int lucky;//幸运值
    private int money;//金币
    private int sourceChip;//本源碎片
    private int bagSpaceNumber;//已用背包空间
    private int maxBagSpaceNumber;//可用最大背包空间
    private int LimitBagSpaceNumber;//背包空间最大限制值

    private int[] bagThings = new int[100];//背包物品



}
