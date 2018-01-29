using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Manager : MonoBehaviour {

    Servant[] EnemyServant;
    Servant[] PlayerServant;


    void BattleServantSetting()
    {
        for (int i = 0; i < 6; i++) ;
            //PlayerServant[i] = Player.formBattleServant[i]
    }

    void StartTurn()
    {
        /*
        턴 시작
        -카드불러오기 5장
        - 카드선택, 스킬선택(적용)
        - 공격 처리(죽을경우 사라짐 후보있을시 백업)
        - 적 공격
        - 턴 종료(경험치 및 아이템 획득)*/
    }    
}
