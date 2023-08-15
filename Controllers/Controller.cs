using Microsoft.AspNetCore.Mvc;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestProjectController : ControllerBase
    {
        /// <summary>
        /// Проверка слова на палиндром
        /// </summary>
        /// <response code="200">bool isPalindrom</response>
        [ProducesResponseType(typeof(bool), 200)]
        [ApiVersion("1.0")]
        [HttpGet("/checkOnPalindrome")]
        public async Task<bool> CheckOnPalindrome(string? inputString)
        {
            var reversedString = new string(inputString.Reverse().ToArray());
            return inputString == reversedString;
        }

        /// <summary>
        /// Сумма нечетных чисел по модулю
        /// </summary>
        /// <response code="200">int sum</response>
        [ProducesResponseType(typeof(int), 200)]
        [ApiVersion("1.0")]
        [HttpGet("/getSum")]
        public async Task<int> GetSumModule(string? inputString)
        {
            var list = inputString.Split(" ");
            int sum = 0;
            bool isFirst = true;
            for (int ind = 0; ind < list.Length; ++ind)
            {
                var digit = int.Parse(list[ind]);
                if (digit % 2 != 0 && isFirst)
                {
                    isFirst = false;
                    continue;
                }
                else
                {
                    if (digit % 2 != 0)
                    {
                        sum += Math.Abs(int.Parse(list[ind]));
                        isFirst = true;
                    }
                }
            }
            return sum;
        }

        /// <summary>
        /// Сортировка массива
        /// </summary>
        ///  <param name="isDescending">Сортировка по возрастанию или убыванию</param>
        /// <response code="200">string[]</response>
        [ProducesResponseType(typeof(string[]), 200)]
        [ApiVersion("1.0")]
        [HttpGet("/getOrderList")]
        public async Task<string[]> GetOrderList(string? inputString, bool isDescending = false)
        {
            var list = inputString.Split(" ");
            bool swapped;
            bool isFirst = true;
            int length = list.Length;
            do
            {
                swapped = false;
                for (int ind = 1; ind < length; ++ind)
                {
                    if (isDescending)
                    {
                        if (int.Parse(list[ind - 1]) < int.Parse(list[ind]))
                        {
                            int temp = int.Parse(list[ind - 1]);
                            list[ind - 1] = list[ind];
                            list[ind] = temp.ToString();
                            swapped = true;
                        }
                    }
                    else
                    {
                        if (int.Parse(list[ind - 1]) > int.Parse(list[ind]))
                        {
                            int temp = int.Parse(list[ind - 1]);
                            list[ind - 1] = list[ind];
                            list[ind] = temp.ToString();
                            swapped = true;
                        }
                    }

                }
                --length;
            } while (swapped);
            return list;
        }

    }
}
