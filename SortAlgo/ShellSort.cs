namespace SortAlgo
{
    class ShellSort : SortBase
    {
        long iteracao = 0;
        long comparacao = 0;
        long troca = 0;

        public override void Ordenar(int[] vetor)
        {
            TotalElementos = vetor.Length;

            int n = vetor.Length;
            var vet = vetor;

            stopwatch.Start();

            int i, j, value;
            int gap = 1;
            while (gap < n)
            {
                gap = 3 * gap + 1;
            }

            while (gap > 1)
            {
                gap /= 3;
                for (i = gap; i < n; i++)
                {
                    iteracao++;
                    value = vetor[i];
                    j = i;
                    comparacao++;
                    while (j >= gap && value < vet[j - gap])
                    {
                        vetor[j] = vetor[j - gap];
                        j = j - gap;
                        troca++;
                        comparacao++;
                    }
                    vetor[j] = value;
                }
            }

            stopwatch.Stop();
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
