using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class targetScore : MonoBehaviour
{    
    [SerializeField] private float size = 0.1f;
    [SerializeField] private TextMeshProUGUI score;

    public int _score;
#region input system
    private InputSystem inputs;

    private void Awake()
    {
        inputs = new InputSystem();   
    }

    void OnDisable()
    {
        inputs.Disable();
    }

    void OnEnable()
    {
        inputs.Enable();
    }

    #endregion

    void Start()
    {
        inputs.Player.Attack.performed += _ => Attake();        
    }

    private void Attake()
    {
        RaycastHit2D hit = Physics2D.CircleCast(Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10, size, Vector2.up);
        if(!hit || hit.collider.gameObject.tag != "target") return;

        _score ++;
        score.text = _score.ToString();

        hit.collider.gameObject.SetActive(false);
        StopCoroutine(GetComponent<Spowner>().c);
        GetComponent<Spowner>().c = StartCoroutine(GetComponent<Spowner>().Spown());
    }
}
