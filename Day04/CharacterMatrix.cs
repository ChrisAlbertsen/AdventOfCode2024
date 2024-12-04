//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Day04
//{
//    class CharacterMatrix
//    {
//        public string[] content;
//        public int numberOfXCordinates;
//        public int numberOfYCordinates;
//        public int currentXCordinate;
//        public int currentYCordinate;
//        public string searchWord;

//        public CharacterMatrix(string[] TwoDimensionalContent)
//        {
//            bool allSameLength = TwoDimensionalContent.All(s => s.Length == TwoDimensionalContent[0].Length);
//            if (!allSameLength) throw new Exception("Some rows are longer than others. Not Supported");
//            content = TwoDimensionalContent;
//        }

//        public int FindNumberOfWordUses(string searchWord)
//        {
//            this.searchWord = searchWord;
//            for (int y = 0; y < content.Length; y++) {
//                for (int x = 0; x < content[y].Length; x++)
//                {
//                    for (int i = 0; i < searchWord.Length; i++) {

//                }
//        }

//        public char leftSearch(int x)
//        {
//            if (x == searchWord.Length) return '?';
//            return content[currentYCordinate][currentXCordinate - x];
//        }
//        public char rightSearch(int x)
//        {
//            return content[currentYCordinate][currentXCordinate + x];
//        }
//        public char upSearch(int y)
//        {
//            return content[currentYCordinate - y][currentXCordinate];
//        }
//        public char downSearch(int y)
//        {
//            return content[currentYCordinate + y][currentXCordinate];
//        }
//        public char diagonalUpLeftSearch(int x, int y) {
//            return content[currentYCordinate - y][currentXCordinate - x];
//        }
//        public char diagonalUpRightSearch(int x, int y)
//        {
//            return content[currentYCordinate - y][currentXCordinate + x];
//        }
//        public char diagonalDownRightSearch(int x, int y)
//        {
//            return content[currentYCordinate + y][currentXCordinate + x];
//        }
//        public char diagonalDownLeftSearch(int x, int y)
//        {
//            return content[currentYCordinate + y][currentXCordinate - x];
//        }
//    }
