using System;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Constants constants;
    PivotEngine engine;
    float pivObjDist;
    float angularSpeed;
    int direction;  // -1->clockwise 1->anticlockwise
    bool pivotAtHead;

    void Start()
    {
        pivObjDist = constants.pivObjDist;
        angularSpeed = constants.angularSpeed;
        engine = GetComponent<PivotEngine>();
        engine.Init(0f, 0f, pivObjDist, 0f);
        direction = 1;
        pivotAtHead = false;
    }

    void Update()
    {
        engine.Rotate(Time.deltaTime * direction * angularSpeed);
    }

    public Action TogglePivotCallbacks = () => { };
    public void TogglePivot()
    {
        pivotAtHead = !pivotAtHead;
        float radAngle = transform.eulerAngles.z * Mathf.Deg2Rad;
        Vector2 to = (Vector2)transform.localPosition + pivObjDist * new Vector2(Mathf.Cos(radAngle), Mathf.Sin(radAngle)) * (pivotAtHead ? 1 : -1);
        engine.MovePiv(to);

        TogglePivotCallbacks();
    }

    public Action ReflectCallbacks = () => { };
    public void Reflect(bool signalFromHead, int hitWallInd)
    {
        int xLarger = transform.localPosition.x > engine.pivRelPar.x ? 1 : -1;
        int yLarger = transform.localPosition.y > engine.pivRelPar.y ? 1 : -1;
        int[] dir = new int[] { -1 * xLarger, yLarger, xLarger, -1 * yLarger }; // wall index: 0->up 1->right 2->bottom 3->left
        direction = pivotAtHead == signalFromHead ? direction : dir[hitWallInd];
        //transform.localScale = new Vector3(1f, direction, 1f);

        ReflectCallbacks();
    }

    public void Killed()
    {

    }
}