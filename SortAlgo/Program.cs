using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
            bool sair = false;
            do
            {
                int tamanho = -1;
                do
                {
                    Console.Clear();
                    Console.WriteLine("1 - Tamanho Fixo");
                    Console.WriteLine("2 - Tamanho Manual");
                    Console.WriteLine("-----------");
                    Console.WriteLine("0 - Sair");
                    var opt = Console.ReadLine();
                    if (opt == "1")
                    {
                        tamanho = 0;
                    }
                    else
                        if (opt == "2")
                    {
                        do
                        {
                            Console.Write("Tamanho do vetor: ");
                        } while (!int.TryParse(Console.ReadLine(), out tamanho) && tamanho <= 0);
                    }
                    if (opt == "0")
                        return;

                } while (tamanho < 0);
                bool voltar1 = false;
                int[] vetor = null;
                string metodo = "";
                do
                {
                    SortBase sort = null;
                    bool voltar0 = false;
                    do
                    {
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("1 - Seleção");
                            Console.WriteLine("2 - Bolha");
                            Console.WriteLine("3 - Inserção");
                            Console.WriteLine("4 - Quick");
                            Console.WriteLine("5 - Merge");
                            Console.WriteLine("6 - Shell");
                            Console.WriteLine("7 - Counting");
                            Console.WriteLine("-----------");
                            Console.WriteLine("0 - Voltar");

                            switch (Console.ReadLine())
                            {
                                case "1":
                                    sort = new SelectionSort();
                                    break;
                                case "2":
                                    sort = new BubleSort();
                                    break;
                                case "3":
                                    sort = new InsertionSort();
                                    break;
                                case "4":
                                    sort = new QuickSort();
                                    break;
                                case "5":
                                    sort = new MergeSort();
                                    break;
                                case "6":
                                    sort = new ShellSort();
                                    break;
                                case "7":
                                    sort = new CountingSort();
                                    break;
                                case "0":
                                    voltar0 = true;
                                    break;
                                default:
                                    return;
                            }
                        } while (sort == null && !voltar0);
                        if (voltar0)
                            break;

                        vetor = null;

                        metodo = "";
                        voltar1 = false;

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Escolha uma opção");
                            Console.WriteLine("1 - Vetor Randomico");
                            Console.WriteLine("2 - Vetor Semi ordenado");
                            Console.WriteLine("3 - Vetor ordenado");
                            Console.WriteLine("4 - Vetor ordenado invertido");
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("0 - Voltar");

                            switch (Console.ReadLine())
                            {
                                case "0":
                                    voltar1 = true;
                                    break;
                                case "1":
                                    if (tamanho == 0)
                                        vetor = (int[])Constantes.Randomico.Clone();
                                    else
                                        vetor = CriarVetorRandom(tamanho);
                                    metodo = "Aleatório";
                                    break;
                                case "2":
                                    if (tamanho == 0)
                                        vetor = (int[])Constantes.SemiOrdenados.Clone();
                                    else
                                        vetor = CriarVetorSemiOrdenado(tamanho);
                                    metodo = "Semi ordenado";
                                    break;
                                case "3":
                                    if (tamanho == 0)
                                        vetor = (int[])Constantes.Ordenados.Clone();
                                    else
                                        vetor = CriarVetorSemiOrdenado(tamanho).OrderBy(x => x).ToArray();
                                    metodo = "Ordenado";
                                    break;
                                case "4":
                                    if (tamanho == 0)
                                        vetor = (int[])Constantes.OrdenadosInvertidos.Clone();
                                    else
                                        vetor = CriarVetorSemiOrdenado(tamanho).OrderByDescending(x => x).ToArray();
                                    metodo = "Invertido";
                                    break;
                                default:
                                    break;
                            }
                        } while (vetor == null && !voltar1);
                    } while (voltar1);
                    if (voltar0)
                        break;
                    Console.Clear();
                    sort.Ordenar(vetor);

                    Console.WriteLine(sort.ToString(metodo));
                    sort.Dispose();
                    sort = null;
                    vetor = null;
                    Console.WriteLine("\r\n\r\nPara sair precione: ESQ, senão precione qualquer outra tecla para continuar");
                    GC.Collect();
                    var key = Console.ReadKey();
                    sair = key.Key == ConsoleKey.Escape;

                } while (!sair);
            } while (!sair);
            //var t = CriarVetorRandom(100000);
            //System.IO.File.WriteAllText("D:\\Randomico.txt", string.Join(", ", t));
            //System.IO.File.WriteAllText("D:\\SemiOrdenado.txt", string.Join(", ", semiOrdenado(t.OrderBy(x => x).ToArray())));
            //System.IO.File.WriteAllText("D:\\Ordenado.txt", string.Join(", ", t.OrderBy(x => x)));
            //System.IO.File.WriteAllText("D:\\invertido.txt", string.Join(", ", t.OrderByDescending(x => x)));
        }
        private static void ImprimeVetor(int[] vetor)
        {
            Console.Write(string.Join(" | ", vetor));
        }
        private static int[] CriarVetorRandom(int tamanho)
        {
            Random r = new Random();
            int[] vetor = new int[tamanho];
            for (int i = 0; i < tamanho; i++)
            {
                vetor[i] = r.Next(0, tamanho);
            }
            return vetor;
        }

        private static int[] semiOrdenado(int[] vetor)
        {
            Random r = new Random();
            var next = r.Next(0, 100);
            for (int i = 0; i < vetor.Length; i++)
            {
                if (i == next)
                {
                    vetor[i] = r.Next(i - 5, i + 10);
                    next = r.Next(i, i + 10);
                }
                if (next < i)
                    next = r.Next(i, i + 10);
            }

            return vetor;
        }

        private static int[] CriarVetorSemiOrdenado(int tamanho)
        {
            Random r = new Random();
            int[] vetor = new int[tamanho];
            for (int i = 0; i < tamanho; i++)
            {
                vetor[i] = r.Next(i, i + 10);// r.Next(0, tamanho);
            }
            return vetor;
        }
    }
}
