using UnityEngine;
using System.Collections;

public class FadeEffect : MonoBehaviour
{
    public SpriteRenderer sprite;
    [SerializeField] float alphaVal;
    [SerializeField]
    float timer = 5f;
    [SerializeField]
    float timeReset = 3f;
    private float randomAlphaChange;

    void Start()
    {
        randomAlphaChange = Random.Range(0.05f, 0.25f);
    }


    private void Update()
    {
        timer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.B))
        {
            //Debug.Log("Pressed b button");
            alphaVal -= randomAlphaChange;
            alphaVal = Mathf.Clamp(alphaVal, 0f, 1f);
            sprite.color = new Color(1f, 1f, 1f, alphaVal);
            timer = timeReset;
        }
        else if (timer < 1f)
        {
         //   Debug.Log("Resetting alpha value");
            alphaVal += randomAlphaChange;
            alphaVal = Mathf.Clamp(alphaVal, 0f, 1f);
            sprite.color = new Color(1f, 1f, 1f, alphaVal);
            timer = timeReset;
        }
    }

}
