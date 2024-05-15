using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUpgradeState : TurretBaseState
{
    private float checkTime;
    public TurretUpgradeState(Turret turret) : base(turret) { }

    public override void Enter()
    {
        turret.turretStateName = TurretStateName.UPGRADE;
        //����� ����Ʈ ����
    }

    public override void Update()
    {
        checkTime += Time.time;

        if (checkTime >= turret.turretUpgradeTime)
        {
            //��ã�� ���·�  ����
            turret.turretStatemachine.ChangeState(TurretStateName.SEARCH);
        }
    }

    public override void Exit()
    {
        checkTime = 0;
        turret.Upgrade();
    }
}