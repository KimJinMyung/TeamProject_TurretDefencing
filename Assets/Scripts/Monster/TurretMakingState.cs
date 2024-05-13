using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMakingState : TurretBaseState
{
    private float checkTime;
    public TurretMakingState(Turret turret) : base(turret) { }

    public override void Enter()
    {
        turret.turretStateName = TurretStateName.MAKING;
        //만드는 이펙트 생성
    }

    public override void Update()
    {
        checkTime += Time.time;

        if(checkTime > turret.turretMakingTime)
        {
            //적찾기 상태로 변환
        }
    }

    public override void Exit()
    {
        checkTime = 0;
        //만드는 이펙트 끄기
    }
}
