using System;
using System.Collections.Generic;

using UnityEngine;

public class PathRequestManager : MonoBehaviour {
    private readonly Queue<PathRequest> pathRequestsQueue = new();
    private PathRequest currentPathRequest;

    private static PathRequestManager instance;
    private Pathfinding pathfinding;

    private bool isProcessingPath;

    private void Awake() {
        instance = this;
        pathfinding = GetComponent<Pathfinding>();
    }

    public static void RequestPath(Vector3 pathStart, Vector3 pathEnd, Action<Vector3[], bool> callback) {
        PathRequest pathRequest = new(pathStart, pathEnd, callback);
        instance.pathRequestsQueue.Enqueue(pathRequest);
        instance.TryProcessNext();
    }

    private void TryProcessNext() {
        if (!isProcessingPath && pathRequestsQueue.Count > 0) {
            currentPathRequest = pathRequestsQueue.Dequeue();
            isProcessingPath = true;
            pathfinding.StartFindPath(currentPathRequest.pathStart, currentPathRequest.pathEnd);
        }
    }

    public void FinishedProcessingPath(Vector3[] path, bool success) {
        currentPathRequest.callback(path, success);
        isProcessingPath = false;
        TryProcessNext();
    }

    private struct PathRequest {
        public Vector3 pathStart;
        public Vector3 pathEnd;
        public Action<Vector3[], bool> callback;

        public PathRequest(Vector3 pathStart, Vector3 pathEnd, Action<Vector3[], bool> callback) {
            this.pathStart = pathStart;
            this.pathEnd = pathEnd;
            this.callback = callback;
        }
    }
}