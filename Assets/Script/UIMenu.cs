using DG.Tweening;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private GameObject objMenu;
    //ㅇ ㅣ함수는 여기에 있으면 안됌 .ㄷ
    private bool isMove = false;
    public void OnMenu()
    {

        // 이동 중이면 호출하지 않음
        if (isMove) return;

        isMove = true; // 애니메이션 시작 시 이동 중으로 설정

        if (!objMenu.activeSelf) // 메뉴를 열 때
        {
            objMenu.SetActive(true);
            objMenu.transform.DOLocalMoveY(objMenu.transform.localPosition.y - 550f, 0.5f).SetEase(Ease.OutCubic).OnComplete(() =>
            {
                isMove = false; // 애니메이션이 끝난 후 이동 종료 상태로 변경
            });
        }
        else // 메뉴를 닫을 때
        {
            objMenu.transform.DOLocalMoveY(objMenu.transform.localPosition.y + 550f, 0.5f).SetEase(Ease.OutCubic).OnComplete(() =>
            {
                objMenu.SetActive(false);
                isMove = false; // 애니메이션 종료 후 이동 상태 변경
            });
        }

        //if (isMove == false)
        //{
        //    isMove = true;
        //    if (!objMenu.activeSelf)
        //    {

        //        objMenu.SetActive(true);
        //        objMenu.transform.DOLocalMoveY(objMenu.transform.localPosition.y - 550f, 0.5f).SetEase(Ease.OutCubic).OnComplete(() =>
        //        {
        //            isMove = false;
        //        });
        //    }
        //}
        //else
        //{
        //    if (isMove == false)
        //    objMenu.transform.DOLocalMoveY(objMenu.transform.localPosition.y + 550f, 0.5f).SetEase(Ease.OutCubic).OnComplete(() =>
        //    {
        //        objMenu.SetActive(false);
        //        isMove = false;
        //    });

        //}
    }

}
