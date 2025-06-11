using System.Collections;
using TMPro;
using UnityEngine;

public class Spowner : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float Wait = 5f, Cooldown = 1f;
    [SerializeField] private TextMeshProUGUI Missed;

    private Vector2 _screenBondresX, _screenBondresY;
    private int _missed;
    public Coroutine c;
    void Start()
    {
        Random.InitState(Random.Range(0,1000000));
        c = StartCoroutine(Spown());
    }

    private void getScreenBondres()
    {
        _screenBondresX = new Vector2(Camera.main.ViewportToWorldPoint(Vector2.zero).x, Camera.main.ViewportToWorldPoint(Vector2.one).x);
        _screenBondresY = new Vector2(Camera.main.ViewportToWorldPoint(Vector2.zero).y, Camera.main.ViewportToWorldPoint(Vector2.one).y);
    }

    public IEnumerator Spown()
    {
        getScreenBondres();
        Vector2 m_spownpos = new Vector2(Random.Range(_screenBondresX.x, _screenBondresX.y), Random.Range(_screenBondresY.x, _screenBondresY.y));
        target.SetActive(true);
        target.transform.position = m_spownpos;

        yield return new WaitForSeconds(Mathf.Max(Wait / Mathf.Max((GetComponent<targetScore>()._score/50), 1), 0.5f));
        Camera.main.orthographicSize = Mathf.Min(Mathf.Max(10, (GetComponent<targetScore>()._score/50)), 50);
        target.SetActive(false);
        _missed ++;
        Missed.text = _missed.ToString();
        yield return new WaitForSeconds(Cooldown);



        c = StartCoroutine(Spown());
    }
}
