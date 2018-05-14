using System;
using System.IO;

namespace GroupProject_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            //FURBA SHERPA - 101085699
            //ROBERT MAGYARI - 101060341

            int id;
            string mainString;
            char[] AnswerList;
            string output = "";
            char[] ans;
            string[] stu_answer;
            string line;
            int counter = 0;
            int correct_answer = 0;
            int TotalPoints = 0;
            int Total;

            StreamReader sr = new StreamReader("exam.txt");//OPEN THE TXT FILE

            mainString = sr.ReadLine();//READ THE FIRST LINE
            
            AnswerList = mainString.ToCharArray();//TURN THE MAIN ANSWER KEY TO CHARACTER ARRAY

            Console.WriteLine(mainString + " <-- correct answer");//PRINT THE FIRST LINE

            line = sr.ReadLine();//READ THE SECOND LINE

            stu_answer = line.Split();//Split line into two lines. stu_answer[0] is id. stu_answer[1] is the answers

            id = Convert.ToInt32(stu_answer[0]);//convert the id part into integer 

            ans = stu_answer[1].ToCharArray();//CONVERT ANSWER PART TO CHARACTER LIST
            

            while (id != 0)
            {
                for (int i = 0; i <= ans.Length-1;i++)
                {
                    if (ans[i] == AnswerList[i])
                    {
                        string newStr = ans[i].ToString();
                        output += newStr;
                        correct_answer += 1;
                        TotalPoints += 4;
                    }
                    else if(ans[i] == 'X')
                    {
                        output += ans[i];
                        continue;
                    }
                    else
                    {
                        output += "X";
                        TotalPoints -= 1;
                    }
                    
                }
                Total = correct_answer * 100 / 20;
                Console.WriteLine(id + " " + output + "\t" + correct_answer + " out of 20\t"  + Total + "%\t Total Points:" + TotalPoints);
                output = "";
                TotalPoints = 0;
                correct_answer = 0;
                counter++;
                line = sr.ReadLine();
                stu_answer = line.Split();
                id = Convert.ToInt32(stu_answer[0]);
                if (id == 0)
                {
                    break;
                }
                else
                {
                    ans = stu_answer[1].ToCharArray();
                }

            }
            Console.WriteLine("Total number of candidates: " + counter);
            Console.ReadLine();
        }
    }
}
