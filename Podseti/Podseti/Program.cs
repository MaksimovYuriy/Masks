using System.Diagnostics;

string[] mask = "255.252.0.0".Split('.');
string[] adr = "198.1.45.7".Split('.');
string[] number = new string[mask.Length];

for(int i = 0; i < mask.Length; i++)
{
    number[i] = (Convert.ToInt32(mask[i]) & Convert.ToInt32(adr[i])).ToString();
}

Console.WriteLine(string.Join('.', number));

