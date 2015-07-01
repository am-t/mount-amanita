using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MuseStatus : MonoBehaviour
{

    public GameObject musePrefab;
    public int museCount = 4, columnCount = 4;

	// Use this for initialization
	void Start ()
	{

	    RectTransform rowRectTransform = musePrefab.GetComponent<RectTransform>();
	    RectTransform containerRectTransform = gameObject.GetComponent<RectTransform>();

	    float width = containerRectTransform.rect.width/columnCount;
	    float ratio = width/rowRectTransform.rect.width;
        float height = rowRectTransform.rect.height * ratio;

        int rowCount = museCount / columnCount;
	    if (museCount%rowCount > 0)
	    {
	        rowCount++;
	    }

	    int j = 0;

	    for (int i = 1; i <= museCount; i++)
	    {
	        if ((i - 1)%columnCount == 0)
	        {
	            j++;
	        }

	        GameObject newMuse = Instantiate(musePrefab) as GameObject;
	        newMuse.name = gameObject.name + "Muse " + i;
	        newMuse.transform.parent = gameObject.transform;

            //move and size the new item
	        RectTransform rectTransform = newMuse.GetComponent<RectTransform>();

	        float x = -containerRectTransform.rect.width/2 + width*((i - 1)%columnCount);
	        float y = containerRectTransform.rect.height/2 - height*j;
            rectTransform.offsetMin = new Vector2(x, y);

	        x = rectTransform.offsetMin.x + width;
	        y = rectTransform.offsetMin.y + height;
            rectTransform.offsetMax = new Vector2(x, y);
	    }
	}
}
