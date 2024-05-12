using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGunTurret : Turret
{

    private int nowUpgradeCount = 0;
    private int nowHp;
    private int maxHp = 5;
    private int hpRise = 3;
    private float makingTime = 15;
    private float attackDamge = 25;
    private float attackSpeed = 2;
    private float attackRange = 12;
    private float upgradeTime = 15;
    private float repairTime = 15;
    private float attackRise = 5;
    private float attackSpeedRise = 0.5f;
    private float upgradCostRise = 2;
    private float maxUpgradeCount = 5;
    private float repairCost = 5;
    private float upgradeCost = 10;
    private float makingCost = 15;

    private void Awake()
    {
        SetTurret(makingTime, makingCost, attackDamge, attackSpeed, attackRange, maxHp, hpRise, upgradeCost, upgradeTime, repairTime, repairCost, attackRise, attackSpeedRise, upgradCostRise, maxUpgradeCount);
    }

    protected override void Attack()
    {
        if (Physics.Raycast(firePos.transform.position, Vector3.forward, out RaycastHit hit, attackRange))
        {
            //이펙트 생성
            //몬스터 데미지 주는 부분
            //몬스터 함수 불러온단 소리
        } 
    }

}
