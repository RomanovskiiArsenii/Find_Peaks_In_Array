/*
In this kata, you will write a function that returns the positions 
and the values of the "peaks" (or local maxima) of a numeric array.

For example, the array arr = [0, 1, 2, 5, 1, 0] has a peak at 
position 3 with a value of 5 (since arr[3] equals 5).

The output will be returned as a Dictionary<string, List<int>> with 
two key-value pairs: "pos" and "peaks". If there is no peak in the 
given array, simply return {"pos" => new List<int>(), 
"peaks" => new List<int>()}.

Example: pickPeaks([3, 2, 3, 6, 4, 1, 2, 3, 2, 1, 2, 3]) should return 
{pos: [3, 7], peaks: [6, 3]} (or equivalent in other languages)

All input arrays will be valid integer arrays (although it could still 
be empty), so you won't need to validate the input.

The first and last elements of the array will not be considered as peaks 
(in the context of a mathematical function, we don't know what is after 
and before and therefore, we don't know if it is a peak or not).

Also, beware of plateaus !!! [1, 2, 2, 2, 1] has a peak while [1, 2, 2, 2, 3] 
and [1, 2, 2, 2, 2] do not. In case of a plateau-peak, please only return the 
position and value of the beginning of the plateau. 
For example: pickPeaks([1, 2, 2, 2, 1]) returns {pos: [1], peaks: [2]} 

*/
using System.Text;
class Program
{
    public class PickPeaks
    {
        /// <summary>
        /// Метод возвращает пиковые значения и их позиции в массиве целых чисел,
        /// при этом игнорируя первое и последнее значения, поскольку неизвестны
        /// значения до или после крайних значений массива в контексте 
        /// математической функции. В случае с плато, метод возвращает первую
        /// точку плато, если это плато заканчивается в пределах массива,
        /// и отсутствует пиковое значение на выходе с плато
        /// </summary>
        /// <param name="arr">отрезок в виде значений</param>
        /// <returns>коллекция пиковых значений и их позиций</returns>
        public static Dictionary<string, List<int>> GetPeaks(int[] arr)
        {
            Dictionary<string, List<int>> peaksCol = new()
            {
                {"pos", new List<int>()},            //коллекция с позициями по ключу pos
                {"peaks" , new List<int>()}          //коллекция с пиковыми значениями по ключу peaks
            };
            int tempPos = 0, tempPeak = 0;           //вспомогательные переменные
            for (int i = 1; i < arr.Length; i++)
            {
                //если значение больше предыдущего, выписать его данные в переменные
                if (arr[i] > arr[i - 1]) { tempPos = i; tempPeak = arr[i]; }
                //если значение находится на плато, начинаеи следующую итерацию
                else if (arr[i] == arr[i - 1]) { continue; }
                //если значение меньше предыдущего, при этом были выписано 
                //пиковое значение, заносим его в коллекцию
                else if (tempPos != 0)
                {
                    peaksCol["pos"].Add(tempPos); peaksCol["peaks"].Add(tempPeak);
                    tempPos = 0;
                    tempPeak = 0;
                }
            }
            PrintDict(peaksCol);    //вывод в консоль
            return peaksCol;        
        }
        /// <summary>
        /// Вывод в консоль всех позиций и значений
        /// </summary>
        private static void PrintDict(Dictionary<string, List<int>> dict)
        {
            StringBuilder sb = new();
            sb.Append("Positions: ");
            foreach (var item in dict["pos"]) { sb.Append($" {item}"); }
            sb.Append(" Peak values: ");
            foreach (var item in dict["peaks"]) { sb.Append($" {item}"); }
            Console.WriteLine(sb.ToString());
        }
    }
    static void Main(string[] args)
    {
        Dictionary<string, List<int>> peaks = new();
                                                                        //positions //values
        int[] test0 = { 1, 2, 3, 6, 4, 1, 2, 3, 2, 1 };                 //3 7       //6 3
        int[] test1 = { 3, 2, 3, 6, 4, 1, 2, 3, 2, 1, 2, 3 };           //3 7       //6 3
        int[] test2 = { 3, 2, 3, 6, 4, 1, 2, 3, 2, 1, 2, 2, 2, 1 };     //3 7 10    //6 3 2
        int[] test3 = { 2, 1, 3, 1, 2, 2, 2, 2, 1 };                    //2 4       //3 2
        int[] test4 = { 2, 1, 3, 1, 2, 2, 2, 2 };                       //2         //3
        int[] test5 = { 2, 2, 2, 2, 2 };                                //          //
        int[] test6 = { 2, 1, 3, 1, 2, 2, 2, 2 };                       //2         //3
        int[] test7 = { };                                              //          //
        int[] test8 = { -1, -2, -3, -2, -1, -2 };                       //4         //-1
        int[] test9 = { -1, 0, -2 };                                    //1         //0

        peaks = PickPeaks.GetPeaks(test0);
        peaks = PickPeaks.GetPeaks(test1);
        peaks = PickPeaks.GetPeaks(test2);
        peaks = PickPeaks.GetPeaks(test3);
        peaks = PickPeaks.GetPeaks(test4);
        peaks = PickPeaks.GetPeaks(test5);
        peaks = PickPeaks.GetPeaks(test6);
        peaks = PickPeaks.GetPeaks(test7);
        peaks = PickPeaks.GetPeaks(test8);
        peaks = PickPeaks.GetPeaks(test9);
    }
}
