using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleNavMesh
{
    public class SampleScene : MonoBehaviour
    {
        [SerializeField] NavMeshController navMeshController;
        [SerializeField] Button button;
        [SerializeField] Button button2;
        [SerializeField] GameObject prefab;
        [SerializeField] Transform parent;

        void Awake()
        {
            button.onClick.AddListener(() =>
            {
                StartCoroutine(navMeshController.GenerateNavMesh());
            });

            button2.onClick.AddListener(() =>
            {
                var box = Instantiate(prefab, parent);
            });
        }
    }
}