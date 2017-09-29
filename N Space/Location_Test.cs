using System.Collections.Generic;

namespace N_Space {
    public class Location_Test {
        public void CreateLocationTest() {
            Location locationA = new Location(State.Dark, State.Light, new int[]{2,2,2}, 5);

            if (locationA == null) {
                throw new System.ArgumentException("Test Failed:  Location created cannot be null.");
            }
        }

        public void GetNeighborhoodCoordinateTest() {
            Location locationA = new Location(State.Dark, State.Light, new int[] { 2, 2 }, 5);
            List<int[]> testResultA = new List<int[]>();
            int[] testResultArrayA;

            testResultArrayA = new int[] { 1, 1 };
            testResultA.Add(testResultArrayA);
            testResultArrayA = new int[] { 1, 2 };
            testResultA.Add(testResultArrayA);
            testResultArrayA = new int[] { 1, 3 };
            testResultA.Add(testResultArrayA);
            testResultArrayA = new int[] { 2, 1 };
            testResultA.Add(testResultArrayA);
            testResultArrayA = new int[] { 2, 3 };
            testResultA.Add(testResultArrayA);
            testResultArrayA = new int[] { 3, 1 };
            testResultA.Add(testResultArrayA);
            testResultArrayA = new int[] { 3, 2 };
            testResultA.Add(testResultArrayA);
            testResultArrayA = new int[] { 3, 3 };
            testResultA.Add(testResultArrayA);

            if (!locationA.GetNeighborCoodrinates().Equals(testResultA)) {
                throw new System.ArgumentException("Test Failed:  2D Location neighbors do not match known neighbors away from edges.");
            }

            Location locationB = new Location(State.Dark, State.Light, new int[] { 0, 1 }, 5);
            List<int[]> testResultB = new List<int[]>();
            int[] testResultArrayB;

            testResultArrayB = new int[] { 0, 0 };
            testResultB.Add(testResultArrayB);
            testResultArrayB = new int[] { 0, 2 };
            testResultB.Add(testResultArrayB);
            testResultArrayB = new int[] { 1, 0 };
            testResultB.Add(testResultArrayB);
            testResultArrayB = new int[] { 1, 1 };
            testResultB.Add(testResultArrayB);
            testResultArrayB = new int[] { 1, 2 };
            testResultB.Add(testResultArrayB);

            if (!locationB.GetNeighborCoodrinates().Equals(testResultB)) {
                throw new System.ArgumentException("Test Failed:  2D Location neighbors do not match known neighbors near small edges.");
            }

            Location locationC = new Location(State.Dark, State.Light, new int[] { 4, 5 }, 5);
            List<int[]> testResultC = new List<int[]>();
            int[] testResultArrayC;

            testResultArrayC = new int[] { 3, 4 };
            testResultC.Add(testResultArrayC);
            testResultArrayC = new int[] { 3, 5 };
            testResultC.Add(testResultArrayC);
            testResultArrayC = new int[] { 4, 4 };
            testResultC.Add(testResultArrayC);
            testResultArrayC = new int[] { 5, 4 };
            testResultC.Add(testResultArrayC);
            testResultArrayC = new int[] { 5, 5 };
            testResultC.Add(testResultArrayC);

            if (!locationC.GetNeighborCoodrinates().Equals(testResultC)) {
                throw new System.ArgumentException("Test Failed:  2D Location neighbors do not match known neighbors near large edges.");
            }

            Location locationD = new Location(State.Dark, State.Light, new int[] { 1, 1, 1 }, 5);
            List<int[]> testResultD = new List<int[]>();
            int[] testResultArrayD;

            testResultArrayD = new int[] { 0, 0, 0 };
            testResultD.Add(testResultArrayD);
            testResultArrayD = new int[] { 0, 0, 1 };
            testResultD.Add(testResultArrayD);
            testResultArrayD = new int[] { 0, 0, 2 };
            testResultD.Add(testResultArrayD);
            testResultArrayD = new int[] { 0, 1, 0 };
            testResultD.Add(testResultArrayD);
            testResultArrayD = new int[] { 0, 1, 1 };
            testResultD.Add(testResultArrayD);
            testResultArrayD = new int[] { 0, 1, 2 };
            testResultD.Add(testResultArrayD);
            testResultArrayD = new int[] { 0, 2, 0 };
            testResultD.Add(testResultArrayD);
            testResultArrayD = new int[] { 0, 2, 1 };
            testResultD.Add(testResultArrayD);
            testResultArrayD = new int[] { 0, 2, 2 };
            testResultD.Add(testResultArrayD);
            testResultArrayD = new int[] { 1, 0, 0 };
            testResultD.Add(testResultArrayD);
            testResultArrayD = new int[] { 1, 0, 1 };
            testResultD.Add(testResultArrayD);
            testResultArrayD = new int[] { 1, 0, 2 };
            testResultD.Add(testResultArrayD);
            testResultArrayD = new int[] { 1, 1, 0 };
            testResultD.Add(testResultArrayD);
            testResultArrayD = new int[] { 1, 1, 2 };
            testResultD.Add(testResultArrayD);
            testResultArrayD = new int[] { 1, 2, 0 };
            testResultD.Add(testResultArrayD);
            testResultArrayD = new int[] { 1, 2, 1 };
            testResultD.Add(testResultArrayD);
            testResultArrayD = new int[] { 1, 2, 2 };
            testResultD.Add(testResultArrayD);
            testResultArrayD = new int[] { 2, 0, 0 };
            testResultD.Add(testResultArrayD);
            testResultArrayD = new int[] { 2, 0, 1 };
            testResultD.Add(testResultArrayD);
            testResultArrayD = new int[] { 2, 0, 2 };
            testResultD.Add(testResultArrayD);
            testResultArrayD = new int[] { 2, 1, 0 };
            testResultD.Add(testResultArrayD);
            testResultArrayD = new int[] { 2, 1, 1 };
            testResultD.Add(testResultArrayD);
            testResultArrayD = new int[] { 2, 1, 2 };
            testResultD.Add(testResultArrayD);
            testResultArrayD = new int[] { 2, 2, 0 };
            testResultD.Add(testResultArrayD);
            testResultArrayD = new int[] { 2, 2, 1 };
            testResultD.Add(testResultArrayD);
            testResultArrayD = new int[] { 2, 2, 2 };
            testResultD.Add(testResultArrayD);

            if (!locationD.GetNeighborCoodrinates().Equals(testResultD)) {
                throw new System.ArgumentException("Test Failed:  3D Location neighbors do not match known neighbors away from edges.");
            }
        }

        public void GetFutureStateTest() {
            Location locationA = new Location(State.Dark, State.Light, new int[] { 2, 2, 2 }, 5);

            if (locationA.GetFutureState() != State.Light) {
                throw new System.ArgumentException("Test Failed:  Location get future state expected Light.");
            }
        }

        public void GetPresentStateTest() {
            Location locationA = new Location(State.Dark, State.Light, new int[] { 2, 2, 2 }, 5);

            if (locationA.GetPresentState() != State.Light) {
                throw new System.ArgumentException("Test Failed:  Location get present state expected Light.");
            }
        }

        public void SetFutureStateTest() {
            Location locationA = new Location(State.Dark, State.Light, new int[] { 2, 2, 2 }, 5);

            locationA.SetFutureState(State.Dark);
            if (locationA.GetFutureState() != State.Dark) {
                throw new System.ArgumentException("Test Failed:  Location set future state expected Dark.");
            }
        }

        public void SetPresentStateTest() {
            Location locationA = new Location(State.Dark, State.Light, new int[] { 2, 2, 2 }, 5);

            locationA.SetPresentState(State.Dark);
            if (locationA.GetPresentState() != State.Dark) {
                throw new System.ArgumentException("Test Failed:  Location get present state expected Dark.");
            }
        }
    }
}
