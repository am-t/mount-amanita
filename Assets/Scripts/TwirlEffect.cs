using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class TwirlEffect : MonoBehaviour
{

    public Twirl twirl;
    
    private float twirlRadius;
    private float twirlAngle;
    private float randomSubtraction;
    private float randomRadius;

    private GameController gc;
    public int museNumber;

    // Use this for initialization
    void Start()
    {
        gc = gameObject.GetComponent<GameController>();

        twirl = GetComponent<Twirl>();
        twirlRadius = twirl.radius.x;
        //twirlRadiusY = twirl.radius.y;
        twirlAngle = twirl.angle;

        randomSubtraction = Random.Range(0.1f, 0.2f);
        randomRadius = Random.Range(1.5f, 3f);

        twirl.radius.x = randomRadius;
        twirl.radius.y = randomRadius;

        twirl.angle = Random.Range(60f, 220f);
    }

    // Update is called once per frame
    void Update()
    {
        //As long as concentration is certain level
        if (true && gc.museStatus[museNumber] == 1)
        {
            //Debug.Log("Pressed V button");
            //Debug.Log("RandomSubtraction value is " + randomSubtraction);
            //blurSizeVal--;
            //blurSizeVal = Mathf.Clamp(blurSizeVal, 0f, 7f);

            twirlAngle -= 10f;
            twirlRadius -= randomSubtraction;


            twirlRadius = Mathf.Clamp(twirlRadius, 0, 1.5f);
            twirlAngle = Mathf.Clamp(twirlAngle, 0, 160f);

            twirl.radius.x = twirlRadius;
            twirl.radius.y = twirlRadius;
            twirl.angle = twirlAngle;

        }else{
            twirlAngle += 10f;
            twirlRadius += randomSubtraction;


            twirlRadius = Mathf.Clamp(twirlRadius, 0, 1.5f);
            twirlAngle = Mathf.Clamp(twirlAngle, 0, 160f);

            twirl.radius.x = twirlRadius;
            twirl.radius.y = twirlRadius;
            twirl.angle = twirlAngle;

        }
        
    }
}
