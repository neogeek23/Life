using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace N_Space {
    public class Location {
        private State? _present;
        private State? _future;
        private readonly int[] _coordinate;
        private readonly List<int[]> _neighbors;

        public Location(State? present, State? future, int[] coordinate, int maxSize) {
            _present = present;
            _future = future;
            _coordinate = coordinate;
            _neighbors = SetNeighborCoordinates(maxSize);
        }

        public List<int[]> GetNeighborCoodrinates() {
            return _neighbors;
        }

        private List<int[]> SetNeighborCoordinates(int maxSize) {
            List<int[]> seed = new List<int[]>();

            seed.Add(_coordinate);
            seed = IndexEvaluationTrain(seed, 0);
            return RemoveUndesirableNeighbors(seed, maxSize);
        }

        private List<int[]> RemoveUndesirableNeighbors(List<int[]> seed, int maxSize) {
            bool shouldRemove;
            foreach (int[] s in seed) {
                shouldRemove = s.Equals(_coordinate);
                if (!shouldRemove) {
                    foreach (int i in s) {
                        shouldRemove = i < 0 || i > maxSize;
                    }
                }
                if (shouldRemove) {
                    seed.Remove(s);
                }
            }
            return seed;
        }

        private List<int[]> IndexEvaluationTrain(List<int[]> seed, int index) {
            if (index < _coordinate.Length) {
                return IndexEvaluationTrain(CoordinateMutator(seed, index), index + 1);
            }
            return seed;
        }

        private List<int[]> CoordinateMutator(List<int[]> currentList, int index) {
            List<int[]> result = new List<int[]>();
            int[] mutations = new int[3];

            mutations[0] = -1;
            mutations[1] = 0;
            mutations[2] = 1;

            for (int i = 1; i < currentList.Count; i++) {
                for (int j = 0; j < mutations.Length; j++) {
                    int[] tempCopy = (int[])currentList[i].Clone();
                    tempCopy[index] = tempCopy[index] + mutations[j];
                    result.Add(tempCopy);
                }
            }
            return result;
        }

        public State? GetPresentState() {
            return _present;
        }

        public State? GetFutureState() {
            return _future;
        }

        public void SetPresentState(State? n) {
            _present = n;
        }

        public void SetFutureState(State? n) {
            _future = n;
        }
    }
}