using System;
using System.Linq;

//unfinished 

class SingingCats
{
    static int[] catsCheck;
    static int[] songsCheck;
    static int TotalMin;

    static void Main()
    {
        string text = Console.ReadLine();
        int cats = text.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .First();
        text = Console.ReadLine();
        int songs = text.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .First();

        var matrix = new bool[cats, songs];
        TotalMin = cats;
        catsCheck = new int[cats];
        songsCheck = new int[songs];

        text = Console.ReadLine();
        while (text != "Mew!")
        {
            var arr = text.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int cat = int.Parse(arr[1]);
            int song = int.Parse(arr[4]);
            matrix[cat - 1, song - 1] = true;
            catsCheck[cat - 1] = 1;
            songsCheck[song - 1] = 1;
            text = Console.ReadLine();
        }
        if (DumbCatCheck(cats))
        {
            Console.WriteLine("No concert!");
        }
        else
        {
            FindMinMethod(matrix, cats, songs, 0, 0);
            Console.WriteLine(TotalMin);
        }

    }

    static void FindMinMethod(bool[,] matrix, int cats, int songs, int count, int curentStart)
    {
        if (count >= TotalMin)
        {
            return;
        }
        bool allChecked = true;
        for (int i = curentStart; i < songs; i++)
        {
            if (songsCheck[i] == 0)
            {
                continue;
            }
            //select song
            songsCheck[i] = 0;
            count++;
            for (int j = 0; j < cats; j++)
            {
                if (matrix[j, i] == true)
                {
                    catsCheck[j]++;
                }
                if (catsCheck[j] == 0)
                {
                    allChecked = false;
                }
            }
            //update if need and go deeper if need ! 
            if (allChecked)
            {
                if (count < TotalMin)
                {
                    TotalMin = count;
                }
            }
            else
            {
                FindMinMethod(matrix, cats, songs, count, i+1);
            }
            //deselect song
            songsCheck[i] = 1;
            count--;
            for (int j = 0; j < cats; j++)
            {
                if (matrix[j, i] == true)
                {
                    catsCheck[j]--;
                }
            }

        }
    }

    static bool DumbCatCheck(int cats)
    {
        for (int i = 0; i < cats; i++)
        {
            if (catsCheck[i] == 0) // there is cat that dont know any songs - epic ! 
            {
                return true;
            }
            else
            {
                catsCheck[i] = 0;
            }
        }
        return false;

    }
}




// private static void DFSTry(bool[,] matrix, int cats, int songs, int curentCount, int curentCat)
// {
//     bool allChecked = true;
//     if (curentCount >= TotalMin)
//     {
//         return;
//     }
//     for (int i = curentCat; i < cats; i++)
//     {
//
//         if (catsCheck[i] != 0)
//         {
//             continue; // curent cat already sign some of other songs 
//         }
//         for (int j = 0; j < songs; j++)
//         {
//             if (songsCheck[j] == 0 && matrix[i, j] == true)
//             {
//                 //song check
//                 songsCheck[j]++;
//                 curentCount++;
//                 for (int k = 0; k < cats; k++)
//                 {
//                     if (matrix[k, j] == true)
//                     {
//                         catsCheck[k]++;
//                     }
//                     if (catsCheck[k] == 0)
//                     {
//                         allChecked = false;
//                     }
//                 }
//                 
//                 if (allChecked == true)
//                 {
//                     //result update 
//                     if (curentCount < TotalMin)
//                     {
//                         TotalMin = curentCount;
//                     }
//
//                 }
//                 else
//                 {
//                     //go deeper
//                     DFSTry(matrix, cats, songs, curentCount, i + 1);
//                 }
//
//                 //song decheck
//                 for (int k = 0; k < cats; k++)
//                 {
//                     if (matrix[k, j] == true)
//                     {
//                         catsCheck[k]--;
//                     }
//                 }
//                 songsCheck[j]--;
//                 curentCount--;
//             }
//
//         }
//     }
//
// }
//


//static int SongCounter(bool[,] matrix, int cats, int songs)
//{
//    // finding most popular song 
//    int popular = 0;
//    int popularIndex = 0;
//    for (int i = 0; i <songs; i++)
//    {
//        if (songsCheck[i] > popular)
//        {
//            popular = songsCheck[i];
//            popularIndex = i;
//        }
//    }
//    //recursion bottom 
//    if (popular == 0)
//    {
//        return 0;
//    }
//    //all cats checked flag
//    bool flag = true;
//    for (int i = 0; i < cats; i++)
//    {
//        //if cat is already checked
//        if (catsCheck[i] == false)
//        {
//            continue;
//        }
//        flag = false;  //at least once been here = 1 unchecked cat
//
//        //if curent cat can sing that most popular song
//        if (matrix[i, popularIndex] == true)
//        {
//            //then that cat will sing exactly that song
//            catsCheck[i] = false;
//        }
//    }
//    if (flag)
//    {
//        return 0;
//    }
//    //that song wont be sing again
//    songsCheck[popularIndex] = 0;
//    return 1 + SongCounter(matrix, cats, songs);
//
//}





//static void Updater(bool[,] matrix, int cats, int songs)
//{
//    for (int i = 0; i < songs; i++)
//    {
//        //no need to update songs that nobody sing or already checked
//
//        if (songsCheck[i] != 0)
//        {
//            //if need update make it 0 and re-count singers
//            songsCheck[i] = 0;
//            for (int j = 0; j < cats; j++)
//            {
//                if (matrix[j, i])
//                {
//                    songsCheck[i]++;
//                }
//            }
//        }
//    }
//}