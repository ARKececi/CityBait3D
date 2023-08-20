using UnityEngine;

namespace LevelSystem.LevelManager.Controller
{
    public class LevelLoaderController : MonoBehaviour
    {
        public void LoaderLevel(int _levelID, Transform levelHolder)
        {
            Instantiate(Resources.Load<GameObject>($"LevelPrefabs/level{_levelID}"), levelHolder);
        }
    }
}