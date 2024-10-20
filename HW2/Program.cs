namespace HW2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task4("To be, or not to be, that is the question,\r\nWhether 'tis nobler in the mind to suffer\r\nThe slings and arrows of outrageous fortune,\r\nOr to take arms against a sea of troubles,\r\nAnd by opposing end them? To die: to sleep;\r\nNo more; and by a sleep to say we end\r\nThe heart-ache and the thousand natural shocks\r\nThat flesh is heir to, 'tis a consummation\r\nDevoutly to be wish'd. To die, to sleep", "die"); 
        }

        static void Task1() 
        {
            int[] A = { 1, 2, 3, 4,5 };
            double[,] B = new double[3, 4];

            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    B[i, j] = random.NextDouble() * 100;
                }
            }
            //-------------------------------
            Console.WriteLine("A:");
            foreach (int elem in A)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();
          

            Console.WriteLine("B:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(B[i, j].ToString("F2") + "\t");
                }
                Console.WriteLine();
            }
            //-------------------------------
            double max = A[0], min = A[0], sum = 0, product = 1;
            int sumEvenA = 0, sumOddColsB = 0;

            foreach (int elem in A)
            {
                if (elem > max) max = elem;
                if (elem < min) min = elem;
                sum += elem;
                product *= elem;
                if (elem % 2 == 0) sumEvenA += elem;
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    double elem = B[i, j];
                    if (elem > max) max = elem;
                    if (elem < min) min = elem;
                    sum += elem;
                    product *= elem;
                    if (j % 2 == 1) sumOddColsB += (int)elem; 
                }
            }
            //-------------------------------
            Console.WriteLine($"Max: {max}");
            Console.WriteLine($"Min: {min}");
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Prod: {product}");
            Console.WriteLine($"Sum a: {sumEvenA}");
            Console.WriteLine($"Sum b: {sumOddColsB}");
        }
        static void Task2()
        {
            int[,] array = new int[5, 5];
            Random random = new Random();
            //-------------------------------
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    array[i, j] = random.Next(-100, 101);
                }
            }
            //-------------------------------

            Console.WriteLine("Массив:");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }

            //-------------------------------
            int min = array[0, 0], max = array[0, 0];
            int minPos = 0, maxPos = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    int index = i * 5 + j;
                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                        minPos = index;
                    }
                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                        maxPos = index;
                    }
                }
            }
            //-------------------------------
            int start = Math.Min(minPos, maxPos);
            int end = Math.Max(minPos, maxPos);
            int sum = 0;

            for (int index = start + 1; index < end; index++)
            {
                int i = index / 5;
                int j = index % 5;
                sum += array[i, j];
            }

            Console.WriteLine($"Сумма элементов между минимальным и максимальным: {sum}");
        }
        static void Task3(string input)
        {
            input = input.Replace(" ", "");

            int result = 0;
            string number = ""; 

            char lastOperator = '+';


            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    number += c;
                }
                else
                {
                    int currentNumber = int.Parse(number);

                    if (lastOperator == '+')
                    {
                        result += currentNumber;
                    }
                    else if (lastOperator == '-')
                    {
                        result -= currentNumber;
                    }


                    lastOperator = c;
                    number = "";
                }
            }
            if (!string.IsNullOrEmpty(number))
            {
                int currentNumber = int.Parse(number);
                if (lastOperator == '+')
                {
                    result += currentNumber;
                }
                else if (lastOperator == '-')
                {
                    result -= currentNumber;
                }
            }

            Console.WriteLine($"Результат: {result}");
        }
        static void Task4(string text, string forbiddenWord)
        {
            string replacedText = text;
            int count = 0;

            while (replacedText.Contains(forbiddenWord))
            {
                replacedText = replacedText.Replace(forbiddenWord, new string('*', forbiddenWord.Length));
                count++;
            }

            Console.WriteLine("res:");
            Console.WriteLine(replacedText);

        }
    }
    }

