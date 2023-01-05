namespace Jogo;
class Program
{
    static void Main(string[] args)
    {
        Start();
        FirstQuestion();
        SecondQuestion();
        ThirdQuestion();
    }
    public static void Start() 
    {
        Console.Clear();

        Console.WriteLine("Ola Aventureiro(a) qual o seu nome?");
        string name = Console.ReadLine();

        Console.WriteLine($"Bom {name} você desmaiou em meio a batalha e precisamos de sua ajuda mais do que nunca. Poderia nos ajudar?");
        Console.ReadKey();
        

    }
    static void FirstQuestion()
    {
        Console.Clear();

        Console.WriteLine("Qual sera sua resposta?");
        Console.WriteLine("");
        Console.WriteLine("1 - Claro conte comigo");
        Console.WriteLine("2 - nem pensar, vou dar o fora daqui");

        Console.WriteLine("--------------------\\--------------------");
        Console.WriteLine("Digite o numero referente a sua resposta: ");

        short res = short.Parse(Console.ReadLine());

        switch(res)
        {
            case 1: FirstAnswerOne(); break;
            case 2: FirstAnswerTwo(); break;
            default: Start(); break;
        }

    }
    static void FirstAnswerOne()
    {
        Console.Clear();
        Console.WriteLine("1 - Claro conte comigo");
        Console.WriteLine("");

        Console.WriteLine("Então vamos logo não temos tempo a perder, pegue sua espada e defenda meu flanco pois os inimigos estao chegando");

        Console.ReadKey();
        SecondQuestion();

    }
    static void FirstAnswerTwo()
    {
        Console.Clear();
        Console.WriteLine("2 - nem pensar, vou dar o fora daqui");
        Console.WriteLine("");

        Console.WriteLine("Covardes não merecém uma segunda chance de viver, sucumba!");
        Console.WriteLine("");

        Console.WriteLine("Você morreu!! ");
        

        Console.ReadKey();
        System.Environment.Exit(0);
        
    }
    static void SecondQuestion()
    {
        Console.Clear();
        Console.WriteLine("*O inimigo esta a sua frente o que você faz?*");
        Console.WriteLine("");
        Console.WriteLine("1- Tenta acerta com um movimento de espada preciso");
        Console.WriteLine("2- Tenta uma tecnica elaborada e estilosa com a qual você não possui maestria");

        Console.WriteLine("--------------------\\--------------------");
        Console.WriteLine("Digite o numero referente a sua resposta: ");

        short res = short.Parse(Console.ReadLine());

        switch(res)
        {
            case 1: SecondAnswerOne(); break;
            case 2: SecondAnswerTwo(); break;
            default: Start(); break;
        }
    }
    static void SecondAnswerOne()
    {
        Console.Clear();
        Console.WriteLine("1- O Acerta com um movimento de espada preciso");
        Console.WriteLine("");

        Console.WriteLine("*Você acerta o inimgo que cai sem vida ao chão*");

        Console.ReadKey();
        ThirdQuestion();
    }
    static void SecondAnswerTwo()
    {
        Console.Clear();
        Console.WriteLine("2- Tenta uma tecnica elaborada e estilosa com a qual você não possui maestria");
        Console.WriteLine("");

        Console.WriteLine("*Mas que idiotice foi essa? HAHAHA SUCUMBA BABACA!!!!!!*");
        Console.WriteLine("");
        Console.WriteLine("O inimigo te acerta um golpe dilacerante enquanto gargalha em meio ao calor da batalha");

        Console.WriteLine("");
        Console.WriteLine("Você morreu!! ");
        

        Console.ReadKey();
        System.Environment.Exit(0);

    }
    static void ThirdQuestion()
    {
    
        Console.Clear();
        Console.WriteLine("Muito bem aventureiro, graças a suas habilidades conseguimos sobreviver!!!");
        Console.WriteLine("");

        Console.WriteLine("Vamos ate a taverna mais próxima comemorar!!!");
        Console.WriteLine("");

        Console.WriteLine("Continua...");
        

        Console.ReadKey();
        System.Environment.Exit(0);
    }
    }
