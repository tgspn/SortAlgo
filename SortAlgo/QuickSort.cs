using System;

namespace SortAlgo
{
    class QuickSort : SortBase
    {
        long iteracao = 0;
        long comparacao = 0;
        long troca = 0;
        private void ordenacaoQuickSort(int[] vetor, int esq, int dir)
        {
            int r;
            comparacao++;
            if (esq < dir)
            {
                r = particao(vetor, esq, dir);
                //Console.WriteLine("pivô {0}", r);
                ordenacaoQuickSort(vetor, esq, r - 1);
                ordenacaoQuickSort(vetor, r + 1, dir);
            }
        }
        private int particao(int[] vetor, int esq, int dir)
        {
            int i, j;
            i = esq;
            int pivo = vetor[esq];

            for (j = i + 1; j <= dir; j++)
            {
                comparacao++;
                if (vetor[j] < pivo)
                {
                    i++;
                    Trocar(vetor, i, j);
                    troca++;
                }
                iteracao++;
            }
            Trocar(vetor, i, esq);
            troca++;


            return i; // retorna a posição do pivô
        }
        public override void Ordenar(int[] vetor)
        {
            Random r = new Random();
            TotalElementos = vetor.Length;
            int n = vetor.Length;
            int pivo = -1;
            var modo = "";
            do
            {
                Console.Clear();
                Console.WriteLine("1 - pivô randomico");
                Console.WriteLine("2 - pivô Manual");
                Console.WriteLine("3 - pivô Mediano Radomico");
                Console.WriteLine("4 - pivô Mediano Fixo");
                var pivoOpt = Console.ReadLine();

                switch (pivoOpt)
                {
                    case "1":
                        pivo = r.Next(0, n);
                        modo = "Aleatório";
                        break;
                    case "2":
                        do
                        {
                            Console.Clear();
                            Console.Write("Entre com o pivô:");

                        } while (!int.TryParse(Console.ReadLine(), out pivo));
                        Console.WriteLine();
                        modo = "Manual";
                        break;
                    case "3":
                        {
                            var v1 = vetor[r.Next(0, n - 1)];
                            var v2 = vetor[r.Next(0, n - 1)];
                            var v3 = vetor[r.Next(0, n - 1)];

                            pivo = v2;
                            modo = "Mediana Aleatória";
                        }
                        break;
                    case "4":
                        {

                            var v1 = new int[n / 2];
                            Array.Copy(vetor, v1, n / 2);
                            var v2 = new int[n / 2];
                            Array.Copy(vetor, n / 2, v2, 0, n - (n / 2));
                            if (v1.Length == v2.Length)
                                pivo = v2[0] == 0 ? v1[v1.Length] : (v1[v1.Length - 1] + v2[0]) / 2;
                            else
                                pivo = v2[0];

                            modo = "Mediana Fixa";
                        }
                        break;
                    default:
                        break;
                }

            } while (pivo < 0);
            //var pivo = 50000;// r.Next(0, n - 1);
            Console.Clear();
            Console.WriteLine("& " + modo + "\t& " + pivo);
            stopwatch.Start();
            try
            {
                ordenacaoQuickSort(vetor, pivo, n - 1);
            }
            catch (StackOverflowException ex)
            {
                Console.WriteLine(ex);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                stopwatch.Stop();
                TotalIteracao = iteracao;
                TotalComparacao = comparacao;
                TotalTroca = troca;
            }
        }



        private void Trocar(int[] vetor, int origem, int destino)
        {
            int aux = vetor[origem];
            vetor[origem] = vetor[destino];
            vetor[destino] = aux;
        }
    }
}
