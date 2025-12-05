using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HelloGladios
{
    public class HelloComponent : MonoBehaviour
    {
       void Awake()
        {
            SceneManager.activeSceneChanged += SceneChanged;
        }

        private void SceneChanged(Scene arg0, Scene arg1)
        {
            HelloClass.DisplayMessage();
        }

        void OnDestroy()
        {
            SceneManager.activeSceneChanged -= SceneChanged;
        }
    }
}
