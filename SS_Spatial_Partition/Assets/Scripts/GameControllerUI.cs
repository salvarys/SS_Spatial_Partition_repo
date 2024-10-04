using UnityEngine;
using UnityEngine.UI;

namespace SpatialPartitionPattern
{
    public class GameControllerUI : MonoBehaviour
    {
        public GameController gameController; 
        public Text updateTimeText;         
        public Toggle spatialPartitionToggle; 

        private float updateTime = 0f;        
        private bool useSpatialPartition = true;

        void Start()
        {
            spatialPartitionToggle.isOn = useSpatialPartition;
            spatialPartitionToggle.onValueChanged.AddListener(ToggleSpatialPartition);
        }

        void Update()
        {
      
            System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();

            gameController.Update(); 

            stopwatch.Stop();
            updateTime = (float)stopwatch.Elapsed.TotalMilliseconds;

            updateTimeText.text = $"Update Time: {updateTime:F2} ms";
        }

        void ToggleSpatialPartition(bool isOn)
        {
            useSpatialPartition = isOn;

            if (useSpatialPartition)
            {
                gameController.enabled = true; 
            }
            else
            {
                gameController.enabled = false; 
            }
        }
    }
}
