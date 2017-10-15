using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Space {
    public class Region {
        private readonly State _default;
        private readonly int _size;
        private readonly int _dimensionCount;
        private readonly Dimension _deviantTree;

        public Region(int dimensionSize, int maxSize) {
            _default = State.Default;
            _dimensionCount = dimensionSize;
            _size = maxSize;
            _deviantTree = new Dimension(0, null);
        }

        public int GetSize() {
            return _size;
        }

        public int GetDimensionCount() {
            return _dimensionCount;
        }

        public State GetDefaultState() {
            return _default;
        }

        public Dimension GetDeviantTree() {
            return _deviantTree;
        }

        public void AddInitialCoordinate(int[] coordinate, State state) {
            Dimension currentDimension = _deviantTree;
            for (int i = 0; i < coordinate.Length; i++) {
                List<Dimension> currentChildren = currentDimension.GetChildList();

                if (currentChildren == null) {
                    currentDimension = AddNewChild(i, coordinate, currentDimension, state);
                }
                else {
                    bool wasIndexFound = false;
                    foreach (Dimension dim in currentChildren) {
                        wasIndexFound |= dim.GetIndex() == coordinate[i];
                        if (dim.GetIndex() == coordinate[i]) {
                            currentDimension = dim;
                            break;
                        }
                    }
                    if (!wasIndexFound) {
                        currentDimension = AddNewChild(i, coordinate, currentDimension, state);
                    }
                }
            }
        }

        private Dimension AddNewChild(int n, int[] coordinate, Dimension currentDimension, State state) {
            Location newLocation;
            if (n == coordinate.Length - 1) {
                newLocation = new Location(state, null, coordinate, _size);
            } else {
                newLocation = null;
            }
            Dimension newChild = new Dimension(coordinate[n], newLocation);
            newChild.SetParent(currentDimension);
            currentDimension.AddChild(newChild);
            return currentDimension.GetChildList()[Convert.ToInt32(currentDimension.GetChildIndexOf(coordinate[n]))];
        }

        public void RemoveCoordinate(int[] coordinate) {
            Dimension currentDimension = _deviantTree;
            for (int i = 0; i < coordinate.Length; i++) {
                int? currentIndex = currentDimension.GetChildIndexOf(coordinate[i]);
            }
        }

        public void PrintSpace() {
            PrintFromDimension(_dimensionCount, _deviantTree, null);
        }

        private string DimensionalAnchor(int n, int index, int charactersPerIndex) {
            string extra = "";
            if (charactersPerIndex % 2 == 1) {  //if we have an odd number per, we are short a character at the end
                extra = "-";
            }
            return n.ToString().PadRight(charactersPerIndex, '-').PadRight((charactersPerIndex * _size / 2) + (charactersPerIndex/2), '-') +
                   index.ToString().PadRight((charactersPerIndex * _size / 2) + (charactersPerIndex / 2), '-') + extra;
        }

        private int DetermineCharacterSizeOfNumber(int n) {
            return n.ToString().Length;
        }

        private string Make2D_X_Header(int charactersPerIndex) {
            string result = "";
            string temp = "";
            for (int i = 0; i < _size; i++) {
                result += i.ToString().PadLeft(charactersPerIndex, '-');
            }

            temp = "";
            for (int i = 0; i < charactersPerIndex; i++) {
                temp += "-";
            }
            return temp + result + "\n";
        }

        private string MakeMultiDimHeader(int charactersPerIndex, List<int> dimIndexHeaderList) {
            string result = "";
            for (int i = _dimensionCount; i > _dimensionCount - dimIndexHeaderList.Count; i--) {
                result += DimensionalAnchor(i, dimIndexHeaderList[Math.Abs(i - _dimensionCount)], charactersPerIndex) + "\n";
            }
            return result;
        }

        private void Print2DSpace(Dimension deviants, int charactersPerIndex, List<int> dimIndexHeaderList) {
            string result = MakeMultiDimHeader(charactersPerIndex, dimIndexHeaderList) + Make2D_X_Header(charactersPerIndex);
            for (int i = 0; i < _size; i++) {
                result += i.ToString().PadLeft(charactersPerIndex - 1, '-') + ":";
                int? ParentIndex = deviants.GetChildIndexOf(i);
                if (ParentIndex != null) {
                    for (int j = 0; j < _size; j++) {
                        int? ChildIndex = deviants.GetChild(ParentIndex).GetChildIndexOf(j);
                        if (ChildIndex != null) {
                            result += Convert.ToInt32(deviants.GetChild(ParentIndex).GetChild(ChildIndex).GetLocation()
                                .GetPresentState()).ToString().PadLeft(charactersPerIndex);
                        }
                        else {
                            result += Convert.ToInt32(_default).ToString().PadLeft(charactersPerIndex);
                        }
                    }
                }
                else {
                    for (int j = 0; j < _size; j++) {
                        result += Convert.ToInt32(_default).ToString().PadLeft(charactersPerIndex);
                    }
                }
                if (i < _size - 1) {
                    result += "\n";
                }
            }
            Console.WriteLine(result + "\n");
        }

        private void Print2DSpaceDefaults(int charactersPerIndex, List<int> dimIndexHeaderList) {
            string result = MakeMultiDimHeader(charactersPerIndex, dimIndexHeaderList) + Make2D_X_Header(charactersPerIndex);
            for (int i = 0; i < _size; i++) {
                result += i.ToString().PadLeft(charactersPerIndex - 1, '-') + ":";
                for (int j = 0; j < _size; j++) {
                    result += Convert.ToInt32(_default).ToString().PadLeft(charactersPerIndex);
                }

                if (i < _size - 1) {
                    result += "\n";
                }
            }
            Console.WriteLine(result + "\n");
        }

        private void PrintFromDimension(int n, Dimension deviants, List<int> currentDimIndexList) {
            int charactersPerIndex = DetermineCharacterSizeOfNumber(_size) + 1;
            if (deviants != null && n > 2) {
                for (int i = 0; i < _size; i++) {
                    if (currentDimIndexList == null) {
                        currentDimIndexList = new List<int>();
                    }
                    currentDimIndexList.Add(i);
                    int? index = deviants.GetChildIndexOf(i);
                    if (index != null) {
                        PrintFromDimension(n - 1, deviants.GetChildList()[Convert.ToInt32(index)], currentDimIndexList);
                    }
                    else {
                        PrintFromDimension(n - 1, null, currentDimIndexList);
                    }
                    currentDimIndexList.RemoveAt(currentDimIndexList.Count - 1);
                }
            } else if (deviants == null && n > 2) {
                for (int i = 0; i < _size; i++) {
                    if (currentDimIndexList == null) {
                        currentDimIndexList = new List<int>();
                    }
                    currentDimIndexList.Add(i);
                    PrintFromDimension(n - 1, null, currentDimIndexList);
                    currentDimIndexList.RemoveAt(currentDimIndexList.Count - 1);
                }
            } else if (deviants != null && n <= 2) {
                Print2DSpace(deviants, charactersPerIndex, currentDimIndexList);
            } else {
                Print2DSpaceDefaults(charactersPerIndex, currentDimIndexList);
            }
        }
    }
}
