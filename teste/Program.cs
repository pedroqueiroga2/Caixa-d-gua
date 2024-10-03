using System;

class WaterTankSystem
{
    private int waterLevel; // Nível de água no reservatório
    private bool buoyA; // Boia A (Nível crítico)
    private bool buoyB; // Boia B (Nível cheio)
    private bool buoyC; // Boia C (Nível de acionamento da bomba)
    private bool pumpStatus; // Estado da bomba
    private bool valveStatus; // Estado da eletroválvula

    public WaterTankSystem()
    {
        waterLevel = 0;
        buoyA = false;
        buoyB = false;
        buoyC = false;
        pumpStatus = false;
        valveStatus = false;
    }

    public void UpdateBuoys()
    {
        // Atualizar os estados das boias com base no nível de água
        if (waterLevel < 10) // Nível crítico
        {
            buoyA = true;
            buoyC = false;
        }
        else if (waterLevel > 50) // Nível cheio
        {
            buoyB = true;
            buoyC = false;
        }
        else
        {
            buoyA = false;
            buoyB = false;
            buoyC = true;
        }
    }

    public void ControlSystem()
    {
        UpdateBuoys();

        // Verificar inconsistências
        if ((buoyA && waterLevel == 0) || (buoyB && waterLevel > 50))
        {
            Console.WriteLine("Erro: Inconsistência no sistema de monitoramento.");
            pumpStatus = false;
            valveStatus = false;
            return;
        }

        // Ligar a bomba se necessário
        if (buoyC && waterLevel > 0)
        {
            pumpStatus = true;
            Console.WriteLine("Bomba ligada.");
        }
        else
        {
            pumpStatus = false;
            Console.WriteLine("Bomba desligada.");
        }

        // Controlar a eletroválvula
        if (!buoyB)
        {
            valveStatus = true;
            Console.WriteLine("Eletroválvula aberta.");
        }
        else
        {
            valveStatus = false;
            Console.WriteLine("Eletroválvula fechada.");
        }
    }

    public void SetWaterLevel(int level)
    {
        waterLevel = level;
    }
}

// Exemplo de uso
class Program
{
    static void Main(string[] args)
    {
        WaterTankSystem tankSystem = new WaterTankSystem();
        
        tankSystem.SetWaterLevel(5); // Definir nível de água
        tankSystem.ControlSystem();
        
        Console.ReadLine(); // Para manter a janela aberta
    }
}
