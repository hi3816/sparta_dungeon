using DG.Tweening;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private GameObject objMenu;
    //�� ���Լ��� ���⿡ ������ �ȉ� .��
    private bool isMove = false;
    public void OnMenu()
    {

        // �̵� ���̸� ȣ������ ����
        if (isMove) return;

        isMove = true; // �ִϸ��̼� ���� �� �̵� ������ ����

        if (!objMenu.activeSelf) // �޴��� �� ��
        {
            objMenu.SetActive(true);
            objMenu.transform.DOLocalMoveY(objMenu.transform.localPosition.y - 550f, 0.5f).SetEase(Ease.OutCubic).OnComplete(() =>
            {
                isMove = false; // �ִϸ��̼��� ���� �� �̵� ���� ���·� ����
            });
        }
        else // �޴��� ���� ��
        {
            objMenu.transform.DOLocalMoveY(objMenu.transform.localPosition.y + 550f, 0.5f).SetEase(Ease.OutCubic).OnComplete(() =>
            {
                objMenu.SetActive(false);
                isMove = false; // �ִϸ��̼� ���� �� �̵� ���� ����
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
