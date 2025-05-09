using System.Reflection.PortableExecutable;
using System.Text;

public static class RunLengthEncoding
{
    // Función local para evitar duplicación de código
    private static void AppendEncodedLetter(StringBuilder sb, char ch, int cnt)
    {
        if (cnt == 1)
            sb.Append(ch);
        else
            sb.Append($"{cnt}{ch}");
    }

    public static string Encode(string input)
    {
        if(string.IsNullOrEmpty(input)){
            return "";
        }

        var result = new StringBuilder();
        char auxCh = input[0];
        int counter = 0;


        foreach(char ch in input)
        {
            if(ch == auxCh)
            {
                counter++;
            }else
            {
                //Store the letter with its value
                AppendEncodedLetter(result, auxCh, counter);

                //Reset counter var
                counter = 1;
                //New letter to count
                auxCh =  ch;
            }

        }
        //If the last letter it's the same or if it's diferent it wont be stored
        //Store the last leter
        AppendEncodedLetter(result, auxCh, counter);
        

        return result.ToString();

    }


    public static string Decode(string input)
    {
        //recorrer el array hasta encontrar un numero (ojo que puedes ser de dos cifras)
        // cuando encuentres un numero lo metes en un stringbuilder que solo tenga el numero, si despues
        // el siguiente caracter es una letra, conviertes el stringbuilder a un int y haces un append al resultado
        // Con las letras que necesitas.

        if(string.IsNullOrEmpty(input))
        {
            return "";
        }

        var result = new StringBuilder();
        var auxIntSb = new StringBuilder(); 

        foreach(char ch in input)
        {
            if(char.IsDigit(ch))
            {
                auxIntSb.Append(ch);

            }else
            {
                if(auxIntSb.Length == 0)
                {
                    result.Append(ch);
                }else
                {
                    result.Append(new string(ch, int.Parse(auxIntSb.ToString())));
                }
                
                //Reset aux
                auxIntSb.Clear();
                
            }
        }

        return result.ToString();

        
    }
}
