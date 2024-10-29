using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Editor;

public interface IInteractable
{
    public string GetInteractPrompt();
    public void OnInteract();
}
public class Interaction : MonoBehaviour
{
    public float checkRate = 0.05f; //오브젝트 체크 수행하는 시간 간격
    private float lastCheckTime;    //마지막체크시간
    public float maxCheckDistance;  //최대 체크거리
    public LayerMask layerMask;

    public GameObject curInteractGameObject;
    private IInteractable curInteractable;

    public TextMeshProUGUI promptText;
    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        if (Time.time - lastCheckTime > checkRate)//체크간격에 맞춰 실행 ex : 0.05초마다 실행
        {
            lastCheckTime = Time.time;

            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))//조사거리안에 해당 물체에 닿았는지
            {
                if (hit.collider.gameObject != curInteractGameObject)//최근 상호작용한 오브젝트가 아니라면
                {
                    curInteractGameObject = hit.collider.gameObject;
                    curInteractable = hit.collider.GetComponent<IInteractable>();
                    SetPromptText();
                }
            }
            else
            {
                curInteractGameObject = null;
                curInteractable = null;
                promptText.gameObject.SetActive(false);
            }
        }
    }

    private void SetPromptText()
    {
        promptText.gameObject.SetActive(true);
        promptText.text = curInteractable.GetInteractPrompt();
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && curInteractable != null)
        {
            curInteractable.OnInteract();   //아이템 집기
            curInteractGameObject = null;
            curInteractable = null;
            promptText.gameObject.SetActive(false);
        }
    }
}
