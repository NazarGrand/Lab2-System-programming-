using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    struct Metacharacters
    {
         public int firstN, secondN;
        public int positionStart, positionEnd;
    };
    class Maska
    {
    Metacharacters[] metacharacters = new Metacharacters[1];
    int sizeStr = 1;

    public void DecipheringMetacharacters(string mask)
    {
        string strNumber = "";
        int flag = 0;

        metacharacters[sizeStr - 1].positionStart = -1;
        metacharacters[sizeStr - 1].positionEnd = -1;

        for (int i = 0; i < mask.Length; i++)
        {
            if ((flag == 0) && (mask[i] == '{'))
            {
                flag = 1;
                metacharacters[sizeStr - 1].positionStart = i;
                i++;
            }

            if (flag == 1)
            {
                if (Char.IsDigit(mask[i]))
                {
                    strNumber += mask[i];
                }

                if ((strNumber != "") && (mask[i] == ','))
                {
                    metacharacters[sizeStr - 1].firstN = Convert.ToInt32(strNumber);
                    flag = 2;
                    strNumber = "";
                    i++;
                }

                if (!Char.IsDigit(mask[i]))
                {
                    flag = 0;
                    strNumber = "";
                    metacharacters[sizeStr - 1].positionStart = -1;
                }
            }

            if (flag == 2)
            {
                if (Char.IsDigit(mask[i]))
                {
                    strNumber += mask[i];
                }

                if ((strNumber != "") && (mask[i] == '}'))
                {
                    metacharacters[sizeStr - 1].secondN = Convert.ToInt32(strNumber);
                    metacharacters[sizeStr - 1].positionEnd = i;

                        if (metacharacters[sizeStr - 1].firstN > metacharacters[sizeStr - 1].secondN)
                        {
                            metacharacters[sizeStr - 1].positionStart = -1;
                            metacharacters[sizeStr - 1].positionEnd = -1;
                        }
                        else
                        {
                            Array.Resize<Metacharacters>(ref metacharacters, metacharacters.Length + 1);
                            sizeStr++;
                        }

                    flag = 0;
                    strNumber = "";
                }

                if (!Char.IsDigit(mask[i]))
                {
                    flag = 0;
                    strNumber = "";
                    metacharacters[sizeStr - 1].positionStart = -1;
                    metacharacters[sizeStr - 1].positionEnd = -1;
                }
            }
        }
            sizeStr--;
            Array.Resize<Metacharacters>(ref metacharacters, metacharacters.Length - 1);
        }

        public string resultStr = "";
    public bool MaskCheck(string text, string mask)
    {
            resultStr = "";
        int lowCount, highCount;
        int indexM = 0;
        resultStr = "";
        int j = 0;

        for (int i = 0; i < text.Length; i++)
        {
            char symb;

            if (j >= sizeStr)
            {
                while (i < text.Length)
                {
                    if ((text[i] != mask[indexM]))
                        return false;
                    resultStr += text[i];
                    i++;
                    indexM++;
                }
            }

            if ((indexM > mask.Length - 1) && (i > text.Length - 1))
                return true;

            while (indexM < metacharacters[j].positionStart)
            {
                if ((text[i] != mask[indexM]))
                    return false;
                resultStr += text[i];
                i++;
                indexM++;
            }

            if (i > text.Length - 1)
            {
                resultStr = "";
                return false;
            }
            else
                symb = text[i];

            lowCount = metacharacters[j].firstN;
            highCount = metacharacters[j].secondN;

            int r;
            int ind = 0;
            int fl = 0;
            int check = 0;

            for (r = j; r < sizeStr - 1; r++)
            {
                if (metacharacters[r + 1].positionStart - metacharacters[r].positionEnd == 1)
                {
                    check = 0;

                    /*if( (text[i] == text[i + metacharacters[r].secondN - 1]) &&
                     (text[i] != text[i + metacharacters[r].secondN + metacharacters[r+1].firstN - 1])
                     && (text[i] == mask[metacharacters[r+1].positionEnd + 1]  ) )
                     break;   */

                    lowCount += metacharacters[r + 1].firstN;
                    highCount += metacharacters[r + 1].secondN;
                    ind += 1;

                    int t;
                    for (t = 1; t < lowCount; t++)
                    {
                        if (symb != text[i + t])
                        {
                            check = 1;
                            if (fl == 0)
                            {
                                lowCount = metacharacters[j].firstN;
                                highCount = metacharacters[j].secondN;
                                ind = 0;
                            }

                            if (fl == 1)
                            {
                                lowCount -= metacharacters[r + 1].firstN;
                                highCount -= metacharacters[r + 1].secondN;
                                ind -= 1;
                                fl = 0;
                                break;
                            }
                        }
                    }

                    if (check == 0)
                    {
                        fl = 1;
                    }
                    else
                        break;

                }
                else
                {
                    break;
                }
            }

            j += ind;

            /*cout<<endl<<"Low = "<<lowCount<<endl;
            cout<<endl<<"High = "<<highCount<<endl; */

            for (int t = 1; t < lowCount; t++)
            {
                    if (i + t < text.Length)
                    {
                        if (symb != text[i + t])
                        {
                            resultStr = "";
                            return false;
                        }
                    }
                    else
                        return false;
            }

            int p;
            for (p = lowCount; p < highCount; p++)
            {  
                 if(metacharacters[j].positionEnd + 1 < mask.Length)
                if (text[i + p] == mask[metacharacters[j].positionEnd + 1])
                    break;

                 if(i + p < text.Length)
                if (symb != text[i + p])
                    break;
                //return false;
            }

            for (int l = 0; l < highCount; l++)
                resultStr += symb;

            i += p;
            indexM = metacharacters[j].positionEnd + 1;

            if ((indexM > mask.Length - 1) && (i < text.Length))
            {
                resultStr = "";
                return false;
            }

            if ((indexM < mask.Length) && (i > text.Length - 1))
            {
                resultStr = "";
                return false;
            }

            j++;
            i--;
        }
        return true;
    }
    
    }
}
