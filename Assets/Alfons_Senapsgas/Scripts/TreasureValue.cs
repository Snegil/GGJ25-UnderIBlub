using UnityEngine;

public class TreasureValue : MonoBehaviour
{

    [SerializeField]
    int value = 0;

    public int Value
    {
        get => value;
    }
}
