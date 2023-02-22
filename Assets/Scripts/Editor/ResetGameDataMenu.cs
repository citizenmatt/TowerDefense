using TowerDefense.Game;
using UnityEditor;
using UnityEngine;

public class ResetGameDataMenu : MonoBehaviour
{
    [MenuItem("Services/Game data/Reset")]
    public static void ResetGameData()
    {
        GameManager.instance.ResetData();
    }
}