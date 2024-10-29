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
    public float checkRate = 0.05f; //������Ʈ üũ �����ϴ� �ð� ����
    private float lastCheckTime;    //������üũ�ð�
    public float maxCheckDistance;  //�ִ� üũ�Ÿ�
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
        if (Time.time - lastCheckTime > checkRate)//üũ���ݿ� ���� ���� ex : 0.05�ʸ��� ����
        {
            lastCheckTime = Time.time;

            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))//����Ÿ��ȿ� �ش� ��ü�� ��Ҵ���
            {
                if (hit.collider.gameObject != curInteractGameObject)//�ֱ� ��ȣ�ۿ��� ������Ʈ�� �ƴ϶��
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
            curInteractable.OnInteract();   //������ ����
            curInteractGameObject = null;
            curInteractable = null;
            promptText.gameObject.SetActive(false);
        }
    }
}
