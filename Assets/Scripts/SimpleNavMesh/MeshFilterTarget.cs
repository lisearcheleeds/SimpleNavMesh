﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace SimpleNavMesh
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshCollider))]
    class MeshFilterTarget : MonoBehaviour, INavMeshTarget
    {
        MeshFilter meshFilter;
        Collider collider;

        MeshFilter MeshFilter
        {
            get
            {
                if (meshFilter == null)
                {
                    meshFilter = GetComponent<MeshFilter>();
                }

                return meshFilter;
            }
        }

        Collider Collider
        {
            get
            {
                if (collider == null)
                {
                    collider = GetComponent<Collider>();
                }

                return collider;
            }
        }

        NavMeshTargetData navMeshTargetData;

        public NavMeshTargetData NavMeshTargetData
        {
            get
            {
                if (navMeshTargetData == null)
                {
                    UpdateNavMeshTargetData();
                }

                return navMeshTargetData;
            }
        }

        public void UpdateNavMeshTargetData()
        {
            var sharedMesh = MeshFilter.sharedMesh;
            if (sharedMesh == null)
            {
                navMeshTargetData = null;
                return;
            }

            var source = new NavMeshBuildSource();
            source.shape = NavMeshBuildSourceShape.Mesh;
            source.sourceObject = sharedMesh;
            source.transform = MeshFilter.transform.localToWorldMatrix;
            source.area = 0;

            navMeshTargetData = new NavMeshTargetData(source, Collider.bounds);
        }

        void Update()
        {
            UpdateNavMeshTargetData();
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            var collider = Collider.bounds;
            Gizmos.DrawWireCube(collider.center, collider.size);
        }
    }
}