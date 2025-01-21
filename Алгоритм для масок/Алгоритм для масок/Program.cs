//Сеть, маска и коллекция делителей для подсетей

string[] network = "45.200.0.128".Split('.'); //Ввести адрес руками
int mask = 26; //Ввести маску руками
int[] divs = { 2, 4, 4 }; //Ввести части руками (1/x, 1/y, 1/z...), вводится только знаменатель
List<int> parts = new List<int>();
List<int> masks = new List<int>();

int[] network_parts = new int[4];
for(int i = 0; i < 4; i++)
{
    network_parts[i] = Convert.ToInt32(network[i]);
}

var need_adresses = (int)Math.Round(Math.Pow(2, (32 - mask)));

Console.WriteLine("Нужно всего адресов:");
Console.WriteLine(need_adresses);

foreach (int d in divs)
{
    var count = need_adresses / d;
    parts.Add(count);
    masks.Add(32 - (int)Math.Round(Math.Log2(count)));
}

//Имеем
//Массив новый масок
//Массив с количеством адресов для подсетей
Console.WriteLine("Количество адресов подсетей:");
foreach(var part in parts)
{
    Console.Write(part + " ");
}
Console.WriteLine();
Console.WriteLine("Новые маски:");
foreach (var m in masks)
{
    Console.Write(m + " ");
}
Console.WriteLine();

int current_free = 256 - network_parts[3] - need_adresses;

List<string> result = new List<string>();

if(current_free >= 0)
{
    Console.WriteLine("С последней");
    foreach (var part in parts)
    {
        string res = string.Join(".", network_parts);
        result.Add(res);
        Console.WriteLine($"{network_parts[0]}.{network_parts[1]}.{network_parts[2]}.{network_parts[3]}");
        network_parts[3] += part;
    }
}
else
{
    Console.WriteLine("С предпоследней");
    foreach (var part in parts)
    {
        string res = string.Join(".", network_parts);
        result.Add(res);
        Console.WriteLine($"{network_parts[0]}.{network_parts[1]}.{network_parts[2]}.{network_parts[3]}");
        var dop_part = part;
        while(dop_part > 0)
        {
            var to256 = 256 - network_parts[3];
            var ost = dop_part - to256;
            if(ost >= 0)
            {
                network_parts[2]++;
                network_parts[3] = 0;
                dop_part -= to256;
            }
            else
            {
                network_parts[3] += dop_part;
                break;
            }
        }
    }
}

Console.WriteLine($"Итог: ");
for (int i = 0; i < result.Count; i++)
{
    Console.WriteLine($"{result[i]} /{masks[i]}");
}
