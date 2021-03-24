using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoRenato
{
    class Program
    {
        static void Main(string[] args)
        {



            string filePath = @"C:\Users\luis\Downloads\The Great Monster Spreadsheet (D&D5e)_.csv";

            List<Monstros> monstros = new List<Monstros>();
            int escolha = 0;

            do
            {

                try
                {

                    #region --- Coloca o arquivo CSV em uma lista


                    List<string> lines = File.ReadAllLines(filePath).Skip(1).ToList();

                    foreach (var line in lines)
                    {
                        string[] entries = line.Split(';');

                        Monstros newMonster = new Monstros();

                        newMonster.name = entries[0];
                        newMonster.type = entries[1];
                        newMonster.allign = entries[2];
                        newMonster.size = entries[3];
                        newMonster.CR = entries[4];
                        newMonster.AC = entries[5];
                        newMonster.HP = Convert.ToInt32(entries[6]);
                        newMonster.STR = Convert.ToInt32(entries[7]);
                        newMonster.DEX = Convert.ToInt32(entries[8]);
                        newMonster.CON = Convert.ToInt32(entries[9]);
                        newMonster.INT = Convert.ToInt32(entries[10]);
                        newMonster.WIS = Convert.ToInt32(entries[11]);
                        newMonster.CHA = Convert.ToInt32(entries[12]);

                        monstros.Add(newMonster);
                    }

                    #endregion


                    Console.WriteLine("-----------------------Manual dos Monstros-------------------------");
                    Console.WriteLine("1. Cadastro de Mosntro.");
                    Console.WriteLine("2. Filtrar Mostros.");
                    Console.WriteLine("3. Oredenar Manual.");
                    Console.WriteLine("0. Sair \n");
                    Console.WriteLine("--->");

                    escolha = Convert.ToInt32(Console.ReadLine());


                }
                catch (Exception ex)
                {

                    Console.WriteLine("You did an oopsie!!!");
                    Console.WriteLine(ex.Message);
                }

                switch (escolha)
                {

                    case 1:

                        Console.Clear();

                        Console.WriteLine("Para cadastrar um monstro Informe as seguites caracteristicas na ordem correta:");
                        Console.WriteLine("Name, Type, Allignment, Size, CR, AC, Hp, STR, DEX, CON, INT, WIS, CHA");


                        monstros.Add(new Monstros
                        {
                            name = Console.ReadLine(),
                            type = Console.ReadLine(),
                            allign = Console.ReadLine(),
                            size = Console.ReadLine(),
                            CR = Console.ReadLine(),
                            AC = Console.ReadLine(),
                            HP = Convert.ToInt32(Console.ReadLine()),
                            STR = Convert.ToInt32(Console.ReadLine()),
                            DEX = Convert.ToInt32(Console.ReadLine()),
                            CON = Convert.ToInt32(Console.ReadLine()),
                            INT = Convert.ToInt32(Console.ReadLine()),
                            WIS = Convert.ToInt32(Console.ReadLine()),
                            CHA = Convert.ToInt32(Console.ReadLine())
                        });

                        List<string> output = new List<string>();

                        foreach (var monstro in monstros)
                        {
                            output.Add($"{monstro.name}; {monstro.type}; {monstro.allign}; {monstro.size}; {monstro.CR}; {monstro.AC}; {monstro.HP}; {monstro.STR}; {monstro.DEX}; {monstro.CON};" +
                                $"{monstro.INT}; {monstro.WIS}; {monstro.CHA};");
                        }

                        Console.WriteLine("Atualizando arquivo CSV");

                        File.WriteAllLines(filePath, output);

                        Console.WriteLine("Arquivo atualizado");

                        break;

                    case 2:
                        Console.Clear();



                        Console.WriteLine("Escolha o Tipo do Monstro:");

                        string pesquisa = Console.ReadLine();

                        if ((monstros.Exists(x => x.type.Contains(pesquisa)) && (monstros.Exists(x => x.type.Length == pesquisa.Length))))
                        {


                            monstros = monstros.Where(x => x.type.Contains(pesquisa)).ToList();


                            foreach (var monstro in monstros)
                            {
                                Console.WriteLine($"{monstro.name} {monstro.type} {monstro.allign} {monstro.size} {monstro.CR} {monstro.AC} {monstro.HP} {monstro.STR} {monstro.DEX} {monstro.CON}" +
                                    $"{monstro.INT} {monstro.WIS} {monstro.CHA}");
                            }

                        }

                        else
                        {
                            Console.WriteLine("You did an oopsie!!!");
                            Console.WriteLine("Tipo de Mosntro Invalido\n\n\n");
                        }

                        break;

                    case 3:

                        Console.Clear();

                        int escolha2 = 0;

                        do
                        {
                            try
                            {
                                Console.WriteLine("1. Bubble Sort.");
                                Console.WriteLine("2. Insertion Sort.");
                                Console.WriteLine("3. Shell Sort.");
                                Console.WriteLine("4. Quick Sort.");
                                Console.WriteLine("----->");

                                escolha2 = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception Ex)
                            {
                                Console.WriteLine("You did an oopsie");
                                Console.WriteLine(Ex.Message);
                            }

                            switch (escolha2)
                            {

                                case 1:

                                    var listaClonada = new List<Monstros>();
                                    listaClonada.AddRange(monstros);

                                    var resultadoOrdenacao = bubbleSort(listaClonada);

                                    foreach (var monstro in resultadoOrdenacao)
                                    {
                                        Console.WriteLine($"{monstro.name} {monstro.type} {monstro.allign} {monstro.size} {monstro.CR} {monstro.AC} {monstro.HP} {monstro.STR} {monstro.DEX} {monstro.CON}" +
                                            $"{monstro.INT} {monstro.WIS} {monstro.CHA}");
                                    }
                                    break;

                                case 2:

                                    var listaClonada2 = new List<Monstros>();

                                    listaClonada2.AddRange(monstros);

                                    var resultadoOrdenacao2 = insertionSort(listaClonada2);

                                    foreach (var monstro in resultadoOrdenacao2)
                                    {
                                        Console.WriteLine($"{monstro.name} {monstro.type} {monstro.allign} {monstro.size} {monstro.CR} {monstro.AC} {monstro.HP} {monstro.STR} {monstro.DEX} {monstro.CON}" +
                                            $"{monstro.INT} {monstro.WIS} {monstro.CHA}");
                                    }
                                    break;

                                case 3:

                                    var listaClonada3 = new List<Monstros>();

                                    listaClonada3.AddRange(monstros);

                                    var resultadoOrdenacao3 = shellSort(listaClonada3);

                                    foreach (var monstro in resultadoOrdenacao3)
                                    {
                                        Console.WriteLine($"{monstro.name} {monstro.type} {monstro.allign} {monstro.size} {monstro.CR} {monstro.AC} {monstro.HP} {monstro.STR} {monstro.DEX} {monstro.CON}" +
                                            $"{monstro.INT} {monstro.WIS} {monstro.CHA}");
                                    }

                                    break;

                                case 4:

                                    var listaClonada4 = new List<Monstros>();

                                    listaClonada4.AddRange(monstros);

                                    var resultadoOrdenacao4 = shellSort(listaClonada4);

                                    foreach (var monstro in resultadoOrdenacao4)
                                    {
                                        Console.WriteLine($"{monstro.name} {monstro.type} {monstro.allign} {monstro.size} {monstro.CR} {monstro.AC} {monstro.HP} {monstro.STR} {monstro.DEX} {monstro.CON}" +
                                            $"{monstro.INT} {monstro.WIS} {monstro.CHA}");
                                    }

                                    break;

                                default:
                                    break;
                            }

                        } while (escolha2 > 0);


                        break;

                    default:
                        break;

                }



            } while (escolha > 0);

            Console.ReadKey();

        }

        public static List<Monstros> bubbleSort(List<Monstros> vetor)
        {
            int tamanho = vetor.Count;

            for (int i = tamanho - 1; i >= 1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (vetor[j].HP > vetor[j + 1].HP)
                    {
                        Monstros aux = vetor[j];
                        vetor[j] = vetor[j + 1];
                        vetor[j + 1] = aux;
                    }
                }
            }

            return vetor;
        }
        public static List<Monstros> insertionSort(List<Monstros> vetor)
        {
            int i, j;

            Monstros atual;

            for (i = 1; i < vetor.Count; i++)
            {
                atual = vetor[i];
                j = i;
                while ((j > 0) && (vetor[j - 1].HP > atual.HP))
                {
                    vetor[j] = vetor[j - 1];
                    j = j - 1;
                }
                vetor[j] = atual;
            }

            return vetor;
        }

        public static List<Monstros> shellSort(List<Monstros> vetor)
        {
            int h = 1;
            int n = vetor.Count;

            while (h < n)
            {
                h = h * 3 + 1;
            }

            h = h / 3;
            int j;
            while (h > 0)
            {
                for (int i = h; i < n; i++)
                {
                    Monstros c = vetor[i];
                    j = i;
                    while (j >= h && vetor[j - h].HP > c.HP)
                    {
                        vetor[j] = vetor[j - h];
                        j = j - h;
                    }
                    vetor[j] = c;
                }
                h = h / 2;
            }

            return vetor;
        }

        public static List<Monstros> quickSort(List<Monstros> vetor)

        {

            int inicio = 0;

            int fim = vetor.Count - 1;

            quickSort(vetor, inicio, fim);

            return vetor;

        }

        private static void quickSort(List<Monstros> vetor, int inicio, int fim)
        {

            if (inicio < fim)
            {
                Monstros p = vetor[inicio];

                int i = inicio + 1;

                int f = fim;

                while (i <= f)
                {

                    if (vetor[i].HP <= p.HP)

                    {
                        i++;
                    }
                    else if (p.HP < vetor[f].HP)

                    {
                        f--;
                    }
                    else

                    {
                        Monstros troca = vetor[i];

                        vetor[i] = vetor[f];

                        vetor[f] = troca;

                        i++;

                        f--;
                    }
                }

                vetor[inicio] = vetor[f];

                vetor[f] = p;

                quickSort(vetor, inicio, f - 1);

                quickSort(vetor, f + 1, fim);

            }
        }
    }
}