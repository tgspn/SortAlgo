namespace SortAlgo
{
    class MergeSort : SortBase
    {
        long iteracao = 0;
        long comparacao = 0;
        long troca = 0;
        int[] vet;
        void merge(int[] vetor, int inicio, int meio, int fim)
        {
            int[] esq, dir;
            int nEsq, nDir;
            int contador, i, d, e;
            nEsq = meio - inicio + 2;
            nDir = fim - meio + 1;
            esq = new int[nEsq];
            dir = new int[nDir];
            contador = 0;
            for (i = inicio; i <= meio; i++)
            {
                esq[contador] = vetor[i];
                contador++;
                iteracao++;
            }
            esq[contador] = int.MaxValue;//INT_MAX;
            contador = 0;
            for (i = meio + 1; i <= fim; i++)
            {
                dir[contador] = vetor[i];
                contador++;
                iteracao++;
            }
            dir[contador] = int.MaxValue; //INT_MAX;
            // Intercalacao
            e = 0;
            d = 0;
            for (i = inicio; i <= fim; i++)
            {
                comparacao++;
                if (esq[e] <= dir[d])
                {
                    vetor[i] = esq[e];
                    e++;
                    troca++;
                }
                else
                {
                    vetor[i] = dir[d];
                    d++;
                }
                iteracao++;
            }
            esq = null;
            dir = null;
        }

        void mergesort(int[] vetor, int inicio, int fim)
        {
            int meio;
            TotalComparacao++;
            if (inicio < fim)
            {
                meio = (inicio + fim) / 2;
                mergesort(vetor, inicio, meio);
                mergesort(vetor, meio + 1, fim);
                merge(vetor, inicio, meio, fim);
            }
        }
        public override void Ordenar(int[] vetor)
        {
            TotalElementos = vetor.Length;

            int n = vetor.Length;

            stopwatch.Start();
            vet = vetor;
            mergesort(vetor, 0, n - 1);

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
