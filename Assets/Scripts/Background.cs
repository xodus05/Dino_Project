using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // public float speed;
    // public int startIndex;
    //public int endIndex;
    // public Transform[] sprites;

    //  float viewHeight;

    public float speed;
    public Transform[] backgrounds;

    float leftPosX = 0f;
    float rightPosX = 10f;
    float xScreenHalfSize;
    float yScreenHalfSize;

    // private void Awake()
    // {
    //    viewHeight = Camera.main.orthographicSize * 2;
    // }


    // void Update()
    // {
    //    Vector3 curPos = transform.position;
    //    Vector3 nextPos = Vector3.left * speed * Time.deltaTime;
    //     transform.position = curPos + nextPos;

    //    if (sprites[endIndex].position.y < viewHeight)
    //    {
    //        Vector3 backSpritePos = sprites[startIndex].localPosition;
    //       Vector3 frontSpritePos = sprites[endIndex].localPosition;
    //       sprites[endIndex].transform.localPosition = backSpritePos + Vector3.right * viewHeight;

    //         int startIndexSave = startIndex;
    //         startIndex = endIndex;
    //         endIndex = (startIndexSave - 1 == -1) ? sprites.Length - 1 : startIndexSave - 1;
    //    }
    // }

    void Start()
    {
        yScreenHalfSize = Camera.main.orthographicSize;
        xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;

        leftPosX = -(xScreenHalfSize * 2);
        rightPosX = xScreenHalfSize * 2 * backgrounds.Length;
    }

    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].position += new Vector3(-speed, 0, 0) * Time.deltaTime;

            if (backgrounds[i].position.x < leftPosX)
            {
                Vector3 nextPos = backgrounds[i].position;
                nextPos = new Vector3(nextPos.x + rightPosX, nextPos.y, nextPos.z);
                backgrounds[i].position = nextPos;
            }
        }
    }

}
