using System.Globalization;
using System.Threading.Tasks;

string[] input = "129.45.4.27".Split('.'); //Ввод входного адреса

//Ввод адресов назначения
string[] need =
{
    "129.44.0.0",
    "129.44.64.0",
    "129.44.128.0",
    "129.44.192.0",
    "0.0.0.0",
    "129.44.64.5"
};

//Ввод масок соответственно
string[] masks =
{
    "255.255.192.0",
    "255.255.192.0",
    "255.255.192.0",
    "255.255.192.0",
    "0.0.0.0",
    "255.255.255.255"
};

List<string> output = new List<string>();

int[] input_ints = new int[input.Length];
for(int i = 0; i < input.Length; i++)
{
    input_ints[i] = Convert.ToInt32(input[i]);
}

for(int i = 0; i < need.Length; i++)
{
    string[] parts = masks[i].Split('.');
    int[] mask_ints = new int[4];
    mask_ints[0] = input_ints[0] & Convert.ToInt32(parts[0]);
    mask_ints[1] = input_ints[1] & Convert.ToInt32(parts[1]);
    mask_ints[2] = input_ints[2] & Convert.ToInt32(parts[2]);
    mask_ints[3] = input_ints[3] & Convert.ToInt32(parts[3]);
    string new_adr = string.Join(".", mask_ints);
    output.Add(new_adr);
}

for(int i = 0; i < output.Count; i++)
{
    Console.WriteLine($"{output[i]} - {need[i]} - {output[i] == need[i]}");
}