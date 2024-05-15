using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBlueScreenState : TurretBaseState
{

    public TurretBlueScreenState(Turret turret) : base(turret) { }

    public override void Enter()
    {
        turret.OnRenderer();
        turret.turretStateName = TurretStateName.BLUESCREEN;
        //üũ�� Ʈ���� on
        //�ͷ��� �ݶ��̴� off
        turret.turretCollider.enabled = false;
        //�ͷ��� �±׿� ���̾� ���ֱ�
        turret.gameObject.tag = "Untagged";
        turret.gameObject.layer = LayerMask.NameToLayer("debug");
    }

    public override void Update()
    {
        turret.ChangeColor();
    }

    public override void Exit() 
    {
        turret.ResetColor();
        turret.OffRenderer();
        //üũ�� Ʈ���� off
        //�ͷ��� �ݶ��̴� on
        turret.turretCollider.enabled = true;
        //�ͷ��� �±׿� ���̾� ����
        turret.gameObject.tag = "Turret";
        turret.gameObject.layer = LayerMask.NameToLayer("Turret");
    }
}