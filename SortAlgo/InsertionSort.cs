namespace SortAlgo
{
    class InsertionSort : SortBase
    {
        public InsertionSort() : base()
        {

        }
        public override void Ordenar(int[] vetor)
        {
            TotalElementos = vetor.Length;
        //    vetor = new int[] { 6, 3, 8, 5, 2, 0, 7, 9, 4, 1 };
            int i = 0;
            int j = 0;
            int aux = 0;
            long n = TotalElementos;
            long iteracao = 0;
            long comparacao = 0;
            long troca = 0;
            int[] vet = vetor;
            //ImprimirVetor(vetor);
            stopwatch.Start();

            for (i = 1; i < n; i++)
            {
               // ImprimirVetor(vetor,i,i-1);
                aux = vetor[i];
                comparacao++;
                for (j = i - 1; j >= 0 && aux < vetor[j]; j--)
                {
                   
                    iteracao++;
                    Trocar(vetor, j, j + 1);
                    troca++;
                    comparacao++;
                   // ImprimirVetor(vetor, j, j + 1);
                }
                vetor[j + 1] = aux;
                iteracao++;
            }

            stopwatch.Stop();
            ImprimirVetor(vetor);
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
