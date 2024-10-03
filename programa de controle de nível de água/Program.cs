using System.Threading.Tasks;

int reservatorio = 0;
bool bomba;
bool boiaC;
bool boiaA = true;
bool boiaB = false;

Console.WriteLine("O reservatório está vazio?");
string verif = Console.ReadLine().ToLower();



if (verif != "sim")
{
    Console.WriteLine("qual o nível de água?\n0 Vazio\n1 nível baixo de água\n2 metade da caixa d`água\n3 caixa d`água cheia");
    int.TryParse(Console.ReadLine().ToLower(), out int nivel);
    if(nivel == 1)
    {
        Console.WriteLine("nível de água muito baixo");
        
    }
    else if(nivel==2 )
    {

        if((boiaA==true) && (boiaB==false))
        {
        Console.WriteLine("Bomba está funcionando, caixa D`água enchendo com pouca vazão");
        }
        else
        {
            Console.WriteLine("error");
        }   
    }
    else if(nivel==3)
    {
        
    }
   
}

   

