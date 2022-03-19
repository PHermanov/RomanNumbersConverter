int RomanToInt(string s)
{
    var literals = new Dictionary<char, int>
    {
        {'I', 1},
        {'V', 5},
        {'X', 10},
        {'L', 50},
        {'C', 100},
        {'D', 500},
        {'M', 1000}
    };

    var complexLiterals = new Dictionary<string, int>
    {
        {"IV", 4},
        {"IX", 9},
        {"XL", 40},
        {"XC", 90},
        {"CD", 400},
        {"CM", 900}
    };

    var result = 0;

    for (var i = 0; i < s.Length; i++)
    {
        var literal = s[i];

        var nextLiteral = char.MinValue;
        if (i < s.Length - 1)
        {
            nextLiteral = s[i + 1];
        }

        var complexLiteral = literal switch
        {
            'I' when nextLiteral is 'V' => "IV",
            'I' when nextLiteral is 'X' => "IX",
            'X' when nextLiteral is 'L' => "XL",
            'X' when nextLiteral is 'C' => "XC",
            'C' when nextLiteral is 'D' => "CD",
            'C' when nextLiteral is 'M' => "CM",
            _ => string.Empty
        };

        if (!string.IsNullOrEmpty(complexLiteral))
        {
            result += complexLiterals[complexLiteral];
            i++;
        }
        else
        {
            result += literals[literal];
        }
    }

    return result;
}

string IntToRoman(int num)
{
    var result = string.Empty;

    var thousandth = num / 1000;
    if (thousandth > 0)
    {
        for (var j = 0; j < thousandth; j++)
        {
            result += "M";
        }
    }

    var hundred = num % 1000 / 100;

    if (hundred > 0)
    {
        switch (hundred)
        {
            case 4: result += "CD"; break;
            case >= 5 and < 9:
            {
                result += "D";

                if (hundred > 5)
                {
                    for (var j = 0; j < hundred - 5; j++)
                    {
                        result += "C";
                    }
                }

                break;
            }
            case 9: result += "CM"; break;
            default:
            {
                for (var j = 0; j < hundred; j++)
                {
                    result += "C";
                }
                break;

            }
        }
    }

    var tenth = num % 100 / 10;

    if (tenth > 0)
    {
        switch (tenth)
        {
            case 4: result += "XL"; break;
            case >= 5 and < 9:
            {
                result += "L";

                if (tenth > 5)
                {
                    for (var j = 0; j < tenth - 5; j++)
                    {
                        result += "X";
                    }
                }

                break;
            }
            case 9: result += "XC"; break;
            default:
            {
                for (var j = 0; j < tenth; j++)
                {
                    result += "X";
                }
                break;

            }
        }
    }


    var one = num % 10;

    if (one > 0)
    {
        switch (one)
        {
            case 4: result += "IV"; break;
            case >= 5 and < 9:
                {
                    result += "V";

                    if (one > 5)
                    {
                        for (var j = 0; j < one - 5; j++)
                        {
                            result += "I";
                        }
                    }

                    break;
                }
            case 9: result += "IX"; break;
            default:
                {
                    for (var j = 0; j < one; j++)
                    {
                        result += "I";
                    }
                    break;

                }
        }
    }

    return result;
}