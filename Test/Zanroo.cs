using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Zanroo
    {
        public string Test(string[] arrayOfWord, string text)
        {
            string openHtmlText = @"<strong>";
            string closeHtmlText = @"</strong>";


            if (String.IsNullOrWhiteSpace(text) || arrayOfWord == null || !arrayOfWord.Any())
            {
                return text;
            }

            //TODO : ต้อง normalize array of word ให้ไม่มีคำซ้ำกันก่อน

            string output = text;
            List<int> openTagPos = new List<int>();
            List<int> closeTagPos = new List<int>();

            foreach (var word in arrayOfWord)
            {
                string wordTrimmed = word;
                //string wordTrimmed = word.Trim();
                if (!text.Contains(wordTrimmed))
                {
                    return text;
                }
                else
                {
                    int indexStart = text.IndexOf(wordTrimmed);
                    int indexEnd = indexStart + wordTrimmed.Length;
                    openTagPos.Add(indexStart);
                    closeTagPos.Add(indexEnd);
                }

            }
            var merge = openTagPos.Concat(closeTagPos);
            merge = merge.OrderByDescending(x => x);

            output = text;
            foreach (var higherPos in merge)
            {
                bool isOpen = false;
                bool isClose = false;
                if (openTagPos.Any(x => x == higherPos))
                {
                    isOpen = true;
                }
                if (closeTagPos.Any(x => x == higherPos))
                {
                    isClose = true;
                }
                if (isClose)
                {
                    output = output.Substring(0, higherPos) + closeHtmlText + output.Substring(higherPos, output.Length - higherPos);
                }
                if (isOpen)
                {
                    output = output.Substring(0, higherPos) + openHtmlText + output.Substring(higherPos, output.Length - higherPos);
                }

                // TODO : ** ต้องเปลี่ยนค่า <strong> ใน text ก่อน ค่อยใส่ พอเสร็จค่อยยัดคืน
            }
            return output;

        }
    }
}

