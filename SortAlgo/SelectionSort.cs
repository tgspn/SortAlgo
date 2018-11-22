using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgo
{
    class SelectionSort : SortBase
    {
        public SelectionSort() : base()
        {

        }
        public override void Ordenar(int[] vetor)
        {
            TotalElementos = vetor.Length;

            int i = 0;
            int j = 0;
            long n = TotalElementos;
            long iteracao = 0;
            long comparacao = 0;
            long troca = 0;
            stopwatch.Start();
           // ImprimirVetor(vetor);
            for (i = 0; i < n - 1; i++)
            {
                int idxMenor = i;
                for (j = i + 1; j < n; j++)
                {
                    comparacao++;
                    if (vetor[j] < vetor[idxMenor])
                    {
                        idxMenor = j;
                    }
                }
                Trocar(vetor, i, idxMenor);
                troca++;
                iteracao++;
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
           // ImprimirVetor(vetor);
        }
    }
}
