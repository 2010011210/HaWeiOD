using ConsoleApp.Utility;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.StringUtility.GetLastWordLength();
            //2.StringUtility.GetWordCount();

            //3.ArrayUtility.GetSortArray();  
            //4.ArrayUtility.GetSortArrayByArrayIndex();   //
            //5 StringUtility.Get8Letter();

            //6 IntUtility.Data16Convert(); 
            //7 IntUtility.MathRound(); 

            //8 DicUtility.SortedDic();  //ReverseAndRemoveDuplicate

            //9 IntUtility.ReverseAndRemoveDuplicate();  //GetLetterCount
            //10 StringUtility.GetLetterCount();          //GetLetterCount  ReverseWords
            //11 StringUtility.ReverseWords();          //
            //12 IntUtility.GetByteOneCount();          
            //13 IntUtility.EmptyBottle();          
            //14 StringUtility.RemoveLeastLetter();         
            //15 StringUtility.SimplePassWord();          //GetLetterCount ReverseWordsByNotLetterSplit
            //16 StringUtility.ReverseWordsByNotLetterSplit();          //GetLetterCount ReverseWordsByNotLetterSplit  
            //17 ArrayUtility.BagQuestion();          //GetLetterCount ReverseWordsByNotLetterSplit  BagQuestion  MoveCursor
            //18 ArrayUtility.MoveCursor();          //GetLetterCount ReverseWordsByNotLetterSplit  BagQuestion  MoveCursor  
            //19 IntUtility.MinCommonMultiple();          //GetLetterCount ReverseWordsByNotLetterSplit  BagQuestion  MoveCursor  MinCommonMultiple

            //20 LinkListUtility.GetDefindeNode();  //链表  VerifyCode
            //21 StringUtility.VerifyCode();  //链表  VerifyCode  GetSymmetryCount
            //22 StringUtility.GetSymmetryCount();  //链表  VerifyCode  GetSymmetryCount  PrimeNumber
            //23 IntUtility.PrimeNumber();  //链表  VerifyCode  GetSymmetryCount  PrimeNumber  ProcessTask

            string dateStr = "2024-08-20 09:00:00";
            bool isd = DateTime.TryParse(dateStr, out DateTime date);
            //DateTime date = DateTime.TryParse(dateStr, out date);

            //24 ArrayUtility.ProcessTask();   //Pizza
            //25 ArrayUtility.Pizza();   //Pizza  GetSubString  PizzaByDynamicPlan
            //ArrayUtility.PizzaByDynamicPlan();   //Pizza  GetSubString  PizzaByDynamicPlan
            //26 StringUtility.GetSubString();  // ZhuanPanShouSi
            //27 ArrayUtility.ZhuanPanShouSi();  // ZhuanPanShouSi  
            //28 ArrayUtility.SortedByHeightAndWeight();  // ZhuanPanShouSi  SortedByHeightAndWeight  
            //29 StringUtility.MultiString();  // ZhuanPanShouSi  SortedByHeightAndWeight  MultiString  GetPeakCount

            //30 ArrayUtility.GetPeakCount(); //CompleteMaxTasks
            //31 ArrayUtility.CompleteMaxTasks();   //
            //32 ArrayUtility.CompressSaveNode();   //CompressSaveNode  ShitouJiandaoBu
            //33 ArrayUtility.ShitouJiandaoBu();   //CompressSaveNode  ShitouJiandaoBu  
            //34 StringUtility.GetMinParkPosition();   //CompressSaveNode  CPUSwitch
            //35 ArrayUtility.CPUSwitch();   //CompressSaveNode  CPUSwitch  
            //36 IntUtility.NumberPlus();   //CompressSaveNode  CPUSwitch  NumberPlus  
            //37 StringUtility.FireStartLetter();   //CompressSaveNode   HotColdFlag
            //38 ArrayUtility.HotColdFlag();   //CompressSaveNode   HotColdFlag  GetLongestString
            //39 StringUtility.GetLongestString();
            //40 ArrayUtility.GetMaxAndMinSum();  // 
            //41 DicUtility.GetAppTimeSpan();  // GetAppTimeSpan  GetRoadPoint
            //ArrayUtility.GetRoadPoint();  // GetAppTimeSpan  GetRoadPoint  
            // StringUtility.CharOrderByAscil();  // GetAppTimeSpan  GetRoadPoint  CharOrderByAscil  FangGeZi
            // ArrayUtility.FangGeZi();  // GetAppTimeSpan  GetRoadPoint  CharOrderByAscil  FangGeZi  
            // ArrayUtility.SnakeTable();  // GetAppTimeSpan  GetRoadPoint  CharOrderByAscil  FangGeZi  SnipperTable  
            // ArrayUtility.SlideWindow();  // GetAppTimeSpan  GetRoadPoint  CharOrderByAscil  FangGeZi  SnipperTable  SlideWindow  IntToBinary
            // IntUtility.IntToBinary();  //BinaryToInt
            // IntUtility.BinaryToInt();  //BinaryToInt  
            // ArrayUtility.GetLongestIncreArr();  //BinaryToInt  GetLongestIncreArr
            // List<string> list = new List<string>();  //MiGong
            // ArrayUtility.MiGong();  //BinaryToInt
            IntUtility.BinaryToInt();  //BinaryToInt



            Console.WriteLine("Hello, World!");

        }
    }
}
