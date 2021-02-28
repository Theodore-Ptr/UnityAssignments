using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    //rotation support
    private int rotationValue;
    private bool rowStopped;
    //rotation coroutine sypport
    private float timeInterval;
    //rect transform support
    RectTransform rowRT;
    RectTransform image;

    public bool RowStopped{
        get { return rowStopped; }
    }

    // Start is called before the first frame update
    void Start()
    {
        rowStopped = true;
        GameControl.ButtonPressed += StartRotating;
        rowRT = GetComponent<RectTransform>();
        image = (RectTransform)rowRT.GetChild(0);

    }

    /// <summary>
    /// delegate that calls coroutine for rotation
    /// </summary>
    private void StartRotating()
    {
        StartCoroutine("Rotate");
    }

    /// <summary>
    /// coroutine to process rotation
    /// </summary>
    /// <returns></returns>
    private IEnumerator Rotate()
    {
        rowStopped = false;
        timeInterval = 0.025f;
  
        //initial rotation
        for (int i = 0; i < 40; i++) {
            //out of slot case
            if (image.localPosition.y <= -280)
                image.localPosition = new Vector3(image.localPosition.x, 280, image.localPosition.z);

            //rotation
            image.localPosition = new Vector3(image.localPosition.x, image.localPosition.y - 14f, image.localPosition.z);

            yield return new WaitForSeconds(timeInterval);
        }

        //extra rotation support
        rotationValue = Random.Range(60, 100);

        switch(rotationValue % 5)
        {
            case 1:
                rotationValue += 4;
                break;
            case 2:
                rotationValue += 3;
                break;
            case 3:
                rotationValue += 2;
                break;
            case 4:
                rotationValue += 1;
                break;
        }

        for (int i = 0; i < rotationValue; i++)
        {
            //out of slot case
            if (image.localPosition.y <= -280)
                image.localPosition = new Vector3(image.localPosition.x, 280, image.localPosition.z);

            //rotation
            image.localPosition = new Vector3(image.localPosition.x, image.localPosition.y - 14f, image.localPosition.z);

            //freeze support
            if (i > Mathf.RoundToInt(rotationValue * 0.25f))
                timeInterval = 0.05f;
            if (i> Mathf.RoundToInt(rotationValue * 0.5f))
                timeInterval = 0.1f;
            if (i > Mathf.RoundToInt(rotationValue * 0.75f))
                timeInterval = 0.15f;
            if (i > Mathf.RoundToInt(rotationValue * 0.95f))
                timeInterval = 0.2f;

            yield return new WaitForSeconds(timeInterval);
        }
        rowStopped = true;
        yield return new WaitForSeconds(timeInterval);
    }

    private void OnDestroy()
    {
        GameControl.ButtonPressed -= StartRotating;
    }
}
