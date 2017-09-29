namespace N_Space {
    public class Dimension_Test {
        public void CreateDimensionTest() {
            Location LocationA = new Location(State.Light, State.Dark, new int[]{0,1}, 2);
            Dimension DimensionTestA = new Dimension(0, LocationA);

            if (DimensionTestA == null) {
                throw new System.ArgumentException("Test Failed:  Dimension created cannot be null.");
            }
        }

        public void DimensionParentTest() {
            Dimension DimensionTestA = new Dimension(0, null);
            
            if (DimensionTestA.GetParent() != null) {
                throw new System.ArgumentException("Test Failed:  Dimension Parent Test expected null on get.");
            }

            Location LocationB = new Location(State.Light, State.Dark, new int[] { 0, 0 }, 1);
            Dimension DimensionTestB = new Dimension(0, LocationB);
            DimensionTestA.SetParent(DimensionTestB);

            if (DimensionTestA.GetParent() != DimensionTestB) {
                throw new System.ArgumentException("Test Failed:  Dimension Parent Test expected DimensionTestB on get following set.");
            }
        }

        public void DimensionChildTest() {
            Dimension DimensionTestA = new Dimension(0, null);
            Dimension DimensionTestB = new Dimension(1, null);
            Dimension DimensionTestC = new Dimension(0, null);

            DimensionTestB.SetParent(DimensionTestA);
            DimensionTestA.AddChild(DimensionTestB);

            if (DimensionTestA.GetChildList()[0] != DimensionTestB) {
                throw new System.ArgumentException("Test Failed:  Dimension Child Test expected DimensionTestB on get.");
            }

            DimensionTestC.SetParent(DimensionTestA);
            DimensionTestA.AddChild(DimensionTestC);

            if (DimensionTestA.GetChildList()[0] != DimensionTestC) {
                throw new System.ArgumentException("Test Failed:  Dimension Child Test expected DimensionTestC on get following sort.");
            }
        }

        public void DimensionIndexTest() {
            Dimension DimensionTestA = new Dimension(0, null);

            if (DimensionTestA.GetIndex() != 0) {
                throw new System.ArgumentException("Test Failed:  Dimension Index Test expected 0 on get.");
            }
        }

        public void DimensionStateTest() {
            Dimension DimensionTestA = new Dimension(0, null);
            
            if (DimensionTestA.GetLocation() != null) {
                throw new System.ArgumentException("Test Failed:  Dimension State Test expected null on get.");
            }

            Location LocationB = new Location(State.Light, State.Dark, new int[] { 2, 2 }, 5);
            Dimension DimensionTestB = new Dimension(0, LocationB);

            if (DimensionTestB.GetLocation() != LocationB) {
                throw new System.ArgumentException("Test Failed:  Dimension State Test expected LocationB on get.");
            }
        }
    }
}
