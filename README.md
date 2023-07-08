# Find_Peaks_In_Array

GetPeaks is a method that returns the positions 
and the values of the "peaks" (or local maxima) of a numeric array.
The output will be returned as a Dictionary<string, List<int>> with 
two key-value pairs: "pos" and "peaks".

Example: pickPeaks([3, 2, 3, 6, 4, 1, 2, 3, 2, 1, 2, 3]) should return 
{pos: [3, 7], peaks: [6, 3]} (or equivalent in other languages)

The first and last elements of the array will not be considered as peaks 
(in the context of a mathematical function, we don't know what is after 
and before, and therefore, we don't know if it is a peak or not).

Plateau [1, 2, 2, 2, 1] has a peak, while [1, 2, 2, 2, 3] and [1, 2, 2, 2, 2] 
do not. In case of a plateau-peak, method return the position and value of the 
beginning of the plateau.
For example: pickPeaks([1, 2, 2, 2, 1]) returns {pos: [1], peaks: [2]} 
