namespace SortAlgo
{
    class BubleSort : SortBase
    {
        public override void Ordenar(int[] vetor)
        {
            TotalElementos = vetor.Length;
            //vetor = new int[] { 6, 3, 8, 5, 2, 0, 7, 9, 4, 1 };
            int i = 0;
            int j = 0;
            long n = TotalElementos;
            long iteracao = 0;
            long comparacao = 0;
            long troca = 0;
            double teste = 0;
            bool trocou = true;
            //ImprimirVetor(vetor);
            stopwatch.Start();

            for (i = (int)n - 1; i >= 1 && trocou; i--)
            {
                trocou = false;
                for (j = 0; j < i; j++)
                {
                    iteracao++;
                    comparacao++;
                    //ImprimirVetor(vetor, j);
                    if (vetor[j] > vetor[j + 1])
                    {
                        Trocar(vetor, j, j + 1);
                        troca++;
                        trocou = true;
                    }

                }
                iteracao++;
            }

            stopwatch.Stop();
            //ImprimirVetor(vetor);
            TotalIteracao = iteracao;
            TotalComparacao = comparacao;
            TotalTroca = troca;
        }



        private void Trocar(int[] vetor, int origem, int destino)
        {

            int aux = vetor[origem];
            vetor[origem] = vetor[destino];
            vetor[destino] = aux;

        }
    }
}
