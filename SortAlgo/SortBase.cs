using System;
using System.Diagnostics;

namespace SortAlgo
{
    abstract class SortBase : IDisposable
    {
        protected Stopwatch stopwatch;
        public SortBase()
        {
            stopwatch = new Stopwatch();
        }
        public long TotalElementos { get; protected set; }
        public long TotalIteracao { get; protected set; }
        public long TotalComparacao { get; protected set; }
        public long TotalTroca { get; protected set; }
        public TimeSpan Duracao { get => stopwatch.Elapsed; }
        public abstract void Ordenar(int[] vetor);

        public sealed override string ToString()
        {
            return ToString("");
        }
        public string ToString(string metodo)
        {
            return $"Total de Elementos: {TotalElementos}\r\nTotal de troca: {TotalTroca}\r\nDuracao: {Duracao}\r\nIteracoes: {TotalIteracao}\r\nTotal comparação: {TotalComparacao}\r\n\r\n" +
               $"{string.Join(";", metodo, TotalTroca, Duracao.ToString("hh\\:mm\\:ss\\.fff"), TotalIteracao, TotalComparacao)}\r\n\r\n" +
               $"{string.Join("\t& ", metodo, TotalTroca, Duracao.ToString("hh\\:mm\\:ss\\.fff"), TotalIteracao, TotalComparacao)}";
        }
        protected void ImprimirVetor(int[] vetor)
        {
            Console.WriteLine(string.Join(" | ", vetor));
        }
        protected void ImprimirVetor(int[] vetor, int j,int seraTrocado)
        {
            var str = string.Join(" | ", vetor);
            var index = str.IndexOf(vetor[j].ToString());
            var str2 = str.Substring(0, index);
            str2 += " " + vetor[j].ToString() + " ";
            str2 += str.Substring(index + 1);

            str = str2;

            index = str.IndexOf(vetor[seraTrocado].ToString());
            str2 = str.Substring(0, index);
            str2 += " " + vetor[seraTrocado].ToString() + " ";
            str2 += str.Substring(index + 1);

            Console.WriteLine(str2);
        }
        public void Dispose()
        {
            stopwatch = null;
        }
    }
}
