namespace SortAlgo
{
    class CountingSort : SortBase
    {
        long iteracao = 0;
        long comparacao = 0;
        long troca = 0;
        private int[] vet;

        public void sort(int[] array/*, int leftIndex, int rightIndex*/)
        {

            //Encontrar o maior valor 
            int maiorValor = 0;
            for (int m = 0; m < array.Length; m++)
            {
                iteracao++;
                comparacao++;
                if (array[m] > maiorValor)
                {
                    maiorValor = array[m];
                }
            }

            maiorValor++;
            //Cria vetor com o tamanho do maior elemento
            int[] vetorContagem = new int[maiorValor];

            //Inicializar com zero o vetor temporario
            for (int i = 0; i < vetorContagem.Length; i++)
            {
                vetorContagem[i] = 0;
            }

            //Contagem das ocorrencias no vetor desordenado
            for (int j = 0; j < array.Length; j++)
            {
                iteracao++;
                vetorContagem[array[j]] += 1;
            }
            int total = 0;
            //Achando a posição inicial de cada item
            for (int i = 0; i < maiorValor; i++)
            {
                var oldCount = vetorContagem[i];
                vetorContagem[i] = total;
                total += oldCount;
                //vetorTemporario[i] = vetorTemporario[i] + vetorTemporario[i - 1];
            }
            //Ordenando o array da direita para a esquerda
            int[] vetorAuxiliar = new int[array.Length];
            //for (int j = maiorValor-1; j >= 0; j--)
            //{
            //    vetorAuxiliar[vetorTemporario[array[j]]] = array[j];
            //    vetorTemporario[array[j]] -= 1;
            //}

            for (int i = 0; i < array.Length; i++)
            {
                var item = array[i];
                vetorAuxiliar[vetorContagem[item]] = item;
                vetorContagem[item]++;
                iteracao++;
                troca++;
            }

            //Retornando os valores ordenados para o vetor de entrada
            for (int i = 0; i < array.Length; i++)
            {
                iteracao++;
                array[i] = vetorAuxiliar[i];
            }
        }

        public override void Ordenar(int[] vetor)
        {
            TotalElementos = vetor.Length;

            int n = vetor.Length;
            vet = vetor;

            stopwatch.Start();

            sort(vetor);

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
